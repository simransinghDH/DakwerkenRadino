using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DakwerkenRadino.Business.Models
{
    public class ContactFormModel
    {
        public ContactFormModel()
        {
            SelectedSortOfJob = new string[5];        
        }

        [Required(ErrorMessage = "Gelieve uw e-mailadres in te geven")]
        [RegularExpression(@"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}\b", ErrorMessage = "Uw e-mailadres is niet correct")]
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddres { get; set; }

        [Required(ErrorMessage = "Gelieve uw naam in te geven")]
        [StringLength(55, ErrorMessage = "Jammer, uw naam is te lang")]
        [DisplayName("Naam")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gelieve uw telefoonnummer in te geven")]
        [RegularExpression(@"[+0-9/.\s]+", ErrorMessage = "Uw telefoonnummer is niet correct")]
        [DisplayName("Telefoonnummer")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Gelieve uw adres in te geven")]
        [StringLength(60, ErrorMessage = "Jammer, uw adres is te lang")]
        [DisplayName("Straat en nummer")]
        public string StreetAndNumber { get; set; }

        [Required(ErrorMessage = "Gelieve uw postcode in te geven")]
        [RegularExpression(@"\d{4}", ErrorMessage = "Uw postcode is niet correct (bv. 9000 )")]
        [DisplayName("Postcode")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Gelieve uw gemeente in te geven")]
        [StringLength(60, ErrorMessage = "Jammer, uw gemeente is te lang")]
        [DisplayName("Gemeente")]
        public string City { get; set; }

        [DisplayName("Type werk")]
        public IEnumerable<SelectListItem> SortOfJobs 
        {
            get
            {
                return new[] 
                {
                    new SelectListItem { Text = "Roofing en EPDM", Value = "roofing" },
                    new SelectListItem { Text = "Pannen", Value = "pannen" },
                    new SelectListItem { Text = "Zink en koper", Value = "zink en koper" },
                    new SelectListItem { Text = "Isolatie", Value = "isolatie" },
                    new SelectListItem { Text = "Gevelbekleding", Value = "gevelbekleding" }
                };
            } 
        }

        public string[] SelectedSortOfJob { get; set; }

        [DisplayName("Uw bericht")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        public override string ToString()
        {
            return string.Format(Core.Keys.Email.Message,
                        Name, EmailAddres, PhoneNumber, StreetAndNumber,
                        Zipcode, City, string.Join(", ", SelectedSortOfJob),
                        Message);
        }
    }
}
