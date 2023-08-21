namespace sqlcrud.Model.DTOs
{
    public class UpdateCompanyDto
    {
        public string companyname { get; set; }

        public string description { get; set; }

        public string industry { get; set; }

        public string email { get; set; }

        public string country { get; set; }

        public string deleted { get; set; }
    }
}
