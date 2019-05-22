using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiB
{
    public class Quad
    {

        public int Num { get; set; }
        public string Operator { get; set; }
        public object OperandA { get; set; }
        public object OperandB { get; set; }
        public object Result { get; set; }
        public int NumL { get; set; }

        public Quad(string oprtr, string opA, string opB, string result, int n, int nl)
        {

            Operator = oprtr;
            OperandA = opA;
            OperandB = opB;
            Result = result;
            Num = n;
            NumL = nl;
        }

    }
}