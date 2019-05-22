using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace CompiB
{
    /// <summary>
    /// Conjunto de metodos utiles para todo el proyecto
    /// </summary>
    class Helpers
    {
        /// <summary>
        /// Transforma una lista a string
        /// 
        /// </summary>
        /// <typeparam name="T">Tipo de dato</typeparam>
        /// <param name="list">Lista a transformar</param>
        /// <returns></returns>
        public static string ListToString<T>(List<T> list)
        {
            string strList = "";

            // TODO: Usar string builder
            foreach (var item in list)
                strList += item.ToString();

            return strList;
        }

        public static List<State> DeSeralization()
        {
            List<State> states = new List<State>();
            
            //Seleccion de formateador
            BinaryFormatter formateador = new BinaryFormatter();


            //Se crea el Stream
            Stream miStream = new FileStream(Environment.CurrentDirectory + "\\estadosSerializados11", FileMode.Open, FileAccess.Read, FileShare.None);


            //Deserializacion
            states = (List<State>)formateador.Deserialize(miStream);

            //Cerrar Stream
            miStream.Close();

            return states;
        }

        public static List<Production> DeSeralization2()
        {
            List<Production> producciones = new List<Production>();
            BinaryFormatter formateador = new BinaryFormatter();


            //Se crea el Stream
            Stream miStream = new FileStream(Environment.CurrentDirectory + "\\producciones", FileMode.Open, FileAccess.Read, FileShare.None);


            //Deserializacion
            producciones = (List<Production>)formateador.Deserialize(miStream);

            //Cerrar Stream
            miStream.Close();
            return producciones;
        }
    }
}
