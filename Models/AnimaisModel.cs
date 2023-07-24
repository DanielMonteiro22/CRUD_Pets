using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetsSite.Models
{
    [Table("Pets")]
    public class AnimaisModel
    {
        [Column("id")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Column("name")]
        [Display(Name = "name")]
        public string name { get; set; }

        [Column("animal")]
        [Display(Name = "animal")]
        public string animal { get; set; }

        [Column("raca")]
        [Display(Name = "raca")]
        public string raca { get; set; }
    }
}
