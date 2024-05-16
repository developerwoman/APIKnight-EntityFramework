using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIKnight.Entities
{
    [Table("Knights")]
    public class Knight
    {
        [Key]
        public int KnightId { get; set; }
        [ForeignKey("Attributes")]
        public int AttributeId { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Birthday { get; set; }
        public int Age { get; set; }
        public string KeyAttribute { get; set; }
        public List<KnightWeapon> WeaponsKnight { get; set; } = new List<KnightWeapon>();
        public Attribute Attribute { get; set; }
    }
}
