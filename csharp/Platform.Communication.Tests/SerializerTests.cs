using System;
using System.IO;
using Xunit;
using Platform.Singletons;
using Platform.Communication.Protocol.Xml;

namespace Platform.Communication.Tests
{
    /// <summary>
    /// <para>
    /// Represents the serializer tests.
    /// </para>
    /// <para></para>
    /// </summary>
    public static class SerializerTests
    {
        /// <summary>
        /// <para>
        /// Tests that serialize to file test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void SerializeToFileTest()
        {
            var tempFilename = Path.GetTempFileName();
            Serializer<object>.ToFile(Default<object>.Instance, tempFilename);
            Assert.Equal(File.ReadAllText(tempFilename), $"<?xml version=\"1.0\"?>{Environment.NewLine}<anyType xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" />");
            File.Delete(tempFilename);
        }

        /// <summary>
        /// <para>
        /// Tests that serialize as xml string test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void SerializeAsXmlStringTest()
        {
            var serializedObject = Serializer<object>.ToString(Default<object>.Instance);
            Assert.Equal(serializedObject, $"<?xml version=\"1.0\" encoding=\"utf-16\"?>{Environment.NewLine}<anyType xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" />");
        }
    }
}
