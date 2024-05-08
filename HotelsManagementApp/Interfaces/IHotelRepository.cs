using HotelsManagementApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace HotelsManagementApp.Interfaces
{
    public interface IHotelRepository
    {
        IQueryable<Hotel> GetAll();
        Hotel GetById(int id);
        void Add(Hotel hotel);
        void Update(Hotel hotel);
        void Delete(Hotel hotel);
        IEnumerable<CountStatisticsDTO> GetAllWithAverageEmployees();
        IEnumerable<HotelStatsDTO> GetAllWithRoomCount(int granica);
        IQueryable<Hotel> GetByEmployeeCount(int minimum);
        IQueryable<Hotel> GetAllBySearchParams(int najmanje, int najvise);

    }
}
