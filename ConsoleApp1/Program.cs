using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 8;
            List<List<string>> table = new List<List<string>>();
            //init
            int jFlag = 0;
            InitTable(n, table);

            while (jFlag < n)
            {
                ResetTable(n, table);

                int qCnt = 0;
                for (int i = 0; i < n; i++)
                {
                    int j = 0;
                    if (i == 0) j = jFlag;
                    for ( ; j < n; j++)
                    {
                        if (table[i][j] != ".")
                        {
                            table[i][j] = "Q";
                            qCnt++;
                            //X Bye
                            for (int k = 0; k < n; k++)
                            {
                                if (k != j)
                                    table[i][k] = ".";
                            }
                            //Y Bye
                            for (int k = 0; k < n; k++)
                            {
                                if (k != i)
                                    table[k][j] = ".";
                            }
                            //Z Bye
                            int zi = i + 1;
                            int zj = j + 1;
                            for (; zi < n && zj < n; zi++, zj++)
                            {
                                table[zi][zj] = ".";
                            }
                            //Z Bye
                            if (i < n-1 && j != 0)
                            {
                                zi = i + 1;
                                zj = j - 1;
                                for (; zi >= 0 && zi < n && zj < n && zj >= 0; zi++, zj--)
                                {
                                    table[zi][zj] = ".";
                                }
                            }
                        }
                    }

                    foreach (var yItem in table[i])
                        Console.Write(yItem);
                    Console.WriteLine();
                }
                Console.WriteLine("*******");

                jFlag++;
                //if (qCnt == n)
                //{
                //    foreach (var xItem in table)
                //    {
                //        foreach (var yItem in xItem)
                //            Console.Write(yItem);
                //        Console.WriteLine();
                //    }
                //    Console.WriteLine("*******");
                //}
            }
            Console.WriteLine("End");

            Console.ReadKey();
        }

        private static void InitTable(int n, List<List<string>> table)
        {
            for (int i = 0; i < n; i++)
            {
                table.Add(new List<string>());
                for (int j = 0; j < n; j++)
                {
                    table[i].Add("0");
                }
            }
        }

        private static void ResetTable(int n, List<List<string>> table)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    table[i][j]="0";
                }
            }
        }
    }
}
