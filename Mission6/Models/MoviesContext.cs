using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class MoviesContext :DbContext
    {
        //Constructor
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {

        }

        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<MovieCategory> Categories { get; set; }

        /* To seed db with data */
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieCategory>().HasData(
                new MovieCategory {CategoryId = 1, CategoryName = "Action/Adventure" }, //Category Entry
                new MovieCategory {CategoryId = 2, CategoryName = "Comedy" }, //Category Entry
                new MovieCategory {CategoryId = 3, CategoryName = "Romance" }, //Category Entry
                new MovieCategory { CategoryId = 4, CategoryName = "SciFi" } //Category Entry

                );

            mb.Entity<MovieModel>().HasData(
                new MovieModel //one movie entry
                {
                    MovieId = 1,
                    Title = "Star Wars III - Revenge of the Sith",
                    Year = 2005,
                    Director = "George Lucas",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Favorite Movie",
                    CategoryId = 4
                },
                new MovieModel //one movie entry
                {
                    MovieId = 2,
                    Title = "Superbad",
                    Year = 2007,
                    Director = "Greg Mottola",
                    Rating = "R",
                    Edited = false,
                    LentTo = "",
                    Notes = "Funny and a little bad",
                    CategoryId = 2
                },
                new MovieModel //one movie entry
                {
                    MovieId = 3,
                    Title = "Thor: Ragnarok",
                    Year = 2017,
                    Director = "Taika Waititi",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Great superhero movie",
                    CategoryId = 1
                }
           );
        }
    }
}
