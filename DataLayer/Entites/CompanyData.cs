using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entites
{
    internal class CompanyData
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Industry { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string Deleted { get; set; }
    }
}
