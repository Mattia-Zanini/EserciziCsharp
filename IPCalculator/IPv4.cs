class IPv4
{
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

    public static bool VerifyCIDR(string cidrStr)
    {
        if (Convert.ToInt32(cidrStr) < 1 || Convert.ToInt32(cidrStr) > 32)
            return false;
        return true;
    }

    public static byte[] OctalStringToOctalIP(string ipStr)
    {
        byte[] octalIP = new byte[4];
        string[] octalStr = ipStr.Split('.');

        for (int i = 0; i < 4; i++)
            octalIP[i] = Convert.ToByte(octalStr[i]);

        return octalIP;
    }
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

    private static string AddDotts(string ipStr)
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

    private static int AndOperation(char x, char y)
    {
        int result = Convert.ToInt32(x - '0') & Convert.ToInt32(y - '0');
        return result;
    }
}