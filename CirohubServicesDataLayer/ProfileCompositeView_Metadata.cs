using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Objects;


namespace CirohubServicesDataLayer
{
    [MetadataType(typeof(ProfileCompositeView_Metadata))]
    public partial class ProfileCompositeView
    {

        public List<ProfileConnection> ProfileConnections { get; set; }
        
        public partial class ProfileCompositeView_Metadata
        {

        }

        public void BuildProfileMatches()
        {
            try
            {
                CirohubDBEntities entities = new CirohubDBEntities();
                var id = new SqlParameter("profileID", ProfileId);
                entities.Database.ExecuteSqlCommand("Profile_BuildProfileMatches_Geolocation @profileID", id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

           // entities.Database.SqlQuery("", ProfileId);


        }

    }
}