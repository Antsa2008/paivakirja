using System;
using System.Collections.Generic;

// Luokka yksittäiselle päiväkirjamerkinnälle
class Entry
{
    // Merkinnän tunniste
    public int Id { get; set; }

    // Merkinnän teksti
    public string Text{ get; set; }

    // Päivämäärä jolloin merkintä luotiin
    public DateTime Date { get; set; }
}

class Program
{
    // Lista johon kaikki merkinnät tallennetaan
    static List<Entry> entries = new List<Entry>();

    // Seuraava vapaa ID merkinnälle
    static int nextId = 1;

    static void Main(string[] args)
    {
        // Pääsilmukka pitää ohjelman käynnissä
        while (true)
        {
            // Tulostetaan päävalikko
            Console.WriteLine("\n--- PäiväKirja ---");
            Console.WriteLine("1. Lisää merkintä");
            Console.WriteLine("2. Näytä merkinnät");
            Console.WriteLine("3. Muokkaa merkintää");
            Console.WriteLine("4. Poista merkintä");
            Console.WriteLine("5. Poistu");

            // Luetaan käyttäjän valinta
            Console.Write("Valinta: ");
            string choice = Console.ReadLine();

            // Tarkistetaan käyttäjän valinta
            switch (choice)
            {
                case "1":
                    AddEntry(); // Lisää uusi merkintä
                    break;

                case "2":
                    ShowEntries(); // Näyttää kaikki merkinnät
                    break;

                case "3":
                    EditEntry(); // Muokkaa merkintää
                    break;

                case "4":
                    DeleteEntry(); // Poistaa merkinnän
                    break;

                case "5":
                    return; // Lopettaa ohjelman

                default:
                    Console.WriteLine("Virheellinen valinta.");
                    break;
            }
        }
    }

    // Lisää uuden päiväkirjamerkinnän
    static void AddEntry()
    {
        Console.Write("Kirjoita merkintä: ");
        string text = Console.ReadLine();

        // Lisätään uusi merkintä listaan
        entries.Add(new Entry
        {
            Id = nextId++,
            Text = text,
            Date = DateTime.Now
        });

        Console.WriteLine("Merkintä lisätty.");
    }

    // Näyttää kaikki merkinnät
    static void ShowEntries()
    {
        // Tarkistetaan onko merkintöjä
        if (entries.Count == 0)
        {
            Console.WriteLine("Ei merkintöjä.");
            return;
        }

        // Käydään kaikki merkinnät läpi
        foreach (var entry in entries)
        {
            Console.WriteLine($"ID: {entry.Id} | {entry.Date}");
            Console.WriteLine(entry.Text);
            Console.WriteLine("------------------");
        }
    }

    // Muokkaa olemassa olevaa merkintää
    static void EditEntry()
    {
        Console.Write("Anna muokattavan merkinnän ID: ");
        int id = int.Parse(Console.ReadLine());

        // Etsitään merkintä ID:n perusteella
        var entry = entries.Find(e => e.Id == id);

        // Tarkistetaan löytyikö merkintä
        if (entry == null)
        {
            Console.WriteLine("Merkintää ei löytynyt.");
            return;
        }

        Console.Write("Uusi teksti: ");
        entry.Text = Console.ReadLine();

        Console.WriteLine("Merkintä päivitetty.");
    }

    // Poistaa merkinnän listasta
    static void DeleteEntry()
    {
        Console.Write("Anna poistettavan merkinnän ID: ");
        int id = int.Parse(Console.ReadLine());

        // Etsitään poistettava merkintä
        var entry = entries.Find(e => e.Id == id);

        // Tarkistetaan löytyikö merkintä
        if (entry == null)
        {
            Console.WriteLine("Merkintää ei löytynyt.");
            return;
        }

        // Poistetaan merkintä listasta
        entries.Remove(entry);

        Console.WriteLine("Merkintä poistettu.");
    }
}