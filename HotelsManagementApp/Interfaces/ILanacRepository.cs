using HotelsManagementApp.Models;
using System.Linq;

namespace HotelsManagementApp.Interfaces
{
    public interface ILanacHotelaRepository
    {
        IQueryable<LanacHotela> GetAll();
        IQueryable<LanacHotela> GetOldestTwo();
        LanacHotela GetById(int id);
        void Add(LanacHotela lanacHotela);
        void Update(LanacHotela lanacHotela);
        void Delete(LanacHotela lanacHotela);
    }
}
