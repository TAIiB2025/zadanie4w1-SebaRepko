using System.ComponentModel.DataAnnotations;

namespace WebAPI
{
    public class KsiazkaDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Tytul { get; set; }

        [Required]
        [RegularExpression("^(?i)(fantasy|romans|dystopia)$")]
        public string Gatunek { get; set; }

        [Range(0, 2025)]
        public int Rok { get; set; }

        public string Autor { get; set; }
    }
}
