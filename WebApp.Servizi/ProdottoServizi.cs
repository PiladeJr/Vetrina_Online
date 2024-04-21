using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Enum;
using WebApp.Modelli;

namespace WebApp.Servizi
{
    public class ProdottoServizi
    {
        private readonly ApplicationDbContext _dbContext;

        public ProdottoServizi(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  List<Prodotto>GetProdotti()
        {
            return  _dbContext.Prodotti.ToList();
        }

        public Prodotto GetProdottoById(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("ID non valido");
            }
            return _dbContext.Prodotti.FirstOrDefault(p => p.IDProdotto == id);
        }
        public List<Prodotto> FiltraProdotti(EnumWebApp.Categoria? categoria, EnumWebApp.Taglia? taglia)
        {
            IQueryable<Prodotto> prodottiFiltrati = _dbContext.Prodotti;

            if (categoria != null)
            {
                prodottiFiltrati = prodottiFiltrati.Where(p => p.Categoria == categoria);
            }

            if (taglia != null)
            {
                prodottiFiltrati = prodottiFiltrati.Where(p => p.Taglia == taglia);
            }

            return prodottiFiltrati.ToList();
        }

        public List<Prodotto> RicercaProdottiBarra(string nomeRicerca)
        {
            IQueryable<Prodotto> elencoProdotti = _dbContext.Prodotti;

            if (!string.IsNullOrEmpty(nomeRicerca))
            {
                elencoProdotti = elencoProdotti.Where(p => p.Nome.Contains(nomeRicerca));
            }

            return elencoProdotti.ToList();
        }

        /*public async Task AggiungiProdottoAsync(Guid idUtente, Prodotto prodotto)
        {
            var utente = await _dbContext.Utenti.FirstOrDefaultAsync(u => u.Id.Equals(idUtente));
            var lista = _dbContext.Lista.FirstOrDefault(l =>
            l.ListaProdotti.ToList().Any(p => p.IDProdotto.Equals(prodotto.IDProdotto)));
            if (lista == null && utente != null)
            {
                var newList = new Lista();
                newList.ListaProdotti.Add(prodotto);
                newList.UtenteAssociato = utente;
            }
            {

            }
            if (prodotto != null)
            {
                _dbContext.Prodotti.Add(prodotto);
            }
            _dbContext.SaveChanges();
        }*/

        public void AggiornaProdotto(Prodotto prodotto)
        {
            _dbContext.Entry(prodotto).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void EliminaProdotto(Guid id)
        {
            var prodotto = _dbContext.Prodotti.Find(id);
            if (prodotto != null)
            {
                _dbContext.Prodotti.Remove(prodotto);
                _dbContext.SaveChanges();
            }
        }

        //public async Task AddNewMovieAsync(NewMovieVM data)
        //{
        //    var newMovie = new Movie()
        //    {
        //        Name = data.Name,
        //        Description = data.Description,
        //        Price = data.Price,
        //        ImageURL = data.ImageURL,
        //        CinemaId = data.CinemaId,
        //        StartDate = data.StartDate,
        //        EndDate = data.EndDate,
        //        MovieCategory = data.MovieCategory,
        //        ProducerId = data.ProducerId
        //    };
        //    await _context.Movies.AddAsync(newMovie);
        //    await _context.SaveChangesAsync();

        //    //Add Movie Actors
        //    foreach (var actorId in data.ActorIds)
        //    {
        //        var newActorMovie = new Actor_Movie()
        //        {
        //            MovieId = newMovie.Id,
        //            ActorId = actorId
        //        };
        //        await _context.Actors_Movies.AddAsync(newActorMovie);
        //    }
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<Movie> GetMovieByIdAsync(int id)
        //{
        //    var movieDetails = await _context.Movies
        //        .Include(c => c.Cinema)
        //        .Include(p => p.Producer)
        //        .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
        //        .FirstOrDefaultAsync(n => n.Id == id);

        //    return movieDetails;
        //}

        //public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        //{
        //    var response = new NewMovieDropdownsVM()
        //    {
        //        Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
        //        Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
        //        Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
        //    };

        //    return response;
        //}

        //public async Task UpdateMovieAsync(NewMovieVM data)
        //{
        //    var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

        //    if (dbMovie != null)
        //    {
        //        dbMovie.Name = data.Name;
        //        dbMovie.Description = data.Description;
        //        dbMovie.Price = data.Price;
        //        dbMovie.ImageURL = data.ImageURL;
        //        dbMovie.CinemaId = data.CinemaId;
        //        dbMovie.StartDate = data.StartDate;
        //        dbMovie.EndDate = data.EndDate;
        //        dbMovie.MovieCategory = data.MovieCategory;
        //        dbMovie.ProducerId = data.ProducerId;
        //        await _context.SaveChangesAsync();
        //    }

        //    //Remove existing actors
        //    var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
        //    _context.Actors_Movies.RemoveRange(existingActorsDb);
        //    await _context.SaveChangesAsync();

        //    //Add Movie Actors
        //    foreach (var actorId in data.ActorIds)
        //    {
        //        var newActorMovie = new Actor_Movie()
        //        {
        //            MovieId = data.Id,
        //            ActorId = actorId
        //        };
        //        await _context.Actors_Movies.AddAsync(newActorMovie);
        //    }
        //    await _context.SaveChangesAsync();
        //}


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

