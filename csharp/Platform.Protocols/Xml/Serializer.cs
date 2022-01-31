using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Protocols.Xml
{
    /// <summary>
    /// <para>
    /// Represents the serializer.
    /// </para>
    /// <para></para>
    /// </summary>
    public static class Serializer<T>
    {
        /// <summary>
        /// <para>
        /// The .
        /// </para>
        /// <para></para>
        /// </summary>
        public static readonly XmlSerializer Instance = new XmlSerializer(typeof(T));

        /// <summary>
        /// <para>
        /// Creates the file using the specified path.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="path">
        /// <para>The path.</para>
        /// <para></para>
        /// </param>
        /// <returns>
        /// <para>The</para>
        /// <para></para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T FromFile(string path)
        {
            using var stream = File.OpenRead(path);
            return (T)Instance.Deserialize(stream);
        }

        /// <summary>
        /// <para>
        /// Creates the string using the specified xml.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="xml">
        /// <para>The xml.</para>
        /// <para></para>
        /// </param>
        /// <returns>
        /// <para>The</para>
        /// <para></para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T FromString(string xml)
        {
            using var reader = new StringReader(xml);
            return (T)Instance.Deserialize(reader);
        }

        /// <summary>
        /// <para>
        /// Returns the file using the specified object.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="@object">
        /// <para>The object.</para>
        /// <para></para>
        /// </param>
        /// <param name="path">
        /// <para>The path.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToFile(T @object, string path)
        {
            using var stream = File.OpenWrite(path);
            Instance.Serialize(stream, @object);
        }

        /// <summary>
        /// <para>
        /// Returns the string using the specified object.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="@object">
        /// <para>The object.</para>
        /// <para></para>
        /// </param>
        /// <returns>
        /// <para>The string</para>
        /// <para></para>
        /// </returns>
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
