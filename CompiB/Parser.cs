using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiB
{
    class Parser
    {
        List<State> states;
        List<TokenState> stackAnalysis; // Pila de analisis sintático
        string input; // Cadena a evaluar
        List<ActionLog> log;
        Stack<BinaryTreeNode> nodesStack;
        Stack<string> operatorsStack;
        string globalType;
        int counter; // Contador de nodos visitados en DFSSearch
        List<Production> productions;
        int numLinea=1;
        public List<Simbolo> TabSim;
        Stack<BinaryTreeNode> auxArr;
        List<Simbolo> auxTS;

       // internal List<Node> AFD;
        internal List<State> States { get { return states; } set { states = value; } }
        internal List<ActionLog> Log { get { return log; } set { log = value; } }
        internal List<Production> Productions { get { return productions; }  }
        internal int Lines { get { return numLinea; } }
        internal Stack<BinaryTreeNode> NodeStack { get { return nodesStack; } }

        public Parser(List<Production> p, List<State> s/*List<Node> AFDList*/)
        {
            productions = p;
            // AFD = AFDList;
            States = s;/*new List<State>();*/
            stackAnalysis = new List<TokenState>();
            log = new List<ActionLog>();
            nodesStack = new Stack<BinaryTreeNode>();
            auxArr = new Stack<BinaryTreeNode>();
            operatorsStack = new Stack<string>();

            counter = 1;

        }

        public bool EvalString(String inputString)
        {
            TabSim = new List<Simbolo>();
            auxTS = new List<Simbolo>();
            nodesStack = new Stack<BinaryTreeNode>();
            auxArr = new Stack<BinaryTreeNode>();
            numLinea = 1;
            bool valid = true;
            List<Token> inputTokens = new List<Token>();
            input = inputString;
            // Se limpia al log
            Log.Clear();

            inputTokens = Tokenizer.Convert(input);

            inputTokens.Add(new Token("$", true));
            stackAnalysis.Clear();
          //  nodesStack.Clear();
            stackAnalysis.Add(new TokenState() { token = new Token("$", true), state = 0 });

            while (valid)
            {
                TokenState cAction = stackAnalysis.Last(); // Current Action
                Token cToken = inputTokens.First(); // Current Token
                Action nextAction;
                while (cToken.Content == "sdl")
                {
                    numLinea++;
                    inputTokens.RemoveAt(0);
                    cToken= inputTokens.First();
                }
                // Imprimir pila de A.S.

                // Limpiar estados de la pila de A.S.
                for (var i = 0; i < stackAnalysis.Count; i++)
                    stackAnalysis[i].dirty = false;

                // Verificar si el token existe en las listas
                valid = states[cAction.state].Terminals.ContainsKey(cToken.Content) || states[cAction.state].NonTerminals.ContainsKey(cToken.Content);

                if (!valid) break;

                if (cToken.IsTerminal)
                    nextAction = states[cAction.state].Terminals[cToken.Content];
                else
                    nextAction = states[cAction.state].NonTerminals[cToken.Content];

                if (nextAction.IsEmpty())
                {
                    valid = false;
                    break;
                }
                else
                {
                    // Agregar acciones al log
                    log.Add(new ActionLog()
                    {
                        Stack = Helpers.ListToString(stackAnalysis),
                        Input = Helpers.ListToString(inputTokens),
                        Action = nextAction.action == 'S' ? nextAction.ToString() : nextAction.ToString() + " (" + productions[nextAction.state].ToString() + " )"
                    });
                }

                // Continua Análisis Sintáctico
                if (nextAction.action == 'S')
                {
                    stackAnalysis.Add(new TokenState() { token = cToken, state = nextAction.state });
                    inputTokens.RemoveAt(0);
                }
                else if (nextAction.action == 'R')
                {
                    Production production = productions[nextAction.state];
                    Production productionAux = new Production();
                    productionAux.Left = production.Left;
                    productionAux.Id = production.Id;
                    var rLen = production.Right.Count;

                    if (nextAction.state == 0) // Estado R0 o aceptar
                        break;

                    // Encuentra match
                    for (var i = 0; i < rLen; i++)
                    {
                        Token r = new Token();
                        r.Content = production.Right[i].Content;
                        r.IsTerminal = true;
                       // r = production.Right[i];
                        int indexStack = (stackAnalysis.Count) - rLen + i;
                        var itState = stackAnalysis[indexStack];

                        if (!itState.dirty && itState.token.Content == r.Content)
                        {
                            itState.dirty = true;
                            r.Val = itState.token.Val;
                            productionAux.Right.Add(r);
                        }
                    }

                    // Remplazar los TokenState sucios
                    for (var i = stackAnalysis.Count - 1; i >= 0; i--)
                    {
                        var itState = stackAnalysis[i];

                        if (itState.dirty)
                        {
                            stackAnalysis.RemoveAt(i);
                        }
                    }

                    SemanticAnalysis(productionAux, nextAction.state); //Aqui se hacen las reducciones

                    int newState;
                    TokenState lastState = stackAnalysis.Last();

                    if (production.Left.IsTerminal)
                        newState = states[lastState.state].Terminals[production.Left.Content].state;
                    else
                        newState = states[lastState.state].NonTerminals[production.Left.Content].state;

                    stackAnalysis.Add(new TokenState() { token = production.Left, state = newState });
                }
            }

            // TODO: Descomentar cuando esten todos los esquemas de traduccion
            if (valid)
            {
               /* graphVizEdges.Clear();
                counter = 1;
                DFSSearch(nodesStack.Peek());
                CreateGraphFile();*/
            }

            return valid;
        }

        private void SemanticAnalysis(Production p, int productionIndex)
        {
            switch (productionIndex)
            {
                // def-vent -> CreaVentana ( id , cadena , num , num1 , num2 , num3 ) { secuencia-ctrl }
                case 5:
                    {
                        BinaryTreeNode a = new BinaryTreeNode("idV", new BinaryTreeNode(p.Right[2].Val), new BinaryTreeNode(p.Right[4].Val));
                        BinaryTreeNode b = new BinaryTreeNode("posV", new BinaryTreeNode(p.Right[6].Val), new BinaryTreeNode(p.Right[8].Val));
                        BinaryTreeNode c = new BinaryTreeNode("tamV", new BinaryTreeNode(p.Right[10].Val), new BinaryTreeNode(p.Right[12].Val));
                        BinaryTreeNode n = new BinaryTreeNode("vista", b, c);
                        
                        b = new BinaryTreeNode("at", a, n);
                        c = nodesStack.Pop();

                        nodesStack.Push(new BinaryTreeNode("CV1", b, c));
                    }
                    break;

                // def-vent -> CreaVentana ( id , cadena ) { secuencia-ctrl }
                case 6:
                    {
                        BinaryTreeNode a = new BinaryTreeNode("idV", new BinaryTreeNode(p.Right[2].Val), new BinaryTreeNode(p.Right[4].Val));
                        BinaryTreeNode b = nodesStack.Pop();

                        nodesStack.Push(new BinaryTreeNode("CV2", a, b));
                    }
                    break;

                // secuencia-ctrl -> secuencia-ctrl def-ctrl
                case 7:
                    {
                        BinaryTreeNode b = nodesStack.Pop();
                        BinaryTreeNode a = nodesStack.Count == 0 ? null : nodesStack.Pop();

                        nodesStack.Push(new BinaryTreeNode(";", a, b));
                    }
                    break;

                // def-ctrl -> CreaBoton ( id , cadena , num , num , num , num ) { def-evnt }
                case 9:
                    {
                        BinaryTreeNode a = new BinaryTreeNode("idB", new BinaryTreeNode(p.Right[2].Val), new BinaryTreeNode(p.Right[4].Val));
                        BinaryTreeNode b = new BinaryTreeNode("posB", new BinaryTreeNode(p.Right[6].Val), new BinaryTreeNode(p.Right[8].Val));
                        BinaryTreeNode c = new BinaryTreeNode("tamB", new BinaryTreeNode(p.Right[10].Val), new BinaryTreeNode(p.Right[12].Val));
                        BinaryTreeNode n = new BinaryTreeNode("vista", b, c);

                        b = new BinaryTreeNode("at", a, n);

                        c = nodesStack.Pop();

                        nodesStack.Push(new BinaryTreeNode("CB", b, c));
                    }
                    break;

                // def-ctrl -> CreaTextbox ( id , num , num , num , num ) ;
                case 10:
                    {
                        BinaryTreeNode a = new BinaryTreeNode(p.Right[2].Val);
                        BinaryTreeNode b = new BinaryTreeNode("posT", new BinaryTreeNode(p.Right[4].Val), new BinaryTreeNode(p.Right[6].Val));
                        BinaryTreeNode c = new BinaryTreeNode("tamT", new BinaryTreeNode(p.Right[8].Val), new BinaryTreeNode(p.Right[10].Val));
                        BinaryTreeNode n = new BinaryTreeNode("vista", b, c);

                        nodesStack.Push(new BinaryTreeNode("CT", a, n));
                    }
                    break;

                // def-ctrl -> CreaLabel ( id , cadena , num , num ) ;
                case 11:
                    {
                        BinaryTreeNode a = new BinaryTreeNode("idL", new BinaryTreeNode(p.Right[2].Val), new BinaryTreeNode(p.Right[4].Val));
                        BinaryTreeNode b = new BinaryTreeNode("posL", new BinaryTreeNode(p.Right[6].Val), new BinaryTreeNode(p.Right[8].Val));

                        nodesStack.Push(new BinaryTreeNode("CL", a, b));
                    }
                    break;

                // secuencia-sent -> sentencia secuencia-sent
                case 14:
                    {
                        var b = nodesStack.Pop();
                        var a = nodesStack.Count == 0 ? null : nodesStack.Pop();

                        nodesStack.Push(new BinaryTreeNode(";", a, b));
                    }
                    break;

                // sent-if -> if (exp) { secuencia - sent }
                case 26:
                    {
                        BinaryTreeNode b = nodesStack.Pop();
                        BinaryTreeNode a = nodesStack.Pop();

                        nodesStack.Push(new BinaryTreeNode("sent-if", a, b));
                    }
                    break;

                // sent-if -> if (exp) { secuencia - sent } else { secuencia - sent }
                case 27:
                    {
                        BinaryTreeNode c = nodesStack.Pop();
                        BinaryTreeNode b = nodesStack.Pop();
                        BinaryTreeNode a = nodesStack.Pop();

                        BinaryTreeNode n = new BinaryTreeNode("else", b, c);
                        nodesStack.Push(new BinaryTreeNode("sent-if-else", a, n));
                    }
                    break;

                // sent-repeat->repeat { secuencia - sent } until(exp)
                case 28:
                    {
                        BinaryTreeNode b = nodesStack.Pop();
                        BinaryTreeNode a = nodesStack.Pop();

                        nodesStack.Push(new BinaryTreeNode("repeat", a, b));
                    }
                    break;

                // sent-assign->id := exp;
                case 29:
                    {
                        BinaryTreeNode b = nodesStack.Pop();
                        BinaryTreeNode a = new BinaryTreeNode(p.Right[0].Val);
                        nodesStack.Push(new BinaryTreeNode(":=", a, b));
                    }
                    break;

                // sent-assign -> id [ indice ] := exp ;
                case 30:
                    {
                        BinaryTreeNode b = nodesStack.Pop();
                        BinaryTreeNode a = new BinaryTreeNode(p.Right[0].Val + "[" + auxArr.Pop().Content + "]");
                        nodesStack.Push(new BinaryTreeNode(":=", a, b));
                    }
                    break;

                // sent-while -> while ( exp ) { secuencia-sent }
                case 31:
                    {
                        BinaryTreeNode b = nodesStack.Pop();
                        BinaryTreeNode a = nodesStack.Pop();
                        nodesStack.Push(new BinaryTreeNode("while", a, b));
                    }

                    break;

                // sent-do-while -> do { secuencia-sent } while ( exp ) ;
                case 32:
                    {
                        BinaryTreeNode b = nodesStack.Pop();
                        BinaryTreeNode a = nodesStack.Pop();
                        nodesStack.Push(new BinaryTreeNode("do", a, b));
                    }
                    break;

                // sent-switch -> switch ( id ) { secuencia-case }
                case 33:
                    {
                        BinaryTreeNode b = nodesStack.Pop();
                        BinaryTreeNode a = new BinaryTreeNode(p.Right[2].Val);

                        nodesStack.Push(new BinaryTreeNode("switch", a, b));
                    }
                    break;

                // secuencia-case -> secuencia-case sentencia-case
                case 34:
                    {
                        BinaryTreeNode b = nodesStack.Pop();
                        BinaryTreeNode a = nodesStack.Pop();

                        nodesStack.Push(new BinaryTreeNode("case-sep", a, b));
                    }
                    break;

                // sentencia-case -> case id { secuencia-sent } break ;
                case 36:
                    {
                        BinaryTreeNode b = nodesStack.Pop();
                        BinaryTreeNode a = new BinaryTreeNode(p.Right[1].Val);

                        nodesStack.Push(new BinaryTreeNode("case", a, b));
                    }
                    break;

                // sent-for -> for ( id := num : num , num ) { secuencia-sent }
                case 37:
                    {
                        BinaryTreeNode c = nodesStack.Pop();
                        BinaryTreeNode b = new BinaryTreeNode("incremento", new BinaryTreeNode(p.Right[6].Val), new BinaryTreeNode(p.Right[8].Val));
                        BinaryTreeNode n = new BinaryTreeNode(";", b, c);
                        BinaryTreeNode a = new BinaryTreeNode(":=", new BinaryTreeNode(p.Right[2].Val), new BinaryTreeNode(p.Right[4].Val));

                        nodesStack.Push(new BinaryTreeNode("for", a, n));
                    }
                    break;

                // sent-func -> MessageBox ( cadena )
                case 38:
                    {
                        BinaryTreeNode a = new BinaryTreeNode(p.Right[2].Val);
                        nodesStack.Push(new BinaryTreeNode("MS", a, null));
                    }
                    break;
                //sent-declara -> tipo identificadores
                case 39:
                    TabSim.AddRange(auxTS);
                    auxTS = new List<Simbolo>();
                    break;
                //sent-declara -> tipo [ indice ] identificadores
                case 40:
                    {
                        foreach(Simbolo s in auxTS)
                        {
                            s.Tipo += "["+auxArr.Pop().Content+"]";
                        }
                        TabSim.AddRange(auxTS);
                        auxTS = new List<Simbolo>();
                    }
                    break;
                
                //indice -> num    
                case 41:
                    auxArr.Push(new BinaryTreeNode(p.Right[0].Val));
                    break;

                //indice->id
                case 42:
                    auxArr.Push(new BinaryTreeNode(p.Right[0].Val));
                    break;

                //identificadores -> identificadores , id
                case 43:
                    insertTabSim(p.Right[2].Val);
                    break;

                //identificadores -> id
                case 44:
                    insertTabSim(p.Right[0].Val);
                    break; 

                // exp -> exp-simple opcomparacion exp-simple
                // exp-simple -> exp-simple opsuma term
                case 45:
                case 47:
                    {
                        BinaryTreeNode b = nodesStack.Pop();
                        BinaryTreeNode a = nodesStack.Pop();
                        //nodesStack.Push(new BinaryTreeNode(operatorsStack.Pop(), a, b));
                        nodesStack.Push(new BinaryTreeNode(p.Right[1].Val, a, b));
                    }
                    break;

                // tipos
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                    {
                        globalType = p.Right[0].Content;
                    }
                    break;

                // term->term opmult factor
                case 56:
                    {
                        BinaryTreeNode b = nodesStack.Pop();
                        BinaryTreeNode a = nodesStack.Pop();

                        nodesStack.Push(new BinaryTreeNode(p.Right[1].Val, a, b));
                    }
                    break;

                // term -> factor
                case 57:
                    {
                        //nodesStack.Push(new BinaryTreeNode(p.Right[0].Val));
                    }
                    break;

                //  factor-> num
                //  factor-> id
                //  factor->cadena
                case 59:
                case 60:
                case 61:
                    {
                        nodesStack.Push(new BinaryTreeNode(p.Right[0].Val));
                    }
                    break;
                //factor->id [ indice ]
                case 62:
                    {
                        nodesStack.Push(new BinaryTreeNode(p.Right[0].Val+"["+auxArr.Pop().Content+"]"));
                    }
                    break;
            }
        }

        public void insertTabSim(string name)
        {
            Simbolo s;
            switch (globalType)
            {
                case "int":
                    s = new Simbolo(name, "0", globalType);
                    break;
                case "string":
                    s = new Simbolo(name, "", globalType);
                    break;
                case "vent":
                    s = new Simbolo(name, "0", globalType);
                    break;
                case "textBox":
                    s = new Simbolo(name, "", globalType);
                    break;
                case "label":
                    s = new Simbolo(name, "", globalType);
                    break;
                case "boton":
                    s = new Simbolo(name, "", globalType);
                    break;
                case "float":
                    s = new Simbolo(name, "0.0", globalType);
                    break;
                default:
                    s = new Simbolo(name, "null", globalType);
                    break;
            }
            
            bool repeat = false;
            for (int i = 0; i < TabSim.Count; i++)
            {
                if (name == TabSim[i].Nombre)
                    repeat = true;
            }
            for (int i = 0; i < auxTS.Count; i++)
            {
                if (name == auxTS[i].Nombre)
                    repeat = true;
            }
            if (!repeat)
                auxTS.Add(s);
        }
    }
}
