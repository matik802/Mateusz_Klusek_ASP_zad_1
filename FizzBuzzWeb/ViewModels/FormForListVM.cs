using System.ComponentModel.DataAnnotations;

namespace FizzBuzzWeb.ViewModels
{
    public class FormForListVM
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string? Name { get; set; }
        public string? Result { get; set; }
        public DateTime Created { get; set; }
    }
}
