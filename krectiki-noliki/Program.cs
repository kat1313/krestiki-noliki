using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace крестики_нолики
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ss;
            int xx;
            int oo;
            int[,] asi = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 }, { 1, 5, 9 }, { 3, 5, 7 } };
            int[] x;
            int[] o;
            int nich;
            string x4 = "\n-------------\n";
            string x3 = "-------------\n| ";
            string x2 = "\n-------------\n| ";
            string x1 = " | ";
            Console.WriteLine("начать новую игру?\n     да\tнет");
            start(Console.ReadLine());

            void start(string s)
            {
                xx = 0;
                oo = 0;
                nich = 0;
                x = new int[] { 0, 0, 0, 0, 0 };
                o = new int[] { 0, 0, 0, 0, 0 };
                ss = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                switch (s)
                {
                    case "да":
                        {
                            Console.WriteLine("кто будет ходить первым?\n      x\to");
                            WhoFirst(Console.ReadLine());
                            break;
                        }
                    case "нет":
                        {
                            Console.WriteLine("желаете прекратить игру?\n      да\tнет");
                            end(Console.ReadLine());
                            break;
                        }
                    default:
                        Console.WriteLine("такого нет!\nначать новую игру?\n     да\tнет");
                        start(Console.ReadLine());
                        break;
                }
            }

            void end(string s)
            {
                switch (s)
                {
                    case "да":
                        Environment.Exit(0);
                        break;
                    case "нет":
                        Console.WriteLine("начать новую игру?\n     да\tнет");
                        start(Console.ReadLine());
                        break;
                }
            }

            void WhoFirst(string s)
            {
                switch (s)
                {
                    case "х":
                        OutputTheField(nich);
                        Xx(xx);
                        break;
                    case "о":
                        OutputTheField(nich);
                        Oo(oo);
                        break;
                    case "зи":
                        Console.WriteLine("желаете прекратить игру?\n      да\tнет");
                        end(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("такого нет!\nкто будет ходить первым?\n      x\to\t хочу закончить игру(зи)");
                        WhoFirst(Console.ReadLine());
                        break;
                }
            }

            int WhatNeed(string r)
            {
                if (r == "1" || r == "2" || r == "3" || r == "4" || r == "5" || r == "6" || r == "7" || r == "8" || r == "9")
                {
                    nich++;
                    return Convert.ToInt32(r);
                }
                else
                    Console.WriteLine("неверный ход!");
                return 0;
            }

            void WriteArrayX(int m)
            {
                if (m == 0)
                    Xx(xx);
                else if (ss[m - 1] != "x" && ss[m - 1] != "o")
                {
                    x[xx] = m;
                    xx++;
                    ss[m - 1] = "x";
                    OutputTheField(nich);
                    victory(x, 1);
                    if (nich == 9)
                    {
                        Console.WriteLine("ничья!");
                        Console.WriteLine("начать новую игру?\n     да\tнет");
                        start(Console.ReadLine());
                    }
                }
                else
                {
                    Console.WriteLine("эта клеточка уже занята!\nвыберите другую!");
                    Xx(xx);
                }
            }

            void WriteArrayO(int m)
            {
                if (m == 0)
                    Oo(oo);
                else if (ss[m - 1] != "x" && ss[m - 1] != "o")
                {
                    o[oo] = m;
                    oo++;
                    ss[m - 1] = "o";
                    OutputTheField(nich);
                    victory(o, 0);if (nich == 9)
                    {
                        Console.WriteLine("ничья!");
                        Console.WriteLine("начать новую игру?\n     да\tнет");
                        start(Console.ReadLine());
                    }
                }
                else
                {
                    Console.WriteLine("эта клеточка уже занята!\nвыберите другую!");
                    Xx(xx);
                }
            }

            void victory(int[] s, int a)
            {
                for (int j = 0; j < 8; j++)
                {
                    bool h0 = s.Contains(asi[j, 0]);
                    bool h1 = s.Contains(asi[j, 1]);
                    bool h2 = s.Contains(asi[j, 2]);
                    while (h0 == true && h1 == true && h2 == true)
                    {
                        Console.Write(x3);
                        for (int i = 0; i < 3; i++)
                        {
                            if (i==asi[j,0]-1|| i == asi[j, 1] - 1|| i == asi[j, 2] - 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                OutputOfVariables(i);
                            }
                            else if (ss[i] == "x")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                OutputOfVariables(i);
                            }
                            else if (ss[i] == "o")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                OutputOfVariables(i);
                            }
                            else
                            {
                                OutputOfVariables(i);
                            }
                        }
                        Console.Write(x2);
                        for (int i = 3; i < 6; i++)
                        {
                            if (i == asi[j, 0] - 1 || i == asi[j, 1] - 1 || i == asi[j, 2] - 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                OutputOfVariables(i);
                            }
                            else if (ss[i] == "x")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                OutputOfVariables(i);
                            }
                            else if (ss[i] == "o")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                OutputOfVariables(i);
                            }
                            else
                            {
                                Console.ResetColor();
                                OutputOfVariables(i);
                            }
                        }
                        Console.Write(x2);
                        for (int i = 6; i < 9; i++)
                        {
                            if (i == asi[j, 0] - 1 || i == asi[j, 1] - 1 || i == asi[j, 2] - 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                OutputOfVariables(i);
                            }
                            else if (ss[i] == "x")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                OutputOfVariables(i);
                            }
                            else if (ss[i] == "o")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                OutputOfVariables(i);
                            }
                            else
                            {
                                Console.ResetColor();
                                OutputOfVariables(i);
                            }
                        }
                        Console.Write(x4);
                        if (a == 1)
                            Console.WriteLine("победа X!");
                        else if (a == 0)
                            Console.WriteLine("победа O!");
                        else
                            Console.WriteLine("???");
                        Console.WriteLine("начать новую игру?\n     да\tнет");
                        start(Console.ReadLine());
                    }
                }          
            }
            void OutputOfVariables (int i)
            {
                Console.Write(ss[i]);
                Console.ResetColor();
                Console.Write(x1);
            }

            void Xx(int s)
            {
                Console.WriteLine("ход x:");
                int d = WhatNeed(Console.ReadLine());
                WriteArrayX(d);
                Oo(oo);
            }

            void Oo(int s)
            {
                Console.WriteLine("ход o:");
                int d = WhatNeed(Console.ReadLine());
                WriteArrayO(d);
                Xx(xx);
            }

            void OutputTheField(int n)
            {
                Console.Write(x3);
                for(int i=0; i<3;i++)
                {
                    if(ss[i]=="x")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        OutputOfVariables(i);
                    }
                    else if (ss[i] == "o")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        OutputOfVariables(i);
                    }
                    else
                    {
                        Console.ResetColor();
                        OutputOfVariables(i);
                    }
                }
                Console.Write(x2);
                for (int i = 3; i < 6; i++)
                {
                    if (ss[i] == "x")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        OutputOfVariables(i);
                    }
                    else if (ss[i] == "o")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        OutputOfVariables(i);
                    }
                    else
                    {
                        Console.ResetColor();
                        OutputOfVariables(i);
                    }
                }
                Console.Write(x2);
                for (int i = 6; i < 9; i++)
                {
                    if (ss[i] == "x")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        OutputOfVariables(i);
                    }
                    else if (ss[i] == "o")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        OutputOfVariables(i);
                    }
                    else
                    {
                        Console.ResetColor();
                        OutputOfVariables(i);
                    }
                }
                Console.Write(x4);
            }
        }
    }
}
