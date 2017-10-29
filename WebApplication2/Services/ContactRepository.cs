using System;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class ContactRepository
    {
        private const string CacheKey = "ContactStore";
        private const string CacheKey2 = "ContactStore4";

        public ContactRepository()
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var contacts = new Contact[]
                    {
                        new Contact
                        {
                            Id = 1, Name = "Glenn Block"
                        },
                        new Contact
                        {
                            Id = 2, Name = "Dan Roth"
                        }
                    };

                    ctx.Cache[CacheKey] = contacts;
                }
            }
            if (ctx != null)
            {
                if (ctx.Cache[CacheKey2] == null)
                {
                    var contacts = new Contact[]
                    {
                        new Contact
                        {
                            Id = 1, Name = "ArekX"
                        },
                        new Contact
                        {
                            Id = 2, Name = "DArek2"
                        }
                    };

                    ctx.Cache[CacheKey2] = contacts;
                }
            }
        }

        public Contact[] GetAllContacts()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Contact[])ctx.Cache[CacheKey];
            }

            return new Contact[]
            {
                new Contact
                {
                    Id = 0,
                    Name = "Placeholder"
                }
            };
        }


        public Contact[] GetAllContactsv2()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Contact[])ctx.Cache[CacheKey2];
            }

            return new Contact[]
            {
                new Contact
                {
                    Id = 0,
                    Name = "Placeholder"
                }
            };
        }

        public bool SaveContact(Contact contact)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Contact[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(contact);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}