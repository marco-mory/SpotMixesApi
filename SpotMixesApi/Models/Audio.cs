using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SpotMixesApi.Models
{
    public class Audio
    {
        [BsonId]
        [BsonRepresentation((BsonType.ObjectId))]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime DatePublication { get; set; } = DateTime.Now;
        public int Reproduction {get;set;}
    }
}