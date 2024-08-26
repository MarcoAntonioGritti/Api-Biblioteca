using ApiBiblioteca.Context;
using ApiBiblioteca.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;  
namespace ApiBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly BibliotecaContext _context;
        public LivroController(BibliotecaContext context)
        {
            _context = context;
        }

        //Este metodo retornara uma lista de livros existentes na Biblioteca
        [HttpGet("Lista/Livros")]
        public ActionResult<IEnumerable<string>> ListarLivros()
        {
            //Variavel que recebe o contexto de livros(dados) e lista todos eles
            var listaLivros = _context.Livros.ToList();
            return Ok(listaLivros);
        }

        //Este metodo ira servir para procurar um livro expecifico por seu isbn
        [HttpGet("{isbn}")]
        public IActionResult ProcurarLivroPorIsbn(int isbn)
        {
            //Variavel que rebece o contexto de livros, e ira o primeiro valor encotrado ou o padrão
            var livro = _context.Livros.FirstOrDefault(l => l.Isbn == isbn)
;
            if (livro == null)
                return NotFound();

            return Ok(livro);
        }

        //Este metodo ira servir para adicionar algum livro 
        [HttpPost("AdicioanarLivro")]
        public IActionResult AdicionarLivro(Livro livro)
        {
            //Adicionando um livro dentro do contexto de Livros
            _context.Livros.Add(livro);
            //Salvando as ultimas atualizações feitas 
            _context.SaveChanges();
           
            return CreatedAtAction(nameof(ProcurarLivroPorIsbn), new { livro = livro.Id }, livro); /*Aqui eu estou retonando junto com a response, um endpoint que pode ser
                                                                                                    usado para encontrar o livro recém criado,seu id e os atributos*/
        }

        //Este metodo ira servir para fazer a atualização de algum cadastro(Não se pode atualizar um atributo expecifico)
        [HttpPut("AtualizarLivroComPut{id}")]   
        public IActionResult AtualizarLivro(int id, Livro livro) 
        {
            //Variavel que recebe o contexto de Livros, e procura o valor passado a ele no banco de dados
            var livroBanco = _context.Livros.Find(id);

            if(livroBanco == null)
                return NotFound();
            //Aqui o banco de dados esta recebendo o valor nos parametros
            livroBanco.Titulo = livro.Titulo;
            livroBanco.Autor = livro.Autor;
            livroBanco.Isbn = livro.Isbn;
            livroBanco.DataDePublicacao = livro.DataDePublicacao;
            livroBanco.Genero = livro.Genero;
            livroBanco.Emprestado = livro.Emprestado;

            //Contexto sendo atualizado com os novos valores e salvado
            _context.Livros.Update(livroBanco);
            _context.SaveChanges();

            return Ok(livroBanco);
        }

        [HttpPatch("AtualizarLivroComPatch/{id}")]
        public IActionResult AtualizarLivroComPatch(int id,[FromBody] JsonPatchDocument<Livro> livro) 
        {
            //Caso as alterações desejadas não forem enviadas corretamente,sera enviado um erro 400
            if (livro == null)
                return BadRequest();

            //Caso as alterações sejam enviadas corretamente, sera entrado dentro do contexot de livros e procurado pelo o id fornecido
            var livroBanco = _context.Livros.Find(id);

            //Caso o id não exista, sera enviado um erro 404
            if (livroBanco == null)
                return NotFound();

            //Caso exista, sera aplicado as mudanças e sera capiturado pelo ModelState quaisquer erros de validação que podem ocorrer no proceso
            livro.ApplyTo(livroBanco,ModelState);
            
            //Se duratne a aplicação, ocorrer um erro de validação, sera retornado um erro 400 e os detalhes da validação
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            //Caso tudo ocorra bem,sera salvado as aplicações feitas 
            _context.SaveChanges();

            return Ok(livroBanco);

        }

        //Este metodo ira servir para remover um livro da biblioteca, por meio do seu id
        [HttpDelete("RemoverLivro/{id}")]
        public IActionResult DeletarLivro (int id )
        {
            //Variavel que recebe o contexto de Livros, e procura o valor passado a ele no banco de dados
            var livro = _context.Livros.Find( id );

            //Caso o id não exista, sera enviado um erro 404
            if ( livro == null ) 
                return NotFound();  

            //Caso exita, sera removido do contexto o livro passado e salvados as alterações
            _context.Livros.Remove( livro );
            _context.SaveChanges();
            return NoContent();
        }
    }
}
