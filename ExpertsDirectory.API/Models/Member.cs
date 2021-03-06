using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertDirectory.API.Models
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }       
        public string Email { get; set; }

        public ICollection<MemberHeader> MemberHeaders { get; set; }

        public ICollection<MemberFriend> MemberFriends { get; set; }
    }
}
