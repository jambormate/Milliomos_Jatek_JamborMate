using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milliomos_Jatek
{
	internal class Kerdes
	{
		int kodszam;
		string question;
		string[] valasz;
		string helyes_valasz;
		string kategoria;

		public Kerdes(int kodszam, string question, string[] valasz, string helyes_valasz, string kategoria)
		{
			this.kodszam = kodszam;
			this.question = question;
			this.valasz = valasz;
			this.helyes_valasz = helyes_valasz;
			this.kategoria = kategoria;
		}

		public int Kodszam { get => kodszam; set => kodszam = value; }
		public string Question { get => question; set => question = value; }
		public string[] Valasz { get => valasz; set => valasz = value; }
		public string Helyes_valasz { get => helyes_valasz; set => helyes_valasz = value; }
		public string Kategoria { get => kategoria; set => kategoria = value; }

		//static void Main(string[] args)
		//{
		//	string[] valaszok = [];

		//	Beolvasas("kerdes.txt", valaszok);

		//	foreach (var item in valaszok)
		//	{
		//		Console.WriteLine(item);
		//	}
		//}

		//static void Beolvasas(string filenev, string[] valaszok)
		//{
		//	StreamReader sr = new StreamReader(filenev);

		//	while (!sr.EndOfStream)
		//	{
		//		string sor = sr.ReadLine();
		//		string[] szavak = sor.Split(';');
				
		//	}
		//}
		//van egy sejtésem hogy ez nem működik

		//public override string? ToString()
		//{
		//	return $"{kodszam}, {question}, {valasz}, {helyes_valasz}, {kategoria}";
		//}
	}
}
