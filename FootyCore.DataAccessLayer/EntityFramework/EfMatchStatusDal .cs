using FootyCore.DataAccessLayer.Abstract;
using FootyCore.DataAccessLayer.Concrete;
using FootyCore.DataAccessLayer.Repositories;
using FootyCore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.DataAccessLayer.EntityFramework
{
    public class EfMatchStatusDal : GenericRepository<MatchStatus>, IMatchStatusDal
    {
        public EfMatchStatusDal(FootyContext context) : base(context)
        {
        }
    }
}
