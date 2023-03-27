using System.ComponentModel.DataAnnotations;

namespace FizzBuzzWeb.Forms
{
	public class Form
	{
		[Required(ErrorMessage = "Pole {0} jest wymagane.")]
		[Range(1899,2022,ErrorMessage = "Wartosc {0} nie miesci sie w przedziale od {1} do {2}.")]
		public int Year { get; set; }
		[Required(ErrorMessage = "Pole {0} jest wymagane.")]
		[StringLength(100, ErrorMessage = "Dlugosc {0} nie moze przekroczyc 100 znakow.")]
		public string Name { get; set; }
	}
}
