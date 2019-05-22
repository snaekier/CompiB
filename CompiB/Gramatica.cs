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
    public partial class Gramatica : Form
    {
        public Gramatica()
        {
            InitializeComponent();
            richTextBox1.Text = File.ReadAllText(Environment.CurrentDirectory + "\\TinyBen2.txt");
        }
    }
}
