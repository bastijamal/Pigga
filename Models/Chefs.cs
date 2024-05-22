using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PiggaProject.Models
{
	public class Chefs
	{

		public int Id { get; set; }
        [MinLength(3)]
        public string FullName { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        public string Description { get; set; }

        public string? PhotoUrl { get; set; }

        [NotMapped]
        public IFormFile ImgFiel { get; set; }
    }


}

