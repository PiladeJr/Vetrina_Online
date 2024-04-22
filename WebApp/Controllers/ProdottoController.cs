using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Enum;
using WebApp.Modelli;
using WebApp.Servizi;

namespace WebApp.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ProdottoController : Controller
    {
        private readonly ProdottoServizi _prodottoServizi;

        public ProdottoController(ApplicationDbContext _dbcontext)
        {
            _prodottoServizi = new ProdottoServizi(_dbcontext) ;
        }
        [HttpGet]
        [Route("prodotto/index")]
        public async Task<ActionResult> IndexProdotto()
        {
            var prodotti = await _prodottoServizi.GetProdotti();
            return View(prodotti);
        }

        [HttpGet]
        [Route("prodotto/getprodotto")]
        public async Task<IActionResult> GetProdotti()
        {
            var prodotti = await _prodottoServizi.GetProdotti();
            return Ok(prodotti);
        }

        [HttpGet]
        [Route("prodotto/filtra")]
        public async Task<IActionResult> FiltraProdotto(EnumWebApp.Categoria? categoria, EnumWebApp.Taglia? taglia)
        {
            var prodotti = await _prodottoServizi.GetProdotti();
            var prodottiFiltrati = await _prodottoServizi.FiltraProdotti(categoria, taglia);
            return Ok(prodottiFiltrati);
        }
        [HttpGet]
        [Route("prodotto/ricercaprodotto")]
        public async Task<IActionResult> RicercaProdottiBarra(string nomeRicerca)
        {
            var prodotti = await _prodottoServizi.GetProdotti();
            var prodottiCercati = await _prodottoServizi.RicercaProdottiBarra(nomeRicerca);
            return Ok(prodottiCercati);
        }


        [HttpGet("{id}")]
        [Route("prodotto/getprodottobyid")]
        public async Task<IActionResult> GetProdottoById(Guid id)
        {
            var prodotto = await _prodottoServizi.GetProdottoById(id);
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
            //await _prodottoServizi.AggiungiProdottoAsync(Guid.NewGuid(), prodotto);
            return CreatedAtAction(nameof(GetProdottoById), new { id = prodotto.IDProdotto }, prodotto);
        }

        [HttpPut("{id}")]
        [Route("prodotto/aggiornaprodotto")]
        public async Task<IActionResult> AggiornaProdotto(Guid id, [FromBody] Prodotto prodotto)
        {
            if (id != prodotto.IDProdotto)
            {
                return BadRequest();
            }

            await _prodottoServizi.AggiornaProdotto(prodotto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Route("prodotto/eliminaprodotto")]
        public async Task<IActionResult> EliminaProdotto(Guid id)
        {
            await _prodottoServizi.EliminaProdotto(id);
            return NoContent();
        }


    }
}