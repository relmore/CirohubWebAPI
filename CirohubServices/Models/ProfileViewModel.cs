using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CirohubServices.Models
{
    public class ProfileViewModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PrimaryPhone { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public ProfileViewModelCompany Company { get; set; }
        public List<ProfileViewModelIndustry> IndustrySellingProfile { get; set; }
        public List<ProfileViewModelPartnerCompany> PartnerCompanies { get; set; }
        public  List<ProfileViewModelService> ProfileServices { get; set; }

    }

        public class ProfileViewModelCompany
        {
            public int CompanyID { get; set; }
            public int NumberEmployeesID { get; set; }
            public int IndustryID { get; set; }
            public string JobTitle { get; set; }
            public string PrimaryPhone { get; set; }
            public string ZipCode { get; set; }
            public string City { get; set; }
            public string State { get; set; }
        }

    public class ProfileViewModelIndustry
    {
        public int IndustryID { get; set; }
        public string Buy { get; set; }
        public string Sell { get; set; }
    }

    public class ProfileViewModelPartnerCompany
    {
        public int CompanyID { get; set; }
        public string Buy { get; set; }
        public string Sell { get; set; }
    }

    public class ProfileViewModelService
    {
        public int ServiceCatID { get; set; }
        public int ServiceID { get; set; }

        public string Buy { get; set; }
        public string Sell { get; set; }
    }

}

           