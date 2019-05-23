using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiB
{
    class Interpreter
    {
        Dictionary<string, dynamic> simbTable;
        List<Quad> quadsList;

        public struct FormItem
        {
            public string id;
            public int posX, posY, SizeX, SizeY;

            public void SetID(string id)
            {
                this.id = id;
            }

            public void SetPosition(int x, int y)
            {
                posX = x;
                posY = y;
            }

            public void SetSize(int x, int y)
            {
                SizeX = x;
                SizeY = y;
            }

        }

        public Interpreter()
        {
            GenerateManualQuads();
            ReadByQuads();
        }

        private void GenerateManualQuads()
        {
            quadsList.Add(new Quad(":=", "2000", null, "numero", 0, 1));
            quadsList.Add(new Quad(":=", "0", null, "dato", 1, 2));
            quadsList.Add(new Quad(">", "numero", "1000", "t1", 2, 3));
            quadsList.Add(new Quad("gotoF", "t1", "10", null, 3, 3));
            quadsList.Add(new Quad("-", "numero", "1", "t2", 4, 4));
            quadsList.Add(new Quad(":=", "t2", null, "numero", 5, 4));
            quadsList.Add(new Quad("+", "dato", "1", "t3", 6, 5));
            quadsList.Add(new Quad(":=", "t3", null, "dato", 7, 5));
            quadsList.Add(new Quad("goto", "3", null, null, 8, 6));
            quadsList.Add(new Quad("end", null, null, null, 9, 7));
        }

        private void GenerateManualQuads2()
        {

        }

        private void ReadByQuads()
        {
            //int tempCounter = 1;
            for (int i = 0; i < quadsList.Count; i++)
            {
                string keyVar;
                string OpA, OpB;
                dynamic OperatorA;
                dynamic OperatorB;
                bool res;
                switch (quadsList[i].Operator)
                {
                    case ":=":
                        keyVar = quadsList[i].Result.ToString();
                        OpA = quadsList[i].OperandA.ToString();
                        if (simbTable.Keys.Contains(keyVar))
                            AddData(OpA, keyVar);
                        else
                        {
                            simbTable.Add(keyVar, null);
                            AddData(OpA, keyVar);
                        }
                        break;
                    case "<":
                        keyVar = quadsList[i].Result.ToString();
                        // ## extraer Operando A
                        OpA = quadsList[i].OperandA.ToString();
                        OperatorA = ExtractOperand(OpA);
                        // ## extraer Operando B 
                        OpB = quadsList[i].OperandB.ToString();
                        OperatorB = ExtractOperand(OpB);

                        //resultado de <
                        res = OperatorA < OperatorB;
                        simbTable.Add(keyVar, res);
                        break;
                    case "<=":
                        keyVar = quadsList[i].Result.ToString();
                        OpA = quadsList[i].OperandA.ToString();
                        OperatorA = ExtractOperand(OpA);
                        OpB = quadsList[i].OperandB.ToString();
                        OperatorB = ExtractOperand(OpB);

                        //resultado de <=
                        res = OperatorA <= OperatorB;
                        simbTable.Add(keyVar, res);
                        break;
                    case ">":
                        keyVar = quadsList[i].Result.ToString();
                        OpA = quadsList[i].OperandA.ToString();
                        OperatorA = ExtractOperand(OpA);
                        OpB = quadsList[i].OperandB.ToString();
                        OperatorB = ExtractOperand(OpB);

                        //resultado de >
                        res = OperatorA > OperatorB;
                        simbTable.Add(keyVar, res);
                        break;
                    case ">=":
                        keyVar = quadsList[i].Result.ToString();
                        OpA = quadsList[i].OperandA.ToString();
                        OperatorA = ExtractOperand(OpA);
                        OpB = quadsList[i].OperandB.ToString();
                        OperatorB = ExtractOperand(OpB);

                        //resultado de >=
                        res = OperatorA >= OperatorB;
                        simbTable.Add(keyVar, res);
                        break;
                    case "+":
                        //TODO
                        break;
                    case "-":
                        keyVar = quadsList[i].Result.ToString();
                        OpA = quadsList[i].OperandA.ToString();
                        OperatorA = ExtractOperand(OpA);
                        OpB = quadsList[i].OperandB.ToString();
                        OperatorB = ExtractOperand(OpB);

                        //resultado de -
                        res = OperatorA - OperatorB;
                        simbTable.Add(keyVar, res);
                        break;
                    case "*":
                        keyVar = quadsList[i].Result.ToString();
                        OpA = quadsList[i].OperandA.ToString();
                        OperatorA = ExtractOperand(OpA);
                        OpB = quadsList[i].OperandB.ToString();
                        OperatorB = ExtractOperand(OpB);

                        //resultado de *
                        res = OperatorA * OperatorB;
                        simbTable.Add(keyVar, res);
                        break;
                    case "/":
                        keyVar = quadsList[i].Result.ToString();
                        OpA = quadsList[i].OperandA.ToString();
                        OperatorA = ExtractOperand(OpA);
                        OpB = quadsList[i].OperandB.ToString();
                        OperatorB = ExtractOperand(OpB);

                        //resultado de /
                        res = OperatorA / OperatorB;
                        simbTable.Add(keyVar, res);
                        break;
                    case "^":
                        keyVar = quadsList[i].Result.ToString();
                        OpA = quadsList[i].OperandA.ToString();
                        OperatorA = ExtractOperand(OpA);
                        OpB = quadsList[i].OperandB.ToString();
                        OperatorB = ExtractOperand(OpB);

                        //resultado de ^
                        //checar si es menor de 0 la potencia, es una raiz cuadrada
                        if (OperatorB >= 1)
                            res = Math.Pow(OperatorA, OperatorB);
                        else
                            res = Math.Sqrt(OperatorA);
                        simbTable.Add(keyVar, res);
                        break;
                    case "GOTO":
                        break;
                    case "GOTOTRUE":
                        break;
                    case "GOTOFALSE":
                        break;
                    case "idV":
                        break;
                    case "posV":
                        break;
                    case "tamV":
                        break;
                    case "idT":
                        break;
                    case "posT":
                        break;
                    case "tamT":
                        break;
                    case "idB":
                        break;
                    case "posB":
                        break;
                    case "tamB":
                        break;
                    case "endB":
                        break;
                    case "idL":
                        break;
                    case "posL":
                        break;
                }
            }
        }

        private void AddData(string resultVar, string keyVar)
        {
            int n;bool b;
            if (simbTable.Keys.Contains(resultVar))
                simbTable[keyVar] = simbTable[resultVar];
            else
            {
                bool isNumeric = int.TryParse(resultVar, out n);
                bool isBoolean = bool.TryParse(resultVar, out b);
                if (isNumeric)
                    simbTable[keyVar] = n;
                else if (isBoolean)
                    simbTable[keyVar] = b;
                else
                    simbTable[keyVar] = resultVar;
            }
        }

        private dynamic ExtractOperand(string Op)
        {
            int n;bool b;
            if (simbTable.Keys.Contains(Op))
                return simbTable[Op];
            else
            {
                bool isNumeric = int.TryParse(Op, out n);
                bool isBoolean = bool.TryParse(Op, out b);
                if (isNumeric)
                    return n;
                else if (isBoolean)
                    return b;
                else
                    return Op;
            }
        }
    }
}
