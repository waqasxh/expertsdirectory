using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertDirectory.API.Models.Repository
{
    public class MemberRespository : IDataRepository<Member>
    {
        readonly ExpertsDirectoryContext _expertDirectoryContext;

        public MemberRespository(ExpertsDirectoryContext context)
        {
            _expertDirectoryContext = context;
        }
        public void Add(Member entity)
        {
            _expertDirectoryContext.Members.Add(entity);
            _expertDirectoryContext.SaveChanges();
        }

        public void Delete(Member entity)
        {
            _expertDirectoryContext.Members.Remove(entity);
            _expertDirectoryContext.SaveChanges();
        }

        public Member Get(long id)
        {
            return _expertDirectoryContext.Members.Include(x => x.MemberFriends).FirstOrDefault(e => e.Id == id);
        }

        public Member Get(long id, string query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetAll()
        {
            //We are Eager Loading Frinds
            return _expertDirectoryContext.Members.Include(x=> x.MemberFriends).ToList();
        }

        public void Update(Member dbEntity, Member entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Website = entity.Website;
            dbEntity.Email = entity.Email;            
            _expertDirectoryContext.SaveChanges();
        }        
    }
}
