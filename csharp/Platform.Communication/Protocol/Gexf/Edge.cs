using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Communication.Protocol.Gexf
{
    /// <summary>
    /// <para>
    /// Represents the edge.
    /// </para>
    /// <para></para>
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// <para>
        /// The element name.
        /// </para>
        /// <para></para>
        /// </summary>
        public static readonly string ElementName = "edge";
        /// <summary>
        /// <para>
        /// The id attribute name.
        /// </para>
        /// <para></para>
        /// </summary>
        public const string IdAttributeName = "id";
        /// <summary>
        /// <para>
        /// The source attribute name.
        /// </para>
        /// <para></para>
        /// </summary>
        public const string SourceAttributeName = "source";
        /// <summary>
        /// <para>
        /// The target attribute name.
        /// </para>
        /// <para></para>
        /// </summary>
        public const string TargetAttributeName = "target";
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
        /// Gets or sets the source value.
        /// </para>
        /// <para></para>
        /// </summary>
        [XmlAttribute(AttributeName = SourceAttributeName)]
        public long Source
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        /// <summary>
        /// <para>
        /// Gets or sets the target value.
        /// </para>
        /// <para></para>
        /// </summary>
        [XmlAttribute(AttributeName = TargetAttributeName)]
        public long Target
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
        public void WriteXml(XmlWriter writer) => WriteXml(writer, Id, Source, Target, Label);

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
        /// <param name="sourceNodeId">
        /// <para>The source node id.</para>
        /// <para></para>
        /// </param>
        /// <param name="targetNodeId">
        /// <para>The target node id.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, long id, long sourceNodeId, long targetNodeId) => WriteXml(writer, id, sourceNodeId, targetNodeId, null);

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
        /// <param name="sourceNodeId">
        /// <para>The source node id.</para>
        /// <para></para>
        /// </param>
        /// <param name="targetNodeId">
        /// <para>The target node id.</para>
        /// <para></para>
        /// </param>
        /// <param name="label">
        /// <para>The label.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, long id, long sourceNodeId, long targetNodeId, string label)
        {
            // <edge id="0" source="0" target="0" label="..." />
            writer.WriteStartElement(ElementName);
            writer.WriteAttributeString(IdAttributeName, id.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString(SourceAttributeName, sourceNodeId.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString(TargetAttributeName, targetNodeId.ToString(CultureInfo.InvariantCulture));
            if (!string.IsNullOrWhiteSpace(label))
            {
                writer.WriteAttributeString(LabelAttributeName, label);
            }
            writer.WriteEndElement();
        }
    }
}
