using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIKnight.Entities
{
    [Table("KnightWeapons")]
    public class KnightWeapon
    {
        [Key]
        public int KnightWeaponID { get; set; }

        [ForeignKey("Knights")]
        public int KnightID { get; set; }
        public Knight Knight { get; set; }

        [ForeignKey("Weapons")]
        public int WeaponID { get; set; }
        public Weapon Weapon { get; set; }

        public KnightWeapon()
        {

        }
    }
}
