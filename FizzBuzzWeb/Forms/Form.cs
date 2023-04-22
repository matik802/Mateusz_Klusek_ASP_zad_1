using System.ComponentModel.DataAnnotations;

namespace FizzBuzzWeb.Forms
{
	public class Form
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Pole {0} jest wymagane.")]
		[Range(1899,2022,ErrorMessage = "Wartosc {0} nie miesci sie w przedziale od {1} do {2}.")]
		[RegularExpression(@"^[0-9]*$", ErrorMessage ="W pole {0} przyjmuje wartosci liczbowe naturalne.")]
		public int Year { get; set; }
		//[Required(ErrorMessage = "Pole {0} jest wymagane.")]
		[StringLength(100, ErrorMessage = "Dlugosc {0} nie moze przekroczyc 100 znakow.")]
		public string? Name { get; set; }
	}
}
