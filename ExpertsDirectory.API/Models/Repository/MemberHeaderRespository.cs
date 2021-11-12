using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertDirectory.API.Models.Repository
{
    public class MemberHeaderRespository : IDataRepository<MemberHeader>
    {
        readonly ExpertsDirectoryContext _expertDirectoryContext;

        public MemberHeaderRespository(ExpertsDirectoryContext context)
        {
            _expertDirectoryContext = context;
        }

        public void Add(MemberHeader entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(MemberHeader entity)
        {
            throw new NotImplementedException();
        }

        public MemberHeader Get(long id)
        {
            throw new NotImplementedException();
        }

        public MemberHeader Get(long id, string query)
        {
            var q = "%" + query.Replace(" ", "%") + "%";
            var queryResults = _expertDirectoryContext.MemberHeader.Where(e => (EF.Functions.Like(e.Text, q)) && e.MemberId != id);
            return queryResults.FirstOrDefault();
        }

        public IEnumerable<MemberHeader> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(MemberHeader dbEntity, MemberHeader entity)
        {
            throw new NotImplementedException();
        }
    }
}
