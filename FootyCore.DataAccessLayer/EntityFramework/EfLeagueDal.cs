using FootyCore.DataAccessLayer.Abstract;
using FootyCore.DataAccessLayer.Concrete;
using FootyCore.DataAccessLayer.Repositories;
using FootyCore.EntityLayer.Entities;


namespace FootyCore.DataAccessLayer.EntityFramework
{
    public class EfLeagueDal : GenericRepository<League>, ILeagueDal
    {
        public EfLeagueDal(FootyContext context) : base(context)
        {
        }
    }
}
