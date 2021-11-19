using Xunit;
using Platform.Communication.Protocol.Udp;

namespace Platform.Communication.Tests
{
    public static class UdpReceiverTests
    {
        [Fact]
        public static void DisposalTest()
        {
            using var receiver = new UdpReceiver();
        }
    }
}
