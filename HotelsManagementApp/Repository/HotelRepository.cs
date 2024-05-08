using HotelsManagementApp.Interfaces;
using HotelsManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HotelsManagementApp.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly AppDbContext _context;

        public HotelRepository(AppDbContext context)
        {
            this._context = context;
        }

        public void Add(Hotel hotel)
        {
            _context.Hoteli.Add(hotel);
            _context.SaveChanges();
        }

        public void Delete(Hotel hotel)
        {
            _context.Hoteli.Remove(hotel);
            _context.SaveChanges();
        }

        public IQueryable<Hotel> GetAll()
        {
            return _context.Hoteli.OrderBy(hotel => hotel.GodinaOtvaranja);
        }

        public Hotel GetById(int id)
        {
            return _context.Hoteli.Include(l => l.LanacHotela).FirstOrDefault(h => h.Id == id);
        }

        public void Update(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public IEnumerable<CountStatisticsDTO> GetAllWithAverageEmployees()
        {
            return _context.Hoteli.Include(l => l.LanacHotela).GroupBy(z => z.LanacHotelaId).Select(group =>
                new CountStatisticsDTO
                {
                    LanacHotelaId = group.Key,
                    LanacHotelaNaziv = _context.LanciHotela.Where(lanac => lanac.Id == group.Key).Select(lanac => lanac.Naziv).Single(),
                    ProsecanBrojZaposlenih = (int)group.Average(l => l.BrojZaposlenih)
                })
                .OrderByDescending(stats => stats.ProsecanBrojZaposlenih)
                .ToList();
        }

        public IEnumerable<HotelStatsDTO> GetAllWithRoomCount(int granica)
        {
            return _context.Hoteli.Include(l => l.LanacHotela).GroupBy(z => z.LanacHotelaId).Select(group =>
                new HotelStatsDTO
                {
                    LanacHotelaId = group.Key,
                    LanacHotelaNaziv = _context.LanciHotela.Where(lanac => lanac.Id == group.Key).Select(lanac => lanac.Naziv).Single(),
                    UkupanBrojSoba = group.Sum(l => l.BrojSoba)
                })
                .Where(stats => stats.UkupanBrojSoba > granica)
                .OrderByDescending(stats => stats.UkupanBrojSoba)
                .ToList();
        }

        public IQueryable<Hotel> GetByEmployeeCount(int minimum)
        {
            return _context.Hoteli.Include(g => g.LanacHotela).Where(s => s.BrojZaposlenih >= minimum).OrderBy(s => s.BrojZaposlenih);
        }

        public IQueryable<Hotel> GetAllBySearchParams(int najmanje, int najvise)
        {
            return _context.Hoteli.Where(h => h.BrojSoba >= najmanje && h.BrojSoba <= najvise).OrderBy(f => f.BrojSoba);
        }
    }
}
