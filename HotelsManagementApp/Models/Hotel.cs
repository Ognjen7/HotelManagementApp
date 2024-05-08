using System.ComponentModel.DataAnnotations;

namespace HotelsManagementApp.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 1, ErrorMessage = "Vrednost mora imati 1-80 karaktera")]
        public string Naziv { get; set; }

        [Required]
        [Range(1950, 2000)]
        public int GodinaOtvaranja { get; set; }

        [Required]
        [Range(1, 5000, ErrorMessage = "Vrednost mora biti veca od 1!")]
        public int BrojZaposlenih { get; set; }

        [Required]
        [Range(9, 1000, ErrorMessage = "Vrednost mora biti veca od 9 i manja od 1000!")]
        public int BrojSoba { get; set; }
        public int LanacHotelaId { get; set; }
        public LanacHotela LanacHotela { get; set; }
    }
}
