using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEnd.Models
{
    public class FriendViewModel
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
        [DisplayName("Date of Birth")]
        public string DoB { get; set; }
    }
}
