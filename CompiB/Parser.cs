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
        //Stack<BinaryTreeNode> nodesStack;
        Stack<string> operatorsStack;
        string globalType;
        int counter; // Contador de nodos visitados en DFSSearch
        List<Production> productions;

       // internal List<Node> AFD;
        internal List<State> States { get { return states; } set { states = value; } }
        internal List<ActionLog> Log { get { return log; } set { log = value; } }

        public Parser(List<Production> p, List<State> s/*List<Node> AFDList*/)
        {
            productions = p;
            // AFD = AFDList;
            States = s;/*new List<State>();*/
            stackAnalysis = new List<TokenState>();
            log = new List<ActionLog>();
            //nodesStack = new Stack<BinaryTreeNode>();
            operatorsStack = new Stack<string>();

            counter = 1;

        }

        public bool EvalString(String inputString)
        {
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
                    var rLen = production.Right.Count;

                    if (nextAction.state == 0) // Estado R0 o aceptar
                        break;

                    // Encuentra match
                    for (var i = 0; i < rLen; i++)
                    {
                        Token r = production.Right[i];
                        int indexStack = (stackAnalysis.Count) - rLen + i;
                        var itState = stackAnalysis[indexStack];

                        if (!itState.dirty && itState.token.Content == r.Content)
                        {
                            itState.dirty = true;
                            r.Val = itState.token.Val;
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

                   // SemanticAnalysis(production, nextAction.state); Aqui se hacen las reducciones

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
    }
}
