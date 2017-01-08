using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CirohubServicesDataLayer;


namespace CirohubServices.Controllers
{
    public class IndustriesController : ApiController
    {
        public IEnumerable<Industry> Get()
        {
            
            using (CirohubDBEntities entities = new CirohubDBEntities())
            {

                return entities.Industries.ToList();
            }
        }

        public Industry Get(int id)
        {
            using (CirohubDBEntities entities = new CirohubDBEntities())
            {

                return entities.Industries.FirstOrDefault(e => e.IndustryId == id);
            }
        }


    }

}
