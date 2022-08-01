namespace Apresentação
{
    public class Livro : Publicacao
    {
        public string NomeLivro { get; set; }
        public int Ano { get; set; }
        public Autor AutorDoLivro { get; set; }
        public Livro(Autor Autor1, string NomeLivro1, int Ano1)
        {
            NomeLivro = NomeLivro1;
            Ano = Ano1;
            AutorDoLivro = Autor1;
        }
        public virtual void SerLivro()
        {
            Console.WriteLine("\nÉ um livro ");
        }
        public override void TerDOI()
        {
            base.TerDOI();
        }
        public override void TerISBN()
        {
            Console.WriteLine("Todo livro deve ter ISBN");
        }
        public override string ToString()
        {
            return "\nNome do Livro:" + NomeLivro + "\n Ano:" + Ano + "\nAutor:" + AutorDoLivro.Nome;
        }
    }
}