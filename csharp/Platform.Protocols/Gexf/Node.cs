using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Protocols.Gexf
{
    /// <summary>
    /// <para>
    /// Represents the node.
    /// </para>
    /// <para></para>
    /// </summary>
    public class Node
    {
        /// <summary>
        /// <para>
        /// The element name.
        /// </para>
        /// <para></para>
        /// </summary>
        public static readonly string ElementName = "node";
        /// <summary>
        /// <para>
        /// The id attribute name.
        /// </para>
        /// <para></para>
        /// </summary>
        public const string IdAttributeName = "id";
        /// <summary>
        /// <para>
        /// The label attribute name.
        /// </para>
        /// <para></para>
        /// </summary>
        public const string LabelAttributeName = "label";

        /// <summary>
        /// <para>
        /// Gets or sets the id value.
        /// </para>
        /// <para></para>
        /// </summary>
        [XmlAttribute(AttributeName = IdAttributeName)]
        public long Id
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        /// <summary>
        /// <para>
        /// Gets or sets the label value.
        /// </para>
        /// <para></para>
        /// </summary>
        [XmlAttribute(AttributeName = LabelAttributeName)]
        public string Label
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        /// <summary>
        /// <para>
        /// Writes the xml using the specified writer.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="writer">
        /// <para>The writer.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteXml(XmlWriter writer) => WriteXml(writer, Id, Label);

        /// <summary>
        /// <para>
        /// Writes the xml using the specified writer.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="writer">
        /// <para>The writer.</para>
        /// <para></para>
        /// </param>
        /// <param name="id">
        /// <para>The id.</para>
        /// <para></para>
        /// </param>
        /// <param name="label">
        /// <para>The label.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, long id, string label)
        {
            // <node id="0" label="..." />
            writer.WriteStartElement(ElementName);
            writer.WriteAttributeString(IdAttributeName, id.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString(LabelAttributeName, label);
            writer.WriteEndElement();
        }
    }
}
