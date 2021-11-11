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

        void IDataRepository<MemberFriend>.Delete(MemberFriend entity)
        {
            throw new NotImplementedException();
        }

        MemberFriend IDataRepository<MemberFriend>.Get(long id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<MemberFriend> IDataRepository<MemberFriend>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IDataRepository<MemberFriend>.Update(MemberFriend dbEntity, MemberFriend entity)
        {
            throw new NotImplementedException();
        }
    }
}
