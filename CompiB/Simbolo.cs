using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiB
{
    class Simbolo
    {
        string tipo;
        string valor;
        string nombre;

        public Simbolo(string t, string v)
        {
            tipo = t;
            valor = v;
        }

        internal string Tipo { get { return tipo; } }
        internal string Valor { get { return tipo; } set { valor = value; } }
        internal string Nombre { get { return tipo; } }
    }
}
