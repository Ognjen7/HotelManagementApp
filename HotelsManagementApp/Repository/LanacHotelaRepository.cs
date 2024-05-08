using HotelsManagementApp.Interfaces;
using HotelsManagementApp.Models;
using System.Linq;

namespace HotelsManagementApp.Repository
{
    public class LanacHotelaRepository : ILanacHotelaRepository
    {
        private readonly AppDbContext _context;

        public LanacHotelaRepository(AppDbContext context)
        {
            this._context = context;
        }

        public void Add(LanacHotela lanacHotela)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(LanacHotela lanacHotela)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<LanacHotela> GetAll()
        {
            return _context.LanciHotela;
        }

        public LanacHotela GetById(int id)
        {
            return _context.LanciHotela.FirstOrDefault(l => l.Id == id);
        }

        public IQueryable<LanacHotela> GetOldestTwo()
        {
            return _context.LanciHotela.OrderBy(l => l.GodinaOsnivanja).Take(2);
        }

        public void Update(LanacHotela lanacHotela)
        {
            throw new System.NotImplementedException();
        }
    }
}
