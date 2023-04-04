using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Api.Models.Entities
{
    public class City:BaseEntity
    {
       
        public string CityName { get; set; }
        public string CountryName { get; set; }

    }
}