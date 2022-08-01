
namespace Apresentação
{
    public class Autor
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public Autor(int iD1, string Nome1)
        {
            ID = iD1;
            Nome = Nome1;
        }
        public override string ToString()
        {
            return "\nID do autor:" + ID + "\n Nome:" + Nome;
        }
    }
}