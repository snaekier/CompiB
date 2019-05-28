using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CompiB
{
    public partial class Form1 : Form
    {
        int posicion = 0;
        string[] Reservadas = new string[] { "defid","CreaVentana","CreaLabel","CreaBoton",
                "CreaTextbox","defmain","Click","if","else","repeat","until","while","switch","case",
                "break","for","MessageBox","Loop","ImprimeTextBox","int","string","vent","textBox","label","boton","float"};
        string[] simbolos = new string[] { "{", "}", "[", "]", ",", "(", ")", ":", ":=", ";", "*", "/", "-", "+", "^", "<","<=",">",">=","!=" };
        Timer timer;
        string sourceFilePath;
        Parser parser;
        List<Quad> currentQuads;
        int iQuad = 0;
        char banQuad = '0';
        Interpreter interpreter;
        public int firstNumL;
        bool banAlto = true;

        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += new EventHandler(timerTick);
            timer.Start();
            ejecucion();
            this.programaText.SelectionStart = this.programaText.Text.Length;
        }

        /// <summary>
        /// Para el control del # de linea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerTick(object sender, EventArgs e)
        {
            //pictureBox1.Refresh();
        }

        /// <summary>
        /// Se cargan los archivos necesarios para poder ejecutar los programas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            parser = new Parser(Helpers.DeSeralization2(), Helpers.DeSeralization());

            //Código para num de linea
            LineNumberTextBox.Font = programaText.Font;
            programaText.Select();
            AddLineNumbers();
        }

        private void programaText_TextChanged(object sender, EventArgs e)
        {
            posicion = programaText.SelectionStart;
            ejecucion();

            //código para numeración de linea
            if (programaText.Text == "")
            {
                AddLineNumbers();
            }
        }

        /// <summary>
        /// Cambia el color de las palabras reservadas
        /// </summary>
        private void ejecucion()
        {
            this.programaText.Select(0, programaText.Text.Length);
            programaText.SelectionColor = Color.White;
            this.programaText.Select(posicion, 0);

            string[] texto = programaText.Text.Trim().Split(' ','\r','\n');
            int inicio = 0;

            foreach (string x in texto)
            {
                foreach (string y in Reservadas)
                {
                    if (x.Length != 0)
                    {
                        if (x.Trim().Equals(y))
                        {
                            inicio = this.programaText.Text.IndexOf(x, inicio);
                            this.programaText.Select(inicio, x.Length);
                            programaText.SelectionColor = Color.Blue;
                            this.programaText.Select(posicion, 0);
                            inicio = inicio + 1;
                        }
                    }
                }
                foreach(string y in simbolos)
                {
                    if (x.Length != 0)
                    {
                        if (x.Trim().Equals(y))
                        {
                            inicio = this.programaText.Text.IndexOf(x, inicio);
                            this.programaText.Select(inicio, x.Length);
                            programaText.SelectionColor = Color.Red;
                            this.programaText.Select(posicion, 0);
                            inicio = inicio + 1;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Mostrar los numero de linea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void pictureBox1_Paint(object sender, PaintEventArgs e)
        //{
        //    int altura = programaText.GetPositionFromCharIndex(0).Y;

        //    if (programaText.Lines.Length > 0)
        //        for (int i = 0; i < programaText.Lines.Length; i++)
        //        {
        //            /*try
        //            {
        //                if (Cuadruplos.Count > 0)
        //                {
        //                    if (Cuadruplos[AptCuadruplo].Linea == i + 1)
        //                        e.Graphics.DrawString((i + 1).ToString(), programaText.Font, Brushes.Green, PictureNumText.Width - (e.Graphics.MeasureString((i + 1).ToString(), programaText.Font).Width + 10), altura);
        //                    else
        //                        e.Graphics.DrawString((i + 1).ToString(), programaText.Font, Brushes.Blue, PictureNumText.Width - (e.Graphics.MeasureString((i + 1).ToString(), programaText.Font).Width + 10), altura);
        //                }
        //                else*/
        //                    e.Graphics.DrawString((i + 1).ToString(), programaText.Font, Brushes.Blue, pictureBox1.Width - (e.Graphics.MeasureString((i + 1).ToString(), programaText.Font).Width + 10), altura);
        //                altura += programaText.Font.Height;
        //           /* }
        //            catch { }*/
        //        }
        //    else
        //        e.Graphics.DrawString("1", programaText.Font, Brushes.Blue, pictureBox1.Width - (e.Graphics.MeasureString("1", programaText.Font).Width + 10), altura);

        //}

        /// <summary>
        /// Abrir un proyecto ya hecho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = "Archivos de texto (*.txt)| *.txt";
            dialog.AddExtension = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {

                programaText.Text = File.ReadAllText(dialog.FileName);
                sourceFilePath = dialog.FileName;
            }
        }

        /// <summary>
        /// Guarda el archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(programaText.Text))
            {
                if (File.Exists(sourceFilePath))
                {
                    File.WriteAllText(sourceFilePath, programaText.Text);
                }
                else
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.DefaultExt = "txt";
                    dialog.AddExtension = true;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        sourceFilePath = dialog.FileName;
                        File.WriteAllText(sourceFilePath, programaText.Text);

                    }
                }

            }
        }

        /// <summary>
        /// Muestra la tabla de AS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void anaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<State> states = parser.States;
            DataTable tabla = new DataTable();
            for (int i = 0; i < states.Count; i++)
            {

                Dictionary<string, Action> allTokens = states[i].NonTerminals.Concat(states[i].Terminals).ToDictionary(x => x.Key, x => x.Value);

                if (i == 0)
                {
                    DataColumn colEstado = new DataColumn();
                    colEstado.ColumnName = "Estado";
                    tabla.Columns.Add(colEstado);
                    colEstado.ReadOnly = true;
                    foreach (KeyValuePair<string, Action> token in allTokens)
                    {

                        DataColumn col = new DataColumn();
                        col.ColumnName = token.Key.Replace("(", "PI").Replace(")", "PD").Replace("[", "CI").Replace("]", "CD");
                        tabla.Columns.Add(col);
                        col.ReadOnly = true;

                    }

                }

                DataRow r = tabla.NewRow();

                r[0] = i;
                foreach (KeyValuePair<string, Action> token in allTokens)
                {

                    string k = token.Key.Replace("(", "PI").Replace(")", "PD").Replace("[", "CI").Replace("]", "CD");
                    r[k] = token.Value;


                }
                tabla.Rows.Add(r);

            }

            TAS vent1 = new TAS(tabla);
            vent1.Show();
            
        }

        /// <summary>
        /// Realiza la compilación del programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void compilarB_Click(object sender, EventArgs e)
        {
            if (parser.EvalString(programaText.Text)){
                QuadGenerator quadGenerator = new QuadGenerator();
                currentQuads = quadGenerator.Generate(parser.NodeStack.Peek());
                muestraQuads();muestraSim();
                MessageBox.Show("Todo correcto");
                ejecutaB.Enabled = true;
                lowLvlB.Enabled = true;
                highLvlB.Enabled = true;

                interpreter = new Interpreter(currentQuads, parser.TabSim);
                banAlto = true;
            }
            else
            {
                MessageBox.Show("Error en la línea: "+parser.Lines, "Algo salio mal");
                ejecutaB.Enabled = false;
                lowLvlB.Enabled = false;
                highLvlB.Enabled = false;
            }
        }

        private void muestraSim()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Nombre"); tabla.Columns.Add("Tipo"); tabla.Columns.Add("Valor");
            foreach(Simbolo s in parser.TabSim)
            {
                tabla.Rows.Add(s.Nombre, s.Tipo, s.Valor.ToString());
            }
            tabsimGrid.DataSource = tabla;
        }

        private void muestraQuads()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Num"); tabla.Columns.Add("Operador"); tabla.Columns.Add("Operando 1"); tabla.Columns.Add("Operando 2"); tabla.Columns.Add("Resultado"); tabla.Columns.Add("Linea");
            foreach (Quad q in currentQuads)
            {
                tabla.Rows.Add(q.Num, q.Operator,q.OperandA,q.OperandB,q.Result, q.NumL);
            }
            cuadruplosGrid.DataSource = tabla;
        }

        /// <summary>
        /// Muestra una ventana con la grámatica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grámaticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gramatica grammar = new Gramatica();
            grammar.Show();
        }

        private void tAASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Stack"); tabla.Columns.Add("Input"); tabla.Columns.Add("Action");
            foreach (ActionLog log in parser.Log)
            {
                tabla.Rows.Add(log.Stack, log.Input, log.Action);
            }
            TAAS vent3 = new TAAS(tabla);
            vent3.Show();
        }

        private void ejecutaB_Click(object sender, EventArgs e)
        {
            interpreter.cleanInterpreter();
            interpreter.ExeAllQuads(0);
        }

        private void highLvlB_Click(object sender, EventArgs e)
        {
            if (banAlto)
            {
                interpreter.cleanInterpreter();
                interpreter.UpdateSimbTable();
                firstNumL = interpreter.GetFirstLine();
                banAlto = false;
            }
            firstNumL = interpreter.quadsAlto(firstNumL);
            if(firstNumL == -1)
            {
                MessageBox.Show("Termino Ejecucion de Alto nivel");
                banAlto = true;
            }
        }

        private void lowLvlB_Click(object sender, EventArgs e)
        {
            if (iQuad == 0)
            {
                interpreter.cleanInterpreter();
                interpreter.UpdateSimbTable();
                //interpreter.step1 = true;
                //interpreter.step2 = false;
            }
            
            cuadruplosGrid.Rows[iQuad].Selected = true;
            iQuad = interpreter.interpreterStep(iQuad);
        }



        //Código para numero de linea
        public int getWidth()
        {
            int w = 25;
            // get total lines of programaText    
            int line = programaText.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)programaText.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)programaText.Font.Size;
            }
            else
            {
                w = 50 + (int)programaText.Font.Size;
            }

            return w;
        }

        public void AddLineNumbers()
        {
            // create & set Point pt to (0,0)    
            Point pt = new Point(0, 0);
            // get First Index & First Line from programaText    
            int First_Index = programaText.GetCharIndexFromPosition(pt);
            int First_Line = programaText.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from programaText    
            int Last_Index = programaText.GetCharIndexFromPosition(pt);
            int Last_Line = programaText.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox    
            LineNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value    
            LineNumberTextBox.Text = "";
            LineNumberTextBox.Width = getWidth();
            // now add each line number to LineNumberTextBox upto last line    
            for (int i = First_Line; i <= Last_Line; i++)
            {
                LineNumberTextBox.Text += i + 1 + "\n";
            }
        }

        private void programaText_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = programaText.GetPositionFromCharIndex(programaText.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
        }

        private void programaText_VScroll(object sender, EventArgs e)
        {
            LineNumberTextBox.Text = "";
            AddLineNumbers();
            LineNumberTextBox.Invalidate();
        }

        private void programaText_FontChanged(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = programaText.Font;
            programaText.Select();
            AddLineNumbers();
        }

        private void LineNumberTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            programaText.Select();
            LineNumberTextBox.DeselectAll();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            AddLineNumbers();
        }

        private void programaText_SelectionChanged_1(object sender, EventArgs e)
        {
            Point pt = programaText.GetPositionFromCharIndex(programaText.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
        }

        private void programaText_Resize(object sender, EventArgs e)
        {
            AddLineNumbers();
        }
    }
}
