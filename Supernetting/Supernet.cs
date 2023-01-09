class Supernet : IPv4
{
    //Questa funzione prende come input una matrice di indirizzi IPv4 e restituisce un indirizzo supernet. 
    //Si inizia convertendo tutti gli indirizzi in stringhe binarie e sostituendo i punti con una stringa vuota. 
    //Una volta fatto, si esegue un'operazione AND binaria su tutti gli indirizzi. Infine, gli indirizzi 
    //vengono convertiti nuovamente in una stringa con i punti. Questa stringa è l'indirizzo supernet.
    public static byte[] GetSupernetAddress(byte[][] addresses)
    {
        string firstAddressStr = IPv4.OctalIPToBinaryString(addresses[0]).Replace(".", "");

        for (int i = 1; i < addresses.Length; i++)
        {
            string tmp = "";
            string ip = IPv4.OctalIPToBinaryString(addresses[i]).Replace(".", "");
            for (int j = 0; j < 32; j++)
            {
                tmp += AndOperation(firstAddressStr[j], ip[j]);
            }
            firstAddressStr = tmp;
        }

        firstAddressStr = AddDotts(firstAddressStr);
        //Console.WriteLine(firstAddressStr);

        return IPv4.OctalStringBinaryToOctalIP(firstAddressStr);
    }

    //Questa funzione opera su una lista di indirizzi IP e su un indirizzo di supernet. 
    //Verifica a quale punto gli indirizzi IP e il supernet corrispondono. 
    //Restituisce la lunghezza del CIDR più corto che contiene tutti gli indirizzi IP.
    public static int GetSupernetCIDR(byte[][] addresses, byte[] supernetAddr)
    {
        int min = 32;
        string supernetAddrStr = IPv4.OctalIPToBinaryString(supernetAddr).Replace(".", "");

        for (int i = 0; i < addresses.Length; i++)
        {
            int n = 0;
            string ip = IPv4.OctalIPToBinaryString(addresses[i]).Replace(".", "");
            for (int j = 0; j < 32; j++)
            {
                if (supernetAddrStr[j] == ip[j])
                    n++;
                else
                    break;
            }
            if (n < min)
                min = n;
        }

        return min;
    }
}