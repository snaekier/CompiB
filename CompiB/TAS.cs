using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompiB
{
    public partial class TAS : Form
    {
        public TAS(DataTable tabla)
        {
            
            InitializeComponent();

            
            dataGridView1.DataSource = tabla.DefaultView;
        }
    }
}
