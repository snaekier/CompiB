using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompiB
{
    public class VentForm
    {
        public string id, text;
        public int posX, posY, tamX, tamY;
        Form form = new Form();

        public void Create()
        {
            form.Location = new Point(posX, posY);
            form.Width = tamX;
            form.Height = tamY;
            form.Text = text;
        }

        public void Show()
        {
            form.Show();
        }
    }

    public class ButtonForm
    {
        public string id, text, startQuad, endQuad;
        public int posX, posY, tamX, tamY;

        public void Create()
        {
            
        }
    }

    public class TxtBoxForm
    {
        public string id, text;
        public int posX, posY, tamX, tamY;

        public void Create()
        {

        }
    }

    public class LblForm
    {
        public string id, text;
        public int posX, posY;

        public void Create()
        {

        }
    }
}
