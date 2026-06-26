using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Ciudad
    {
        public string nombre;
        public string tipo_pedido;
        public float temperatura;
        public override string ToString()
        {
            return $"{nombre} [Envío: {tipo_pedido} - Cocina: {temperatura} min]";
        }
    }
}