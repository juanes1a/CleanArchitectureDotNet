using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityRepository.Movie
{
    [Table("Movies")]
    public class MovieData
    {
        [Key]
        public string id { get; set; }

        [Required, Column(name:"Name"), MaxLength(25)]
        public string name { get; set; }
    }
}
