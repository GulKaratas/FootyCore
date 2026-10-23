using FootyCore.DataAccessLayer.Abstract;
using FootyCore.DataAccessLayer.Concrete;
using FootyCore.DataAccessLayer.Repositories;
using FootyCore.EntityLayer.Entities;

namespace FootyCore.DataAccessLayer.EntityFramework
{
    public class EfMatchDal : GenericRepository<Match> , IMatchDal
    {
        public EfMatchDal(FootyContext context) : base(context)
        {
        }
    }
}
