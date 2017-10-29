using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class ContactController : ApiController
    {

        private ContactRepository contactRepository;

        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }

        // GET: Contact

        public Contact[] Get()
        {
            return contactRepository.GetAllContacts();
        }
        //public Contact Get(int id)
        //{
        //    //return "value";
        //    return contactRepository.GetAllContactsv2()[0];
        //}

        public Contact Get(int id)
        {
            return contactRepository.GetAllContactsv2()[0];
        }

        //public bool Save([FromBody] Contact contact)
        //{
        //    return contactRepository.SaveContact(contact);
        //}
        public HttpResponseMessage Post(Contact contact)
        {
            this.contactRepository.SaveContact(contact);
            var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);
            return response;
        }


    }
}
