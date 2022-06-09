using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeAppForDigitSpace.DataAccessLayer.Models
{
    public class Person
    {
        public int Id { get; set; }
        public Guid TransportId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SequenceId { get; set; }
        public string[] CreditCardNumbers { get; set; }
        public int Age { get; set; }
        public string[] Phones { get; set; }
        public long BirthDate { get; set; }
        public double Salary { get; set; }
        public bool IsMarred { get; set; }
        public Gender Gender { get; set; }
        public Child[] Children { get; set; }
    }
    public class Child
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
