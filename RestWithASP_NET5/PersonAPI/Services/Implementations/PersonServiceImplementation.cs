using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Model;
using Model.Context;

namespace Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;
        private MySqlContext _context;

        public PersonServiceImplementation(MySqlContext context)
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
             var result =  _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
             if(result != null){
                 try
                 {
                     _context.Persons.Remove(result);
                     _context.SaveChanges();
                 }
                 catch (System.Exception)
                 {
                     
                     throw;
                 }
             }
        }

        public List<Person> FindAll()
        {
           return _context.Persons.ToList();
        }

        private Person MokPerson()
        {
            string gender = "Male";
            long id = IncrementAndGet();
            if(id%2 == 0){
                gender = "Female"; 
            }
            return new Person
            {
                Id = id,
                FirstName = "João " + id,
                Address = "Cidade " + id,
                Gender = gender
            };
        }

        public Person FindById(long id)
        { 
            /*string gender = "Male";
        
            if(id%2 == 0){
                gender = "Female"; 
            }
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "João " + id,
                Address = "Cidade " + id,
                Gender = gender
            };*/
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person Update(Person person)
        {
            if(!Exists(person)) return new Person();
            var result =  _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if(result != null){
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (System.Exception)
                {
                    
                    throw;
                }
                
            }
            return result;
        
        }

        private bool Exists(Person person)
        {
            return _context.Persons.Any(p => p.Id.Equals(person.Id));
        }
    }
}