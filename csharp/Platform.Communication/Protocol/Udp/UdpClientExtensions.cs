using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using Platform.Singletons;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Communication.Protocol.Udp
{
    public static class UdpClientExtensions
    {
        public static readonly Encoding DefaultEncoding = Encoding.UTF8;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SendString(this UdpClient udp, IPEndPoint ipEndPoint, string message)
        {
            var bytes = DefaultEncoding.GetBytes(message);
            return udp.Send(bytes, bytes.Length, ipEndPoint);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ReceiveString(this UdpClient udp)
        {
            IPEndPoint remoteEndPoint = default;
            return DefaultEncoding.GetString(udp.Receive(ref remoteEndPoint));
        }
    }
}
