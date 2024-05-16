using Microsoft.EntityFrameworkCore;
using APIKnight.Entities;


namespace APIKnight.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Knight> Knights { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Entities.Attribute> Attributes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Knights

            modelBuilder.Entity<Knight>(b =>
            {
                b.HasKey(e => e.KnightId);
                b.Property(e => e.KnightId).ValueGeneratedOnAdd();
            });


            modelBuilder.Entity<Knight>()
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            modelBuilder.Entity<Knight>()
                .Property(p => p.Nickname)
                .IsRequired()
                .HasColumnType("varchar(200)");


            modelBuilder.Entity<Knight>()
                .Property(p => p.Birthday)
                .IsRequired()
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Knight>()
              .Property(p => p.Age)
              .IsRequired()
              .HasColumnType("int");

            modelBuilder.Entity<Knight>()
                .Property(p => p.KeyAttribute)
                .IsRequired()
                .HasColumnType("varchar(100)");

            modelBuilder.Entity<Knight>()
                .HasMany(e => e.WeaponsKnight)
                .WithOne(e => e.Knight)
                .HasForeignKey(e => e.KnightWeaponID);


            modelBuilder.Entity<Knight>()
                  .HasOne(e => e.Attribute);


            modelBuilder.Entity<Knight>()
                .ToTable("Knights");

            base.OnModelCreating(modelBuilder);

            #endregion

            #region Attribute

            modelBuilder.Entity<Entities.Attribute>(b =>
            {
                b.HasKey(e => e.AttributeId);
                b.Property(e => e.AttributeId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Entities.Attribute>()
                .Property(x => x.Strength)
                .HasColumnType("int");

            modelBuilder.Entity<Entities.Attribute>()
                 .Property(x => x.Dexterity)
                 .HasColumnType("int");

            modelBuilder.Entity<Entities.Attribute>()
                .Property(x => x.Constitution)
                .HasColumnType("int");

            modelBuilder.Entity<Entities.Attribute>()
                 .Property(x => x.Intelligence)
                 .HasColumnType("int");

            modelBuilder.Entity<Entities.Attribute>()
                 .Property(x => x.Wisdom)
                 .HasColumnType("int");

            modelBuilder.Entity<Entities.Attribute>()
                .Property(x => x.Charism)
                .HasColumnType("int");


            modelBuilder.Entity<Entities.Attribute>()
                .ToTable("Attributes");

            base.OnModelCreating(modelBuilder);
            #endregion

            #region Weapons

            modelBuilder.Entity<Weapon>(b =>
            {
                b.HasKey(e => e.WeaponId);
                b.Property(e => e.WeaponId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Weapon>()
                .Property(x => x.Name)
                .HasColumnType("varchar(100)");

            modelBuilder.Entity<Weapon>()
                .Property(x => x.Mod)
                .HasColumnType("int");


            modelBuilder.Entity<Weapon>()
                .Property(x => x.Attr)
                .HasColumnType("varchar(100)");

            modelBuilder.Entity<Weapon>()
              .Property(x => x.Equipped)
              .HasColumnType("boolean");

            modelBuilder.Entity<Weapon>()
              .ToTable("Weapons");

            base.OnModelCreating(modelBuilder);

            #endregion

            #region KnightWeapons

            modelBuilder.Entity<KnightWeapon>(b =>
            {
                b.HasKey(e => e.KnightWeaponID);
                b.Property(e => e.KnightWeaponID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<KnightWeapon>()
               .HasOne(e => e.Knight);

            modelBuilder.Entity<KnightWeapon>()
               .HasOne(e => e.Weapon);

            modelBuilder.Entity<KnightWeapon>()
              .ToTable("KnightWeapons");

            base.OnModelCreating(modelBuilder);

            #endregion

        }
    }
}
