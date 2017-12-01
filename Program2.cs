using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKI4_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            int j1 = 0;
            string slovo = Convert.ToString(Console.ReadLine());
            string k = Convert.ToString(Console.ReadLine());
            string key = String.Empty;
            for (int i = 0; i < slovo.Length; i++)
            {
                for (int j = j1; j < k.Length;)
                {
                    key += k[j];
                    j1++;
                    if (j1 == k.Length)
                    {
                        j1 = 0;
                    }
                    else break;
                    break;
                }
            }
            Console.WriteLine(key);
            j1 = 0;
            int I = 0;
            //string temp = String.Empty;
            string shifr = String.Empty;
            string azbuka = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
            string az = azbuka;
            char[] alf = az.ToCharArray();
            int temp = 0;
            for (int i = 0; i < slovo.Length; i++)
            {
                for (int j = j1; j < key.Length;)
                {

                    for (int z = 0; z < alf.Length; z++)
                    {
                        if (key[j] == alf[z])
                        {
                            I = z;
                        }
                    }
                    for (int a = 0; a < azbuka.Length; a++)
                    {
                        if (slovo[i] == azbuka[a])
                        {
                            if(a+I<azbuka.Length)
                            shifr += azbuka[a + I];
                            else if (a + I >= azbuka.Length)
                            { 
                                temp = (a+I)-azbuka.Length;
                                shifr += azbuka[temp];
                            }
                        }
                    }
                    j1++;
                    break;
                }
            }
            Console.WriteLine(shifr);
            
            Console.ReadKey();
        }
    }
}
