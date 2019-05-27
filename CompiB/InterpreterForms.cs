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
        Button button = new Button();

        public void Create()
        {
            button.Location = new Point(posX, posY);
            button.Width = tamX;
            button.Height = tamY;
            button.Text = text;
        }

        public void eventoBoton()
        {
            button.Click += new EventHandler(button_Click);
        }

        public void button_Click(object sender, EventArgs e)
        {

        }

        public void agregaBoton(Form forma)
        {
            forma.Controls.Add(button);
        }
    }

    public class TxtBoxForm
    {
        public string id, text;
        public int posX, posY, tamX, tamY;
        TextBox textBox = new TextBox();

        public void Create()
        {
            textBox.Location = new Point(posX, posY);
            textBox.Width = tamX;
            textBox.Height = tamY;
            textBox.Text = text;
        }

        public void agregaTextBox(Form forma)
        {
            forma.Controls.Add(textBox);
        }
    }

    public class LblForm
    {
        public string id, text;
        public int posX, posY;
        Label label = new Label();

        public void Create()
        {
            label.Location = new Point(posX, posY);
            label.Text = text;
        }

        public void agregaLabel(Form forma)
        {
            forma.Controls.Add(label);
        }
    }
}
