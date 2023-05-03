class IPv4
{
    // Questa funzione verifica che una stringa sia un indirizzo IP valido. 
    // Viene utilizzata la funzione Convert.ToByte per controllare che ogni ottetto (separato da un punto) sia un numero valido da 0 a 255. 
    // Se la lunghezza della stringa è diversa da 4, o se almeno uno dei valori non è un numero valido, la funzione restituisce false.
    // Altrimenti, restituisce true.
    public static bool VerifyIPAddress(string ipStr)
    {
        string[] octStr = ipStr.Split('.');
        if (octStr.Length != 4)
            return false;

        for (int i = 0; i < 4; i++)
            try
            {
                Convert.ToByte(octStr[i]);
            }
            catch
            {
                return false;
            }

        return true;
    }

    // Questa funzione verifica se una stringa rappresenta un valore valido per un CIDR.
    // La funzione converte la stringa in un numero intero e controlla che sia compreso tra 1 e 32.
    // Se il valore è valido, la funzione restituisce true, altrimenti false.
    public static bool VerifyCIDR(string cidrStr)
    {
        int cidrInt;
        if (!Int32.TryParse(cidrStr, out cidrInt))
        {
            return false;
        }
        if (cidrInt < 1 || cidrInt > 32)
            return false;
        return true;
    }

    /*
    Questa funzione ha come obiettivo quello di convertire un indirizzo IP da stringa ad un array di byte. 
    In particolare, la stringa, che rappresenta l'indirizzo IP, viene divisa in 4 parti, ognuna separata dal carattere '.', 
    che rappresenta la suddivisione dei numeri dell'indirizzo IP stesso. 
    Successivamente, per mezzo di un ciclo for, viene convertita ciascuna parte della stringa in un elemento dell'array di byte, 
    che rappresenta l'indirizzo IP. 
    Infine, la funzione ritorna l'array di byte appena creato.
    */
    public static byte[] OctalStringToOctalIP(string ipStr)
    {
        byte[] octalIP = new byte[4];
        string[] octalStr = ipStr.Split('.');

        for (int i = 0; i < 4; i++)
            octalIP[i] = Convert.ToByte(octalStr[i]);

        return octalIP;
    }

    //Questa funzione converte un indirizzo IP scritto in stringa (in notazione octale) in un array di byte.
    public static byte[] OctalStringBinaryToOctalIP(string ipStr)
    {
        byte[] octalIP = new byte[4];
        string[] octalStr = ipStr.Split('.');

        for (int i = 0; i < 4; i++)
        {
            byte total = 0;
            int index = 0;
            for (int j = 7; j >= 0; j--)
            {
                total += (byte)(Convert.ToInt32(octalStr[i][j] - '0') * Convert.ToInt32(Math.Pow(2, index)));
                index++;
            }
            octalIP[i] = total;
        }

        return octalIP;
    }

    /*
    Questa funzione converte un indirizzo IP da notazione ottale a notazione binaria. 
    Prende in input un array di byte che rappresenta l'indirizzo IP, poi, utilizzando un ciclo for, 
    converte ogni byte in una stringa binaria. Una volta convertiti tutti i byte, li concatena e 
    ritorna l'indirizzo IP completo in notazione binaria.
    */
    public static string OctalIPToBinaryString(byte[] ipByte)
    {
        int resto = 0;
        string[] ottetiStr = new string[4];
        string ipCompleto = "";

        for (int i = 0; i < 4; i++)
        {
            int num = Convert.ToInt32(ipByte[i]);
            for (int j = 0; j < 8; j++)
            {
                resto = num % 2;
                num /= 2;
                ottetiStr[i] = resto.ToString() + ottetiStr[i];
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if (i != 3)
                ipCompleto += ottetiStr[i] + ".";
            else
                ipCompleto += ottetiStr[i];
        }

        return ipCompleto;
    }

    //Questa funzione prende un array di byte come input e restituisce una stringa
    //rappresentante un indirizzo IP in notazione ottale. Scansiona l'array e concatena 
    //i valori separandoli con un punto. Alla fine, restituisce la stringa generata.
    public static string OctalIPToOctalString(byte[] ipByte)
    {
        string ipCompleto = "";

        for (int i = 0; i < 4; i++)
        {
            if (i != 3)
                ipCompleto += ipByte[i].ToString() + ".";
            else
                ipCompleto += ipByte[i].ToString();
        }

        return ipCompleto;
    }

    //Questa funzione calcola la maschera di sottorete in base al CIDR fornito come argomento. 
    //Divide il CIDR in due parti, una per i bit 1 e l'altra per i bit 0 e li concatena. 
    //Poi converte la stringa in una rappresentazione binaria e la restituisce come array di byte.
    public static byte[] GetSubnetMask(int CIDR)
    {
        string subnetMaskStr = "";
        string subnetStr_1 = "";
        string subnetStr_0 = "";

        for (int i = 0; i < CIDR; i++)
        {
            subnetStr_1 += "1";
        }
        for (int i = 0; i < 32 - CIDR; i++)
        {
            subnetStr_0 += "0";
        }

        string tmp = subnetStr_1 + subnetStr_0;

        for (int i = 0; i < 32; i++)
        {
            if (i == 8 || i == 16 || i == 24)
                subnetMaskStr += "." + tmp[i];
            else
                subnetMaskStr += tmp[i];
        }

        return IPv4.OctalStringBinaryToOctalIP(subnetMaskStr);
    }

    //Questa funzione calcola la wildcardmask in base al CIDR fornito come argomento. 
    //Divide il CIDR in due parti, una per i bit 0 e l'altra per i bit 1 e li concatena. 
    //Poi converte la stringa in una rappresentazione binaria e la restituisce come array di byte.
    public static byte[] GetWildCardMask(int CIDR)
    {
        string subnetMaskStr = "";
        string subnetStr_1 = "";
        string subnetStr_0 = "";

        for (int i = 0; i < CIDR; i++)
        {
            subnetStr_1 += "0";
        }
        for (int i = 0; i < 32 - CIDR; i++)
        {
            subnetStr_0 += "1";
        }

        string tmp = subnetStr_1 + subnetStr_0;

        for (int i = 0; i < 32; i++)
        {
            if (i == 8 || i == 16 || i == 24)
                subnetMaskStr += "." + tmp[i];
            else
                subnetMaskStr += tmp[i];
        }

        return IPv4.OctalStringBinaryToOctalIP(subnetMaskStr);
    }

    //Questa funzione calcola l'indirizzo di rete in base a un indirizzo IP e una maschera di sottorete. 
    //Si esegue un'operazione AND per ogni ottetto delle due stringhe e si concatena il risultato. 
    //Il risultato finale è un array di byte che rappresenta l'indirizzo di rete.
    public static byte[] GetNetworkAddress(byte[] ipByte, byte[] subnetMaskByte)
    {
        string networkAddressStr = "";
        string ipAddressStr = IPv4.OctalIPToBinaryString(ipByte).Replace(".", "");
        string subnetMaskStr = IPv4.OctalIPToBinaryString(subnetMaskByte).Replace(".", "");
        for (int i = 0; i < 32; i++)
        {
            if (i == 8 || i == 16 || i == 24)
                networkAddressStr += "." + AndOperation(ipAddressStr[i], subnetMaskStr[i]);
            else
                networkAddressStr += AndOperation(ipAddressStr[i], subnetMaskStr[i]);
        }
        return IPv4.OctalStringBinaryToOctalIP(networkAddressStr);
    }

    //Questa funzione calcola l'indirizzo broadcast a partire da un indirizzo di rete e un 
    //CIDR (Classless Inter-Domain Routing) fornito come input. Converte l'indirizzo di rete in una stringa binaria, 
    //quindi crea una stringa di broadcast andando a sostituire i bit a destra del CIDR con 1. 
    //La stringa binaria finale viene poi convertita in un indirizzo di rete in formato decimal dotted.
    public static byte[] GetBroadcastAddress(byte[] network, int CIDR)
    {
        string broadcastAddressStr = "";
        string ipAddressStr = IPv4.OctalIPToBinaryString(network).Replace(".", "");

        for (int i = 0; i < CIDR; i++)
        {
            broadcastAddressStr += ipAddressStr[i];
        }
        for (int i = 31; i >= CIDR; i--)
        {
            broadcastAddressStr += "1";
        }
        return IPv4.OctalStringBinaryToOctalIP(AddDotts(broadcastAddressStr));
    }

    //Questa funzione calcola l'intervallo di indirizzi host in una rete specificata da un indirizzo IP 
    //e un CIDR. Prima di tutto, l'indirizzo IP e il CIDR vengono convertiti in una stringa binaria. 
    //Quindi, la prima parte della stringa binaria corrisponde al CIDR. Il resto della stringa corrisponde 
    //all'intervallo di indirizzi host e viene compilato con "0" per l'indirizzo host iniziale e "1" per 
    //l'indirizzo host finale. Successivamente, la stringa binaria viene convertita in una stringa IP. 
    //Infine, la stringa IP viene convertita in un array di byte che rappresenta l'intervallo di indirizzi host.
    public static byte[][] GetHostRange(byte[] network, int CIDR)
    {
        byte[][] range = new byte[2][];
        string firstAddressStr = "";
        string lastAddressStr = "";
        string ipAddressStr = IPv4.OctalIPToBinaryString(network).Replace(".", "");

        for (int i = 0; i < CIDR; i++)
        {
            firstAddressStr += ipAddressStr[i];
            lastAddressStr += ipAddressStr[i];
        }


        //FIRST HOST
        for (int i = CIDR; i < 32; i++)
        {
            if (i == 31)
                firstAddressStr += "1";
            else
                firstAddressStr += "0";
        }
        firstAddressStr = AddDotts(firstAddressStr);

        //LAST HOST
        for (int i = CIDR; i < 32; i++)
        {
            if (i == 31)
                lastAddressStr += "0";
            else
                lastAddressStr += "1";
        }
        lastAddressStr = AddDotts(lastAddressStr);

        range[0] = IPv4.OctalStringBinaryToOctalIP(firstAddressStr);
        range[1] = IPv4.OctalStringBinaryToOctalIP(lastAddressStr);

        return range;
    }

    //Questa funzione prende in input una stringa contenente un indirizzo IP e la formatta aggiungendo 
    //dei punti tra i gruppi di 8 bit. Si itera sulla stringa dall'inizio alla fine e, ogni volta 
    //che si raggiunge un multiplo di otto bit, viene aggiunto un punto. Infine, la stringa formattata viene restituita.
    protected static string AddDotts(string ipStr)
    {
        string result = "";
        for (int i = 0; i < 32; i++)
        {
            if (i == 8 || i == 16 || i == 24)
                result += "." + ipStr[i];
            else
                result += ipStr[i];
        }
        return result;
    }

    //Questa funzione esegue l'operazione di AND bit a bit su due caratteri. 
    //Utilizzando la conversione in intero, converte i caratteri in interi, quindi esegue 
    //l'operazione bit a bit tra i due numeri e restituisce il risultato come intero.
    protected static int AndOperation(char x, char y)
    {
        int result = Convert.ToInt32(x - '0') & Convert.ToInt32(y - '0');
        return result;
    }
}