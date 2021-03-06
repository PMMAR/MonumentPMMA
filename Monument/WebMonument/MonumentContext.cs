namespace WebMonument
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MonumentContext : DbContext
    {
        public MonumentContext()
            : base("name=MonumentContext")
        {
        }

        public virtual DbSet<Adresse> Adresse { get; set; }
        public virtual DbSet<Behandlingstyper> Behandlingstyper { get; set; }
        public virtual DbSet<Bruger> Bruger { get; set; }
        public virtual DbSet<Materialer> Materialer { get; set; }
        public virtual DbSet<SkadeNoter> SkadeNoter { get; set; }
        public virtual DbSet<Skader> Skader { get; set; }
        public virtual DbSet<SkadeTyper> SkadeTyper { get; set; }
        public virtual DbSet<StatueBehandling> StatueBehandling { get; set; }
        public virtual DbSet<StatueNoter> StatueNoter { get; set; }
        public virtual DbSet<StatuePlacering> StatuePlacering { get; set; }
        public virtual DbSet<Statuer> Statuer { get; set; }
        public virtual DbSet<StatueType> StatueType { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<SNote_Tags> SNote_Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresse>()
                .Property(e => e.ByNavn)
                .IsUnicode(false);

            modelBuilder.Entity<Adresse>()
                .HasMany(e => e.Statuer)
                .WithOptional(e => e.Adresse)
                .HasForeignKey(e => e.FK_PostNr);

            modelBuilder.Entity<Behandlingstyper>()
                .Property(e => e.Behandlingstyper1)
                .IsFixedLength();

            modelBuilder.Entity<Behandlingstyper>()
                .HasMany(e => e.StatueBehandling)
                .WithOptional(e => e.Behandlingstyper)
                .HasForeignKey(e => e.fk_Behandlingstype_id);

            modelBuilder.Entity<Bruger>()
                .Property(e => e.Brugernavn)
                .IsUnicode(false);

            modelBuilder.Entity<Bruger>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Bruger>()
                .Property(e => e.Salt)
                .IsFixedLength();

            modelBuilder.Entity<Bruger>()
                .Property(e => e.Fornavn)
                .IsUnicode(false);

            modelBuilder.Entity<Bruger>()
                .Property(e => e.Efternavn)
                .IsUnicode(false);

            modelBuilder.Entity<Bruger>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<SkadeNoter>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<SkadeNoter>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<Skader>()
                .Property(e => e.SkadeGrad)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Skader>()
                .HasMany(e => e.SkadeNoter)
                .WithOptional(e => e.Skader)
                .HasForeignKey(e => e.FK_Skade_id);

            modelBuilder.Entity<Skader>()
                .HasMany(e => e.StatueBehandling)
                .WithOptional(e => e.Skader)
                .HasForeignKey(e => e.fk_Skade_id);

            modelBuilder.Entity<SkadeTyper>()
                .Property(e => e.SkadeTyper1)
                .IsFixedLength();

            modelBuilder.Entity<SkadeTyper>()
                .HasMany(e => e.Skader)
                .WithOptional(e => e.SkadeTyper)
                .HasForeignKey(e => e.fk_SkadeType_id);

            modelBuilder.Entity<StatueNoter>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<StatueNoter>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<StatueNoter>()
                .HasOptional(e => e.SNote_Tags)
                .WithRequired(e => e.StatueNoter);

            modelBuilder.Entity<Statuer>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<Statuer>()
                .Property(e => e.Prioritet)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Statuer>()
                .HasMany(e => e.Materialer)
                .WithOptional(e => e.Statuer)
                .HasForeignKey(e => e.FK_Statue_id);

            modelBuilder.Entity<Statuer>()
                .HasMany(e => e.Skader)
                .WithOptional(e => e.Statuer)
                .HasForeignKey(e => e.FK_Statue_id);

            modelBuilder.Entity<Statuer>()
                .HasMany(e => e.StatueNoter)
                .WithOptional(e => e.Statuer)
                .HasForeignKey(e => e.FK_Statue_id);

            modelBuilder.Entity<Statuer>()
                .HasMany(e => e.StatuePlacering)
                .WithOptional(e => e.Statuer)
                .HasForeignKey(e => e.FK_Statue_id);

            modelBuilder.Entity<Statuer>()
                .HasMany(e => e.StatueType)
                .WithOptional(e => e.Statuer)
                .HasForeignKey(e => e.FK_Statue_id);

            modelBuilder.Entity<Tags>()
                .Property(e => e.Tag_Titel)
                .IsFixedLength();

            modelBuilder.Entity<Tags>()
                .HasMany(e => e.SNote_Tags)
                .WithOptional(e => e.Tags)
                .HasForeignKey(e => e.FK_Tag_id);
        }
    }
}
