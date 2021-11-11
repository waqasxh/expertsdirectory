using ExpertDirectory.API.Models;
using ExpertDirectory.API.Models.Repository;
using ExpertsDirectory.API.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertDirectory.API.Controllers
{
    [ApiController]
    [Route("api/memberfriend")]
    public class MemberFriendController : ControllerBase
    {
        private readonly IDataRepository<MemberFriend> _dataRepository;
        private readonly ILogger<MemberController> _logger;

        public MemberFriendController(IDataRepository<MemberFriend> dataRepository, ILogger<MemberController> logger)
        {
            _dataRepository = dataRepository;
            _logger = logger;
        }

        // PUT: api/memberfriend/5
        [HttpPut("{id}")]        
        public IActionResult Put(long id, [FromBody] MemberFriend memberFriend)
        {
            MemberFriend memberFriend1 = new MemberFriend()
            {
                MemberId = id,
                FriendId = memberFriend.FriendId,
            };

            MemberFriend memberFriend2 = new MemberFriend()
            {
                MemberId = memberFriend.FriendId,
                FriendId = id,
            };

            _dataRepository.Add(memberFriend1);
            _dataRepository.Add(memberFriend2);

            return NoContent();
        }
    }
}
