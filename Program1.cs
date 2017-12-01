using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKI4
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = Convert.ToString(Console.ReadLine());
            Console.WriteLine(str1);
            Console.WriteLine(str1.Length);

            ///////////////////////////////////////////////////////////////

            string str = String.Empty;
            int cz = 0;
            for (cz = 0; cz < str1.Length; cz++)
            {
                if (!char.IsDigit(str1[cz]))
                {
                    str += str1[cz];
                }
            }

            Console.WriteLine("Это будет зашифровано -> " + str);
            double ln = str.Length;

            if (ln % 2 != 0)
            {
                str += 'ъ';
            }
            Console.WriteLine(str);

            for (int i = 2; i < str.Length; i += 3)
                str = str.Insert(i,"|");

            Console.WriteLine(str);

            char[,] table_1 = new char[8, 4];
            char[,] table_2 = new char[8, 4];
            string n1 = Convert.ToString(Console.ReadLine());
            string n = String.Empty;
            for (int i = 0; i < n1.Length; i++)
            {
                if (!char.IsDigit(n1[i]))
                {
                    n += n1[i];
                }
            }
            Console.WriteLine("Ключ 1 -> "+n);
            int z1 = 0;
            string p = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
            Console.WriteLine(p);
            n += p;
            char[] chart = n.ToCharArray();
            IEnumerable<char> p1 = chart.Distinct();
            chart = p1.ToArray();
            string e = new string(chart);
            Console.WriteLine(e);
            chart = e.ToCharArray();
            for (int i = 0; i < table_1.GetLength(0); i++)
            {
                for (int j = 0; j < table_1.GetLength(1); j++)
                {
                    for (int z = z1; z < chart.Length; )
                    {
                        table_1[i, j] = chart[z];
                        z1++;
                        break;
                    }
                }
            }
            Console.WriteLine();
            for (int i = 0; i < table_1.GetLength(0); i++)
            {
                for (int j = 0; j < table_1.GetLength(1); j++)
                {
                    Console.Write(" " + table_1[i, j]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }


            string m1 = Convert.ToString(Console.ReadLine());
            string m = String.Empty;
            for (int i = 0; i < m1.Length; i++)
            {
                if (!char.IsDigit(m1[i]))
                {
                    m += m1[i];
                }
            }
            Console.WriteLine("Ключ 2 -> "+m);
            int z2 = 0;
            m += p;
            char[] chart1 = m.ToCharArray();
            IEnumerable<char> p2 = chart1.Distinct();
            chart1 = p2.ToArray();
            string e1 = new string(chart1);
            chart1 = e1.ToCharArray();
            for (int i = 0; i < table_2.GetLength(0); i++)
            {
                for (int j = 0; j < table_2.GetLength(1); j++)
                {
                    for (int z = z2; z < chart1.Length; )
                    {
                        table_2[i, j] = chart1[z];
                        z2++;
                        break;
                    }
                }
            }
            for (int i = 0; i < table_2.GetLength(0); i++)
            {
                for (int j = 0; j < table_2.GetLength(1); j++)
                {
                    Console.Write(" " + table_2[i, j]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }


            string[] words = str.Split('|');

            int iR1 = 0, jR1 = 0, iR2 = 0, jR2 = 0;

            string shifr = String.Empty; 

            for (int w = 0; w < words.Length; w++)
            {

                char[] ch = words[w].ToCharArray();
                for (int i = 0; i < table_1.GetLength(0); i++)
                {
                    for (int j = 0; j < table_1.GetLength(1); j++)
                    {
                        if (table_1[i,j] == ch[0])
                        {
                            iR1 = i;
                            jR1 = j;
                        }
                    }
                }
                for (int i = 0; i < table_2.GetLength(0); i++)
                {
                    for (int j = 0; j < table_2.GetLength(1); j++)
                    {
                        if (table_2[i, j] == ch[1])
                        {
                            iR2 = i;
                            jR2 = j;
                        }
                    }
                }

                /////////////////////////////////

                if ((iR1 != iR2) && (jR1 != jR2))
                {
                    shifr += table_1[iR2, jR1];
                    shifr += table_2[iR1, jR2];
                }

                else if (iR1 == iR2)
                {
                    if ((jR1 + 1 <= table_1.GetLength(1) - 1) && (jR2 + 1 <= table_2.GetLength(1) - 1))
                    {
                        shifr += table_1[iR1, jR2 + 1];
                        shifr += table_2[iR2, jR1 + 1];
                    }
                    else if ((jR1 + 1 > table_1.GetLength(1) - 1) && (jR2 + 1 <= table_2.GetLength(1) - 1))
                    {
                        shifr += table_1[iR1, 0];
                        shifr += table_2[iR2, jR2 + 1];
                    }
                    else if ((jR1 + 1 <= table_1.GetLength(1) - 1) && (jR2 + 1 > table_2.GetLength(1) - 1))
                    {
                        shifr += table_1[iR1, jR1 + 1];
                        shifr += table_2[iR2, 0];
                    }
                }
                else if (jR1 == jR2)
                {
                    if ((iR1 + 1 <= table_1.GetLength(0) - 1) && (iR2 + 1 <= table_2.GetLength(0) - 1))
                    {
                        shifr += table_1[iR1 + 1, jR2];
                        shifr += table_2[iR2 + 1, jR1];
                    }
                    else if ((iR1 + 1 > table_1.GetLength(0) - 1) && (iR2 + 1 <= table_2.GetLength(0) - 1))
                    {
                        shifr += table_1[0, jR2];
                        shifr += table_2[iR2 + 1, jR1];
                    }
                    else if ((iR1 + 1 <= table_1.GetLength(0) - 1) && (iR2 + 1 > table_2.GetLength(0) - 1))
                    {
                        shifr += table_1[iR1 + 1, jR2];
                        shifr += table_2[0, jR1];
                    }

                }

            }


            Console.WriteLine(shifr);

                Console.ReadKey();
        }
    }
}
