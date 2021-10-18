using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Text.RegularExpressions;

namespace WebApp.Models
{
    public class User :IValidatableObject
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 3)]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }

       

        [MinLength(6, ErrorMessage = "Password must minimum 6 characters")]

        public string Password { get; set; }

        [NotMapped]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            //Email
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Email);
            if (!match.Success)
            {
                yield return new ValidationResult("Invalid Email", new[] { "Email" });
            }

            var phoneRegex = new Regex(@"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$");
            match = phoneRegex.Match(PhoneNumber);
            if (!match.Success)
            {
                yield return new ValidationResult("Invalid PhoneNumber", new[] { "PhoneNumber" });
            }

            if (Country !=null && !Country.Equals("United States"))
            {
                yield return new ValidationResult("Invalid Country", new[] { "Country" });
            }

            if (Country != null && !states.Contains (State))
            {
                yield return new ValidationResult("Invalid State", new[] { "State" });
            }


          
            int comparedate = DateTime.Compare(DateTime.Now, DOB);

            if (comparedate < 0)
            {
                yield return new ValidationResult("Invalid Date Of Birth", new[] { "DOB" });

            }

        }

        [Required(ErrorMessage = "Street Address 1 is required")]
        public string StreetAddress1 { get; set; }

        public string StreetAddress2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        [Phone(ErrorMessage ="Invalid PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime DOB { get; set; }

        private String[] states = {"Alaska",
                  "Alabama",
                  "Arkansas",
                  "American Samoa",
                  "Arizona",
                  "California",
                  "Colorado",
                  "Connecticut",
                  "District of Columbia",
                  "Delaware",
                  "Florida",
                  "Georgia",
                  "Guam",
                  "Hawaii",
                  "Iowa",
                  "Idaho",
                  "Illinois",
                  "Indiana",
                  "Kansas",
                  "Kentucky",
                  "Louisiana",
                  "Massachusetts",
                  "Maryland",
                  "Maine",
                  "Michigan",
                  "Minnesota",
                  "Missouri",
                  "Mississippi",
                  "Montana",
                  "North Carolina",
                  " North Dakota",
                  "Nebraska",
                  "New Hampshire",
                  "New Jersey",
                  "New Mexico",
                  "Nevada",
                  "New York",
                  "Ohio",
                  "Oklahoma",
                  "Oregon",
                  "Pennsylvania",
                  "Puerto Rico",
                  "Rhode Island",
                  "South Carolina",
                  "South Dakota",
                  "Tennessee",
                  "Texas",
                  "Utah",
                  "Virginia",
                  "Virgin Islands",
                  "Vermont",
                  "Washington",
                  "Wisconsin",
                  "West Virginia",
                  "Wyoming" };
    }
}