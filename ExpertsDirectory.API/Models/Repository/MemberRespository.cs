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
            return _expertDirectoryContext.Members
                 .FirstOrDefault(e => e.MemberId == id);
        }

        public IEnumerable<Member> GetAll()
        {
            return _expertDirectoryContext.Members.ToList();
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
