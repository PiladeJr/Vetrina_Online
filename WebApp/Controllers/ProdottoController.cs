using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Enum;
using WebApp.Modelli;
using WebApp.Servizi;

namespace WebApp.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ProdottoController : Controller
    {
        private readonly ProdottoServizi _prodottoServizi;

        public ProdottoController(ProdottoServizi prodottoServizi)
        {
            _prodottoServizi = prodottoServizi;
        }
        [HttpGet]
        [Route("prodotto/index")]
        public ActionResult IndexProdotto()
        {
            return View();
        }
        [HttpGet]
        [Route("prodotto/getprodotto")]
        public IActionResult GetProdotti()
        {
            var prodotti = _prodottoServizi.GetProdotti();
            return Ok(prodotti);
        }

        [HttpGet]
        [Route("prodotto/filtra")]
        public IActionResult FiltraProdotto(EnumWebApp.Categoria? categoria, EnumWebApp.Taglia? taglia)
        {
            IEnumerable<Prodotto> prodottiFiltrati = _prodottoServizi.GetProdotti();
            _prodottoServizi.FiltraProdotti(categoria, taglia);
            return Ok(prodottiFiltrati);
        }
        [HttpGet]
        [Route("prodotto/ricercaprodotto")]
        public IActionResult RicercaProdottiBarra(string nomeRicerca)
        {
            IEnumerable<Prodotto> prodottiCercati = _prodottoServizi.GetProdotti();
            _prodottoServizi.RicercaProdottiBarra(nomeRicerca);
            return Ok(prodottiCercati);
        }

        [HttpGet("{id}")]
        [Route("prodotto/getprodottobyid")]
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
        [Route("prodotto/aggiungiprodotto")]
        public async Task<IActionResult> AggiungiProdottoAsync([FromBody] Prodotto prodotto)
        {
            //this.User;
            await _prodottoServizi.AggiungiProdottoAsync(Guid.NewGuid(), prodotto);
            return CreatedAtAction(nameof(GetProdottoById), new { id = prodotto.IDProdotto }, prodotto);
        }

        [HttpPut("{id}")]
        [Route("prodotto/aggiornaprodotto")]
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
        [Route("prodotto/eliminaprodotto")]
        public IActionResult EliminaProdotto(Guid id)
        {
            _prodottoServizi.EliminaProdotto(id);
            return NoContent();
        }


    }
}