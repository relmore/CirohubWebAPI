using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CirohubServicesDataLayer;
using CirohubServices.Models;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace CirohubServices.Controllers
{
    public class ProfileController : ApiController
    {
        
      /*  public HttpResponseMessage Post([FromBody] ProfileViewModel profile)
        {
            using (CirohubDBEntities entities = new CirohubDBEntities())
            {
                int personID;
                int profileID;
                try {

 
                    //Save Person
                    try
                    {

                        Person person = new Person();
                        person.FirstName = profile.FirstName;
                        person.LastName = profile.LastName;
                        person.City = profile.City;
                        person.State = profile.State;
                        person.ZipCode = profile.ZipCode;
                        person.Phone1 = profile.PrimaryPhone;
                        person.Inactive = "0";
                        entities.People.Add(person);

                        entities.SaveChanges();

                        personID = person.PersonId;
                    }
                    catch (DbEntityValidationException ex)
                    {
                        string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                        throw new DbEntityValidationException(errorMessages);

                    }

                    //save profile
                    try
                    {
                        Profile newProfile = new Profile();
                        newProfile.LoginName = profile.EmailAddress;
                        newProfile.Password = profile.Password;
                        newProfile.PersonID = personID;
                        newProfile.Inactive = "0";
                        entities.Profiles.Add(newProfile);
                        entities.SaveChanges();
                        profileID = newProfile.ProfileId;
                    }
                    catch (DbEntityValidationException ex)
                    {
                        string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                        throw new DbEntityValidationException(errorMessages);
                    }

                    //save profile company
                    if (profile.Company != null)
                    { 
                    
                        try
                        {
                            ProfileCompany company = new ProfileCompany();
                            company.CompanyID = profile.Company.CompanyID;
                            company.City = profile.Company.City;
                            company.State = profile.Company.State;
                            company.ZipCode = profile.Company.ZipCode;
                            company.EmployeeCountID = profile.Company.NumberEmployeesID;
                            company.Phone1 = profile.Company.PrimaryPhone;
                            company.IndustryID = profile.Company.IndustryID;
                            company.Title = profile.Company.JobTitle;
                            company.ModifiedDate = Convert.ToDateTime("1/1/2017");
                            company.ProfileID = profileID;
                            entities.ProfileCompanies.Add(company);
                            entities.SaveChanges();



                        }
                        catch (DbEntityValidationException ex)
                        {
                            string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                            throw new DbEntityValidationException(errorMessages);
                        }
                    }

                    //save profile services
                    if(profile.ProfileServicesBuy != null )
                    { 
                        try
                        {
                            foreach (ProfileViewModelService svc in profile.ProfileServicesBuy)
                            {
                                ProfileService newSvc = new ProfileService();
                                newSvc.ProfileID = profileID;
                                newSvc.ServiceID = svc.ServiceID;
                                newSvc.ServiceCatID = svc.ServiceCatID;
                                newSvc.Buy = "Y";
                                newSvc.ModifiedDate = Convert.ToDateTime("1/1/2017");

                                var existingEnity = entities.ProfileServices.Find(profileID, svc.ServiceID);
                                if(existingEnity == null)
                                {
                                    entities.ProfileServices.Add(newSvc);
                                } 
                                
                                entities.SaveChanges();
                            }
                        }
                        catch (DbEntityValidationException ex)
                        {
                            string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                            throw new DbEntityValidationException(errorMessages);
                        }
                        
                    }

                    //save profile services
                    if (profile.ProfileServicesSell != null)
                    {
                        try
                        {
                            foreach (ProfileViewModelService svc in profile.ProfileServicesSell)
                            {
                                ProfileService newSvc = new ProfileService();
                                newSvc.ProfileID = profileID;
                                newSvc.ServiceID = svc.ServiceID;
                                newSvc.ServiceCatID = svc.ServiceCatID;
                                newSvc.Sell = "Y";
                                newSvc.ModifiedDate = Convert.ToDateTime("1/1/2017");
                                var existingEnity = entities.ProfileServices.Find(profileID, svc.ServiceID);
                                if (existingEnity == null)
                                {
                                    entities.ProfileServices.Add(newSvc);
                                }
                                entities.SaveChanges();
                            }
                        }
                        catch (DbEntityValidationException ex)
                        {
                            string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                            throw new DbEntityValidationException(errorMessages);
                        }

                    }
                    //save profile Industries
                    if (profile.IndustrySellingProfile != null)
                    { 
                        try
                        {
                            foreach (ProfileViewModelIndustry svc in profile.IndustrySellingProfile)
                            {
                                ProfileIndustry newSvc = new ProfileIndustry();
                                newSvc.ProfileID = profileID;
                                newSvc.IndustryID= svc.IndustryID;
                                newSvc.Buy = "N";
                                newSvc.Sell = "Y";
                                newSvc.ModifiedDate = Convert.ToDateTime("1/1/2017");
                                entities.ProfileIndustries.Add(newSvc);
                                entities.SaveChanges();
                            }
                        }
                        catch (DbEntityValidationException ex)
                        {
                            string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                            throw new DbEntityValidationException(errorMessages);
                        }
                    }

                    //save profile Partner Companies
                    if (profile.PartnerCompaniesBuy != null)
                    {
                        try
                        {
                            foreach (ProfileViewModelPartnerCompany svc in profile.PartnerCompaniesBuy)
                            {
                                ProfilePartnerCompany newSvc = new ProfilePartnerCompany();
                                newSvc.ProfileID = profileID;
                                newSvc.CompanyID = svc.CompanyID;
                                newSvc.Buy = "Y";
                                newSvc.ModifiedDate = Convert.ToDateTime("1/1/2017");
                                var existingEnity = entities.ProfilePartnerCompanies.Find(profileID, svc.CompanyID);
                                if (existingEnity == null)
                                {
                                    entities.ProfilePartnerCompanies.Add(newSvc);
                                }
                                entities.SaveChanges();
                            }
                        }
                        catch (DbEntityValidationException ex)
                        {
                            string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                            throw new DbEntityValidationException(errorMessages);
                        }
                    }

                    if (profile.PartnerCompaniesSell != null)
                    {
                        try
                        {
                            foreach (ProfileViewModelPartnerCompany svc in profile.PartnerCompaniesSell)
                            {
                                ProfilePartnerCompany newSvc = new ProfilePartnerCompany();
                                newSvc.ProfileID = profileID;
                                newSvc.CompanyID = svc.CompanyID;
                                newSvc.Sell = "Y";
                                newSvc.ModifiedDate = Convert.ToDateTime("1/1/2017");
                                var existingEnity = entities.ProfilePartnerCompanies.Find(profileID, svc.CompanyID);
                                if (existingEnity == null)
                                {
                                    entities.ProfilePartnerCompanies.Add(newSvc);
                                }
                                entities.SaveChanges();
                            }
                        }
                        catch (DbEntityValidationException ex)
                        {
                            string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                            throw new DbEntityValidationException(errorMessages);
                        }
                    }

                } //end try to save all entities

                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }

                //All entities saved, return profile ID to client
                var message = Request.CreateResponse(HttpStatusCode.Created, profile);
                message.Headers.Location = new Uri(Request.RequestUri + "/" + profileID.ToString());
                return message;
            }

        }*/

        public ProfileCompositeView Post([FromBody] ProfileViewModel profile)
        {
            using (CirohubDBEntities entities = new CirohubDBEntities())
            {
                int personID;
                int profileID;
                try
                {


                    //Save Person
                    try
                    {

                        Person person = new Person();
                        person.FirstName = profile.FirstName;
                        person.LastName = profile.LastName;
                        person.City = profile.City;
                        person.State = profile.State;
                        person.ZipCode = profile.ZipCode;
                        person.Phone1 = profile.PrimaryPhone;
                        person.Inactive = "0";
                        entities.People.Add(person);

                        entities.SaveChanges();

                        personID = person.PersonId;
                    }
                    catch (DbEntityValidationException ex)
                    {
                        string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                        throw new DbEntityValidationException(errorMessages);

                    }

                    //save profile
                    try
                    {
                        Profile newProfile = new Profile();
                        newProfile.LoginName = profile.EmailAddress;
                        newProfile.Password = profile.Password;
                        newProfile.PersonID = personID;
                        newProfile.YearsExperienceID = 1; //Hard code to satisfy rule.  Fix later
                        newProfile.Inactive = "0";
                        entities.Profiles.Add(newProfile);
                        entities.SaveChanges();
                        profileID = newProfile.ProfileId;
                    }
                    catch (DbEntityValidationException ex)
                    {
                        string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                        throw new DbEntityValidationException(errorMessages);
                    }

                    //save profile company
                    if (profile.Company != null)
                    {

                        try
                        {
                            ProfileCompany company = new ProfileCompany();
                            company.CompanyID = profile.Company.CompanyID;
                            company.City = profile.Company.City;
                            company.State = profile.Company.State;
                            company.ZipCode = profile.Company.ZipCode;
                            company.EmployeeCountID = profile.Company.NumberEmployeesID;
                            company.Phone1 = profile.Company.PrimaryPhone;
                            company.IndustryID = profile.Company.IndustryID;
                            company.Title = profile.Company.JobTitle;
                            company.ModifiedDate = Convert.ToDateTime("1/1/2017");
                            company.ProfileID = profileID;
                            entities.ProfileCompanies.Add(company);
                            entities.SaveChanges();



                        }
                        catch (DbEntityValidationException ex)
                        {
                            string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                            throw new DbEntityValidationException(errorMessages);
                        }
                    }

                    //save profile services
                    if (profile.ProfileServicesBuy != null)
                    {
                        try
                        {
                            foreach (ProfileViewModelService svc in profile.ProfileServicesBuy)
                            {
                                ProfileService newSvc = new ProfileService();
                                newSvc.ProfileID = profileID;
                                newSvc.ServiceID = svc.ServiceID;
                                newSvc.ServiceCatID = svc.ServiceCatID;
                                newSvc.Buy = "Y";
                                newSvc.ModifiedDate = Convert.ToDateTime("1/1/2017");

                                var existingEnity = entities.ProfileServices.Find(profileID, svc.ServiceID);
                                if (existingEnity == null)
                                {
                                    entities.ProfileServices.Add(newSvc);
                                }

                                entities.SaveChanges();
                            }
                        }
                        catch (DbEntityValidationException ex)
                        {
                            string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                            throw new DbEntityValidationException(errorMessages);
                        }

                    }

                    //save profile services
                    if (profile.ProfileServicesSell != null)
                    {
                        try
                        {
                            foreach (ProfileViewModelService svc in profile.ProfileServicesSell)
                            {
                                ProfileService newSvc = new ProfileService();
                                newSvc.ProfileID = profileID;
                                newSvc.ServiceID = svc.ServiceID;
                                newSvc.ServiceCatID = svc.ServiceCatID;
                                newSvc.Sell = "Y";
                                newSvc.ModifiedDate = Convert.ToDateTime("1/1/2017");
                                var existingEnity = entities.ProfileServices.Find(profileID, svc.ServiceID);
                                if (existingEnity == null)
                                {
                                    entities.ProfileServices.Add(newSvc);
                                }
                                entities.SaveChanges();
                            }
                        }
                        catch (DbEntityValidationException ex)
                        {
                            string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                            throw new DbEntityValidationException(errorMessages);
                        }

                    }
                    //save profile Industries
                    if (profile.IndustrySellingProfile != null)
                    {
                        try
                        {
                            foreach (ProfileViewModelIndustry svc in profile.IndustrySellingProfile)
                            {
                                ProfileIndustry newSvc = new ProfileIndustry();
                                newSvc.ProfileID = profileID;
                                newSvc.IndustryID = svc.IndustryID;
                                newSvc.Buy = "N";
                                newSvc.Sell = "Y";
                                newSvc.ModifiedDate = Convert.ToDateTime("1/1/2017");
                                entities.ProfileIndustries.Add(newSvc);
                                entities.SaveChanges();
                            }
                        }
                        catch (DbEntityValidationException ex)
                        {
                            string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                            throw new DbEntityValidationException(errorMessages);
                        }
                    }

                    //save profile Partner Companies
                    if (profile.PartnerCompaniesBuy != null)
                    {
                        try
                        {
                            foreach (ProfileViewModelPartnerCompany svc in profile.PartnerCompaniesBuy)
                            {
                                ProfilePartnerCompany newSvc = new ProfilePartnerCompany();
                                newSvc.ProfileID = profileID;
                                newSvc.CompanyID = svc.CompanyID;
                                newSvc.Buy = "Y";
                                newSvc.ModifiedDate = Convert.ToDateTime("1/1/2017");
                                var existingEnity = entities.ProfilePartnerCompanies.Find(profileID, svc.CompanyID);
                                if (existingEnity == null)
                                {
                                    entities.ProfilePartnerCompanies.Add(newSvc);
                                }
                                entities.SaveChanges();
                            }
                        }
                        catch (DbEntityValidationException ex)
                        {
                            string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                            throw new DbEntityValidationException(errorMessages);
                        }
                    }

                    if (profile.PartnerCompaniesSell != null)
                    {
                        try
                        {
                            foreach (ProfileViewModelPartnerCompany svc in profile.PartnerCompaniesSell)
                            {
                                ProfilePartnerCompany newSvc = new ProfilePartnerCompany();
                                newSvc.ProfileID = profileID;
                                newSvc.CompanyID = svc.CompanyID;
                                newSvc.Sell = "Y";
                                newSvc.ModifiedDate = Convert.ToDateTime("1/1/2017");
                                var existingEnity = entities.ProfilePartnerCompanies.Find(profileID, svc.CompanyID);
                                if (existingEnity == null)
                                {
                                    entities.ProfilePartnerCompanies.Add(newSvc);
                                }
                                entities.SaveChanges();
                            }
                        }
                        catch (DbEntityValidationException ex)
                        {
                            string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                            throw new DbEntityValidationException(errorMessages);
                        }
                    }

                } //end try to save all entities

                catch (Exception ex)
                {
                    //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                    throw new Exception(ex.Message);
                }



                //All entities saved, return list of matching profiles
                var ProfileList = entities.GetProfileView(profileID).FirstOrDefault();

                ProfileCompositeView model = entities.GetProfileView(profileID).FirstOrDefault();

                //EXECUTE ALGORITHM TO BUILD PROFILE MATCHES
                model.BuildProfileMatches();

                //GET ALL MATCHING PROFILES
                model.ProfileConnections = entities.GetProfileConnections(profileID).ToList();

                return model;
            }

        }
        public ProfileCompositeView GetProfile(int id)
        {
            using (CirohubDBEntities entities = new CirohubDBEntities())
            {

                var ProfileList = entities.GetProfileView(id).FirstOrDefault();

                ProfileCompositeView model = entities.GetProfileView(id).FirstOrDefault();

                model.ProfileConnections = entities.GetProfileConnections(id).ToList();

                return model;


            }
        }
    }
}
