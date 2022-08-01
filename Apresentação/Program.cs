namespace Apresentação;
class Program
{
    static void Main()
    {
        int ID = 0;
        List<Autor> autores = new();
        List<Livro> livros = new();

        Autor autor1 = new Autor(++ID, "Aristóteles");
        Autor autor2 = new Autor(++ID, "Wittgenstein");
        Autor autor3 = new Autor(++ID, "Frege");
        autores.Add(autor1);
        autores.Add(autor2);
        autores.Add(autor3);
        Livro livro1 = new Livro(autor1, "Etica a nicomaco", 1600);
        Livro livro2 = new Livro(autor1, "Politica", 1700);
        Livro livro3 = new Livro(autor2, "Investigacoes filosoficas", 1900);
        Livro livro4 = new Livro(autor3, "Sobre o sentido e a referencia", 1800);
        livros.Add(livro1);
        livros.Add(livro2);
        livros.Add(livro3);
        livros.Add(livro4);

        int escolha = -1;
        while (escolha != 0)
        {
            Console.WriteLine("\nO que deseja realizar?\n");
            Console.WriteLine("1 - Conversoes de tipos");
            Console.WriteLine("2 - Upcast/Downcast");
            Console.WriteLine("3 - Boxing/Unboxing");
            Console.WriteLine("4 - Generics");
            Console.WriteLine("5 - LINQ");
            Console.WriteLine("0 - Sair\n");
            escolha = Convert.ToInt32(Console.ReadLine());

            switch (escolha)
            {
                case 0:
                    break;
                case 1:
                    ConverterTipos();
                    break;
                case 2:
                    RealizarUpDownCast();
                    break;
                case 3:
                    RealizarBoxUnboxing();
                    break;
                case 4:
                    UsarGenerics();
                    break;
                case 5:
                    FazerLINQ();
                    break;
                default:
                    Console.WriteLine("Opcao invalida");
                    break;
            }

            void ConverterTipos()
            {
                int c = 5;
                double d = c;
                Console.WriteLine("\nConversao implicita");
                Console.WriteLine(d + "  " + c + "\n somando com um numero double:  " + (c + 2, 55));

                double b = 3.14;
                int a = (int)b;
                Console.WriteLine("\nConversao explicita");
                Console.WriteLine(b + "  " + a);

                int z;
                z = Convert.ToInt32("1");
                Console.WriteLine("\nConvert");
                Console.WriteLine(z);

                Console.Write("\nToString:");
                foreach (Autor autor in autores)
                {
                    Console.WriteLine(autor.ToString());
                }

                Console.Write("\nParse:\n");
               
                string[] valores = { "+5430", "-0", "2,100,100", "$35,17", "0xFA1B","-10", "088", "2147483647",
                                "2147483648", "-2147483648", "-2147483649","16e07", "4985.0", "-12034", null };

                foreach (string valor in valores)
                {
                    try
                    {
                        int numero = Int32.Parse(valor);
                        Console.WriteLine("{0} --> {1}", valor, numero);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("{0}: Formato Inválido", valor);
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("{0}: Overflow", valor);
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("{0}: Valor null", valor);
                    }
                }

                Console.Write("\nTryParse:\n");
                foreach (var valor in valores)
                {
                    int numero;
                    bool resultado = Int32.TryParse(valor, out numero);
                    if (resultado==true)
                    {
                        Console.WriteLine("{0} --> {1}", valor, numero);
                    }
                    else
                    {
                        Console.WriteLine("A conversão de '{0}' Falhou.", valor == null ? "<null>" : valor);
                    }
                }
            }

            void RealizarUpDownCast()
            {
                Livro livro5 = new Livro(autor3, "Conceito e objeto", 1930);
                Publicacao p = new Publicacao();
                p.TerISBN();
                // ((Livro)p).SerLivro(); antes do upcast gera exception 
                Console.WriteLine("\nUpCast");
                p = livro5;
                Console.WriteLine("\np == livro é" + " " + (p == livro5));
                p.TerISBN();

                Console.WriteLine("\nDownCast");
                ((Livro)p).SerLivro();
                p.TerISBN();
                Console.WriteLine(livro5 == p);

                Console.WriteLine("\nOperador as");
                livro5 = p as Livro;
                if (livro5 != null)
                {
                    livro5.SerLivro();
                }
                else if (livro5 == null)
                {
                    Console.WriteLine("Operação de downcast inválida (as)");
                }

                Console.WriteLine("\nOperador is");
                if (p is Livro)
                {
                    ((Livro)p).SerLivro();
                }
                else
                {
                    Console.WriteLine("Operação de downcast inválida (is)");
                }
            }

            void RealizarBoxUnboxing()
            {
                string nomeAline = "Aline";
                object objeto1 = nomeAline;
                Console.WriteLine(objeto1);
                nomeAline = "Stephanie";
                Console.WriteLine("nomeAline: " + nomeAline);
                Console.WriteLine("objeto1: " + objeto1);

                string nomeD = (string)objeto1;
                Console.WriteLine("Unboxing:" + nomeD);
                //int numero = (int)objeto1; System.InvalidCastException'
            }

            void UsarGenerics()
            {
                GenericClass<string> livrosLiterarios = new GenericClass<string>();
                livrosLiterarios.Adicionar_Alterar(0, "O Guia do mochileiro das galaxias");
                livrosLiterarios.Adicionar_Alterar(1, "Senhor dos aneis");
                livrosLiterarios.Adicionar_Alterar(2, "Lobo da estepe");
                livrosLiterarios.Adicionar_Alterar(1, "O hobbit");

                livrosLiterarios.MostrarDados(0);
                livrosLiterarios.MostrarDados(1);
                livrosLiterarios.MostrarDados(2);

                GenericClass<int> numeroDOI = new GenericClass<int>();
                numeroDOI.Adicionar_Alterar(0, 54115978);
                numeroDOI.Adicionar_Alterar(1, 25232173);
                numeroDOI.Adicionar_Alterar(2, 84454850);

                numeroDOI.MostrarDados(0);
                numeroDOI.MostrarDados(1);
                numeroDOI.MostrarDados(2);
            }

            void FazerLINQ()
            {
                IEnumerable<string> pesquisaAutores = from autor in autores
                                               where autor.Nome != null
                                               select autor.Nome;
                foreach (string s in pesquisaAutores)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("\n");

                Autor autor4 = new Autor(++ID, "Wittgenstein");
                autores.Add(autor4);
                IEnumerable<string> pesquisaSemRepeticao = from autor in autores.DistinctBy(pesquisaSemRepeticao => pesquisaSemRepeticao.Nome)
                                                    select autor.Nome;
                foreach (string s1 in pesquisaSemRepeticao)
                {
                    Console.WriteLine(s1);
                }
                Console.WriteLine("\n");
                autores.RemoveAt(3);
                IEnumerable<Autor> ordenarPorNome = autores.OrderBy(autor => autor.Nome);
                foreach (Autor autor in ordenarPorNome)
                {
                    Console.WriteLine("{0} - {1}", autor.Nome, autor.ID);
                }
            }
        }
    }
}