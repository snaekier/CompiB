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

        public Interpreter(List<Quad> quads)
        {
            ExeAllQuads(); //solo por test 
        }

        public void ExeAllQuads()
        {
            // Usa ReadQuads dandole el indice inicial y recuperar el siguiente 
            int i = 0;
            while (i >= quadsList.Count - 1)
            {
                i = ReadQuads(i);
            }
        }

        //private void GenerateManualQuads()
        //{
        //    quadsList.Add(new Quad(":=", "2000", null, "numero", 0, 1));
        //    quadsList.Add(new Quad(":=", "0", null, "dato", 1, 2));
        //    quadsList.Add(new Quad(">", "numero", "1000", "t1", 2, 3));
        //    quadsList.Add(new Quad("gotoF", "t1", "10", null, 3, 3));
        //    quadsList.Add(new Quad("-", "numero", "1", "t2", 4, 4));
        //    quadsList.Add(new Quad(":=", "t2", null, "numero", 5, 4));
        //    quadsList.Add(new Quad("+", "dato", "1", "t3", 6, 5));
        //    quadsList.Add(new Quad(":=", "t3", null, "dato", 7, 5));
        //    quadsList.Add(new Quad("goto", "3", null, null, 8, 6));
        //    quadsList.Add(new Quad("end", null, null, null, 9, 7));
        //}

        private int ReadQuads(int i)
        {
            string keyVar;
            string OpA, OpB;
            dynamic OperatorA;
            dynamic OperatorB;
            bool res;
            int nextIndex = -1;
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
                    nextIndex = i++;
                    break;
                case "<":
                    keyVar = quadsList[i].Result.ToString();
                    // ## extraer Operando A y B
                    OpA = quadsList[i].OperandA.ToString();
                    OperatorA = ExtractOperand(OpA);
                    OpB = quadsList[i].OperandB.ToString();
                    OperatorB = ExtractOperand(OpB);

                    //resultado de <
                    res = OperatorA < OperatorB;
                    simbTable.Add(keyVar, res);
                    nextIndex = i++;
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
                    nextIndex = i++;
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
                    nextIndex = i++;
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
                    nextIndex = i++;
                    break;
                case "+":
                    //TODO concatenar aun no esta 
                    keyVar = quadsList[i].Result.ToString();
                    OpA = quadsList[i].OperandA.ToString();
                    OperatorA = ExtractOperand(OpA);
                    OpB = quadsList[i].OperandB.ToString();
                    OperatorB = ExtractOperand(OpB);

                    //resultado de +
                    res = OperatorA + OperatorB;
                    simbTable.Add(keyVar, res);
                    nextIndex = i++;
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
                    nextIndex = i++;
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
                    nextIndex = i++;
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
                    nextIndex = i++;
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
                    nextIndex = i++;
                    break;
                case "GOTO":
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    nextIndex = OperatorA;
                    break;
                case "GOTOTRUE":
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    if (OperatorA)
                        nextIndex = OperatorB;
                    else
                        nextIndex = i++;
                    break;
                case "GOTOFALSE":
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    if (!OperatorA)
                        nextIndex = OperatorB;
                    else
                        nextIndex = i++;
                    break;
                case "idV": //inicializa ventana
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    VentForm VF = new VentForm();
                    VF.id = keyVar;
                    VF.text = OperatorA;
                    simbTable.Add(keyVar, VF);
                    nextIndex = i++;
                    break;
                case "posV":
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    simbTable[keyVar].posX = OperatorA;
                    simbTable[keyVar].posY = OperatorB;
                    nextIndex = i++;
                    break;
                case "tamV": //crea una ventana
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    simbTable[keyVar].tamX = OperatorA;
                    simbTable[keyVar].tamY = OperatorB;

                    simbTable[keyVar].Create();
                    nextIndex = i++;
                    break;
                case "idT": //inicializa txtBox
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    TxtBoxForm TF = new TxtBoxForm();
                    TF.id = keyVar;
                    TF.text = OperatorA;                    //<- TODO checar eso
                    simbTable.Add(keyVar, TF);
                    nextIndex = i++;
                    break;
                case "posT":
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    simbTable[keyVar].posX = OperatorA;
                    simbTable[keyVar].posY = OperatorB;
                    nextIndex = i++;
                    break;
                case "tamT": //crea un txtBox
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    simbTable[keyVar].tamX = OperatorA;
                    simbTable[keyVar].tamY = OperatorB;

                    simbTable[keyVar].Create();
                    nextIndex = i++;
                    break;
                case "idB": //inicializa un Boton
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    ButtonForm BF = new ButtonForm();
                    BF.id = keyVar;
                    BF.text = OperatorA;
                    simbTable.Add(keyVar, BF);
                    nextIndex = i++;
                    break;
                case "posB":
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    simbTable[keyVar].posX = OperatorA;
                    simbTable[keyVar].posY = OperatorB;
                    nextIndex = i++;
                    break;
                case "tamB": //crea un Boton y 
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    simbTable[keyVar].tamX = OperatorA;
                    simbTable[keyVar].tamY = OperatorB;

                    //!!!!!!!!!!!!!!!!!!!brincar el indice a su respectivo endB
                    break;
                case "idL": //inicializa un Label
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    LblForm LF = new LblForm();
                    LF.id = keyVar;
                    LF.text = OperatorA;
                    simbTable.Add(keyVar, LF);
                    nextIndex = i++;
                    break;
                case "posL": //crea un Label
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    simbTable[keyVar].posX = OperatorA;
                    simbTable[keyVar].posY = OperatorB;

                    simbTable[keyVar].Create();
                    nextIndex = i++;
                    break;
                case "endB":
                    // talvez se tenga que hacer algo aqui
                    nextIndex = i++;
                    break;
                case "endV":
                    //tambien aqui
                    nextIndex = i++;
                    break;
            }
            return nextIndex;
        }

        private void AddData(string resultVar, string keyVar)
        {
            int n;
            bool b;
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
            int n;
            bool b;
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
