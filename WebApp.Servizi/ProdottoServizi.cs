using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Modelli;
using WebApp.EnumFolder;

namespace WebApp.Servizi
{
    public class ProdottoServizi
    {
        private readonly ApplicationDbContext _dbContext;

        public ProdottoServizi(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Metodo per ottenere la lista dei prodotti
        public async Task<List<Prodotto>> GetProdottiAsync()
        {
            return await _dbContext.Prodotti.ToListAsync();
        }

        public async Task<Prodotto> GetProdottoById(Guid id)
        {
            return await _dbContext.Prodotti.FirstOrDefaultAsync(po => po.IDProdotto == id);
        }
        public async Task<List<Prodotto>> FiltraProdotti(EnumWebApp.Categoria? categoria, EnumWebApp.Taglia? taglia)
        {
            var prodottiFiltrati = await _dbContext.Prodotti.ToListAsync();
            if (categoria != EnumWebApp.Categoria.NonCategoria && taglia != EnumWebApp.Taglia.NonTaglia)
            {
                prodottiFiltrati = prodottiFiltrati.Where(p => p.Categoria == categoria && p.Taglia == taglia).ToList();
            }
            else if (categoria != EnumWebApp.Categoria.NonCategoria)
            {
                prodottiFiltrati = prodottiFiltrati.Where(p => p.Categoria == categoria).ToList();
            }
            else if (taglia != EnumWebApp.Taglia.NonTaglia)
            {
                prodottiFiltrati = prodottiFiltrati.Where(p => p.Taglia == taglia).ToList();
            }
            return prodottiFiltrati;
        }

        public async Task<List<Prodotto>> RicercaProdottiBarra(string nomeRicerca)
        {
            var lista = await _dbContext.Prodotti.ToListAsync();

            if (!string.IsNullOrEmpty(nomeRicerca))
            {
                lista = lista.Where(p => p.Nome.ToLower().Contains(nomeRicerca.ToLower())).ToList();
            }

            return lista;
        }

        public async Task EliminaProdotto(Prodotto prodottoEliminato, int quantita)
        {
            var prodottoEsistente = _dbContext.Prodotti.FirstOrDefault(p => p.IDProdotto == prodottoEliminato.IDProdotto);
            if (prodottoEliminato != null && prodottoEliminato.Quantita - quantita <= 0)
            {
                _dbContext.Prodotti.Remove(prodottoEliminato);
                await _dbContext.SaveChangesAsync();
            }
            else { prodottoEliminato.Quantita -= quantita; }
            await _dbContext.SaveChangesAsync();
        }
        public async Task AggiungiProdottoAsync(Prodotto prodotto)
        {
            var prodottoEsistente = await _dbContext.Prodotti.FirstOrDefaultAsync(p =>
            p.Nome == prodotto.Nome &&
            p.Descrizione == prodotto.Descrizione &&
            p.Prezzo == prodotto.Prezzo &&
            p.Categoria == prodotto.Categoria &&
            p.Taglia == prodotto.Taglia &&
            p.Colore == prodotto.Colore);
            if (prodottoEsistente!=prodotto)
            {
                await _dbContext.Prodotti.AddAsync(prodotto);
            }
            else
            {
                prodottoEsistente.Quantita = +prodotto.Quantita;
            }
            await _dbContext.SaveChangesAsync();
        }
        public async Task AggiornaProdotto(Prodotto prodottoAggiornato)
        {
            var prodottoEsistente = _dbContext.Prodotti.FirstOrDefault(p => p.IDProdotto == prodottoAggiornato.IDProdotto);

            if (prodottoEsistente != null)
            {
                prodottoEsistente.Nome = prodottoAggiornato.Nome;
                prodottoEsistente.Immagine = prodottoAggiornato.Immagine;
                prodottoEsistente.Descrizione = prodottoAggiornato.Descrizione;
                prodottoEsistente.Prezzo = prodottoAggiornato.Prezzo;
                prodottoEsistente.Quantita = prodottoAggiornato.Quantita;
                prodottoEsistente.Categoria = prodottoAggiornato.Categoria;
                prodottoEsistente.Taglia = prodottoAggiornato.Taglia;
                prodottoEsistente.Colore = prodottoAggiornato.Colore;

                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Il prodotto da aggiornare non è stato trovato nel database.");
            }
        }


        public bool ControlloCampi(string nome, string descrizione, string prezzo, string quantita, string colore, string taglia, string categoria)
        {
            // Verifica se il nome è vuoto o null
            if (string.IsNullOrEmpty(nome) && string.IsNullOrEmpty(prezzo) && string.IsNullOrEmpty(prezzo.ToString()) && string.IsNullOrEmpty(quantita) && string.IsNullOrEmpty(colore)
                && string.IsNullOrEmpty(this.VerificaTaglia(taglia)) && string.IsNullOrEmpty(this.VerificaCategoria(categoria)))
            {
                return false;
            }

            return true;
        }

        public string VerificaTaglia(string taglia)
        {
            switch (taglia)
            {
                case nameof(EnumWebApp.Taglia.XXS):
                case nameof(EnumWebApp.Taglia.XS):
                case nameof(EnumWebApp.Taglia.S):
                case nameof(EnumWebApp.Taglia.M):
                case nameof(EnumWebApp.Taglia.L):
                case nameof(EnumWebApp.Taglia.XL):
                case nameof(EnumWebApp.Taglia.XXL):
                    // La stringa corrisponde a un valore dell'enum Taglia
                    return taglia;
                default:
                    // La stringa non corrisponde a nessun valore dell'enum Taglia
                    return null;
            }
        }
        public string VerificaCategoria(string categoria)
        {
            switch (categoria)
            {
                case nameof(EnumWebApp.Categoria.Maglia):
                case nameof(EnumWebApp.Categoria.Pantalone):
                case nameof(EnumWebApp.Categoria.Giacca):
                case nameof(EnumWebApp.Categoria.Felpa):
                case nameof(EnumWebApp.Categoria.Camicia):
                case nameof(EnumWebApp.Categoria.Maglione):
                case nameof(EnumWebApp.Categoria.Tuta):
                    // La stringa corrisponde a un valore dell'enum Categoria
                    return categoria;
                default:
                    // La stringa non corrisponde a nessun valore dell'enum Categoria
                    return null;
            }
        }
        



        // <--------------------- parte dei controller da aggiungere ai servizi ------------------------------------->
        //public async Task<IActionResult> Filter(string searchString)
        //{
        //    var allMovies = await _service.GetAllAsync(n => n.Cinema);

        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

        //        var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

        //        return View("Index", filteredResultNew);
        //    }

        //    return View("Index", allMovies);
        //}

        ////GET: Movies/Details/1
        //[AllowAnonymous]
        //public async Task<IActionResult> Details(int id)
        //{<
        //    var movieDetail = await _service.GetMovieByIdAsync(id);
        //    return View(movieDetail);
        //}

        ////GET: Movies/Create
        //public async Task<IActionResult> Create()
        //{
        //    var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

        //    ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        //    ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        //    ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(NewMovieVM movie)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

        //        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        //        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        //        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        //        return View(movie);
        //    }

        //    await _service.AddNewMovieAsync(movie);
        //    return RedirectToAction(nameof(Index));
        //}


        ////GET: Movies/Edit/1
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var movieDetails = await _service.GetMovieByIdAsync(id);
        //    if (movieDetails == null) return View("NotFound");

        //    var response = new NewMovieVM()
        //    {
        //        Id = movieDetails.Id,
        //        Name = movieDetails.Name,
        //        Description = movieDetails.Description,
        //        Price = movieDetails.Price,
        //        StartDate = movieDetails.StartDate,
        //        EndDate = movieDetails.EndDate,
        //        ImageURL = movieDetails.ImageURL,
        //        MovieCategory = movieDetails.MovieCategory,
        //        CinemaId = movieDetails.CinemaId,
        //        ProducerId = movieDetails.ProducerId,
        //        ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
        //    };

        //    var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
        //    ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        //    ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        //    ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        //    return View(response);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        //{
        //    if (id != movie.Id) return View("NotFound");

        //    if (!ModelState.IsValid)
        //    {
        //        var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

        //        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        //        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        //        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        //        return View(movie);
        //    }

        //    await _service.UpdateMovieAsync(movie);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}

