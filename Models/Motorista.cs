using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace v1.Models
{
    public class Motorista
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [JsonProperty("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Matricula { get; set; }
    }
}