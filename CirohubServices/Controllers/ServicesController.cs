using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CirohubServicesDataLayer;

namespace CirohubServices.Controllers
{
    public class ServicesController : ApiController
    {
        public IEnumerable<Service> Get()
        {

            using (CirohubDBEntities entities = new CirohubDBEntities())
            {

                return entities.Services.ToList();
            }
        }

        public Service Get(int id)
        {
            using (CirohubDBEntities entities = new CirohubDBEntities())
            {

                return entities.Services.FirstOrDefault(e => e.ServiceId== id);
            }
        }


    }
}

