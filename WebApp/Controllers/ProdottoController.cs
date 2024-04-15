//using Microsoft.AspNetCore.Mvc;

//namespace WebApp.Controllers
//{
//    public class ProdottoController : Controller
//    {
//        [HttpGet]
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using WebApp.Enum;
using WebApp.Modelli;
using WebApp.Servizi;

namespace WebApp.Controllers
{
    public class ProdottoController : Controller
    {
        private readonly ProdottoServizi _prodottoServizi;

        public ProdottoController(ProdottoServizi prodottoServizi)
        {
            _prodottoServizi = prodottoServizi;
        }

        [HttpGet]
        public IActionResult GetProdotti()
        {
            var prodotti = _prodottoServizi.GetProdotti();
            return Ok(prodotti);
        }

        public IActionResult FiltraProdotto(EnumWebApp.Categoria? categoria, EnumWebApp.Taglia? taglia)
        {
            IEnumerable<Prodotto> prodottiFiltrati = _prodottoServizi.GetProdotti();

            if (categoria != null)
            {
                prodottiFiltrati = prodottiFiltrati.Where(p => p.Categoria == categoria);
            }

            if (taglia != null)
            {
                prodottiFiltrati = prodottiFiltrati.Where(p => p.Taglia == taglia);
            }

            return Ok(prodottiFiltrati);
        }

        [HttpGet("{id}")]
        public IActionResult GetProdottoById(Guid id)
        {
            var prodotto = _prodottoServizi.GetProdottoById(id);
            if (prodotto == null)
            {
                return NotFound();
            }
            return Ok(prodotto);
        }

        [HttpPost]
        public IActionResult AggiungiProdotto([FromBody] Prodotto prodotto)
        {
            _prodottoServizi.AggiungiProdotto(prodotto);
            return CreatedAtAction(nameof(GetProdottoById), new { id = prodotto.IDProdotto }, prodotto);
        }

        [HttpPut("{id}")]
        public IActionResult AggiornaProdotto(Guid id, [FromBody] Prodotto prodotto)
        {
            if (id != prodotto.IDProdotto)
            {
                return BadRequest();
            }

            _prodottoServizi.AggiornaProdotto(prodotto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminaProdotto(Guid id)
        {
            _prodottoServizi.EliminaProdotto(id);
            return NoContent();
        }

        
    }
}