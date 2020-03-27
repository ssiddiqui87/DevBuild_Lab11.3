using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class Register
    {
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private string gender;
        private string subscribe;


        [DisplayName("First Name: ")]
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string FirstName { get => firstName; set => firstName = value; }

        [DisplayName("Last Name: ")]
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string LastName { get => lastName; set => lastName = value; }

        [DisplayName("E-mail: ")]
        [EmailAddress]
        [Required]
        public string Email { get => email; set => email = value; }
        [DisplayName("Password: ")]
        [PasswordPropertyText]
        [Required]
        public string Password { get => password; set => password = value; }
        [DisplayName("Gender: ")]
        public string Gender { get => gender; set => gender = value; }
        [DisplayName("Subscribe to our newsletter?")]
        public string Subscribe { get => subscribe; set => subscribe = value; }
    }
}
