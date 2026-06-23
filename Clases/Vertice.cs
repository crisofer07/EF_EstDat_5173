namespace Clases
{
    //VERTICE = NODO
    public class Vertice
    {
        public Ciudad dato;
        //lista simple
        public Vertice sig = null;

        //grafo
        public ListaAristas ls = new ListaAristas();
    }
}
