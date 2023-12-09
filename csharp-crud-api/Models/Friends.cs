using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("myFriends")]
    public class Friend
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("dob")]
        public string DoB { get; set; }
    }
}
