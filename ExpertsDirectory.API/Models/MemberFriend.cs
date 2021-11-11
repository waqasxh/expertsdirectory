using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertDirectory.API.Models
{
    public class MemberFriend
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; } 
        public long MemberId { get; set; }
        public Member Member { get; set; }
        public long FriendId { get; set; }
    }
}
