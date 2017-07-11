using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureWebApp.Models
{
    public class ContactViewModel
    {
        public int ID { get; set; }
        public string  Name { get; set; }
        public string EmailID { get; set; }
        public string Subject { get; set; }
    }
}