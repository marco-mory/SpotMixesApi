using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SpotMixesApi.Models
{
    public class PlayList
    {
        [BsonId]
        [BsonRepresentation((BsonType.ObjectId))]
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public List<Audio> Audio {get; set;}
    }
}