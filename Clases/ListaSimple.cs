namespace Clases
{
    public class ListaSimple
    {
        public Vertice primero = null;

        public void Insertar(Ciudad d)
        {
            Vertice nuevo = new Vertice();
            nuevo.dato = d;

            if (primero == null)
            {
                primero = nuevo;
            }
            else
            {
                Vertice temp = primero;

                while (temp.sig != null)
                {
                    temp = temp.sig;
                }
                temp.sig = nuevo;
            }
        }

        public void Mostrar()
        {
            Vertice temp = primero;

            while (temp != null)
            {
                Console.WriteLine(temp.dato);
                temp = temp.sig;
            }
        }
    }
}
