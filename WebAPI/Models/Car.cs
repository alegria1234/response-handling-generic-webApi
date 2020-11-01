using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Car
    {
        [Required(ErrorMessage = "Required Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required Brand")]
        public string Brand { get; set; }

        public decimal Price { get; set; }
    }
}