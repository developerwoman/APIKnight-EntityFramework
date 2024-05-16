using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIKnight.Entities
{
    [Table("Attributes")]
    public class Attribute
    {
        [Key]
        [NotMapped]
        [JsonIgnore]
        public int AttributeId { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charism { get; set; }
    }
}
