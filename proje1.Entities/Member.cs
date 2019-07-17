using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities
{
    [Table("Member")]
    public class Member
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MemberId { get; set; }

        [Required, StringLength(16)]
        public string Username { get; set; }

        [Required, StringLength(16)]
        public string Password { get; set; }
        
        [Required,StringLength(50)]
        public string Email { get; set; }

        public Guid activateGuid { get; set; }

        public bool memberIsActive { get; set; }
        
        public bool IsAdmin { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }
        

        public Member()
        {

        }
    }
}
