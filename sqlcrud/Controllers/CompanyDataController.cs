using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sqlcrud.Data;
using sqlcrud.Model;
using sqlcrud.Model.DTOs;

namespace sqlcrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyDataController : ControllerBase
    {

        private readonly CompanyDbContext _companyDbContext;

        public CompanyDataController(CompanyDbContext _companyDbContext)
        {
            this._companyDbContext = _companyDbContext;
        }

        [HttpGet]

        public IActionResult GetAll()
        {

            var companyDomain = _companyDbContext.CompanyData.ToList();

            var CompanyDto = new List<CompanyDto>();
            foreach (var companyd in companyDomain)
            {
                CompanyDto.Add(new CompanyDto()
                {
                    id = companyd.id,
                    companyname = companyd.companyname,
                    description = companyd.description,
                    industry = companyd.industry,
                    email = companyd.email,
                    country = companyd.country,
                    deleted = companyd.deleted,


                });
            }
            /* var companydata = new List<CompanyList>
             { new CompanyList
             {
                 id= 1,
                 companyname="Google",
                 description="A technology company",
                 industry="Technology Company",
                 email="support@google.com",
                 country="America"

             }
             };*/
            return Ok(CompanyDto);

        }

        [HttpGet]
        [Route("{id}")]

        public IActionResult GetById([FromRoute] int id) {

            var companydata = _companyDbContext.CompanyData.Find(id);

            if (companydata == null)
            {
                return NotFound();
            }
            return Ok(companydata);

        }

        [HttpPost]

        public IActionResult Create([FromBody] AddCompanyDto addCompany)
        {

            var CompanyDomainModel = new CompanyList
            {
                companyname = addCompany.companyname,
                description = addCompany.description,
                industry = addCompany.industry,
                email = addCompany.email,
                country = addCompany.country,
                deleted="False"

            };

            _companyDbContext.CompanyData.Add(CompanyDomainModel);
            _companyDbContext.SaveChanges();

            var companydomain = new CompanyDto
            {
                id = CompanyDomainModel.id,
                companyname = CompanyDomainModel.companyname,
                description = CompanyDomainModel.description,
                industry = CompanyDomainModel.industry,
                email = CompanyDomainModel.email,
                country = CompanyDomainModel.country,
                deleted = CompanyDomainModel.deleted
            };

            return CreatedAtAction(nameof(GetById), new { id = companydomain.id }, companydomain);

        }

        [HttpPut]
        [Route("{id}")]

        public IActionResult Update([FromRoute] int id, [FromBody] UpdateCompanyDto updateCompany)
        {

            var companydata = _companyDbContext.CompanyData.Find(id);

            if (companydata == null)
            {
                return NotFound();
            }

            companydata.companyname = updateCompany.companyname;
            companydata.description = updateCompany.description;
            companydata.industry = updateCompany.industry;
            companydata.email = updateCompany.email;
            companydata.country = updateCompany.country;
            companydata.deleted = updateCompany.deleted;


            _companyDbContext.SaveChanges();

            var companydto = new CompanyDto
            {
                id = companydata.id,
                companyname = companydata.companyname,
                description = companydata.description,
                industry = companydata.industry,
                email = companydata.email,
                country = companydata.country,
                deleted = companydata.deleted,
            };


            return Ok(companydto);

        }



        [HttpDelete]
        [Route("{id}")]


        public IActionResult Delete ([FromRoute]int id)
        {

            var companydata=_companyDbContext.CompanyData.Find(id);

            if(companydata == null)
            {
                return NotFound();
            }

            companydata.deleted = "True";
            _companyDbContext.SaveChanges();

            var companydto = new CompanyDto
            {
                id = companydata.id,
                companyname = companydata.companyname,
                description = companydata.description,
                industry = companydata.industry,
                email = companydata.email,
                country = companydata.country,
                deleted=companydata.deleted,
            };

            return Ok(companydto);
        }


    }
}
