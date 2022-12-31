/*
Questo codice consente all'utente di inserire una serie di indirizzi IP, in formato decimale, separati da una virgola. 
Una volta inseriti tutti gli indirizzi, il codice esegue un calcolo per determinare la rete supernet di tutti 
gli indirizzi inseriti. 

Inizialmente, una matrice di byte, chiamata indirizzi, viene inizializzata come una matrice vuota. 
Un ciclo do-while viene quindi eseguito, che continua fino a quando l'utente non inserisce "stop". 
Per ogni indirizzo inserito, la matrice "indirizzi" viene ridimensionata di una unità, per contenere 
l'indirizzo IP inserito. Quindi, l'indirizzo viene verificato utilizzando la funzione IPv4.VerifyIPAddress, 
che restituisce true o false a seconda che l'indirizzo sia valido o meno. Se l'indirizzo è valido, 
viene convertito in una matrice di byte utilizzando la funzione IPv4.OctalStringToOctalIP e poi 
immagazzinato nella matrice "indirizzi".

Dopo che l'utente ha inserito tutti gli indirizzi, viene eseguito un calcolo per calcolare la rete supernet 
di tutti gli indirizzi inseriti. Questo viene fatto utilizzando le funzioni IPv4.GetSupernetAddress 
e IPv4.GetSupernetCIDR. La prima funzione restituisce l'indirizzo IP della rete supernet come matrice di byte, 
mentre la seconda restituisce il CIDR associato. Infine, i risultati vengono convertiti in formato decimale e 
stampati sullo schermo.
*/

byte[][] indirizzi = new byte[0][];
do
{
    Console.WriteLine("Inserisci un indirizzo IP, in formato decimal dotted");
    string ipAddress = Console.ReadLine();
    if (ipAddress.ToLower() != "stop")
    {
        Array.Resize<byte[]>(ref indirizzi, indirizzi.Length + 1);

        if (!IPv4.VerifyIPAddress(ipAddress))
        {
            Console.WriteLine("Indirizzo IP errato");
            return;
        }

        byte[] addressIP = IPv4.OctalStringToOctalIP(ipAddress);
        indirizzi[indirizzi.Length - 1] = addressIP;
    }
    else
        break;
} while (true);

byte[] supernetIP = IPv4.GetSupernetAddress(indirizzi);
int SuperCIDR = IPv4.GetSupernetCIDR(indirizzi, supernetIP);
Console.WriteLine(IPv4.OctalIPToOctalString(supernetIP) + "/" + SuperCIDR);