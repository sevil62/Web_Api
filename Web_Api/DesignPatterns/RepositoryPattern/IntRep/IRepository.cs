using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Web_Api.Models.Entities;

namespace Web_Api.DesignPatterns.RepositoryPattern.IntRep
{
    public interface IRepository<T> where T : BaseEntity
    {
        //List Commands
        List<T> GetAll();
        List<T> GetModifieds();
        List<T> GetActives();
        List<T> GetPassives();


        //Modifications

        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void Destroy(T item);



        //Linq Expressions
        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp);

        //Find
        T Find(int id);
    }
}