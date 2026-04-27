using System;
using System.Collections.Generic;

class Entry
{
    public int Id { get; set; }
    public string Text{ get; set; }
    public DateTime Date { get; set; }
}

class Program
{
    static List <Entry> entries = new List<Entry>();
    static int nextId = 1;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- PäiväKirja ---");
            Console.WriteLine("1. Lisää merkintä");
            Console.WriteLine("2. Näytä merkinnät");
            Console.WriteLine("3. Muokkaa merkintää");
            Console.WriteLine("4. Poista merkintä");
            Console.WriteLine("5. Poistu");

            Console.Write("Valinta: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEntry();
                    break;
                case "2":
                    ShowEntries();
                    break;
                case "3":
                    EditEntry();
                    break;
                case "4":
                    DeleteEntry();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Virheellinen valinta.");
                    break;
            }
        }
    }
