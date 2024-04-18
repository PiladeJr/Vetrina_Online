# Progetto Applicazioni Web e Mobile: StyleHub
Link per la documentazione: https://onedrive.live.com/edit?id=8AEB47976EEA3C2!127&resid=8AEB47976EEA3C2!127&ithint=file%2cdocx&authkey=!ACCvxwvsSYPrMfo&wdo=2&cid=08aeb47976eea3c2
## Membri gruppo

- Lotito Davide [114627]
- Tommasini Pilade Jr [122086]
- Di Pietro Leonardo [119025]
- Salvucci Federica [118618]

## Descrizione
Svilupperemo un'applicazione web per una vetrina d'abbigliamento online fittizia, consentendo agli utenti di visualizzare e prenotare capi d'abbigliamento per il ritiro successivo in negozio. Gli utenti potranno navigare tra i prodotti, aggiungerli ad una lista e procedere con l'ordine in una pagina dedicata. Al ricevimento dell'ordine, il negozio si occuperà esclusivamente di preparare l'ordine per il cliente che lo ritirerà in negozio. Le entità pensate per lo sviluppo di tale applicativo sono:

### Utente
- **Registrarsi:** Creare un account fornendo le informazioni richieste.
- **Accedere:** Accedere al proprio account inserendo le credenziali.
- **Visualizzare prodotti:** Esplorare i prodotti disponibili nel catalogo del negozio, con la possibilità di specificare un filtro di ricerca.
- **Aggiungere alla lista:** Aggiungere prodotti ad una lista temporanea direttamente dal catalogo.
- **Visualizzare lista:** Visualizzare la lista dei prodotti aggiunti.
- **Modificare lista:** Modificare la lista, aggiungendo o rimuovendo prodotti.
- **Invio lista:** Inviare la lista dei prodotti al negozio per il ritiro.

### Prodotto
- **Visualizzare dettagli:** Visualizzare i dettagli completi di ciascun prodotto nel catalogo.

### Negozio
- **Ricevere ordini:** Ricevere le liste ordinate dagli utenti.
- **Preparare ordini:** Preparare gli ordini per il ritiro in negozio da parte degli utenti.
- **Confermare ordini pronti:** Confermare agli utenti quando i loro ordini sono pronti per il ritiro.

### Lista ordini
- **Aggiungere prodotti:** Aggiungere prodotti alla lista durante la navigazione nel catalogo.
- **Visualizzare lista:** Visualizzare il contenuto della lista, con i prodotti selezionati e le relative quantità.
- **Modificare lista:** Modificare le quantità dei prodotti nella lista o rimuovere prodotti.
- **Svuotare lista:** Rimuovere tutti i prodotti dalla lista in una sola operazione.

### Amministratore
- **Gestire prodotti:** Aggiungere, modificare o rimuovere prodotti dal catalogo del negozio.
- **Visualizzare ordini:** Visualizzare gli ordini ricevuti dagli utenti, con dettagli come la lista dei prodotti ordinati e lo stato dell'ordine.
- **Confermare ordini:** Confermare gli ordini pronti per il ritiro da parte degli utenti.

## Tecnologie Utilizzate
- **Framework:** ASP.NET Core per lo sviluppo web.
- **Front-End:** HTML5, CSS3, Bootstrap.
- **Back-End:** C#.
- **Database:** Microsoft SQL Server.
- **Bootstrap:** Utilizziamo Bootstrap per garantire la piena responsività della nostra applicazione web, consentendo agli utenti di accedere al nostro sito da qualsiasi dispositivo.
- **Caratteristiche:** applicazione web multipage, MVC.
- **Sicurezza:**

## Tipologia di progetto
La tipologia di progetto scelta è una multipage application, la quale è in grado di separare la logica di presentazione dei dati dalla logica di business.

## Models
I modelli definiti nel nostro progetto sono:
- **Lista** con i seguenti attributi: IDLista, ListaProdotti, QuantitaProdotti, PrezzoTotale, Id, UtenteAssociato
- **Prodotto** con i seguenti attributi: IDProdotto, Nome, Descrizione, Prezzo, Quantita, Categoria, Marchio, DataCreazione, DataUltimaModifica, Taglia, Colore, Materiale, Disponibilita, IDLista, listaAssociata
- **Utente** con i seguenti attributi: Nome, Cognome, DataNascita, isAdmin

## View
Le view sono state implementate con l’ausilio della sintassi Razor. Le classi sono così divise:
- ForgotPassword
- Login
- Logout
- Register
- ResetPassword
- AreaPersonale
- Carrello
- Index
- Prodotti

## Controller
Nel nostro progetto, per la sezione dei controller, abbiamo usato HomeController per la navigazione all’interno dell’applicativo e successivamente abbiamo aggiunto un controller per ogni modello al fine di poter gestire l’interazione con le singole pagine.

## Layout e Stile
Per la parte stilistica, abbiamo deciso di utilizzare le librerie di Bootstrap per modellare l’estetica dell’applicativo. Abbiamo puntato ad uno stile minimale con un'interfaccia avente angoli smussati, con prevalenza dei colori bianco, grigio chiaro e blu scuro. La navbar in alto consente la navigazione all’interno dell’applicativo mentre l’homepage per la visualizzazione dei prodotti è stata strutturata a schede contenenti l’immagine del prodotto, le informazioni principali ed un bottone che consente di aggiungere il prodotto alla lista.

## Autenticazione


## Database
