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
        private readonly IDataRepository<Member> _memberRepository;
        private readonly IDataRepository<MemberFriend> _memberFriendRepository;
        private readonly IDataRepository<MemberHeader> _memberHeaderRepository;
        private readonly ILogger<MemberController> _logger;

        public MemberFriendController(IDataRepository<Member> memberRepository, IDataRepository<MemberFriend> memberFriendRepository, IDataRepository<MemberHeader> memberHeaderRepository, ILogger<MemberController> logger)
        {
            _memberRepository = memberRepository;
            _memberFriendRepository = memberFriendRepository;
            _memberHeaderRepository = memberHeaderRepository;
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

            _memberFriendRepository.Add(memberFriend1);
            _memberFriendRepository.Add(memberFriend2);

            return NoContent();
        }

        // GET: api/memberfriend?q=query
        [HttpGet]
        public IActionResult Get([FromQuery(Name = "id")] long id, [FromQuery(Name = "q")] string q)
        {
            //First we will retieve the header by reqired expertise            
            var targetHeader = _memberHeaderRepository.Get(id, q);
            if(targetHeader == null)
            {
                return Ok("No expert found for given expertise");
            }

            var targetMember = _memberRepository.Get(targetHeader.MemberId);
            var currentMember = _memberRepository.Get(id);

            //Already friend
            var currentFriend = currentMember.MemberFriends.FirstOrDefault(x => x.FriendId == targetMember.Id);

            if (currentFriend != null)
            {
                return Ok("You already have a friend " + targetMember.Name + " with given expertise");
            }

            //Friend of Friends
            foreach (var currentMemberFriend in currentMember.MemberFriends)
            {
                var targetPerson = targetMember.MemberFriends.FirstOrDefault(x => x.FriendId == currentMemberFriend.FriendId);

                if(targetPerson != null)
                {
                    var targetPersonMember = _memberRepository.Get(targetPerson.FriendId);
                    return Ok(currentMember.Name + " > " + targetPersonMember.Name + " > " + targetMember.Name);
                }
            }

            //If we have reached this state we do not have any expert in Friend of Friends list
            //If further levels implmentation is required we can use recursive function or more complex data type like Graph with supported database.

            return Ok("No expert found in Friend of Friends for given expertise");
        }
    }
}
