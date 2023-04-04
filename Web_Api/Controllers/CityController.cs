using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Api.DesignPatterns.SingletonPattern;
using Web_Api.DTOClasses;
using Web_Api.Models.Context;
using Web_Api.Models.Entities;

namespace Web_Api.Controllers
{
    public class CityController : ApiController
    {
        MyContext _db;
        public CityController()
        {
            _db = DBTool.DBInstance;
        }
        [HttpGet]
        public  List<CityDTO> ListCities()
        {
            return _db.Cities.Select(x => new CityDTO
            {
                ID = x.ID,
                CityName = x.CityName,
                CountryName = x.CountryName,
            }).ToList();
        }
        [HttpGet]
        public CityDTO BringCity(int id)
        {
            return _db.Cities.Where(x => x.ID == id).Select(x => new CityDTO
            {
                ID = x.ID,
                CityName = x.CityName,
                CountryName = x.CountryName,
            }).FirstOrDefault();
        }
        [HttpPost]
        public List<CityDTO> AddCity(City item)
        {
            _db.Cities.Add(item);
            _db.SaveChanges();
            return ListCities();
        }

        [HttpPut]
        public List<CityDTO> UpdateCity(City item)
        {
            City toBeUpdated = _db.Cities.Find(item.ID);
            _db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            _db.SaveChanges();
            return ListCities();
        }
        [HttpDelete]
        public List<CityDTO> DeleteCity(int id)
        {
            _db.Cities.Remove(_db.Cities.Find(id));
            _db.SaveChanges();
            return ListCities();
        }
    }
}
