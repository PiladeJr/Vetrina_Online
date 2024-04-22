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
La tipologia di progetto scelta è una multipage application, la quale è in grado di separare la logica di presentazione dei dati dalla logica di business.
Nello specifico una multipage application è un tipo di applicazione web composta da diverse pagine HTML separate, ciascuna dedicata a una parte specifica dell'applicazione.
A differenza delle single page applications (SPA), dove tutto il contenuto è caricato dinamicamente su una sola pagina, le multipage applications offrono una navigazione più tradizionale attraverso le varie sezioni dell'applicazione.
Mentre le SPA sono ideali per applicazioni altamente interattive, le multipage applications sono più adatte per progetti con una vasta gamma di funzionalità o che richiedono una migliore ottimizzazione per i motori di ricerca, poiché ogni pagina può essere ottimizzata individualmente.

### Models
I modelli definiti nel nostro progetto sono:
- **Lista** con i seguenti attributi: IDLista, ListaProdotti, QuantitaProdotti, PrezzoTotale, Id, UtenteAssociato
- **Prodotto** con i seguenti attributi: IDProdotto, Nome, Descrizione, Prezzo, Quantita, Categoria, Marchio, DataCreazione, DataUltimaModifica, Taglia, Colore, Materiale, Disponibilita, IDLista, listaAssociata
- **Utente** con i seguenti attributi: Nome, Cognome, DataNascita, isAdmin

### View
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

### Controller
Nel nostro progetto, per la sezione dei controller, abbiamo usato HomeController per la navigazione all’interno dell’applicativo e successivamente abbiamo aggiunto un controller per ogni modello al fine di poter gestire l’interazione con le singole pagine.

## Layout e Stile
Per la parte stilistica, abbiamo deciso di utilizzare le librerie di Bootstrap per modellare l’estetica dell’applicativo. Abbiamo puntato ad uno stile minimale con un'interfaccia avente angoli smussati, con prevalenza dei colori bianco, grigio chiaro e blu scuro. La navbar in alto consente la navigazione all’interno dell’applicativo mentre l’homepage per la visualizzazione dei prodotti è stata strutturata a schede contenenti l’immagine del prodotto, le informazioni principali ed un bottone che consente di aggiungere il prodotto alla lista.

## Autenticazione
Abbiamo usato Identity di Microsoft come servizio perché offre un'infrastruttura robusta e scalabile per la gestione delle identità degli utenti, semplificando il processo di autenticazione e migliorando la sicurezza del nostro applicativo.
Gli utenti sono stati invitati a registrarsi sulla piattaforma fornendo informazioni personali, come nome, email e password. Queste informazioni sono state poi gestite dal servizio di identità.
Gli utenti hanno accesso alla piattaforma tramite l'autenticazione delle loro credenziali. Il servizio di identità verifica le credenziali fornite e genera un token di accesso per gli utenti autorizzati.
Non è necessaria l’autenticazione per poter interagire con la piattaforma, infatti gli utenti potranno visualizzare l’homepage senza nessuna limitazione, al contrario del carrello che non potrà essere visualizzato se non grazie all’autenticazione.

## Database
Nell'ambito di questo progetto, è stato adottato SQL Server come sistema di gestione dei database, integrato con l'utilizzo di DbContext per l'interazione con il database tramite il framework Entity Framework.
SQL Server offre una solida infrastruttura per la gestione e l'archiviazione dei dati, con funzionalità avanzate per garantire l'affidabilità, la sicurezza e le prestazioni ottimali. DbContext, d'altra parte, funge da ponte tra l'applicazione e il database, facilitando le operazioni di accesso, modifica e manipolazione dei dati attraverso un'interfaccia orientata agli oggetti.
Questa combinazione di tecnologie fornisce un ambiente robusto e scalabile per la gestione dei dati, consentendo un rapido sviluppo delle applicazioni e un'efficace gestione del ciclo di vita dei dati.

## Sicurezza
Nel contesto della sicurezza per il nostro applicativo, è stata adottato un approccio olistico per proteggere l'applicazione e i dati sensibili. Per garantire la sicurezza delle credenziali degli utenti, è stata utilizzata la libreria di Identity, che offre robusti meccanismi di autenticazione e autorizzazione, incluso l'hashing delle password per proteggere le informazioni sensibili.
Inoltre, per prevenire attacchi di tipo SQL injection, sono stati implementati rigorosi controlli di validazione dei dati in ingresso e l'utilizzo di query parametrizzate per evitare l'esecuzione di istruzioni SQL non autorizzate.
Infine, per gestire l'autenticazione degli utenti e mantenere lo stato delle sessioni in modo sicuro, sono stati utilizzati cookie crittografati, che consentono di mantenere l'integrità dei dati tra il client e il server durante le interazioni dell'utente con l'applicazione. Queste misure combinano tecnologie e pratiche avanzate per garantire un ambiente sicuro e affidabile per l'applicazione e i suoi utenti.
