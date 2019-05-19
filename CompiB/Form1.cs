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
        Timer timer;
        string sourceFilePath;

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
            pictureBox1.Refresh();
        }

        /// <summary>
        /// Se cargan los archivos necesarios para poder ejecutar los programas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void programaText_TextChanged(object sender, EventArgs e)
        {
            posicion = programaText.SelectionStart;
            ejecucion();
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
            }
        }

        /// <summary>
        /// Mostrar los numero de linea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int altura = programaText.GetPositionFromCharIndex(0).Y;

            if (programaText.Lines.Length > 0)
                for (int i = 0; i < programaText.Lines.Length; i++)
                {
                    /*try
                    {
                        if (Cuadruplos.Count > 0)
                        {
                            if (Cuadruplos[AptCuadruplo].Linea == i + 1)
                                e.Graphics.DrawString((i + 1).ToString(), programaText.Font, Brushes.Green, PictureNumText.Width - (e.Graphics.MeasureString((i + 1).ToString(), programaText.Font).Width + 10), altura);
                            else
                                e.Graphics.DrawString((i + 1).ToString(), programaText.Font, Brushes.Blue, PictureNumText.Width - (e.Graphics.MeasureString((i + 1).ToString(), programaText.Font).Width + 10), altura);
                        }
                        else*/
                            e.Graphics.DrawString((i + 1).ToString(), programaText.Font, Brushes.Blue, pictureBox1.Width - (e.Graphics.MeasureString((i + 1).ToString(), programaText.Font).Width + 10), altura);
                        altura += programaText.Font.Height;
                   /* }
                    catch { }*/
                }
            else
                e.Graphics.DrawString("1", programaText.Font, Brushes.Blue, pictureBox1.Width - (e.Graphics.MeasureString("1", programaText.Font).Width + 10), altura);

        }

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
    }
}
