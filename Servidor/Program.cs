using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Servidor
{
    class Program
    {
		private const int listenPort = 11000;
		static void Main(string[] args)
        {
			bool done = false;
			UdpClient listener = new UdpClient(listenPort);
			IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
			string received_data;
			byte[] receive_byte_array;
			try
			{
				while (!done)
				{
					Console.WriteLine("Waiting for broadcast");					
					receive_byte_array = listener.Receive(ref groupEP);
					Console.WriteLine("Received a broadcast from {0}", groupEP.ToString());
					received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
					Console.WriteLine("data follows \n{0}\n\n", received_data);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
			listener.Close();			
		}
	}
 
}
