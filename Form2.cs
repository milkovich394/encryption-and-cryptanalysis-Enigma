using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace enigma_Form
{
    public partial class Form2 : Form
    {

        string aft_ref;
        string aft_rot;
        string aft_kom;
        string alfabhet;
        string text;

        double[] text_ch, aftref_ch, aftrot_ch, aftkom_ch;

        private void button3_Click(object sender, EventArgs e)
        {

            Form3 form3 = new Form3(alfabhet, aftrot_ch, aftkom_ch);
            form3.ShowDialog();
        }

        public Form2(string aft_ref, string aft_rot, string aft_kom, string alfabhet, string text)
        {
            InitializeComponent();

            this.aft_ref = aft_ref;
            this.aft_rot = aft_rot;
            this.aft_kom = aft_kom;
            this.alfabhet = alfabhet;
            this.text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Analiz analiz = new Analiz(aft_ref, aft_rot, aft_kom, alfabhet, text);
            text = text.ToUpper();
            text_ch = analiz.Chastota(text);
            aftref_ch = analiz.Chastota(aft_ref);

            for(int i = 0; i < alfabhet.Length; i++)
            {
                richTextBox1.Text = richTextBox1.Text+ alfabhet[i]+ "   "+ Math.Round(text_ch[i], 5)+"    "+ Math.Round(aftref_ch[i],5);
                richTextBox1.Text = richTextBox1.Text + "\n";

            }
            char[]reflector = analiz.AnalizReflector();
            for (int i = 0; i < alfabhet.Length; i++)
            {
                textBox1.Text = textBox1.Text + reflector[i];

            }
            char[]rot_ch = analiz.AnalizRotor();
            char[,] rotor = analiz.otvet_rotor;
            for (int i = 0; i < rotor.GetLength(0); i++)
            {
                for (int j = 0; j < alfabhet.Length; j++)
                {
                    richTextBox2.Text = richTextBox2.Text+rotor[i, j] + "  ";
                }
                richTextBox2.Text = richTextBox2.Text + "\n";
            }
           
            for (int i = 0; i < alfabhet.Length; i++)
            {
                textBox2.Text = textBox2.Text + rot_ch[i];

            }
            aftrot_ch = analiz.Chastota(aft_rot);
            aftkom_ch = analiz.Chastota(aft_kom);

         
            char[] kommutator = analiz.AnalizKommutator();
            for (int i = 0; i < alfabhet.Length; i++)
            {
                textBox3.Text = textBox3.Text + kommutator[i];

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(alfabhet, text_ch, aftref_ch);
            form3.ShowDialog();
        }
    }
}
