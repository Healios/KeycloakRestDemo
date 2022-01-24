namespace Core.Models.Company
{
    public class Address
    {
        public string PrimaryAddress { get; set; } = "";

        public string? SecondaryAddress { get; set; }

        public string PostCode { get; set; } = "";

        public string City { get; set; } = "";

        public string Country { get; set; } = "";
    }
}
