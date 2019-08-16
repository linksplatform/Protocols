﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using Platform.Disposables;
using Platform.Exceptions;

namespace Platform.Communication.Protocol.Udp
{
    public delegate void MessageHandlerCallback(string message);

    /// <summary>
    /// Represents the receiver of messages transfered via UDP protocol.
    /// Представляет получателя сообщений по протоколу UDP.
    /// </summary>
    public class UdpReceiver : DisposableBase //-V3073
    {
        private const int DefaultPort = 15000;

        private bool _receiverRunning;
        private Thread _thread;
        private readonly int _listenPort;
        private readonly UdpClient _udp;
        private readonly MessageHandlerCallback _messageHandler;

        public bool Available => _udp.Available > 0;

        public UdpReceiver(int listenPort, bool autoStart, MessageHandlerCallback messageHandler)
        {
            _udp = new UdpClient(listenPort);
            _listenPort = listenPort;
            _messageHandler = messageHandler;
            if (autoStart)
            {
                Start();
            }
        }

        public UdpReceiver(int listenPort, MessageHandlerCallback messageHandler)
            : this(listenPort, true, messageHandler)
        {
        }

        public UdpReceiver(MessageHandlerCallback messageHandler)
            : this(DefaultPort, true, messageHandler)
        {
        }

        public UdpReceiver()
            : this(DefaultPort, true, message => { })
        {
        }

        public void Start()
        {
            if (!_receiverRunning && _thread == null)
            {
                _receiverRunning = true;
                _thread = new Thread(Receiver);
                _thread.Start();
            }
        }

        public void Stop()
        {
            if (_receiverRunning && _thread != null)
            {
                _receiverRunning = false;
                // Send Packet to itself to switch Receiver from Receiving.
                var loopback = new IPEndPoint(IPAddress.Loopback, _listenPort);
                var stopper = new UdpClient();
                stopper.SendAsync(new byte[0], 0, loopback).ContinueWith((task) => stopper.Dispose());
                _thread.Join();
                _thread = null;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Receive() => _udp.ReceiveString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReceiveAndHandle() => _messageHandler(Receive());

        // Функция извлекающая пришедшие сообщения
        // и работающая в отдельном потоке.
        private void Receiver()
        {
            while (_receiverRunning)
            {
                try
                {
                    ReceiveAndHandle();
                }
                catch (Exception exception)
                {
                    exception.Ignore();
                }
            }
        }

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