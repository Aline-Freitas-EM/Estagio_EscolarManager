namespace Apresentação
{
    public class GenericClass<T>
    {
        T[] variaveis = new T[3];
        public void Adicionar_Alterar(int indice, T item)
        {
            if (indice >= 0 && indice < 3)
                variaveis[indice] = item;
        }
        public T MostrarDados(int indice)
        {
            if (indice >= 0 && indice < 3)
            {
                Console.WriteLine(variaveis[indice]);
                return variaveis[indice];
            }
            else
                return default(T); //referencia nula
        }
    }
}
