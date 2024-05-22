using System;
using System.ComponentModel.DataAnnotations;

namespace PiggaProject.ViewModels
{
	public class RegisterVm
	{
        [MinLength(3)]
        [MaxLength(10)]
		public string Name { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}

