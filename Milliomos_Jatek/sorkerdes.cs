using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milliomos_Jatek
{
	internal class Sorkerdes
	{
		string sorQuestion;
		string[] sorValasz;
		string helyesSorValasz;
		string sorKategoria;

		public Sorkerdes(string sorQuestion, string[] sorValasz, string helyesSorValasz, string sorKategoria)
		{
			this.sorQuestion = sorQuestion;
			this.sorValasz = sorValasz;
			this.helyesSorValasz = helyesSorValasz;
			this.sorKategoria = sorKategoria;
		}

		public string SorQuestion { get => sorQuestion; set => sorQuestion = value; }
		public string[] SorValasz { get => sorValasz; set => sorValasz = value; }
		public string HelyesSorValasz { get => helyesSorValasz; set => helyesSorValasz = value; }
		public string SorKategoria { get => sorKategoria; set => sorKategoria = value; }

		//public override string? ToString()
		//{
		//	return $"{sorQuestion}, {sorValasz}, {helyesSorValasz}, {sorKategoria}";
		//}
	}
}
