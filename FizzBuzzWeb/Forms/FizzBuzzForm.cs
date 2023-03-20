﻿using System.ComponentModel.DataAnnotations;

namespace FizzBuzzWeb.Forms
{
    public class FizzBuzzForm
    {
        [Display(Name = "Twoj szczesliwy numerek")]
        [Required, Range(1, 1000, ErrorMessage = "Oczekiwana wartosc {0} z zakresu {1} i {2}.")]
        public int? Number { get; set; }
    }
}
