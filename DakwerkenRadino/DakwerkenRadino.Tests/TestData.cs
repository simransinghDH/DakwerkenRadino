using DakwerkenRadino.Business.Models;

namespace DakwerkenRadino.Tests
{
    public static class TestData
    {
        private static ContactFormModel contactFormModel = new ContactFormModel
        {
            EmailAddres = "simran.test@gmail.com",
            Name = "Simran Tester",
            PhoneNumber = "055005050",
            StreetAndNumber = "Baker Street 22B",
            Zipcode = "6666",
            City = "Fantasy Island",
            Message = "Ding Dong",
            SelectedSortOfJob = new[] { "Roofing", "Pannen" }
        };

        public static ContactFormModel ContactFormModel
        {
            get
            {
                return contactFormModel;
            }
        }
    }
}