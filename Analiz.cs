using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enigma_Form
{
    internal class Analiz
    {

        string aft_ref;
        string aft_rot;
        string aft_kom;
        string alfabhet;
        public char[,] otvet_rotor;

        public char[] analiz_ref;
        public char[] analiz_kom;
        public char[] analiz_rot;

        string text;

        public Analiz(string aft_ref, string aft_rot, string aft_kom, string alfabhet, string text)
        {
            this.aft_ref = Deleter(aft_ref);
            this.aft_rot = Deleter(aft_rot);
            this.aft_kom = Deleter(aft_kom);
            this.alfabhet = alfabhet;
            this.text = Deleter(text).ToUpper();

            otvet_rotor = new char[alfabhet.Length, aft_ref.Length];
        }
        string Deleter(string str)
        {
            string new_str = "";
            for (int i = 0; i < str.Length; i++)
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
        
        public double[] Chastota(string str)
        {
            double[] shet = new double[alfabhet.Length];
            double prov = 0;
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < alfabhet.Length; j++)
                {
                    if (str[i] == alfabhet[j])
                    {
                        shet[j] += 1;
                    }

                }
            }
            for (int i = 0; i < shet.Length; i++)
            {
                shet[i] = (shet[i] / aft_kom.Length);
                prov = prov + shet[i];
            }
            return shet;
        }

        public char[] AnalizReflector()
        {
            int[] an_ref = new int[alfabhet.Length];
            char[] anref_ch = new char[alfabhet.Length];
            double[] text_ver = new double[alfabhet.Length];
            double[] ref_ver = new double[alfabhet.Length];

            text_ver = Chastota(text);
            ref_ver = Chastota(aft_ref);

            int k = 0;
            
                for (int i = 0; i < text_ver.Length; i++)
                {
                    for (int j = 0; j < ref_ver.Length; j++)
                    {
                        if (text_ver[i] == ref_ver[j])
                        {
                            an_ref[i] = j;
                        }
                    }
                }
        
            for (int i = 0; i < an_ref.Length; i++)
            {
                k = an_ref[i];
                anref_ch[i] = alfabhet[k];
            }

            return anref_ch;
        }
        public char[] AnalizRotor()
        {
            int n = 0; int l = 0;
            for (int i = 0; i < otvet_rotor.GetLength(0); i++)
            {
                for (int j = 0; j < otvet_rotor.GetLength(1); j++)
                {
                    otvet_rotor[i, j] = '-';
                }
            }
            for (int i = 0; i < aft_ref.Length; i++)
            {
                for (int j = 0; j < alfabhet.Length; j++)
                {
                    if ((aft_ref[i] == alfabhet[j]) & (l < otvet_rotor.GetLength(1)))
                    {
                        n = j;

                        otvet_rotor[n, l] = aft_rot[i];


                        l++;
                    }
                }
            }
            int c = otvet_rotor.GetLength(1) / alfabhet.Length; int h = 1;
            while (h < c)
            {
                for (int i = 0; i < otvet_rotor.GetLength(0); i++)
                {
                    for (int j = 0; j < otvet_rotor.GetLength(1); j++)
                    {
                        if ((j >= alfabhet.Length * h) && (otvet_rotor[i, j - alfabhet.Length * h] == '-'))
                        {
                            otvet_rotor[i, j - alfabhet.Length * h] = otvet_rotor[i, j];
                        }

                    }
                }
                h++;
            }

           
            for (int i = 0; i < otvet_rotor.GetLength(0); i++)
            {
                for (int j = 0; j < alfabhet.Length; j++)
                {
                    if (otvet_rotor[i, j] == '-')
                    {
                        otvet_rotor[i, j] = otvet_rotor[i + 1, j + 1];
                    }
                }
            }
            
            
            char[] otvet = new char[alfabhet.Length];
            for (int i = 0; i < otvet.Length; i++)
            {
                otvet[i] = otvet_rotor[i, 0];
            }

            return otvet;
        }

        public char[] AnalizKommutator()
        {
            char[] ankom_ch = new char[alfabhet.Length];

            for (int i = 0; i < aft_rot.Length; i++)
            {
                for (int j = 0; j < alfabhet.Length; j++)
                {
                    if (aft_rot[i] == alfabhet[j])
                    {
                        ankom_ch[j] = aft_kom[i];
                    }
                }
            }

            return ankom_ch;
        }

        public void AnalizAll()
        {
            analiz_ref = AnalizReflector();
            analiz_rot = AnalizRotor();
            analiz_kom = AnalizKommutator();
        }

    }
}

