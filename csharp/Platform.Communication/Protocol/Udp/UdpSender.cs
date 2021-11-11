using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Platform.Disposables;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Communication.Protocol.Udp
{
    /// <summary>
    /// <para>Represents the sender of messages transfered via UDP protocol.</para>
    /// <para>Представляет отправителя сообщений по протоколу UDP.</para>
    /// </summary>
    public class UdpSender : DisposableBase //-V3073
    {
        private readonly UdpClient _udp;
        private readonly IPEndPoint _ipendpoint;

        /// <summary>
        /// <para>
        /// Initializes a new <see cref="UdpSender"/> instance.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="ipendpoint">
        /// <para>A ipendpoint.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UdpSender(IPEndPoint ipendpoint) => (_udp, _ipendpoint) = (new UdpClient(), ipendpoint);

        /// <summary>
        /// <para>
        /// Initializes a new <see cref="UdpSender"/> instance.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="address">
        /// <para>A address.</para>
        /// <para></para>
        /// </param>
        /// <param name="port">
        /// <para>A port.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UdpSender(IPAddress address, int port) : this(new IPEndPoint(address, port)) { }

        /// <summary>
        /// <para>
        /// Initializes a new <see cref="UdpSender"/> instance.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="hostname">
        /// <para>A hostname.</para>
        /// <para></para>
        /// </param>
        /// <param name="port">
        /// <para>A port.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UdpSender(string hostname, int port) : this(IPAddress.Parse(hostname), port) { }

        /// <summary>
        /// <para>
        /// Initializes a new <see cref="UdpSender"/> instance.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="port">
        /// <para>A port.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UdpSender(int port) : this(IPAddress.Loopback, port) { }

        /// <summary>
        /// <para>
        /// Sends the message.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="message">
        /// <para>The message.</para>
        /// <para></para>
        /// </param>
        /// <returns>
        /// <para>The int</para>
        /// <para></para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Send(string message) => _udp.SendString(_ipendpoint, message);

        /// <summary>
        /// <para>
        /// Disposes the manual.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="manual">
        /// <para>The manual.</para>
        /// <para></para>
        /// </param>
        /// <param name="wasDisposed">
        /// <para>The was disposed.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void Dispose(bool manual, bool wasDisposed)
        {
            if (!wasDisposed)
            {
                _udp.DisposeIfPossible();
            }
        }
    }
}