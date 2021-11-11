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
    [Route("api/member")]
    public class MemberController : ControllerBase
    {
        private readonly IDataRepository<Member> _dataRepository;
        private readonly ILogger<MemberController> _logger;

        public MemberController(IDataRepository<Member> dataRepository, ILogger<MemberController> logger)
        {
            _dataRepository = dataRepository;
            _logger = logger;
        }

        // GET: api/member
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Member> members = _dataRepository.GetAll();
            return Ok(members);
        }

        // GET: api/member/2
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Member member = _dataRepository.Get(id);
            MemberModel memberResult = new MemberModel();

            //Use utility like AutoMapper to Map thes values
            memberResult.Id = member.Id;
            memberResult.Email = member.Email;
            memberResult.Name = member.Name;
            memberResult.Website = member.Website;

            memberResult.Friends = new List<Member>();

            foreach (var memberFriend in member.MemberFriends)
            {
                Member dbFriend = _dataRepository.Get(memberFriend.FriendId);
                memberResult.Friends.Add(dbFriend);
            }

            if (member == null)
            {
                return NotFound("The Member record couldn't be found.");
            }
            return Ok(memberResult);
        }

        // POST: api/member
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Member member)
        {
            if (member == null)
            {
                return BadRequest("Member is null.");
            }
            
            //This scrapping task should be moved to some backgroud worker service
            try
            {
                WebScrapper webScrapper = new WebScrapper();
                var memberHeaders = await webScrapper.RetrieveHeaders(member.Website);

                List<MemberHeader> newMemberHeaders = new List<MemberHeader>();

                foreach(string memberHeader in memberHeaders)
                {
                    newMemberHeaders.Add(new MemberHeader() { Text = memberHeader });
                }

                member.MemberHeaders = newMemberHeaders;

                _dataRepository.Add(member);

                return CreatedAtRoute("Get", new { Id = member.Id }, member);
            }
            catch (Exception ex)
            {
                _logger.LogError("Post Error with Exception: " + ex.ToString() + " and StackTrace: " + ex.StackTrace);
            }


            return StatusCode(500);
        }

        // PUT: api/member/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Member member)
        {
            if (member == null)
            {
                return BadRequest("Member is null.");
            }
            Member memberToUpdate = _dataRepository.Get(id);
            if (memberToUpdate == null)
            {
                return NotFound("The Member record couldn't be found.");
            }
            _dataRepository.Update(memberToUpdate, member);
            return NoContent();
        }

        // DELETE: api/member/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            //Add logic to delete Header and Friends before deleting the Member
            Member member = _dataRepository.Get(id);
            if (member == null)
            {
                return NotFound("The Member record couldn't be found.");
            }
            _dataRepository.Delete(member);
            return NoContent();
        }
    }
}
