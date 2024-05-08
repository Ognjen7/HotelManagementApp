using AutoMapper;
using HotelsManagementApp.Controllers;
using HotelsManagementApp.Interfaces;
using HotelsManagementApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HotelManagementAppTests.Controllers
{
    public class HoteliControllerTest
    {
        [Fact]
        public void GetHotel_ValidId_ReturnsObject()
        {
            // Arrange
            Hotel hotel = new Hotel()
            {
                Id = 1,
                Naziv = "HotelTest",
                GodinaOtvaranja = 2000,
                BrojZaposlenih = 200,
                BrojSoba = 200,
                LanacHotelaId = 1,
                LanacHotela = new LanacHotela { Id = 1, Naziv = "LanacHotelaTest", GodinaOsnivanja = 2000 }
            };

            HotelDTO hotelDTO = new HotelDTO()
            {
                Id = 1,
                Naziv = "HotelTest",
                GodinaOtvaranja = 2000,
                BrojZaposlenih = 200,
                BrojSoba = 200,
                LanacHotelaId = 1,
                LanacHotelaNaziv = "LanacHotelaTest"
            };

            var mockRepository = new Mock<IHotelRepository>();
            mockRepository.Setup(x => x.GetById(1)).Returns(hotel);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new HotelProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new HoteliController(mockRepository.Object, mapper);

            // Act
            var actionResult = controller.GetHotel(1) as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);

            HotelDTO dtoResult = (HotelDTO)actionResult.Value;
            Assert.Equal(hotel.Id, dtoResult.Id);
            Assert.Equal(hotel.Naziv, dtoResult.Naziv);
            Assert.Equal(hotel.GodinaOtvaranja, dtoResult.GodinaOtvaranja);
            Assert.Equal(hotel.BrojZaposlenih, dtoResult.BrojZaposlenih);
            Assert.Equal(hotel.BrojSoba, dtoResult.BrojSoba);
            Assert.Equal(hotel.LanacHotelaId, dtoResult.LanacHotelaId);
            Assert.Equal(hotel.LanacHotela.Naziv, dtoResult.LanacHotelaNaziv);
        }

        [Fact]
        public void PutHotel_InvalidId_ReturnsBadRequest()
        {
            // Arrange
            Hotel hotel = new Hotel()
            {
                Id = 1,
                Naziv = "HotelTest",
                GodinaOtvaranja = 2000,
                BrojZaposlenih = 200,
                BrojSoba = 200,
                LanacHotelaId = 1,
                LanacHotela = new LanacHotela { Id = 1, Naziv = "LanacHotelaTest", GodinaOsnivanja = 2000 }
            };

            var mockRepository = new Mock<IHotelRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new HotelProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new HoteliController(mockRepository.Object, mapper);

            // Act
            var actionResult = controller.PutHotel(24, hotel) as BadRequestResult;

            // Assert
            Assert.NotNull(actionResult);
        }

        [Fact]
        public void GetHoteli_ReturnsCollection()
        {
            // Arrange
            List<Hotel> hoteli = new List<Hotel>() {

                new Hotel()  {
                    Id = 1,
                    Naziv = "HotelTest",
                    GodinaOtvaranja = 2000,
                    BrojZaposlenih = 200,
                    BrojSoba = 200,
                    LanacHotelaId = 1,
                    LanacHotela = new LanacHotela { Id = 1, Naziv = "LanacHotelaTest", GodinaOsnivanja = 2000 }
                },
                new Hotel()  {
                    Id = 2,
                    Naziv = "HotelTest",
                    GodinaOtvaranja = 2001,
                    BrojZaposlenih = 201,
                    BrojSoba = 201,
                    LanacHotelaId = 2,
                    LanacHotela = new LanacHotela { Id = 2, Naziv = "LanacHotelaTest", GodinaOsnivanja = 2001 }
                }
            };

            var mockRepository = new Mock<IHotelRepository>();
            mockRepository.Setup(x => x.GetAll()).Returns(hoteli.AsQueryable());

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new HotelProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new HoteliController(mockRepository.Object, mapper);

            // Act
            var actionResult = controller.GetHoteli() as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);

            List<HotelDTO> dtoResult = (List<HotelDTO>)actionResult.Value;

            for (int i = 0; i < dtoResult.Count; i++)
            {
                Assert.Equal(hoteli[i].Id, dtoResult[i].Id);
                Assert.Equal(hoteli[i].Naziv, dtoResult[i].Naziv);
                Assert.Equal(hoteli[i].GodinaOtvaranja, dtoResult[i].GodinaOtvaranja);
                Assert.Equal(hoteli[i].BrojZaposlenih, dtoResult[i].BrojZaposlenih);
                Assert.Equal(hoteli[i].BrojSoba, dtoResult[i].BrojSoba);
                Assert.Equal(hoteli[i].LanacHotelaId, dtoResult[i].LanacHotelaId);
                Assert.Equal(hoteli[i].LanacHotela.Naziv, dtoResult[i].LanacHotelaNaziv);
            }
        }

    }
}
