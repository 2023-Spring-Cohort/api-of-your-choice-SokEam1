using System.ComponentModel.DataAnnotations;

namespace EldenRing.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Area { get; set; } = null!;

    }

}
