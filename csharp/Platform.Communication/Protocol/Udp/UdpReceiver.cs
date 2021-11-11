using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using Platform.Disposables;
using Platform.Exceptions;
using Platform.Threading;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Communication.Protocol.Udp
{
    /// <summary>
    /// <para>
    /// The message handler callback.
    /// </para>
    /// <para></para>
    /// </summary>
    public delegate void MessageHandlerCallback(string message);

    /// <summary>
    /// <para>Represents the receiver of messages transfered via UDP protocol.</para>
    /// <para>Представляет получателя сообщений по протоколу UDP.</para>
    /// </summary>
    public class UdpReceiver : DisposableBase //-V3073
    {
        private const int DefaultPort = 15000;
        private bool _receiverRunning;
        private Thread _thread;
        private readonly UdpClient _udp;
        private readonly MessageHandlerCallback _messageHandler;

        /// <summary>
        /// <para>
        /// Gets the available value.
        /// </para>
        /// <para></para>
        /// </summary>
        public bool Available
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _udp.Available > 0;
        }

        /// <summary>
        /// <para>
        /// Initializes a new <see cref="UdpReceiver"/> instance.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="listenPort">
        /// <para>A listen port.</para>
        /// <para></para>
        /// </param>
        /// <param name="autoStart">
        /// <para>A auto start.</para>
        /// <para></para>
        /// </param>
        /// <param name="messageHandler">
        /// <para>A message handler.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UdpReceiver(int listenPort, bool autoStart, MessageHandlerCallback messageHandler)
        {
            _udp = new UdpClient(listenPort);
            _messageHandler = messageHandler;
            if (autoStart)
            {
                Start();
            }
        }

        /// <summary>
        /// <para>
        /// Initializes a new <see cref="UdpReceiver"/> instance.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="listenPort">
        /// <para>A listen port.</para>
        /// <para></para>
        /// </param>
        /// <param name="messageHandler">
        /// <para>A message handler.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UdpReceiver(int listenPort, MessageHandlerCallback messageHandler) : this(listenPort, true, messageHandler) { }

        /// <summary>
        /// <para>
        /// Initializes a new <see cref="UdpReceiver"/> instance.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="messageHandler">
        /// <para>A message handler.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UdpReceiver(MessageHandlerCallback messageHandler) : this(DefaultPort, true, messageHandler) { }

        /// <summary>
        /// <para>
        /// Initializes a new <see cref="UdpReceiver"/> instance.
        /// </para>
        /// <para></para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UdpReceiver() : this(DefaultPort, true, message => { }) { }

        /// <summary>
        /// <para>
        /// Starts this instance.
        /// </para>
        /// <para></para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Start()
        {
            if (!_receiverRunning && _thread == null)
            {
                _receiverRunning = true;
                _thread = new Thread(Receiver);
                _thread.Start();
            }
        }

        /// <summary>
        /// <para>
        /// Stops this instance.
        /// </para>
        /// <para></para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Stop()
        {
            if (_receiverRunning && _thread != null)
            {
                _receiverRunning = false;
                _thread.Join();
                _thread = null;
            }
        }

        /// <summary>
        /// <para>
        /// Receives this instance.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The string</para>
        /// <para></para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Receive() => _udp.ReceiveString();

        /// <summary>
        /// <para>
        /// Receives the and handle.
        /// </para>
        /// <para></para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReceiveAndHandle() => _messageHandler(Receive());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Receiver()
        {
            while (_receiverRunning)
            {
                try
                {
                    if (Available)
                    {
                        ReceiveAndHandle();
                    }
                    else
                    {
                        ThreadHelpers.Sleep();
                    }
                }
                catch (Exception exception)
                {
                    exception.Ignore();
                }
            }
        }

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
                Stop();
                _udp.DisposeIfPossible();
            }
        }
    }
}