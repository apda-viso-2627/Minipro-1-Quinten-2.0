string[] namen = { "Basis", "Plus", "Premium", "Deluxe" }; // Array met de namen van de programma's
decimal[] prijzen = { 8m, 12m, 17m, 24m }; // Array met de prijzen van de programma's
int[] duren = { 5, 8, 12, 18 }; // Array met de duurtijden in minuten

int[] aantalBeurten = new int[4]; // Bewaart hoeveel keer elk programma gekozen werd
int abonnementBeurten = 0; // Telt het aantal beurten via abonnement
decimal omzet = 0; // Bewaart de totale omzet
int klantenkaart = 0; // Telt het aantal gespaarde beurten op de klantenkaart

int keuze; // Variabele voor de menukeuze

do // Start van de herhalingslus
{
    Console.ForegroundColor = ConsoleColor.Cyan; // Zet de tekstkleur op cyaan

    Console.WriteLine("\n===== CARWASH ====="); // Toon de titel
    Console.WriteLine("1. Wasbeurt registreren"); // Toon optie 1
    Console.WriteLine("2. Programma's en prijzen"); // Toon optie 2
    Console.WriteLine("3. Abonnement berekenen"); // Toon optie 3
    Console.WriteLine("4. Dagrapport"); // Toon optie 4
    Console.WriteLine("0. Sluiten"); // Toon optie 0

    Console.ResetColor(); // Zet de kleur terug standaard

    while (!int.TryParse(Console.ReadLine(), out keuze)) // Controleert of de invoer een geldig getal is
    {
        Console.Write("Geef een geldig getal in: "); // Vraag opnieuw om een getal
    }

    switch (keuze) // Voer de juiste optie uit
    {
        case 1: // Wasbeurt registreren

            int programma; // Variabele voor het programma

            do // Herhaal tot een geldig programma gekozen wordt
            {
                Console.Write("Programma (1-4): "); // Vraag een programma
            }
            while (!int.TryParse(Console.ReadLine(), out programma) || programma < 1 || programma > 4); // Controle op geldige invoer

            int nummerplaat; // Variabele voor het nummerplaatnummer

            do // Herhaal tot een geldige nummerplaat ingegeven wordt
            {
                Console.Write("Nummerplaatnummer (1-999): "); // Vraag een nummerplaatnummer
            }
            while (!int.TryParse(Console.ReadLine(), out nummerplaat) || nummerplaat < 1 || nummerplaat > 999); // Controle op geldige invoer

            Console.Write("Abonnement? (j/n): "); // Vraag of de klant een abonnement heeft
            string abonnement = Console.ReadLine() ?? ""; // Lees het antwoord in

            Console.WriteLine($"Programma: {namen[programma - 1]}"); // Toon het gekozen programma

            if (abonnement.ToLower() == "j") // Controleer of de klant een abonnement heeft
            {
                Console.ForegroundColor = ConsoleColor.Green; // Zet tekstkleur op groen
                Console.WriteLine("Geen betaling"); // Toon melding
                Console.ResetColor(); // Zet kleur terug standaard
                abonnementBeurten++; // Verhoog teller abonnementbeurten
            }
            else // Klant heeft geen abonnement
            {
                decimal prijs = prijzen[programma - 1]; // Bewaar de prijs van het gekozen programma

                klantenkaart++; // Verhoog de teller van de klantenkaart

                if (klantenkaart == 10) // Controleer of er 10 beurten gespaard zijn
                {
                    prijs = prijs / 2; // Geef 50% korting

                    Console.ForegroundColor = ConsoleColor.Green; // Zet tekstkleur op groen
                    Console.WriteLine("KLANTENKAART!"); // Toon melding
                    Console.WriteLine("50% korting op deze wasbeurt."); // Toon korting
                    Console.ResetColor(); // Zet kleur terug standaard

                    klantenkaart = 0; // Zet de klantenkaart terug op nul
                }

                Console.WriteLine($"Te betalen: {prijs:F2} EUR"); // Toon het bedrag dat betaald moet worden

                omzet += prijs; // Voeg de prijs toe aan de omzet
            }

            Console.WriteLine($"Duur: {duren[programma - 1]} minuten"); // Toon de duurtijd van het programma

            aantalBeurten[programma - 1]++; // Verhoog de teller van het gekozen programma

            break; // Verlaat deze case

            // enzovoort...
    }

} while (keuze != 0); // Blijf herhalen tot de gebruiker 0 kiest