using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milliomos_Jatek
{
	internal class Kerdes
	{
		List<string> valasz;
		string helyes_valasz;
		string kategoria;

		public Kerdes(List<string> valasz, string helyes_valasz, string kategoria)
		{
			this.valasz = valasz;
			this.helyes_valasz = helyes_valasz;
			this.kategoria = kategoria;
		}

		public List<string> Valasz { get => valasz; set => valasz = value; }
		public string Helyes_valasz { get => helyes_valasz; set => helyes_valasz = value; }
		public string Kategoria { get => kategoria; set => kategoria = value; }

		//public override string? ToString()
		//{
		//	return $"{valasz}, {helyes_valasz}, {kategoria}";
		//}
	}
}
