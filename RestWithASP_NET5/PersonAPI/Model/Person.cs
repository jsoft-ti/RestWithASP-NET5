using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Person")]
    public class Person
    {   
        [Column("id")]
        public long Id{get; set;}
        [Column("first_name")]
        public string FirstName{get; set;}
        [Column("address")]
        public string Address{get; set;}
        [Column("gender")]
        public string Gender{get; set;}

    }
}