namespace Milliomos_Jatek
{
	internal class Program
	{
		static void Beolvasas()
		{
			string kerdesek = File.ReadAllText("kerdes.txt");
			string[] kerdesekElvalasztva = kerdesek.Split('\n');
            string sorKerdesek = File.ReadAllText("sorkerdes.txt");
            string[] sorKerdesekElvalasztva = sorKerdesek.Split('\n');

            for (int i = 0; i <kerdesek.Length; i++)
            {
				string[] szavak = kerdesekElvalasztva[i].Split(';');
				int kodszam = int.Parse(szavak[0]);
				string question = szavak[1];
				string[] valasz = { szavak[2], szavak[3], szavak[4], szavak[5] };
				string helyes_valasz = szavak[6];
				string kategoria = szavak[7];

				Kerdes kerdes = new Kerdes(kodszam, question, valasz, helyes_valasz, kategoria);
            }

            for (int i = 0; i < sorKerdesek.Length; i++)
            {
                string[] szavak = sorKerdesekElvalasztva[i].Split(';');
                string sorQuestion = szavak[0];
                string[] sorValasz = { szavak[1], szavak[2], szavak[3], szavak[4] };
                string helyesSorValasz = szavak[5];
                string sorKategoria = szavak[6];

                Sorkerdes kerdes = new Sorkerdes( sorQuestion, sorValasz, helyesSorValasz, sorKategoria);
            }
        }
		static void Main(string[] args)
		{
			Beolvasas();
		}
	}
}
