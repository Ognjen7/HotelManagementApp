namespace HotelsManagementApp.Models
{
    public class HotelDTO
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int GodinaOtvaranja { get; set; }
        public int BrojSoba { get; set; }
        public int BrojZaposlenih { get; set; }
        public int LanacHotelaId { get; set; }
        public string LanacHotelaNaziv { get; set; }
    }
}
