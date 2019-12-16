using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shopping.Data.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [Display(Name="Customer Name")]
        [MaxLength(60, ErrorMessage = "Name can have maximum of 60 characters")]
        public string CustomerName { get; set; }

        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Email not in valid format")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone not in valid format")]
        public string Phone { get; set; }

        [Display(Name = "Credit Card")]
        [DataType(DataType.CreditCard, ErrorMessage = "Credit card number not in calid format")]
        public string CreditCard { get; set; }
    }
}
