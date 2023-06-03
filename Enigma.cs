using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enigma_Form
{
    internal class Enigma
    {
        string alf;
        string reflect;
        string kommut;
        string rotor_start;
        char[] alf_mas;
        char[] ref_mas;
        char[] kom_mas;
        char[] rotstart_mas;
        char[] rotend_mas;

        public string aft_ref, aft_rot, aft_kom;
        public Enigma(string alf, string reflect, string kommut, string rotor_start)
        {
            this.alf = alf;
            this.reflect = reflect;
            this.kommut = kommut;
            this.rotor_start = rotor_start;
            alf_mas = convert(alf);
            ref_mas = convert(reflect);
            kom_mas = convert(kommut);
            rotstart_mas = convert(rotor_start);
            rotend_mas = new char[rotstart_mas.Length];
        }
        public char[] convert(string stroka)
        {
            char[] arr = new char[stroka.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = stroka[i];
            }
            return arr;
        }

        string reflect_method(string text)
        {
            string text_after_ref = "";
            char[] text_mas = convert(text);
            char[] after_mas = new char[text_mas.Length];

            for (int i = 0; i < text.Length; i++)
            {
                
                for (int j = 0; j < alf.Length; j++)
                {
                    if (text_mas[i] == alf_mas[j])
                    {
                        after_mas[i] = ref_mas[j];
                        text_after_ref += ref_mas[j];
                    }
                    
                }
            }
            return text_after_ref;
        }

        string kommut_method(string text)
        {
            string text_after_kom = "";
            char[] text_mas = convert(text);
            char[] after_mas = new char[text_mas.Length];

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < alf.Length; j++)
                {
                    if (text_mas[i] == alf_mas[j])
                    {
                        after_mas[i] = kom_mas[j];
                        text_after_kom += kom_mas[j];
                    }
                    
                }
            }
            return text_after_kom;
        }

        char[] sdvig(char[] mas)
        {
            char[] mas_sdvig = new char[mas.Length];
            char last = mas[mas.Length - 1];
            for (int i = 0; i < mas.Length - 1; i++)
            {
                mas_sdvig[i + 1] = mas[i];
            }
            mas_sdvig[0] = last;
            return mas_sdvig;
        }
        char[] sdvig_obr(char[] mas)
        {
            char[] mas_sdvig = new char[mas.Length];
            char first = mas[0];
            for (int i = mas.Length - 1; i > 0; i--)
            {
                mas_sdvig[i - 1] = mas[i];
            }
            mas_sdvig[mas.Length - 1] = first;
            return mas_sdvig;
        }

        string rotor_method(string text)
        {
            string text_after_rotor = "";
            char[] text_mas = convert(text);
            char[] rotor_next = rotstart_mas;

            for (int i = 0; i < text.Length; i++)
            {
               
                for (int j = 0; j < rotor_start.Length; j++)
                {
                    if (text_mas[i] == alf_mas[j])
                    {
                        text_after_rotor += rotor_next[j];
                    }
                   
                }
                rotor_next = sdvig(rotor_next);

            }
            rotend_mas = rotor_next;
            return text_after_rotor;
        }

        string rotor_method_obr(string text)
        {
            string text_after_rotor = "";
            char[] text_mas = convert(text);
            char[] rotor_next = rotstart_mas;
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < alf_mas.Length; j++)
                {
                    if (text[i] == rotor_next[j])
                    {
                        text_after_rotor += alf_mas[j];
                    }
                }
                rotor_next = sdvig(rotor_next);
            }
            return text_after_rotor;
        }

        public string Enigma_meth(string text)
        {
            Console.WriteLine("ЗАШИФРОВКА");
            text = text.ToUpper();
            aft_ref = reflect_method(text);
            Console.WriteLine("Результат после прохождения через рефлектор: ");
            Console.WriteLine(aft_ref);
            aft_rot = rotor_method(aft_ref);
            Console.WriteLine("Результат после прохождения через ротор: ");
            Console.WriteLine(aft_rot);
            aft_kom = kommut_method(aft_rot);
            Console.WriteLine("Результат после прохождения через коммутатор: ");
            Console.WriteLine(aft_kom);
            Console.WriteLine("-----------------------------------------------------");

            return aft_kom;
        }

        public string Enigma_bigText(string text)
        {
            Console.WriteLine("ЗАШИФРОВКА");
            text = text.ToUpper();
            aft_ref = reflect_method(text);
            //Console.WriteLine("Результат после прохождения через рефлектор: ");
            aft_rot = rotor_method(aft_ref);
            //Console.WriteLine("Результат после прохождения через ротор: ");
            aft_kom = kommut_method(aft_rot);
            Console.WriteLine("DONE");

            return aft_kom;
        }

        public string Enigma_back(string text)
        {
            Console.WriteLine("ДЕШИФРОВКА");
            string aft_kom1 = kommut_method(text);
            Console.WriteLine("Результат после прохождения через коммутатор: ");
            Console.WriteLine(aft_kom1);
            string aft_rot1 = rotor_method_obr(aft_kom1);
            Console.WriteLine("Результат после прохождения через ротор: ");
            Console.WriteLine(aft_rot1);
            string aft1 = reflect_method(aft_rot1);
            Console.WriteLine("Результат после прохождения через рефлектор: ");
            Console.WriteLine(aft1);
            Console.WriteLine("-----------------------------------------------------");

            return aft1;
        }

        public string Enigma_back_bigText(string text)
        {
            Console.WriteLine("ДЕШИФРОВКА");
            string aft_kom1 = kommut_method(text);
            //Console.WriteLine("Результат после прохождения через коммутатор: ");
            string aft_rot1 = rotor_method_obr(aft_kom1);
            //Console.WriteLine("Результат после прохождения через ротор: ");
            string aft1 = reflect_method(aft_rot1);
            Console.WriteLine("DONE");

            return aft1;
        }
    }
}

