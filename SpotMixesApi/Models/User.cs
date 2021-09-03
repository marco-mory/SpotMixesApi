using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SpotMixesApi.Models
{
    public class User : Person
    {
        [BsonId]
        [BsonRepresentation((BsonType.ObjectId))]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Biography { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}