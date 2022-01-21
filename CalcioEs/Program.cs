using System;

namespace Calcio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quante partite ha vinto il Milan?");//domanda all'utente quante partite ha vinto il Milan
            int partiteVinte = int.Parse(Console.ReadLine());//inizializza la variabile "partiteVinte" con il valore che
                                                             //riceve in input da parte dell'utente pari al quantitativo di partite vinte dal Milan
            Console.WriteLine("Quante partite ha pareggiato il Milan?");//domanda all'utente quante partite ha pareggiato il Milan
            int partitePareggiate = int.Parse(Console.ReadLine());//inizializza la variabile "partitePareggiate" con il valore che
                                                                  //riceve in input da parte dell'utente pari al quantitativo di partite pareggiate dal Milan
            Console.WriteLine("Quante partite ha perso il Milan?");//domanda all'utente quante partite ha perso il Milan
            int partitePerse = int.Parse(Console.ReadLine());//inizializza la variabile "partitePerse" con il valore che
                                                             //riceve in input da parte dell'utente pari al quantitativo di partite perse dal Milan
            Squadra Milan = new Squadra();//crea l'oggetto Milan della classe Squadra
            Milan.InizioAnno();//invoca la funzione InizioAnno della classe Squadra che permette di inizializzare tutti gli attributi della classe
            Milan.SetPartite(partiteVinte, partitePareggiate, partitePerse);//passa alla funzione SetPartite della classe Squadra i valori presi in input dall'utente
                                                                            //corrispondenti ai valori di: partite vinte, partite pareggiate e parite perse della squadra Milan

            Console.WriteLine("Quante partite ha vinto la Juventus?");//domanda all'utente quante partite ha vinto la Juventus
            partiteVinte = int.Parse(Console.ReadLine());//cambia il valore della variabile "partiteVinte" con il valore che
                                                         //riceve in input da parte dell'utente pari al quantitativo di partite vinte dalla Juventus
            Console.WriteLine("Quante partite ha pareggiato la Juventus?");//domanda all'utente quante partite ha pareggiato la Juventus
            partitePareggiate = int.Parse(Console.ReadLine());//cambia il valore della variabile "partitePareggiate" con il valore che
                                                              //riceve in input da parte dell'utente pari al quantitativo di partite pareggiate dalla Juventus
            Console.WriteLine("Quante partite ha perso la Juventus?");//domanda all'utente quante partite ha perso la Juventus
            partitePerse = int.Parse(Console.ReadLine());//cambia il valore della variabile "partitePerse" con il valore che
                                                         //riceve in input da parte dell'utente pari al quantitativo di partite perse dalla Juventus
            Squadra Juventus = new Squadra();//crea l'oggetto Juventus della classe Squadra
            Juventus.InizioAnno();//invoca la funzione InizioAnno della classe Squadra che permette di inizializzare tutti gli attributi della classe
            Juventus.SetPartite(partiteVinte, partitePareggiate, partitePerse);//passa alla funzione SetPartite della classe Squadra i valori presi in input dall'utente
                                                                               //corrispondenti ai valori di: partite vinte, partite pareggiate e parite perse della squadra Juventus

            Console.WriteLine($"Partita Milan - Juventus");//avvisa l'utente che c'è la partita Milan contro Juventus

            Console.WriteLine("Quanti goal ha fatto il Milan?");//domanda all'utente quanti goal ha segnato il Milan
            int gF = int.Parse(Console.ReadLine());//inizializza la variabile "gF" con il valore che
                                                   //riceve in input da parte dell'utente pari al quantitativo di goal segnati dal Milan
            Console.WriteLine("Quanti goal ha subito il Milan?");//domanda all'utente quanti goal ha subito il Milan
            int gS = int.Parse(Console.ReadLine());//inizializza la variabile "gS" con il valore che
                                                   //riceve in input da parte dell'utente pari al quantitativo di goal subiti dal Milan
            int partitaMilan = Milan.Partita(gF, gS);//invoca la funzione "Partita" della classe Squadra e gli passa per parametro i valori dei goalFatti e goalSubiti del Milan
                                                     //e restituisce un valore di ritorno in int32

            Console.WriteLine("Quanti goal ha fatto la Juventus?");//domanda all'utente quanti goal ha segnato la Juventus
            gF = int.Parse(Console.ReadLine());//cambia il valore della variabile "gF" con il valore che
            Console.WriteLine("Quanti goal ha subito la Juventus?");//domanda all'utente quanti goal ha subito la Juventus
            gS = int.Parse(Console.ReadLine());//cambia il valore della variabile "gS" con il valore che
                                               //riceve in input da parte dell'utente pari al quantitativo di goal subiti dal Milan
            int partitaJuventus = Juventus.Partita(gF, gS);//invoca la funzione "Partita" della classe Squadra e gli passa per parametro i valori dei goalFatti e goalSubiti della Juventus
                                                           //e restituisce un valore di ritorno in int32

            if (partitaMilan > partitaJuventus)//controlla i valori che le rispettive squadre hanno ricevuto in ritorno e controlla se quello del Milan, di valore, è maggiore rispetto a quello della Juventus
                Console.WriteLine("Ha vinto il Milan");//la partita l'ha vinta il Milan
            else if (partitaMilan < partitaJuventus)//controlla i valori che le rispettive squadre hanno ricevuto in ritorno e controlla se quello della Juventus, di valore, è maggiore rispetto a quello del Milan
                Console.WriteLine("Ha vinto la Juventus");//la partita l'ha vinta la Juventus
            else//questo è il caso in cui i valori delle due squadre sono uguali
                Console.WriteLine("Le due squadre hanno pareggiato");//la partita si è risolta in un pareggio

            Console.WriteLine($"Il Milan ha: {Milan.Punti()} in campionato");//viene mostrato a schermo il quantitativo di punti che detiene il Milan nel campionato, invocando la funzione Punti della classe Squadra
            Console.WriteLine($"La Juventus ha: {Juventus.Punti()} in campionato");//viene mostrato a schermo il quantitativo di punti che detiene la Juventus nel campionato, invocando la funzione Punti della classe Squadra

            Console.WriteLine($"Premi qualsiasi tasto della tastiera per uscire dal programma");//l'utente viene avvisato che se vuole chiudere il programma basta che prema un qualsivoglia tasto appartenete alla tastiera
            Console.ReadKey();//il programma aspetta che l'utente prema qualsiasi tasto della tastiera per chiudere il programma
        }
    }
    class Squadra
    {
        int partiteVinte, partitePareggiate, partitePerse, punti, goalFatti, goalSubiti;//attributi della classe Squadra
        public Squadra()//costruttore della classe Squadra
        {
        }
        public void InizioAnno()//permette di inizializzare gli attributi della classe impostando il loro valore a 0
        {
            this.partiteVinte = 0;//imposta il valore dell'attributo "partiteVinte" a 0
            this.partitePareggiate = 0;//imposta il valore dell'attributo "partitePareggiate" a 0
            this.partitePerse = 0;//imposta il valore dell'attributo "partitePerse" a 0
            this.punti = 0;//imposta il valore dell'attributo "punti" a 0
        }
        public void SetPartite(int pV, int pPa, int pPe)//imposta gli attributi, partiteVinte, partitePareggiate e partitePerse il valore che viene passato per parametro quando la funzione viene invocata
        {
            this.partiteVinte = pV;//imposta il valore dell'attributo "partiteVinte" pari a pV
            this.partitePareggiate = pPa;//imposta il valore dell'attributo "partitePareggiate" pari a pPa
            this.partitePerse = pPe;//imposta il valore dell'attributo "partitePerse" pari a pPe
        }
        public int Punti()//calcola e ritorna, quando viene invocata, un valore corrispondenete al punteggio di una squadra nel campionato
        {
            this.punti += this.partiteVinte * 3;//imposta il valore del'attributo "punti" della classe Squadra, la somma tra il valore del medesimo attributo e il triplo del quantitativo di partiteVinte
            this.punti += this.partitePareggiate;//imposta il valore del'attributo "punti" della classe Squadra, la somma tra il valore del medesimo attributo e il quantitativo di partitePareggiate
            return this.punti;//ritorna il valore dell'attributo "punti"
        }
        private void GoalFatto(int gF)//si occupa di impostare il valore dei goalFatti di una squadra
        {
            this.goalFatti = gF;//imposta il valore del'attributo "goalFatti" pari al parametro gF
        }
        private void GoalSubito(int gS)//si occupa di impostare il valore dei goalSubiti di una squadra
        {
            this.goalSubiti = gS;//imposta il valore del'attributo "goalSubiti" pari al parametro gS
        }
        public int Partita(int gF, int gS)//ritorna un determinato valore a seconda del risultato di una "partita" giocata da una determinata squadra
        {
            this.goalFatti = 0;//inizializza il valore dell'attributo "goalFatti" a 0
            this.goalSubiti = 0;//inizializza il valore dell'attributo "goalSubiti" a 0
            GoalFatto(gF);//invoca la funzione GoalFatto e gli passa un valore per parametro, che equivale ai goal segnati da una squadra
            GoalSubito(gS);//invoca la funzione GoalSubito e gli passa un valore per parametro, che equivale ai goal subiti da una squadra
            if (this.goalFatti > this.goalSubiti)//controlla se il valore dei goalFatti è maggiore di quello dei goalSubiti
            {
                this.partiteVinte++;//la squadra ha segnato più goal rispetto a quelli che ha subito, quindi ha per forza di cose vinto
                return 1;//ritorna il valore int32 pari a 1
            }
            else if(this.goalFatti < this.goalSubiti)//controlla se il valore dei goalFatti è minore di quello dei goalSubiti
            {
                this.partitePerse++;//la squadra ha subito più goal rispetto a quelli che ha segnato, quindi ha per forza di cose perso
                return -1;//ritorna il valore int32 pari a -1
            }
            this.partitePareggiate++;//la squadra ha subito lo stesso numero di goal rispetto a quelli che ha segnato, quindi ha pareggiato
            return 0;//ritorna il valore int32 pari a 0
        }
    }
}
