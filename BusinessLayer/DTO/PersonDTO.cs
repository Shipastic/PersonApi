using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SerializeAppForDigitSpace.BusinessLayer.DTO
{
    public class PersonDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("transportId")]
        public Guid TransportId { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("sequenceId")]
        public int SequenceId { get; set; }

        [JsonPropertyName("creditCardNumbers")]
        public string[] CreditCardNumbers { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("phones")]
        public string[] Phones { get; set; }

        [JsonPropertyName("birthDate")]
        public long BirthDate { get; set; }

        [JsonPropertyName("salary")]
        public double Salary { get; set; }

        [JsonPropertyName("isMarred")]
        public bool IsMarred { get; set; }

        [JsonPropertyName("gender")]
        public GenderDTO Gender { get; set; }

        [JsonPropertyName("children")]
        public ChildDTO[] Children { get; set; }
    }
    public class ChildDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("birthDate")]
        public long BirthDate { get; set; }

        [JsonPropertyName("gender")]
        public GenderDTO Gender { get; set; }
    }
    public enum GenderDTO
    {
        [JsonPropertyName("male")]
        Male,
        [JsonPropertyName("female")]
        Female
    }
}
