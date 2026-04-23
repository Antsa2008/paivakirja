using System;
using System.Collections.Generic;

class Entry
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
}

class Program
{
    static List<Entry> entries = new List<Entry>();
    static int nextId = 1;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- Päiväkirja ---");
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
                    Console.WriteLine("Virheellinen valinta!");
                    break;
            }
        }
    }

    static void AddEntry()
    {
        Console.Write("Kirjoita merkintä: ");
        string text = Console.ReadLine();

        entries.Add(new Entry
        {
            Id = nextId++,
            Text = text,
            Date = DateTime.Now
        });

        Console.WriteLine("Merkintä lisätty!");
    }

    static void ShowEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("Ei merkintöjä.");
            return;
        }

        foreach (var entry in entries)
        {
            Console.WriteLine($"ID: {entry.Id} | {entry.Date}");
            Console.WriteLine(entry.Text);
            Console.WriteLine("------------------");
        }
    }

    static void EditEntry()
    {
        Console.Write("Anna muokattavan merkinnän ID: ");
        int id = int.Parse(Console.ReadLine());

        var entry = entries.Find(e => e.Id == id);

        if (entry == null)
        {
            Console.WriteLine("Merkintää ei löytynyt.");
            return;
        }

        Console.Write("Uusi teksti: ");
        entry.Text = Console.ReadLine();

        Console.WriteLine("Merkintä päivitetty.");
    }

    static void DeleteEntry()
    {
        Console.Write("Anna poistettavan merkinnän ID: ");
        int id = int.Parse(Console.ReadLine());

        var entry = entries.Find(e => e.Id == id);

        if (entry == null)
        {
            Console.WriteLine("Merkintää ei löytynyt.");
            return;
        }

        entries.Remove(entry);
        Console.WriteLine("Merkintä poistettu.");
    }
}