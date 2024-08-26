namespace ApiBiblioteca.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Isbn { get; set; }
        public string DataDePublicacao { get;set; }
        public string Genero { get; set; }
        public bool Emprestado { get; set; }
    }   
}
