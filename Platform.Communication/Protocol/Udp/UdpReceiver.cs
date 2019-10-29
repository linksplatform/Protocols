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

        public bool Available
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _udp.Available > 0;
        }

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UdpReceiver(int listenPort, MessageHandlerCallback messageHandler) : this(listenPort, true, messageHandler) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UdpReceiver(MessageHandlerCallback messageHandler) : this(DefaultPort, true, messageHandler) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UdpReceiver() : this(DefaultPort, true, message => { }) { }

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Receive() => _udp.ReceiveString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReceiveAndHandle() => _messageHandler(Receive());

        /// <remarks>
        /// <para>The method receives messages and runs in a separate thread.</para>
        /// <para>Метод получает сообщения и работает в отдельном потоке.</para>
        /// </remarks>
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