﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompiB
{
    public class Interpreter
    {
        Dictionary<string, dynamic> simbTable = new Dictionary<string, dynamic>();
        List<Quad> quadsList;
        Stack<string> VentStack;
        List<Simbolo> tambSimb;

        public Interpreter(List<Quad> quads, List<Simbolo> tSimb)
        {
            quadsList = quads;
            VentStack = new Stack<string>();
            simbTable = new Dictionary<string, dynamic>();
            tambSimb = tSimb;
        }

        public int GetFirstLine()
        {
            return quadsList[0].NumL;
        }
        public void cleanInterpreter()
        {
            VentStack = new Stack<string>();
            simbTable = new Dictionary<string, dynamic>();
        }

        public int quadsAlto(int line)
        {
            List<Quad> quadsLine = quadsList.FindAll(pred => pred.NumL == line);
            int resLine; 
            int next = -1;
            for (int i = 0; i <= quadsLine.Count - 1; i++)
            {
                next = ReadQuads(quadsLine[i].Num);
            }
            if (next >= quadsList.Count)
                return -1;
            else
                return quadsList[next].NumL;
        }

        /// <summary>
        /// Actualiza la tabla interna de simbolos con la que se genera en la compilación.
        /// </summary>
        /// <param name="tambSimb"></param>
        public void UpdateSimbTable()
        {
            for (int i = 0; i < tambSimb.Count; i++)
            {
                string Type = "";
                int numArr = -1;
                int isArrIdx = tambSimb[i].Tipo.IndexOf("[");
                if (isArrIdx >= 0)
                {   //es un arreglo
                    Type = tambSimb[i].Tipo;
                    Type = Type.Substring(0, isArrIdx);

                    string strNum = tambSimb[i].Tipo.Substring(isArrIdx + 1);
                    numArr = int.Parse(strNum.Remove(strNum.Count() - 1));

                }
                else
                    Type = tambSimb[i].Tipo;
                switch (Type)
                {
                    case "int":
                        if (numArr == -1)
                            simbTable.Add(tambSimb[i].Nombre, 0); //Nuevo valor int con 0
                        else
                        {
                            int[] array = new int[numArr];
                            for (int j = 0; j < numArr; j++)
                                array[j] = 0;   //se llena el arreglo int[numArr] con 0

                            simbTable.Add(tambSimb[i].Nombre, array);
                        }
                        break;
                    case "string":
                        if (numArr == -1)
                            simbTable.Add(tambSimb[i].Nombre, " "); //Nuevo valor int con ' '
                        else
                        {
                            string[] array = new string[numArr];
                            for (int j = 0; j < numArr; j++)
                                array[j] = " ";   //se llena el arreglo int[numArr] con ' '

                            simbTable.Add(tambSimb[i].Nombre, array);
                        }
                        break;
                    case "float":
                        if (numArr == -1)
                            simbTable.Add(tambSimb[i].Nombre, 0); //Nuevo valor int con 0
                        else
                        {
                            float[] array = new float[numArr];
                            for (int j = 0; j < numArr; j++)
                                array[j] = 0;   //se llena el arreglo int[numArr] con 0

                            simbTable.Add(tambSimb[i].Nombre, array);
                        }
                        break;
                }
            }
        }

        public int interpreterStep(int index)
        {
            if (index <= quadsList.Count - 1)
            {
                index = ReadQuads(index);
                if (index == -1)
                    MessageBox.Show("Algo estuvo mal en la Ejecucion", "Atencion:");
            }
            else
                index = 0;
            return index;
        }

        public void ExeAllQuads(int i)
        {
            UpdateSimbTable();
            // Usa ReadQuads dandole el indice inicial y recuperar el siguiente 
            while (i <= quadsList.Count - 1 && i != -1)
                i = ReadQuads(i);
            if(i == -1)
                MessageBox.Show("Algo estuvo mal en la Ejecucion", "Atencion:");
        }

        public void ExeFragmentQuads(int ini, int end)
        {
            int i = ini;
            while (i <= end && i != -1)
                i = ReadQuads(i);
            if (i == -1)
                MessageBox.Show("Algo estuvo mal en la Ejecucion de fragmento", "Atencion:");
        }

        private void AddData(string keyVar, string resultVar)
        {
            int n, numArr = 0;
            bool b, KeyisArray = false;
            float f;
            string arrName = "";

            int arrIndex = keyVar.IndexOf("[");
            if(arrIndex >= 0)   //Verifica si es un arreglo
            {
                arrName = keyVar;
                arrName = arrName.Substring(0, arrIndex);

                string strNum = keyVar.Substring(arrIndex + 1); 
                numArr = int.Parse(strNum.Remove(strNum.Count() - 1));

                keyVar = arrName;
                KeyisArray = true; //si lo es actualiza informacion auxiliar 
            }

            if (simbTable[keyVar] is LblForm || simbTable[keyVar] is TxtBoxForm)
            {   //KeyVar es una forma
                Form currentForm = simbTable[simbTable[keyVar].idOwnerForm].form;
                Control[] c = currentForm.Controls.Find(simbTable[keyVar].id, true);

                dynamic op = ExtractOperand(resultVar);
                c.First().Text = op.ToString();
            }
            else
            {   //KeyVar es una variable
                if (simbTable.Keys.Contains(resultVar))
                {   //resultVar esta en simbTable
                    dynamic op = ExtractOperand(resultVar);
                    if (KeyisArray)  //KeyVar es un arreglo
                        simbTable[arrName][numArr] = op;
                    else
                        simbTable[keyVar] = op;
                }
                else
                {   
                    if (resultVar.Contains("["))
                    {   //resultVar es un arreglo
                        dynamic op = ExtractOperand(resultVar);
                        simbTable[keyVar] = op;
                    }
                    else
                    {   //resultVar esta un dato directo
                        bool isNumeric = int.TryParse(resultVar, out n);
                        bool isBoolean = bool.TryParse(resultVar, out b);
                        bool isFloat = float.TryParse(resultVar, out f);
                        if (KeyisArray)
                        {   //KeyVar es un arreglo
                            if (isNumeric)
                                simbTable[arrName][numArr] = n;
                            else if (isBoolean)
                                simbTable[arrName][numArr] = b;
                            else if (isFloat)
                                simbTable[arrName][numArr] = f;
                            else
                                simbTable[arrName][numArr] = resultVar;
                        }
                        else
                        {
                            if (isNumeric)
                                simbTable[keyVar] = n;
                            else if (isBoolean)
                                simbTable[keyVar] = b;
                            else if (isFloat)
                                simbTable[keyVar] = f;
                            else
                                simbTable[keyVar] = resultVar;
                        }
                    } 
                }
            }  
        }

        private int ReadQuads(int i)
        {
            string keyVar;
            string OpA, OpB;
            dynamic OperatorA;
            dynamic OperatorB;
            bool res;
            float resOp = -1;
            int nextIndex = -1;
            int n;
            string resCadena = "";
            double resOp2 = -1;

            switch (quadsList[i].Operator)
            {
                case ":=":  //keyVar := opA
                    keyVar = quadsList[i].Result.ToString();
                    OpA = quadsList[i].OperandA.ToString();
                    if (simbTable.Keys.Contains(keyVar) || keyVar.Contains("["))
                        AddData(keyVar, OpA);
                    else
                    {
                        simbTable.Add(keyVar, null);
                        AddData(keyVar, OpA);
                    }
                    nextIndex = i;
                    nextIndex++;
                    break;
                case "<":
                    keyVar = quadsList[i].Result.ToString();
                    // ## extraer Operando A y B
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());

                    //resultado de <
                    res = OperatorA < OperatorB;
                    if(simbTable.Keys.Contains(keyVar))
                        simbTable[keyVar] = res;
                    else
                        simbTable.Add(keyVar, res);

                    nextIndex = i;
                    nextIndex++;
                    break;
                case "<=":
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());

                    //resultado de <=
                    res = OperatorA <= OperatorB;
                    if (simbTable.Keys.Contains(keyVar))
                        simbTable[keyVar] = res;
                    else
                        simbTable.Add(keyVar, res);

                    nextIndex = i;
                    nextIndex++;
                    break;
                case ">":
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());

                    //resultado de >
                    res = OperatorA > OperatorB;
                    if (simbTable.Keys.Contains(keyVar))
                        simbTable[keyVar] = res;
                    else
                        simbTable.Add(keyVar, res);

                    nextIndex = i;
                    nextIndex++;
                    break;
                case ">=":
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());

                    //resultado de >=
                    res = OperatorA >= OperatorB;
                    if (simbTable.Keys.Contains(keyVar))
                        simbTable[keyVar] = res;
                    else
                        simbTable.Add(keyVar, res);

                    nextIndex = i;
                    nextIndex++;
                    break;
                case "==":
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());

                    //resultado de ==
                    res = OperatorA == OperatorB;
                    if (simbTable.Keys.Contains(keyVar))
                        simbTable[keyVar] = res;
                    else
                        simbTable.Add(keyVar, res);

                    nextIndex = i;
                    nextIndex++;
                    break;
                case "!=":
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());

                    //resultado de !=
                    res = OperatorA != OperatorB;
                    if (simbTable.Keys.Contains(keyVar))
                        simbTable[keyVar] = res;
                    else
                        simbTable.Add(keyVar, res);

                    nextIndex = i;
                    nextIndex++;
                    break;
                case "+":
                    //TODO concatenar aun no esta 
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    
                    if ((OperatorA is int && (OperatorB is int || OperatorB is float))
                        || (OperatorB is int && (OperatorA is int || OperatorA is float)) 
                        || (OperatorA is float && OperatorB is float))
                    {
                        //resultado de int + int
                        resOp = OperatorA + OperatorB;
                        if (simbTable.Keys.Contains(keyVar))
                            simbTable[keyVar] = resOp;
                        else
                            simbTable.Add(keyVar, resOp);
                    }
                    else
                    {
                        //resultado de string + string
                        resCadena = OperatorA + OperatorB;
                        if (simbTable.Keys.Contains(keyVar))
                            simbTable[keyVar] = resCadena;
                        else
                            simbTable.Add(keyVar, resCadena);

                    }                    
                    nextIndex = i;
                    nextIndex++;
                    break;
                case "-":
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());

                    //resultado de -
                    resOp = OperatorA - OperatorB;
                    if (simbTable.Keys.Contains(keyVar))
                        simbTable[keyVar] = resOp;
                    else
                        simbTable.Add(keyVar, resOp);

                    nextIndex = i;
                    nextIndex++;
                    break;
                case "*":
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());

                    //resultado de *
                    resOp = OperatorA * OperatorB;
                    if (simbTable.Keys.Contains(keyVar))
                        simbTable[keyVar] = resOp;
                    else
                        simbTable.Add(keyVar, resOp);

                    nextIndex = i;
                    nextIndex++;
                    break;
                case "/":
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());

                    //resultado de /
                    resOp = OperatorA / OperatorB;
                    if (simbTable.Keys.Contains(keyVar))
                        simbTable[keyVar] = resOp;
                    else
                        simbTable.Add(keyVar, resOp);

                    nextIndex = i;
                    nextIndex++;
                    break;
                case "%":
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());

                    //resultado de %
                    resOp = OperatorA % OperatorB;
                    if (simbTable.Keys.Contains(keyVar))
                        simbTable[keyVar] = resOp;
                    else
                        simbTable.Add(keyVar, resOp);

                    nextIndex = i;
                    nextIndex++;
                    break;
                case "**":
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());

                    //resultado de ^ checar si es menor de 0 la potencia, es una raiz cuadrada
                    if (OperatorB >= 1)
                        resOp2 = Math.Pow(OperatorA, OperatorB);
                    else
                        resOp2 = Math.Sqrt(OperatorA);
                    resOp = (int)resOp2;
                    if (simbTable.Keys.Contains(keyVar))
                        simbTable[keyVar] = resOp;
                    else
                        simbTable.Add(keyVar, resOp);

                    nextIndex = i;
                    nextIndex++;
                    break;
                case "GOTO":
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    nextIndex = OperatorA;
                    break;
                case "GOTOTRUE":
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    if (OperatorA)
                        nextIndex = OperatorB; //<- checar TODO
                    else
                    {
                        nextIndex = i;
                        nextIndex++;
                    }
                    break;
                case "GOTOFALSE":
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    if (!OperatorA)
                        nextIndex = OperatorB; //<- checar TODO
                    else
                    {
                        nextIndex = i;
                        nextIndex++;
                    }
                    break;
                case "idV": //inicializa ventana
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    VentForm VF = new VentForm();
                    VF.id = keyVar;
                    VF.text = OperatorA;
                    try
                    {
                        simbTable.Add(keyVar, VF);
                    }
                    catch
                    {

                    }
                    

                    //Se agrega al Stack
                    VentStack.Push(keyVar);
                    nextIndex = i;
                    nextIndex++;
                    break;
                case "posV":
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    simbTable[keyVar].posX = OperatorA;
                    simbTable[keyVar].posY = OperatorB;
                    nextIndex = i;
                    nextIndex++;
                    break;
                case "tamV": //crea una ventana
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    simbTable[keyVar].tamX = OperatorA;
                    simbTable[keyVar].tamY = OperatorB;

                    simbTable[keyVar].Create(); //ventana actual
                    simbTable[keyVar].Show();

                    nextIndex = i;
                    nextIndex++;
                    break;
                case "txtB": //inicializa txtBox
                    keyVar = quadsList[i].Result.ToString();
                    TxtBoxForm TF = new TxtBoxForm();
                    TF.id = keyVar;
                    TF.text = "";
                    simbTable.Add(keyVar, TF);
                    nextIndex = i;
                    nextIndex++;
                    break;
                case "posT": //posicion txtBox
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    simbTable[keyVar].posX = OperatorA;
                    simbTable[keyVar].posY = OperatorB;
                    nextIndex = i;
                    nextIndex++;
                    break;
                case "tamT": //crea un txtBox
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    simbTable[keyVar].tamX = OperatorA;
                    simbTable[keyVar].tamY = OperatorB;
                    simbTable[keyVar].idOwnerForm = VentStack.Peek();

                    simbTable[keyVar].Create(); 
                    simbTable[keyVar].AddTextBox(simbTable[VentStack.Peek()].form);

                    nextIndex = i;
                    nextIndex++;
                    break;
                case "idB": //inicializa un Boton
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    ButtonForm BF = new ButtonForm();
                    BF.id = keyVar;
                    BF.text = OperatorA;
                    BF.myInter = this;
                    simbTable.Add(keyVar, BF);
                    nextIndex = i;
                    nextIndex++;
                    break;
                case "posB":
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    simbTable[keyVar].posX = OperatorA;
                    simbTable[keyVar].posY = OperatorB;
                    nextIndex = i;
                    nextIndex++;
                    break;
                case "tamB": //crea un Boton
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    simbTable[keyVar].tamX = OperatorA;
                    simbTable[keyVar].tamY = OperatorB;

                    nextIndex = FindNextEndButton(i + 1);
                    simbTable[keyVar].startQuad = i + 1;
                    simbTable[keyVar].endQuad = nextIndex - 1;
                    simbTable[keyVar].idOwnerForm = VentStack.Peek();

                    simbTable[keyVar].Create();
                    simbTable[keyVar].AddButton(simbTable[VentStack.Peek()].form);
                    simbTable[keyVar].eventoBoton();
                    break;
                case "idL": //inicializa un Label
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    LblForm LF = new LblForm();
                    LF.id = keyVar;
                    LF.text = OperatorA;
                    simbTable.Add(keyVar, LF);
                    nextIndex = i;
                    nextIndex++;
                    break;
                case "posL": //crea un Label
                    keyVar = quadsList[i].Result.ToString();
                    OperatorA = ExtractOperand(quadsList[i].OperandA.ToString());
                    OperatorB = ExtractOperand(quadsList[i].OperandB.ToString());
                    simbTable[keyVar].posX = OperatorA;
                    simbTable[keyVar].posY = OperatorB;
                    simbTable[keyVar].idOwnerForm = VentStack.Peek();

                    simbTable[keyVar].Create();
                    simbTable[keyVar].AddLabel(simbTable[VentStack.Peek()].form);

                    nextIndex = i;
                    nextIndex++;
                    break;
                case "endB":
                    // talvez se tenga que hacer algo aqui
                    nextIndex = i;
                    nextIndex++;
                    break;
                case "endV":
                    VentStack.Pop(); //se libera una ventana, talvez eliminarla (? TODO
                    nextIndex = i;
                    nextIndex++;
                    break;
            }
            return nextIndex;
        }

        private dynamic ExtractOperand(string Op)
        {
            int n;
            bool b;
            float f;

            int numArr = 0;
            string arrName = "";
            int arrIndex = Op.IndexOf("[");

            if (arrIndex >= 0)   //Verifica si es un arreglo
            {
                arrName = Op;
                arrName = arrName.Substring(0, arrIndex);
                string strNum = Op.Substring(arrIndex + 1);
                numArr = int.Parse(strNum.Remove(strNum.Count() - 1));

                return simbTable[arrName][numArr]; 
            }
            else if (simbTable.Keys.Contains(Op))
            {
                if (simbTable[Op] is TxtBoxForm)
                {
                    //Acceder al form en ejecucion
                    Form currentForm = simbTable[simbTable[Op].idOwnerForm].form;
                    Control[] c = currentForm.Controls.Find(simbTable[Op].id, true);
                    string res = c.First().Text.Trim();
                    if (int.TryParse(res, out n))
                        return n;
                    else if (bool.TryParse(res, out b))
                        return b;
                    else if (float.TryParse(res, out f))
                        return f;
                    else
                        return res;
                }
                else
                    return simbTable[Op];
            }
            else
            {
                bool isNumeric = int.TryParse(Op, out n);
                bool isBoolean = bool.TryParse(Op, out b);
                if (isNumeric)
                    return n;
                else if (isBoolean)
                    return b;
                else if (float.TryParse(Op, out f))
                    return f;
                else
                    return Op;
            }
        }

        private int FindNextEndButton(int btnStartIndex)
        {
            int counterOtherButtons = 0;
            for (int i = btnStartIndex; i < quadsList.Count; i++)
            {
                if (quadsList[i].Operator == "idB")
                    counterOtherButtons++;
                if (quadsList[i].Operator == "endB")
                    if (counterOtherButtons == 0)
                        return i;
                    else
                        counterOtherButtons--;
            }
            return -1;
        }
    }
}
