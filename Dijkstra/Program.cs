using System;

namespace Dijkstra
{
    class Program
    {
        static int nRouter = 9;
        public static void Main()
        {
            int[,] grafo = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            dijkstra(grafo, 0);
        }
        private static int minDistanza(int[] dist, bool[] sptSet)
        {
            // Inizializzazione del valore minimo
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < nRouter; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        // Una funzione per stampare l'array di distanza costruito
        private static void mostraSoluzione(int[] dist)
        {
            Console.Write("Step \t\t Costo\n");
            for (int i = 0; i < nRouter; i++)
                Console.Write(i + " \t\t " + dist[i] + "\n");
        }

        // Funzione che implementa l'algoritmo del percorso minimo a
        // sorgente singola di Dijkstra per un grafico rappresentato
        // utilizzando la rappresentazione della matrice di adiacenza
        private static void dijkstra(int[,] grafo, int src)
        {
            // L'array di output. dist[i] manterrà la
            // distanza più breve da src a i
            int[] dist = new int[nRouter];

            // sptSet[i] sarà vero se il vertice i è incluso nell'albero
            // del percorso più breve o se la distanza più breve da src a i è finalizzata
            bool[] sptSet = new bool[nRouter];

            // Inizializza tutte le distanze
            // come INFINITE e stpSet[] come false
            for (int i = 0; i < nRouter; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            // La distanza del vertice sorgente da se stesso è sempre 0
            dist[src] = 0;

            // Trova il percorso più breve per tutti i vertici
            for (int count = 0; count < nRouter - 1; count++)
            {
                // Sceglie il vertice della distanza minima dall'insieme dei vertici non
                // ancora elaborati. u è sempre uguale a src nella prima iterazione.
                int u = minDistanza(dist, sptSet);

                // Contrassegna il vertice selezionato come elaborato
                sptSet[u] = true;

                // Aggiorna il valore dist dei vertici adiacenti del vertice selezionato.
                for (int v = 0; v < nRouter; v++)

                    // Aggiorna dist[v] solo se non è in sptSet, c'è un arco da u a v e il peso totale
                    // del percorso da src a v attraverso u è minore del valore corrente di dist[v]
                    if (!sptSet[v] && grafo[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + grafo[u, v] < dist[v])
                        dist[v] = dist[u] + grafo[u, v];
            }

            // stampa l'array della distanza costruita
            mostraSoluzione(dist);
        }
    }
}