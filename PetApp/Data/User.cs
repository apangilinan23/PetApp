using System.ComponentModel.DataAnnotations.Schema;

namespace PetApp.Data
{
    public class User
    {
        [Column("UserId")]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
