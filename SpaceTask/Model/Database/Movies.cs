using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceTask.Model.Database
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        public string MovieId { get; set; }
        public string FilmName { get; set; }
        public string Description { get; set; }
        public decimal FilmRate { get; set; }
        public string ImageUrl { get; set; }
        public bool IsWatched { get; set; }
    }
}
