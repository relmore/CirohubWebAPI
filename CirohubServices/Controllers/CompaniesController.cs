using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CirohubServicesDataLayer;

namespace CirohubServices.Controllers
{
    public class CompaniesController : ApiController
    {
        public IEnumerable<Company> Get()
        {

            using (CirohubDBEntities entities = new CirohubDBEntities())
            {
                
                return entities.Companies.ToList();
            }
        }

        public Company Get(int id)
        {
            using (CirohubDBEntities entities = new CirohubDBEntities())
            {

                return entities.Companies.FirstOrDefault(e => e.CompanyId == id);
            }
        }


    }
}

