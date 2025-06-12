using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/ksiazki")]
    public class KsiazkiController : ControllerBase
    {
        private static List<KsiazkaDto> listaKsiazek = new List<KsiazkaDto>
        {
            new KsiazkaDto { Id = 1, Tytul = "Zbrodnia i kara", Autor = "Fiodor Dostojewski", Gatunek = "Powieść psychologiczna", Rok = 1866 },
            new KsiazkaDto { Id = 2, Tytul = "Pan Tadeusz", Autor = "Adam Mickiewicz", Gatunek = "Epopeja narodowa", Rok = 1834 },
            new KsiazkaDto { Id = 3, Tytul = "Rok 1984", Autor = "George Orwell", Gatunek = "Dystopia", Rok = 1949 },
            new KsiazkaDto { Id = 4, Tytul = "Wiedźmin: Ostatnie życzenie", Autor = "Andrzej Sapkowski", Gatunek = "Fantasy", Rok = 1993 },
            new KsiazkaDto { Id = 5, Tytul = "Duma i uprzedzenie", Autor = "Jane Austen", Gatunek = "Romans", Rok = 1813 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<KsiazkaDto>> Get()
        {
            return Ok(listaKsiazek);
        }

        [HttpGet("{id}")]
        public ActionResult<KsiazkaDto> GetById(int id)
        {
            var ksiazka = listaKsiazek.FirstOrDefault(k => k.Id == id);
            if (ksiazka == null)
                return NotFound("Nie znaleziono wskazanej książki");

            return Ok(ksiazka);
        }

        [HttpPost]
        public ActionResult Post([FromBody] KsiazkaDto dto)
        {
            dto.Id = listaKsiazek.Count > 0 ? listaKsiazek.Max(k => k.Id) + 1 : 1;
            listaKsiazek.Add(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] KsiazkaDto dto)
        {
            var ksiazka = listaKsiazek.FirstOrDefault(k => k.Id == id);
            if (ksiazka == null)
                return NotFound("Nie znaleziono wskazanej książki");

            ksiazka.Tytul = dto.Tytul;
            ksiazka.Autor = dto.Autor;
            ksiazka.Gatunek = dto.Gatunek;
            ksiazka.Rok = dto.Rok;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var ksiazka = listaKsiazek.FirstOrDefault(k => k.Id == id);
            if (ksiazka == null)
                return NotFound("Nie znaleziono wskazanej książki");

            listaKsiazek.Remove(ksiazka);
            return NoContent();
        }
    }
}
