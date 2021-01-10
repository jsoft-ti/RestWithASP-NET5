using System;
using System.Collections.Generic;
using System.Threading;
using Model;

namespace Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {

            List<Person> persons = new List<Person>();
            for(int i = 0; i < 8; i++){
                Person person = MokPerson();
                persons.Add(person);
            }
            return persons ;  
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
            string gender = "Male";
        
            if(id%2 == 0){
                gender = "Female"; 
            }
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "João " + id,
                Address = "Cidade " + id,
                Gender = gender
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}