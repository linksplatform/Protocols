using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Platform.Disposables;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Communication.Protocol.Udp
{
    /// <summary>
    /// Represents the sender of messages transfered via UDP protocol.
    /// Представляет отправителя сообщений по протоколу UDP.
    /// </summary>
    public class UdpSender : DisposableBase //-V3073
    {
        private readonly UdpClient _udp;
        private readonly IPEndPoint _ipendpoint;

        public UdpSender(IPEndPoint ipendpoint) => (_udp, _ipendpoint) = (new UdpClient(), ipendpoint);

        public UdpSender(IPAddress address, int port) : this(new IPEndPoint(address, port)) { }

        public UdpSender(string hostname, int port) : this(IPAddress.Parse(hostname), port) { }

        public UdpSender(int port) : this(IPAddress.Loopback, port) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Send(string message) => _udp.SendString(_ipendpoint, message);

        protected override void Dispose(bool manual, bool wasDisposed)
        {
            if (!wasDisposed)
            {
                _udp.DisposeIfPossible();
            }
        }
    }
}