using Xunit;
using Platform.Protocols.Udp;

namespace Platform.Protocols.Tests
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
