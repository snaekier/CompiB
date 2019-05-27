using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiB
{
    class QuadGenerator
    {
        delegate void Instruct2Quads(BinaryTreeNode node);
        static List<Quad> Quads;
        static Stack<Quad> ReturnsStack = new Stack<Quad>();
        static Stack<string> TempValuesStack = new Stack<string>();
        static Dictionary<string, Instruct2Quads> Dictionary = new Dictionary<string, Instruct2Quads>();
        int TempCounter;
        

        public List<Quad> Generate(BinaryTreeNode tree)
        {
            Quads = new List<Quad>();
            SwitchNodes(tree);
            return Quads;
        }



        public void SwitchNodes(BinaryTreeNode node)
        {
            switch (node.Content)
            {

                // Crea ventana 1: #5 en Parser
                case "CV1":
                    string idV1 = node.Left.Left.Left.Content;
                    Quads.Add(new Quad("idV", node.Left.Left.Right.Content, "null", idV1,Quads.Count, node.Left.Left.Left.Line));
                    Quads.Add(new Quad("posV", node.Left.Right.Left.Left.Content, node.Left.Right.Left.Right.Content, idV1,Quads.Count, node.Left.Right.Left.Left.Line));
                    Quads.Add(new Quad("tamV", node.Left.Right.Right.Left.Content, node.Left.Right.Right.Right.Content, idV1, Quads.Count, node.Left.Right.Right.Left.Line));
                    node.Solved = true;
                    SwitchNodes(node.Right);

                    Quads.Add(new Quad("endV", "null", "null", idV1, Quads.Count, Quads.Last().NumL+1));

                    break;
                //Crea ventana 1: #6 en Parser
                case "CV2":
                    

                    string idV2 = node.Left.Left.Content;
                    Quads.Add(new Quad("idV", node.Left.Right.Content, "null", idV2, Quads.Count, node.Left.Right.Line));
                    node.Solved = true;
                    SwitchNodes(node.Right);
                    Quads.Add(new Quad("endV", "null", "null", idV2, Quads.Count, Quads.Last().NumL + 1));
                    break;


                // # 7 en Parser
                case ";":
                    if (node.Left != null && !node.Left.Solved)
                        SwitchNodes(node.Left);
                    node.Solved = true;

                    SwitchNodes(node.Right);

                    break;

                // Crea Boton: #9 en Parser
                case "CB":
                    string idB = node.Left.Left.Left.Content;
                    
                    Quads.Add(new Quad("idB", node.Left.Left.Right.Content, null, idB, Quads.Count, node.Left.Left.Right.Line));
                    Quads.Add(new Quad("posB", node.Left.Right.Left.Left.Content, node.Left.Right.Left.Right.Content, idB, Quads.Count, node.Left.Right.Left.Left.Line));
                    Quads.Add(new Quad("tamB", node.Left.Right.Right.Left.Content, node.Left.Right.Right.Right.Content, idB, Quads.Count, node.Left.Right.Right.Left.Line));
                    
                    node.Solved = true;
                    SwitchNodes(node.Right);

                    Quads.Add(new Quad("endB", null, null, idB, Quads.Count, Quads.Last().NumL + 1));
                    // LineaCod++;

                    break;

                case "CT":
                    Quads.Add(new Quad("txtB", "null", "null", node.Left.Content, Quads.Count, node.Left.Line));
                    Quads.Add(new Quad("posT", node.Right.Left.Left.Content, node.Right.Left.Right.Content, node.Left.Content,Quads.Count,node.Right.Left.Left.Line));
                    Quads.Add(new Quad("tamT", node.Right.Right.Left.Content, node.Right.Right.Right.Content, node.Left.Content, Quads.Count, node.Right.Right.Left.Line));
                    break;


                // Crea Label: # 11 en Parser
                case "CL":

                    string idL = node.Left.Left.Content;

                    Quads.Add(new Quad("idL", node.Left.Right.Content, null, idL, Quads.Count, node.Left.Right.Line));
                    Quads.Add(new Quad("posL", node.Right.Left.Content, node.Right.Right.Content, idL, Quads.Count, node.Right.Left.Line));
                    node.Solved = true;


                    break;


                // # 26 en Parser
                case "sent-if":
                    SwitchNodes(node.Left);
                    Quad ifCondition = new Quad("GOTOFALSE", TempValuesStack.Pop(), null, null, Quads.Count, node.Left.Line);
                    Quads.Add(ifCondition);
                    SwitchNodes(node.Right);
                    ifCondition.OperandB = Quads.Count - 1;

                    break;
                // #27 en Parser
                case "sent-if-else":
                    SwitchNodes(node.Left);
                    Quad ifElseCondition = new Quad("GOTOFALSE", TempValuesStack.Pop(), null, null, Quads.Count, node.Left.Line);
                    Quads.Add(ifElseCondition);
                    SwitchNodes(node.Left.Right); // --> (else) --> (left)
                    ifElseCondition.OperandB = Quads.Count - 1;
                    SwitchNodes(node.Left.Right);


                    break;
                // # 28 en Parser
                case "repeat":
                    int quadIndexRepeat = Quads.Count - 1;
                    SwitchNodes(node.Left);
                    SwitchNodes(node.Right);
                    Quads.Add(new Quad("GOTOTRUE", TempValuesStack.Pop(), quadIndexRepeat.ToString(), null, Quads.Count,Quads.Count));
                    break;

                // # 29 en Parser
                // Se hace correccion 
                case ":=":
                    SwitchNodes(node.Left);
                    SwitchNodes(node.Right);
                    var r = TempValuesStack.Pop();
                    var l = TempValuesStack.Pop();
                    Quads.Add(new Quad(":=", r, "null", l, Quads.Count,node.Left.Line));
                    break;

                // # 30 en Parser   Asignacion a arreglo [:= |valor a asignar | indice  | variable tipo arreglo|]
                //case "Arr:=exp":
                //    SwitchNodes(node.Right);
                //    Quads.Add(new Quad(":=",TempValuesStack.Pop(),node.Left.Right.Content,node.Left.Left.Content,255,255));
                //    break;

                // #31 en Parser 
                case "while":
                    var whileReturn = Quads.Count();
                    SwitchNodes(node.Left);
                    Quad condition = new Quad("GOTOFALSE", TempValuesStack.Pop(), null, null, Quads.Count,node.Left.Line);
                    Quads.Add(condition);
                    SwitchNodes(node.Right);
                    condition.OperandB = Quads.Count + 1;
                    Quads.Add(new Quad("GOTO", whileReturn.ToString(), "null", "null", Quads.Count, Quads.Last().NumL+1));
                    break;

                // # 32 en Parser
                case "do":
                    int quadIndex = Quads.Count - 1;
                    SwitchNodes(node.Left);
                    SwitchNodes(node.Right);
                    Quads.Add(new Quad("GOTOTRUE", TempValuesStack.Pop(), quadIndex.ToString(), null, Quads.Count,Quads.Count));
                    break;

                //case "CT":
                //    string idT = node.Left.Content;
                //    Quads.Add(new Quad("idT", node.Left.Content, null, idT, Quads.Count, LineaCod));
                //    Quads.Add(new Quad("postT", node.Right.Left.Left.Content, node.Right.Left.Right.Content, idT, Quads.Count, LineaCod));
                //    Quads.Add(new Quad("tamT", node.Right.Right.Left.Content, node.Right.Right.Right.Content, idT, Quads.Count, LineaCod));
                //    LineaCod++;
                //    node.Solved = true;

                //    break;

               

                // # 33 en Parser
                case "switch":
                    //Quads.Add(new Quad("swicth",null,null,node.Left.Content));

                    TempValuesStack.Push(node.Left.Content);
                    SwitchNodes(node.Right);

                    break;
                // # 34 en Parser
                case "case-sep":
                    Quad caseSepTemp = new Quad("GOTOFALSE", null, null, null, Quads.Count, node.Left.Line);
                    Quads.Add(caseSepTemp);
                    SwitchNodes(node.Left);
                    caseSepTemp.OperandA = TempValuesStack.Pop();
                    caseSepTemp.OperandB = Quads.Count - 1;
                    SwitchNodes(node.Right);

                    break;
                // # 36 en Parser
                case "case":
                    TempCounter++;
                    string tmp = "T" + TempCounter.ToString();
                    Quads.Add(new Quad("=", node.Left.Content, TempValuesStack.Peek(), tmp, Quads.Count, node.Left.Line));
                    TempValuesStack.Push(tmp);
                    break;

                case "for":
                    Quads.Add(new Quad("for", null, null, null, Quads.Count, node.Left.Line));
                    SwitchNodes(node.Left);
                    SwitchNodes(node.Right);
                    /***********************************************************************/
                    break;
                
                case "MS":
                    Quads.Add(new Quad("MS", "null", "null", node.Left.Content, Quads.Count, node.Line));
                    node.Solved = true;
                    break;

                case "+":
                    GenericNode(node);
                    break;

                case "*":
                    GenericNode(node);
                    break;
                case "-":
                   
                    //}
                    GenericNode(node);
                    break;
                case "/":
                  
                    //}
                    GenericNode(node);
                    break;
                case "<=":
                    GenericNode(node);
                    break;
                case ">=":
                    GenericNode(node);
                    break; 
                case "%":
                    GenericNode(node);
                    break;
                case ">":
                    GenericNode(node);
                    break;
                case "<":
                    GenericNode(node);
                    break;
                case "!=":
                    GenericNode(node);
                    break;

                case "==":
                    GenericNode(node);
                    break;

                case "**":
                    GenericNode(node);
                    break;

                // we try to catch here the variables and constants, validate existence in TABSIM etc
                default:
                    TempValuesStack.Push(node.Content);
                    break;
            }

        }

        private void GenericNode(BinaryTreeNode node)
        {



            SwitchNodes(node.Left);
            SwitchNodes(node.Right);
            var rmod = TempValuesStack.Pop();
            var lmod = TempValuesStack.Pop();
            TempCounter++;
            var tempMod = "T" + TempCounter.ToString();
            TempValuesStack.Push(tempMod);
            Quads.Add(new Quad(node.Content, lmod, rmod, tempMod,Quads.Count, node.Left.Line));

        }
    }




}