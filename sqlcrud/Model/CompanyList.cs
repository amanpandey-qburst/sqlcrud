using Microsoft.Identity.Client;

namespace sqlcrud.Model
{
    public class CompanyList
    {
        public int id { get; set; }

        public string companyname { get; set; }

        public string description { get; set; }

        public string industry { get; set; }

        public string email { get; set; }

        public string country { get; set; }

        public string deleted { get; set; }
    }
}
