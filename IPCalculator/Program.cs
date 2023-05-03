Console.WriteLine("Inserisci un indirizzo IP in formato decimal dotted con subnetmask separata da [/]");
string ipAddressAndSubnet = Console.ReadLine();
string[] ipAndSub = ipAddressAndSubnet.Split('/');

string ipAddress = ipAndSub[0];
string CIDRStr = ipAndSub[1];
if (!IPv4.VerifyIPAddress(ipAddress))
{
    Console.WriteLine("Indirizzo IP errato");
    return;
}
if (!IPv4.VerifyCIDR(CIDRStr))
{
    Console.WriteLine("CIDR errato");
    return;
}
int CIDR = Convert.ToInt32(CIDRStr);
byte[] subnetMask = IPv4.GetSubnetMask(CIDR);
byte[] wildCardMask = IPv4.GetWildCardMask(CIDR);


byte[] addressIP = IPv4.OctalStringToOctalIP(ipAddress);
byte[] networkIP = IPv4.GetNetworkAddress(addressIP, subnetMask);
byte[] broadcastIP = IPv4.GetBroadcastAddress(networkIP, CIDR);
byte[][] hostRange = IPv4.GetHostRange(networkIP, CIDR);


Console.WriteLine("\nIP address: " + ipAddress);
Console.WriteLine("Network address: " + IPv4.OctalIPToOctalString(networkIP));
Console.WriteLine("Range: " + IPv4.OctalIPToOctalString(hostRange[0]) + " - " + IPv4.OctalIPToOctalString(hostRange[1]));
Console.WriteLine("Broadcast address: " + IPv4.OctalIPToOctalString(broadcastIP));
Console.WriteLine("SubnetMask: " + IPv4.OctalIPToOctalString(subnetMask) + " [" + CIDR + "]");
Console.WriteLine("WildCardMask: " + IPv4.OctalIPToOctalString(wildCardMask) + " [" + (32 - CIDR) + "]");