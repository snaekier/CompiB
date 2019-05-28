using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiB
{
    public class Simbolo
    {
        string tipo;
        object valor;
        string nombre;

        public Simbolo(string n, object v, string t)
        {
            nombre = n;
            tipo = t;
            valor = v;
        }

        internal string Tipo { get { return tipo; } set { tipo = value; } }
        internal object Valor { get { return valor; } set { valor = value; } }
        internal string Nombre { get { return nombre; } set { nombre = value; } }
    }
}
