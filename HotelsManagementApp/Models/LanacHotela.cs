using System.ComponentModel.DataAnnotations;

namespace HotelsManagementApp.Models
{
    public class LanacHotela
    {
        public int Id { get; set; }

        [Required]
        [StringLength(75, MinimumLength = 1, ErrorMessage = "Vrednost mora imati 1-75 karaktera")]
        public string Naziv { get; set; }

        [Required]
        [Range(1850, 2010)]
        public int GodinaOsnivanja { get; set; }
    }
}
