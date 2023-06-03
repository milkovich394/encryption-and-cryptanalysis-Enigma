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

namespace enigma_Form
{
    public partial class Form1 : Form
    {
        string aft_ref;
        string aft_rot;
        string aft_kom;
        string alfabhet;
        string text;
        public Form1()
        {
            InitializeComponent();
        }
        string fname;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fl = new OpenFileDialog();
            if (fl.ShowDialog() == DialogResult.OK)
            {
                fname = fl.FileName;
                StreamReader sr = new StreamReader(fl.FileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Enigma enigma = new Enigma(textBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text);
            richTextBox2.Text=Adder(enigma.Enigma_bigText(richTextBox1.Text), richTextBox1.Text);
            this.aft_ref = Deleter(enigma.aft_ref);
            this.aft_rot = Deleter(enigma.aft_rot);
            this.aft_kom = Deleter(enigma.aft_kom);

            text = richTextBox1.Text;
            alfabhet = textBox1.Text;

        }
        string Deleter(string str)
        {
            string new_str = "";
            for(int i=0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    new_str = new_str;
                }
                else
                {
                    new_str += str[i];
                }
                
            }
            return new_str;
        }
        string Adder(string str, string ex)
        {
            string new_str = str;
            for (int i = 0; i < str.Length; i++)
            {
                if (ex[i] == ' ')
                {
                    new_str += ' ';
                }

            }
            return new_str;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Enigma enigma = new Enigma(textBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text);
            richTextBox3.Text = Adder(enigma.Enigma_back_bigText(richTextBox2.Text), richTextBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(aft_ref, aft_rot, aft_kom, alfabhet, text);
            form2.ShowDialog();

        }
    }
}
