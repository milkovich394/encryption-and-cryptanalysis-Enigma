using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace enigma_Form
{
    public partial class Form3 : Form
    {
        string[] alf;
        double[] ver;
        double[] ver2;
        public Form3(string alf, double[]ver, double[]ver2)
        {
            InitializeComponent();
            this.alf = convert(alf);
            this.ver = ver;
            this.ver2 = ver2;

            chart1.Palette = ChartColorPalette.SeaGreen;
            for (int i = 0; i < alf.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i,ver[i]);
                chart2.Series[0].Points.AddXY(i, ver2[i]);
            }

        }
        public string[] convert(string stroka)
        {
            string[] arr = new string[stroka.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Char.ToString(stroka[i]);
            }
            return arr;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
