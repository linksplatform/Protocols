using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Communication.Protocol.Xml
{
    public static class Serializer<T>
    {
        public static readonly XmlSerializer Instance = new XmlSerializer(typeof(T));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T FromFile(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return (T)Instance.Deserialize(stream);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T FromString(string xml)
        {
            using (var reader = new StringReader(xml))
            {
                return (T)Instance.Deserialize(reader);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToFile(T @object, string path)
        {
            using (var stream = File.OpenWrite(path))
            {
                Instance.Serialize(stream, @object);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(T @object)
        {
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                Instance.Serialize(writer, @object);
            }
            return sb.ToString();
        }
    }
}
