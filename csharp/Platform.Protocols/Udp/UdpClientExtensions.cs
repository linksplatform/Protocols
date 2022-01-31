using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Protocols.Udp
{
    /// <summary>
    /// <para>
    /// Represents the udp client extensions.
    /// </para>
    /// <para></para>
    /// </summary>
    public static class UdpClientExtensions
    {
        /// <summary>
        /// <para>
        /// The utf.
        /// </para>
        /// <para></para>
        /// </summary>
        public static readonly Encoding DefaultEncoding = Encoding.UTF8;

        /// <summary>
        /// <para>
        /// Sends the string using the specified udp.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="udp">
        /// <para>The udp.</para>
        /// <para></para>
        /// </param>
        /// <param name="ipEndPoint">
        /// <para>The ip end point.</para>
        /// <para></para>
        /// </param>
        /// <param name="message">
        /// <para>The message.</para>
        /// <para></para>
        /// </param>
        /// <returns>
        /// <para>The int</para>
        /// <para></para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SendString(this UdpClient udp, IPEndPoint ipEndPoint, string message)
        {
            var bytes = DefaultEncoding.GetBytes(message);
            return udp.Send(bytes, bytes.Length, ipEndPoint);
        }

        /// <summary>
        /// <para>
        /// Receives the string using the specified udp.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="udp">
        /// <para>The udp.</para>
        /// <para></para>
        /// </param>
        /// <returns>
        /// <para>The string</para>
        /// <para></para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ReceiveString(this UdpClient udp)
        {
            IPEndPoint remoteEndPoint = default;
            return DefaultEncoding.GetString(udp.Receive(ref remoteEndPoint));
        }
    }
}
