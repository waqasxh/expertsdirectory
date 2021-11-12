using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertDirectory.API.Models.Repository
{
    public class MemberFriendRespository : IDataRepository<MemberFriend>
    {
        readonly ExpertsDirectoryContext _expertDirectoryContext;

        public MemberFriendRespository(ExpertsDirectoryContext context)
        {
            _expertDirectoryContext = context;
        }

        public void Add(MemberFriend entity)
        {
            _expertDirectoryContext.MemberFriend.Add(entity);
            _expertDirectoryContext.SaveChanges();
        }

        public void Delete(MemberFriend entity)
        {
            throw new NotImplementedException();
        }

        public MemberFriend Get(long id)
        {
            throw new NotImplementedException();
        }

        public MemberFriend Get(long id, string query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MemberFriend> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(MemberFriend dbEntity, MemberFriend entity)
        {
            throw new NotImplementedException();
        }
    }
}
