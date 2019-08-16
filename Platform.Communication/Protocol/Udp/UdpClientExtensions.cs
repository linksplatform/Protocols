using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using Platform.Threading;
using Platform.Singletons;

namespace Platform.Communication.Protocol.Udp
{
    public static class UdpClientExtensions
    {
        private static readonly Encoding _defaultEncoding = Singleton.Get(() => Encoding.GetEncoding(0));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SendString(this UdpClient udp, IPEndPoint ipEndPoint, string message)
        {
            var bytes = _defaultEncoding.GetBytes(message);
            return udp.SendAsync(bytes, bytes.Length, ipEndPoint).AwaitResult();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ReceiveString(this UdpClient udp) => _defaultEncoding.GetString(udp.ReceiveAsync().AwaitResult().Buffer);
    }
}
