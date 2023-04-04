using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Api.Models.Entities;

namespace Web_Api.DTOClasses
{
    public class CityDTO
    {
        public int ID { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public List<City>Cities  { get; set; }
    }
}