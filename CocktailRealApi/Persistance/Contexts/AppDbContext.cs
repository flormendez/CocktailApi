using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using CocktailRealApi.Models;
using CocktailRealApi.Domain.Models;

namespace CocktailRealApi.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(c => c.Id);
            builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(c => c.Cocktails).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<Cocktail>().ToTable("Cocktails");
            builder.Entity<Cocktail>().HasKey(c => c.Id);
            builder.Entity<Cocktail>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Cocktail>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Cocktail>().Property(c => c.Thumb).IsRequired();
            builder.Entity<Cocktail>().Property(c => c.Instructions).IsRequired();

            builder.Entity<Ingredients>().ToTable("Ingredients");
            builder.Entity<Ingredients>().HasKey(i => i.Id);
            builder.Entity<Ingredients>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Ingredients>().Property(i => i.Name).IsRequired().HasMaxLength(50);
            //builder.Entity<Ingredients>().HasMany(p => p.Cocktails).WithMany(p => p.Cocktails).HasForeignKey(p => p.CategoryId);

            builder.Entity<IngredientsAndCocktailsRelation>().HasKey(ci => new { ci.CocktailId, ci.IngredientId });

            builder.Entity<IngredientsAndCocktailsRelation>()
                .HasOne(e => e.Cocktail)
                .WithMany(e => e.IngredientsTo)
                .HasForeignKey(e => e.CocktailId);

            builder.Entity<IngredientsAndCocktailsRelation>()
                .HasOne(e => e.Ingredients)
                .WithMany(e => e.CocktailWith)
                .HasForeignKey(e => e.IngredientId);


            builder.Entity<Category>().HasData
            (
                new Category { Id = 100, Name = "Cocktail" }, // Id set manually due to in-memory provider
                new Category { Id = 101, Name = "Beer" }
            );

            builder.Entity<Cocktail>().HasData
                (
                    new Cocktail { Id = 100, Name = "Cocktail Name 1", Thumb = "Image/URL", Instructions = "How To Make it", CategoryId = 100 },
                    new Cocktail { Id = 101, Name = "Cocktail Name 2", Thumb = "Image/URL", Instructions = "How To Make it", CategoryId = 100 },
                    new Cocktail { Id = 102, Name = "Cocktail Name 3", Thumb = "Image/URL", Instructions = "How To Make it", CategoryId = 100 }
                );
            builder.Entity<Ingredients>().HasData
                (
                    new Ingredients { Id = 100, Name = "Ingrediente 1" },
                    new Ingredients { Id = 101, Name = "Ingrediente 2" }
                );
            builder.Entity<IngredientsAndCocktailsRelation>().HasData
                (
                    new IngredientsAndCocktailsRelation { CocktailId = 100, IngredientId = 100 },
                    new IngredientsAndCocktailsRelation { CocktailId = 100, IngredientId = 101 }
                );
        }

      
           
        }
    
}