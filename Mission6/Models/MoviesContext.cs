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

        public DbSet<MovieModel> Responses { get; set; }

        /* To seed db with data */
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieModel>().HasData(
                new MovieModel //one movie entry
                {
                    MovieId = 1,
                    Title = "Star Wars III - Revenge of the Sith",
                    Category = "Action/Sci-Fi",
                    Year = 2005,
                    Director = "George Lucas",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Favorite Movie"
                },
                new MovieModel //one movie entry
                {
                    MovieId = 2,
                    Title = "Superbad",
                    Category = "Comedy/Teen",
                    Year = 2007,
                    Director = "Greg Mottola",
                    Rating = "R",
                    Edited = false,
                    LentTo = "",
                    Notes = "Funny and a little bad"
                },
                new MovieModel //one movie entry
                {
                    MovieId = 3,
                    Title = "Thor: Ragnarok",
                    Category = "Action/Sci-Fi",
                    Year = 2017,
                    Director = "Taika Waititi",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Great superhero movie"
                }
           );
        }
    }
}
