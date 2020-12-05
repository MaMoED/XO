using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = new int[,] { { 5, 5, 5 }, { 5, 5, 5 }, { 5, 5, 5 } };

            while (1 == 1)
            {
                string text1 = "- = КРЕСТИКИ НОЛИКИ = -          v1.0 by U_00F8";
                string text2 = ">>>  РЕЖИМ ИГРЫ  ->  2 ИГРОКА .  (ИИ добавлю позже)";
                string text3 = ">>>  ИГРАТЬ НА NUMPAD С РЕЖИМОМ ЦИФЕР .";
                string text4 = "  Игрок 1 , какой символ хотите использовать?\n\n  Х или О\n  [1 - 0]\n";

                Random rnd = new Random();
                bool t = true;
                bool err = false;
                int last = 5;
                bool player = false;
                string a = "";
                int aa = 5;
                string scur = "";
                int cur = -1;
                int x = -1;
                int y = -1;
                for (int i = 0; i < 3; i++) { for (int j = 0; j < 3; j++) { grid[i, j] = rnd.Next(5, 2000000000); } }
                Console.Clear();

                while (1 == 1)
                {
                    if (t)
                    {
                        Console.WriteLine("");
                        Console.Write("                ");
                        for (int i = 0; i < text1.Length; i++)
                        {
                            Thread.Sleep(60);
                            Console.Write(text1[i]);
                        }
                        Thread.Sleep(1000);
                        Console.WriteLine("");
                        Console.WriteLine("");
                        for (int i = 0; i < text2.Length; i++)
                        {
                            Thread.Sleep(30);
                            Console.Write(text2[i]);
                        }
                        Thread.Sleep(500);
                        Console.WriteLine("");
                        for (int i = 0; i < text3.Length; i++)
                        {
                            Thread.Sleep(30);
                            Console.Write(text3[i]);
                        }
                        Thread.Sleep(500);
                        Console.WriteLine("");
                        Console.WriteLine("");
                        for (int i = 0; i < text4.Length; i++)
                        {
                            Thread.Sleep(25);
                            Console.Write(text4[i]);
                        }
                        Console.WriteLine("");
                    }
                    t = false;

                    Console.Write("> ");
                    a = Console.ReadLine();
                    if (!(a == ""))
                    {
                        if (check(a)) { aa = Convert.ToInt32(a); }
                        else {
                            TEXT(text1, text2, text3, text4);
                            Console.WriteLine("Вы ввели не число . . . Повторите попытку .");
                            continue;
                        }
                    }
                    else
                    {
                        TEXT(text1, text2, text3, text4);
                        Console.WriteLine("Вы не ввели число . . . Повторите попытку .");
                        continue;
                    }
                    if (aa < 0 || aa > 1)
                    {
                        TEXT(text1, text2, text3, text4);
                        Console.WriteLine("Вы ввели неверное число . . . Повторите попытку .");
                        continue;
                    }
                    Console.Clear();
                    break;
                }

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("             │   │   ");
                Console.WriteLine("          ───┼───┼───");
                Console.WriteLine("             │   │   ");
                Console.WriteLine("          ───┼───┼───");
                Console.WriteLine("             │   │   ");
                Console.WriteLine("");
                Console.WriteLine("");

                bool one = false;
                while (1 == 1)
                {
                    t = true;
                    if (!player)
                    {
                        if (!one)
                        {
                            Console.WriteLine("Игрок 1 : Выберите клетку [1 - 9]");
                            Console.Write("> ");
                        }
                        one = false;
                        scur = Console.ReadLine();
                        if (!(scur==""))
                        {
                            if(check(scur))
                            {
                                cur = Convert.ToInt32(scur);
                            }
                            else
                            {
                                Console.Clear();
                                if (Map(grid, err)) { err = true; };
                                Console.WriteLine("Игрок 1 : Выберите клетку [1 - 9]");
                                Console.Write("> ");
                                Console.WriteLine("Вы ввели не число . . . Повторите попытку .");
                                one = true;
                                continue;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            if (Map(grid, err)) { err = true; };
                            Console.WriteLine("Игрок 1 : Выберите клетку [1 - 9]");
                            Console.Write("> ");
                            Console.WriteLine("Вы не ввели число . . . Повторите попытку .");
                            one = true;
                            continue;
                        }

                        if (cur < 1 || cur > 9)
                        {
                            Console.Clear();
                            if (Map(grid, err)) { err = true; };
                            Console.WriteLine("Игрок 1 : Выберите клетку [1 - 9]");
                            Console.Write("> ");
                            Console.WriteLine("Вы ввели неверное число . . . Повторите попытку .");
                            one = true;
                            continue;
                        }
                        if (cur == 1) { x = 0; y = 2; }
                        if (cur == 2) { x = 1; y = 2; }
                        if (cur == 3) { x = 2; y = 2; }
                        if (cur == 4) { x = 0; y = 1; }
                        if (cur == 5) { x = 1; y = 1; }
                        if (cur == 6) { x = 2; y = 1; }
                        if (cur == 7) { x = 0; y = 0; }
                        if (cur == 8) { x = 1; y = 0; }
                        if (cur == 9) { x = 2; y = 0; }

                        if (grid[y, x] < 2) {
                            Console.Clear();
                            if (Map(grid, err)) { err = true; };
                            Console.WriteLine("Игрок 1 : Выберите клетку [1 - 9]");
                            Console.Write("> ");
                            Console.WriteLine("Ячейка занята . . . Выберите другую .");
                            one = true;
                            continue;
                        }

                        if (aa == 0) { grid[y, x] = 0; }
                        if (aa == 1) { grid[y, x] = 1; }
                        last = grid[y, x];
                        Console.Clear();
                        if (Map(grid, err)) { err = true; };
                        player = true;
                    }
                    else if (player)
                    {
                        if (!one)
                        {
                            Console.WriteLine("Игрок 2 : Выберите клетку [1 - 9]");
                            Console.Write("> ");
                        }
                        one = false;
                        scur = Console.ReadLine();
                        if (!(scur == ""))
                        {
                            if (check(scur))
                            {
                                cur = Convert.ToInt32(scur);
                            }
                            else
                            {
                                Console.Clear();
                                if (Map(grid, err)) { err = true; };
                                Console.WriteLine("Игрок 2 : Выберите клетку [1 - 9]");
                                Console.Write("> ");
                                Console.WriteLine("Вы ввели не число . . . Повторите попытку .");
                                one = true;
                                continue;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            if (Map(grid, err)) { err = true; };
                            Console.WriteLine("Игрок 2 : Выберите клетку [1 - 9]");
                            Console.Write("> ");
                            Console.WriteLine("Вы не ввели число . . . Повторите попытку .");
                            one = true;
                            continue;
                        }

                        if (cur < 1 || cur > 9)
                        {
                            Console.Clear();
                            if (Map(grid, err)) { err = true; };
                            Console.WriteLine("Игрок 2 : Выберите клетку [1 - 9]");
                            Console.Write("> ");
                            Console.WriteLine("Вы ввели неверное число . . . Повторите попытку .");
                            one = true;
                            continue;
                        }
                        if (cur == 1) { x = 0; y = 2; }
                        if (cur == 2) { x = 1; y = 2; }
                        if (cur == 3) { x = 2; y = 2; }
                        if (cur == 4) { x = 0; y = 1; }
                        if (cur == 5) { x = 1; y = 1; }
                        if (cur == 6) { x = 2; y = 1; }
                        if (cur == 7) { x = 0; y = 0; }
                        if (cur == 8) { x = 1; y = 0; }
                        if (cur == 9) { x = 2; y = 0; }

                        if (grid[y, x] < 2) {
                            Console.Clear();
                            if (Map(grid, err)) { err = true; };
                            Console.WriteLine("Игрок 2 : Выберите клетку [1 - 9]");
                            Console.Write("> ");
                            Console.WriteLine("Ячейка занята . . . Выберите другую .");
                            one = true;
                            continue;
                        }

                        if (aa == 0) { grid[y, x] = 1; }
                        if (aa == 1) { grid[y, x] = 0; }
                        last = grid[y, x];
                        Console.Clear();
                        if (Map(grid, err)) { err = true; };
                        player = false;
                    }

                    ////////////////////////////// [ СВЯЩЕННЫЙ ДВИЖОК ] //////////////////////////////
                    int succ = 1;
                    bool OK = false;
                    for (int yy = 0; yy < 3; yy++)
                    {
                        for (int xx = 0; xx < 3; xx++)
                        {
                            cur = grid[yy, xx];

                            // X .
                            for (int i = 1; i < 3; i++)
                            {
                                if (!((xx - i) < 0))
                                {
                                    if (grid[yy, xx - i] == cur) { succ++; }
                                    else { continue; }
                                }
                                if (!((xx + i) > 2))
                                {
                                    if (grid[yy, xx + i] == cur) { succ++; }
                                    else { continue; }
                                }
                            }
                            if (succ == 3) { OK = true; }
                            succ = 1;

                            // Y .
                            for (int i = 1; i < 3; i++)
                            {
                                if (!((yy - i) < 0))
                                {
                                    if (grid[yy - i, xx] == cur) { succ++; }
                                    else { continue; }
                                }
                                if (!((yy + i) > 2))
                                {
                                    if (grid[yy + i, xx] == cur) { succ++; }
                                    else { continue; }
                                }
                            }
                            if (succ == 3) { OK = true; }
                            succ = 1;

                            // Право верх
                            for (int i = 1; i < 3; i++)
                            {
                                if (!((yy - i) < 0) && !((xx + i) > 2))
                                {
                                    if (grid[yy - i, xx + i] == cur) { succ++; }
                                    else { continue; }
                                }
                                if (!((yy + i) > 2) && !((xx - i) < 0))
                                {
                                    if (grid[yy + i, xx - i] == cur) { succ++; }
                                    else { continue; }
                                }
                            }
                            if (succ == 3) { OK = true; }
                            succ = 1;

                            // Лево верх
                            for (int i = 1; i < 3; i++)
                            {
                                if (!((yy - i) < 0) && !((xx - i) < 0))
                                {
                                    if (grid[yy - i, xx - i] == cur) { succ++; }
                                    else { continue; }
                                }
                                if (!((yy + i) > 2) && !((xx + i) > 2))
                                {
                                    if (grid[yy + i, xx + i] == cur) { succ++; }
                                    else { continue; }
                                }
                            }
                            if (succ == 3) { OK = true; }
                            succ = 1;
                        }
                    }
                    ////////////////////////////// [ СВЯЩЕННЫЙ ДВИЖОК ] //////////////////////////////

                    if (OK)
                    {
                        if (last == 0)
                        {
                            if (aa == 1)
                            {
                                Console.WriteLine("       --=={ ПОБЕДА }==--");
                                Console.WriteLine("");
                                Console.WriteLine("       Победил игрок номер 2 !");
                                Console.WriteLine("");
                                Console.WriteLine("       --=={ +-  -+ }==--");
                            }
                            else if (aa == 0)
                            {
                                Console.WriteLine("       --=={ ПОБЕДА }==--");
                                Console.WriteLine("");
                                Console.WriteLine("       Победил игрок номер 1 !");
                                Console.WriteLine("");
                                Console.WriteLine("       --=={ +-  -+ }==--");
                            }
                            else
                            {
                                Console.WriteLine("       --=={ ПОБЕДА }==--");
                                Console.WriteLine("");
                                Console.WriteLine("       Победил ... разработчик !");
                                Console.WriteLine("");
                                Console.WriteLine("       --=={ +-  -+ }==--");
                            }
                        }
                        else if (last == 1)
                        {
                            if (aa == 1)
                            {
                                Console.WriteLine("       --=={ ПОБЕДА }==--");
                                Console.WriteLine("");
                                Console.WriteLine("       Победил игрок номер 1 !");
                                Console.WriteLine("");
                                Console.WriteLine("       --=={ +-  -+ }==--");
                            }
                            else if (aa == 0)
                            {
                                Console.WriteLine("       --=={ ПОБЕДА }==--");
                                Console.WriteLine("");
                                Console.WriteLine("       Победил игрок номер 2 !");
                                Console.WriteLine("");
                                Console.WriteLine("       --=={ +-  -+ }==--");
                            }
                            else
                            {
                                Console.WriteLine("       --=={ ПОБЕДА }==--");
                                Console.WriteLine("");
                                Console.WriteLine("       Победил ... разработчик !");
                                Console.WriteLine("");
                                Console.WriteLine("       --=={ +-  -+ }==--");
                            }
                        }
                        else
                        {
                            Console.WriteLine("       --=={ ?????? }==--");
                            Console.WriteLine("");
                            Console.WriteLine("       " + last + " ПРОИЗОШЁЛ ВТФ !");
                            Console.WriteLine("");
                            Console.WriteLine("       --=={ +-  -+ }==--");
                        }
                        string test = Console.ReadLine(); break;
                    }
                    if (err)
                    {
                        err = false;
                        Console.WriteLine("       --=={ НИЧЬЯ. }==--");
                        Console.WriteLine("");
                        Console.WriteLine("       Победил ... никто !");
                        Console.WriteLine("");
                        Console.WriteLine("       --=={ +-  -+ }==--");
                        string test3 = Console.ReadLine(); break;
                    }
                }
            }
        }

        public static bool Map(int[,] g, bool e)
        {
            e = true;
            bool one = false;
            for (int i = 0; i < 3; i++)
            {
                if(!one) { Console.WriteLine(""); Console.WriteLine(""); one = true; }
                for (int j = 0; j < 3; j++)
                {
                    if (g[i, j] == 0)
                    {
                        if (j == 0) { Console.Write("          "); }
                        if (j != 2) { Console.Write(" O │"); }
                        else { Console.Write(" O"); }
                    }
                    else if (g[i, j] == 1)
                    {
                        if (j == 0) { Console.Write("          "); }
                        if (j != 2) { Console.Write(" X │"); }
                        else { Console.Write(" X"); }
                    }
                    else
                    {
                        if (j == 0) { Console.Write("          "); }
                        if (j != 2) { Console.Write("   │"); }
                        else { Console.Write("  "); }
                        e = false;
                    }
                }
                if (i != 2)
                {
                    Console.WriteLine("");
                    Console.WriteLine("          ───┼───┼───");
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
            }
            if (e) { return true; }
            return false;
        }
        public static bool check (string s)
        {
            Regex regex = new Regex(@"[0-9]");
            MatchCollection matches = regex.Matches(s);
            if (matches.Count > 0) { return true; }
            return false;
        }
        private static void TEXT (string t1, string t2, string t3, string t4)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.Write("                ");
            Console.Write(t1);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write(t2);
            Console.WriteLine("");
            Console.Write(t3);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write(t4);
            Console.WriteLine("");
            Console.Write("> ");
        }
    }
}
