using Xunit;
using Platform.Communication.Protocol.Udp;

namespace Platform.Communication.Tests
{
    /// <summary>
    /// <para>
    /// Represents the udp receiver tests.
    /// </para>
    /// <para></para>
    /// </summary>
    public static class UdpReceiverTests
    {
        /// <summary>
        /// <para>
        /// Tests that disposal test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void DisposalTest()
        {
            using var receiver = new UdpReceiver();
        }
    }
}
