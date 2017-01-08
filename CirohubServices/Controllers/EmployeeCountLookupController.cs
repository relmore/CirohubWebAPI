using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CirohubServicesDataLayer;

namespace CirohubServices.Controllers
{
    public class EmployeeCountLookupController : ApiController
    {
        public IEnumerable<EmployeeCountLookup> Get()
        {

            using (CirohubDBEntities entities = new CirohubDBEntities())
            {

                return entities.EmployeeCountLookups.ToList();
            }
        }

        public EmployeeCountLookup Get(int id)
        {
            using (CirohubDBEntities entities = new CirohubDBEntities())
            {

                return entities.EmployeeCountLookups.FirstOrDefault(e => e.EmployeeCountID == id);
            }
        }
    }
}
