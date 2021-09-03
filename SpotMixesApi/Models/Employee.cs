using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SpotMixesApi.Models
{
    public class Employee : Person
    {
        [BsonId]
        [BsonRepresentation((BsonType.ObjectId))]
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte RolType { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}