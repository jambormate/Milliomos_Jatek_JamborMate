namespace Milliomos_Jatek
{
    internal class Program
    {
        static List<Kerdes> kerdesek = new List<Kerdes>();
        static List<Sorkerdes> sorkerdesek = new List<Sorkerdes>();
        static void Beolvasas()
        { 
            string[] kerdesekElvalasztva = File.ReadAllLines("kerdes.txt");
            foreach (var sor in kerdesekElvalasztva)
            {
                string[] szavak = sor.Trim().Split(';');
                int kodszam = int.Parse(szavak[0]);
                string question = szavak[1];
                string[] valasz = { szavak[2], szavak[3], szavak[4], szavak[5] };
                string helyes_valasz = szavak[6];
                string kategoria = szavak[7];

                Kerdes kerdes = new Kerdes(kodszam, question, valasz, helyes_valasz, kategoria);
                kerdesek.Add(kerdes);
            }

            string[] sorKerdesekElvalasztva = File.ReadAllLines("sorkerdes.txt");
            foreach (var sor in sorKerdesekElvalasztva)
            {
                string[] szavak = sor.Trim().Split(';');
                string sorQuestion = szavak[0];
                string[] sorValasz = { szavak[1], szavak[2], szavak[3], szavak[4] };
                string helyesSorValasz = szavak[5];
                string sorKategoria = szavak[6];

                Sorkerdes kerdes = new Sorkerdes(sorQuestion, sorValasz, helyesSorValasz, sorKategoria);
                sorkerdesek.Add(kerdes);
            }
        }
        static void Jatek()
        {
            int[] nyeremenyek = { 5000, 10000, 20000, 50000, 100000, 250000, 500000, 750000, 1000000, 1500000, 2000000, 5000000, 10000000, 25000000, 50000000 };
            int[] garantaltSzintek = { 5, 10, 15 };
            int aktualisSzint = 1;
            int elertOsszeg = 0;
            int kozonseg = 1;
            int telefon = 1;
            int felezo = 1;

            Random rnd = new Random();
            int telerand = rnd.Next(1, 101);
            while (aktualisSzint <= nyeremenyek.Length)
            {
                var szintKerdesek = kerdesek.Where(k => k.Kodszam == aktualisSzint).ToList();
                var kerdes = szintKerdesek[rnd.Next(szintKerdesek.Count)];

                Console.WriteLine($"\nKérdés {aktualisSzint}: {kerdes.Question}");
                for (int i = 0; i < 4; i++)
                    Console.WriteLine($"{(char)('A' + i)}: {kerdes.Valasz[i]}");

                Console.WriteLine(kerdes.Helyes_valasz);

                Console.Write("Válasz: ");
                string valasz = Console.ReadLine().ToUpper();

                if (valasz == "KOZONSEG" && kozonseg == 1)
                {
                    kozonseg = 0;
                    int helyesAlap = 20;
                    int maradek = 100 - helyesAlap;
                    int a = rnd.Next(0, maradek + 1);
                    int b = rnd.Next(0, maradek - a + 1);
                    int c = rnd.Next(0, maradek - a - b + 1);
                    int d = maradek - a - b - c;
                    List<int> extra = new List<int> { a, b, c, d }.OrderBy(x => rnd.Next()).ToList();
                    Console.WriteLine("A közönség ezt gondolja:");
                    for (int i = 0; i < 4; i++)
                    {
                        char betu = (char)('A' + i);
                        int ossz = extra[i];
                        if (betu == kerdes.Helyes_valasz.ToUpper()[0])
                            ossz += helyesAlap;
                        Console.WriteLine($"{betu} - {ossz}%");
                    }
                    Console.Write("Válasz: ");
                    valasz = Console.ReadLine().ToUpper();
                }
                if (valasz == "KOZONSEG" && kozonseg == 0)
                {
                    Console.WriteLine($"A közönseg már nem elérhető");
                    Console.Write("Válasz: ");
                    valasz = Console.ReadLine().ToUpper();
                }
                if (valasz == "TELEFON" && telefon == 1)
                {
                    telefon = 0;
                    if (telerand >= 55)
                    {
                        Console.WriteLine($"Szia én azt gondolom hogy a {kerdes.Helyes_valasz} a jó");
                    }
                    else
                    {
                        List<char> valaszok = new List<char> { 'A', 'B', 'C', 'D' };
                        valaszok.Remove(kerdes.Helyes_valasz.ToUpper()[0]);
                        char rossz = valaszok[rnd.Next(valaszok.Count)];
                        Console.WriteLine($"Szia szerintem a {rossz} a jó válasz");
                    }
                    Console.Write("Válasz: ");
                    valasz = Console.ReadLine().ToUpper();
                }
                if (valasz == "TELEFON" && telefon == 0)
                {
                    Console.WriteLine($"A telefon már nem elérhető");
                    Console.Write("Válasz: ");
                    valasz = Console.ReadLine().ToUpper();
                }
                if (valasz == "FELEZO" && felezo == 1)
                {
                    felezo = 0;
                    List<int> rosszValaszok = new List<int>();
                    for (int i = 0; i < 4; i++)
                    {
                        if ((char)('A' + i) != kerdes.Helyes_valasz.ToUpper()[0])
                        {
                            rosszValaszok.Add(i);
                        }
                    }
                    var kiejtettIndexek = rosszValaszok.OrderBy(x => rnd.Next()).Take(2).ToList();
                    Console.WriteLine("Felező segítség:");
                    for (int i = 0; i < 4; i++)
                    {
                        if (!kiejtettIndexek.Contains(i))
                        {
                            Console.WriteLine($"{(char)('A' + i)}: {kerdes.Valasz[i]}");
                        }
                    }
                    Console.Write("Válasz: ");
                    valasz = Console.ReadLine().ToUpper();
                }
                if (valasz == "FELEZO" && felezo == 0)
                {
                    Console.WriteLine($"A felezo már nem elérhető");
                    Console.Write("Válasz: ");
                    valasz = Console.ReadLine().ToUpper();
                }
                if (valasz != kerdes.Helyes_valasz.ToUpper())
                {
                    Console.WriteLine("Sajnos hibás válasz, vége a játéknak.");

                    int garantaltOsszeg = 0;
                    foreach (var szint in garantaltSzintek)
                    {
                        if (aktualisSzint > szint)
                            garantaltOsszeg = nyeremenyek[szint - 1];
                    }
                    Console.WriteLine($"Elért nyereményed: {garantaltOsszeg} Ft");
                    return;
                }
                elertOsszeg = nyeremenyek[aktualisSzint - 1];
                Console.WriteLine($"Helyes válasz! Jutalmad: {elertOsszeg} Ft");
                aktualisSzint++;
            }
            Console.WriteLine("\nGratulálok! Megnyerted a játékot! Maga Milliomos lett!!!!!");
            Console.WriteLine($"Összes nyereményed: {elertOsszeg} Ft");
        }
        static void Main(string[] args)
        {
            Beolvasas();
            Console.WriteLine("Üdvözlöm a kedves versenyzőt a 'legyen ön is milliomos' játékban!");
            var sorkerdes = sorkerdesek[new Random().Next(sorkerdesek.Count)];
            Console.WriteLine("\nSorkérdés:");
            Console.WriteLine(sorkerdes.SorQuestion);
            for (int i = 0; i < 4; i++)
                Console.WriteLine($"{(char)('A' + i)}: {sorkerdes.SorValasz[i]}");
            Console.WriteLine(sorkerdes.HelyesSorValasz);
            Console.Write("Válasz: ");
            string valasz = Console.ReadLine().ToUpper();

            if (valasz != sorkerdes.HelyesSorValasz.ToUpper())
            {
                Console.WriteLine("Sajnos ez a válasz helytelen, emiatt vége a játéknak (még el se kezdődött mondjuk).");
                return;
            }
            Console.WriteLine("Helyes a sorrend!!!!! Kezdődhet a játék!!!!!");
            Jatek();
        }
    }
}
