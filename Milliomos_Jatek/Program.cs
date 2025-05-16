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
		static void Main(string[] args)
		{
			Beolvasas();
            int[] nyeremenyek = { 10000, 20000, 50000, 100000, 250000, 500000, 750000, 1000000, 1500000, 2000000, 5000000, 10000000, 25000000, 50000000 };
            int[] garantaltSzintek = { 4, 9, 14 };
            Console.WriteLine("Üdvözlöm a kedves versenyzőt a 'legyen ön is milliomos' játékban!");

            var sorkerdes = sorkerdesek[new Random().Next(sorkerdesek.Count)];
            Console.WriteLine("\nSorkérdés:");
            Console.WriteLine(sorkerdes.SorQuestion);
            for (int i = 0; i < 4; i++)
                Console.WriteLine($"{(char)('A' + i)}: {sorkerdes.SorValasz[i]}");

            //Console.WriteLine(sorkerdes.HelyesSorValasz);
            Console.Write("Válasz: ");
            string valasz = Console.ReadLine().ToUpper();

            if (valasz != sorkerdes.HelyesSorValasz.ToUpper())
            {
                Console.WriteLine("Sajnos ez a válasz helytelen, emiatt vége a játéknak (még el se kezdődött mondjuk).");
                return;
            }

            Console.WriteLine("Helyes a sorrend!!!!! Kezdődhet a játék!!!!!");
        }
    }
}
