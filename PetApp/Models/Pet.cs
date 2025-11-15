using System.ComponentModel.DataAnnotations.Schema;

namespace PetApp.Models
{
    public class Pet
    {
        [Column("PetId")]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Breed { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Color { get; set; }

        public bool Ready { get; set; }
    }
}
