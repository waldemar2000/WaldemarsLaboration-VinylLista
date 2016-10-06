using System;
using System.Collections.Generic;
using System.IO;

namespace VinylRegister
{
    class Program
    {

        static List<string> vinylistArray = new List<string>();
        public static string albumVariabel;
        public static string artistVariable;
        public static string yearVariabel;

        static void Main(string[] args)
        {

            ReadFromFile("textFil.txt");
            do
            {
                Console.Clear();
                ShowStartMenu();
            } while (true);
        }
        static void ShowStartMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option");
            Console.WriteLine(" 1 - Visa vinyllista");
            Console.WriteLine(" 2 - Lägg till vinyl");
            Console.WriteLine(" 3 - Ta bort en vinyl från listan");
            Console.WriteLine(" 4 - Avsluta programmet");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1": ShowVinylList(); Pause(); break;
                case "2": AddVinyl(); Pause(); break;
                case "3": RemoveVinyl(); Pause(); break;
                case "4": Environment.Exit(0); break;
            }
        }
        static void ShowVinylList()
        {
            Console.Clear();
            for (int i = 0; i < vinylistArray.Count; i++)
            {
                Console.WriteLine("Rad " + (i + 1) + "   -   " + vinylistArray[i]);

            }
        }
        static void AddVinyl()
        {
            Console.Clear();
            Console.WriteLine("Skriv in Artistnamnet");
            artistVariable = Console.ReadLine();
            Console.WriteLine("Skriv in albumnamnet:");
            albumVariabel = Console.ReadLine();
             Console.WriteLine("Skriv in utgivningsår:");
            yearVariabel = Console.ReadLine();

            vinylistArray.Add( artistVariable + "-" + albumVariabel + "-" + yearVariabel);
            File.WriteAllLines("textFil.txt", vinylistArray);

        }

        //Metod som läser in text från en fil.
        static void ReadFromFile(string fil)
        {
            string[] textFil = File.ReadAllLines("textFil.txt");
            vinylistArray.Clear();
            foreach (string item in textFil)
            {
                vinylistArray.Add(item);
            }
        }

        static void Pause()
        {
            Console.WriteLine("Tryck enter");
            Console.ReadLine();

        }

        static void RemoveVinyl()
        {
            int num2 = 0;

            Console.Clear();
            ShowVinylList();
            Console.WriteLine("Vilken rad vill du ta bort?");
            string input = Console.ReadLine();

            int.TryParse(input, out num2);

            vinylistArray.RemoveAt(num2 - 1);
            File.WriteAllLines("textFil.txt", vinylistArray);

        }
    }

}


