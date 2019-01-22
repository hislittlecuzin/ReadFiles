using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hello_World
{
    class Foo {
        int a, b, c = -1;
        public Foo() {

        }

        public void WhileLoop(int[] newi) {

        }

        public void SetA(int newi) {
            a = newi;
        }
        public void SetB(int newi) {
            b= newi;
        }
        public void SetC(int newi) {
            c= newi;
        }
        public void GetAll() {
            Console.WriteLine("{0}{1}{2}", (char)a, (char)b, (char)c);
        }
    }

    class Program
    {
        static string file = "**FilePath**/Test.txt";
        static bool running = true;

        static int spot = 0;

        static int[] coordinate = new int[] { 0, 0 };

        static Foo[,] bar = InitializeArray<Foo>(2, 2); //new Foo[2,2];

        static void Main(string[] args)
        {
            char currentCharacter;
            coordinate[0] = 0;
            coordinate[1] = 0;

            Thread thread = new Thread(Escape);
            thread.Start();

            StreamReader sr = new StreamReader(file);

            while (running)
            {
                if (!sr.EndOfStream)
                {
                    try
                    {
                        currentCharacter = (char)sr.Read();
                        Console.Write(currentCharacter);
                        Interpret(currentCharacter);
                    }
                    catch (Exception e) {
                        Console.Write(e);
                        running = false;
                    }

                }










            }
            Console.WriteLine("Press enter to close");
            Console.ReadKey();
        }

        static void Interpret(char currentCharacter)
        {
            if (currentCharacter == '\r')
                return;
            if (currentCharacter == '\n')
            {
                coordinate[1] = 0; //x for map
                //Console.Write(coordinate[0]);
                coordinate[0]++; // y for map
                return;
            }
            if (currentCharacter == ';')
            {
                
                spot = 0; // coordinate attribute. Goes up to 2 (3 total spots per coordinate.) 
                coordinate[1]++; //x for map
            }
            else
            {
                switch (spot)
                {
                    case 0:
                        bar[coordinate[0], coordinate[1]].SetA((int)currentCharacter);
                        break;
                    case 1:
                        bar[coordinate[0], coordinate[1]].SetB((int)currentCharacter);
                        break;
                    case 2:
                        bar[coordinate[0], coordinate[1]].SetC((int)currentCharacter);
                        break;
                }
                spot++;

            }

        }

        static T[,] InitializeArray<T>(int length, int width) where T : new()
        {
            T[,] array = new T[length, width];

            for (int i = 0; i < length; ++i)
            {
                for (int j = 0; j < width; ++j)
                    array[i, j] = new T();
            }

            return array;
        }

        static void Escape()
        {
            string input;
            //Console.WriteLine("\nThread\n");
            while (running)
            {
                input = Console.ReadLine();
                if (input == "exit")
                {
                    running = false;
                }
                if (Convert.ToInt32(input) == 1)
                {
                    bar[0, 0].GetAll();
                }
                if (Convert.ToInt32(input) == 2)
                {
                    bar[0, 1].GetAll();
                }
                if (Convert.ToInt32(input) == 3)
                {
                    bar[1, 0].GetAll();
                }
                if (Convert.ToInt32(input) == 4)
                {
                    bar[1, 1].GetAll();
                }
            }
        }
    }
}
