/*
uint x = 0b_00000011;
x <<= 1;
Console.WriteLine(Convert.ToString(x, 2).PadLeft(8, '0'));
Console.WriteLine(Convert.ToInt32(x));
*/


Console.WriteLine("Inserisci il CIDR [numero]");
string CIDRStr = Console.ReadLine();
if (!IPv4.VerifyCIDR(CIDRStr))
{
    Console.WriteLine("CIDR errato");
    return;
}

int CIDR = Convert.ToInt32(CIDRStr);
byte[] subnetMask = IPv4.GetSubnetMask(CIDR);

Console.WriteLine("Inserisci un indirizzo IP, in formato decimal dotted");
string ipAddress = Console.ReadLine();
if (!IPv4.VerifyIPAddress(ipAddress))
{
    Console.WriteLine("Indirizzo IP errato");
    return;
}

byte[] addressIP = IPv4.OctalStringToOctalIP(ipAddress);
byte[] networkIP = IPv4.GetNetworkAddress(addressIP, subnetMask);
byte[] broadcastIP = IPv4.GetBroadcastAddress(networkIP, CIDR);
byte[][] hostRange = IPv4.GetHostRange(networkIP, CIDR);

Console.WriteLine("\n");
Console.WriteLine("IP address: " + ipAddress);
Console.WriteLine("Network address: " + IPv4.OctalIPToOctalString(networkIP));
Console.WriteLine("Range: " + IPv4.OctalIPToOctalString(hostRange[0]) + " - " + IPv4.OctalIPToOctalString(hostRange[1]));
Console.WriteLine("Broadcast address: " + IPv4.OctalIPToOctalString(broadcastIP));
Console.WriteLine("SubnetMask: " + IPv4.OctalIPToOctalString(subnetMask));