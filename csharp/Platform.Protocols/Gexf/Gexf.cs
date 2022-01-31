using System;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Protocols.Gexf
{
    /// <summary>
    /// <para>
    /// Represents the gexf.
    /// </para>
    /// <para></para>
    /// </summary>
    [XmlRoot(ElementName = ElementName, Namespace = Namespace)]
    public class Gexf
    {
        /// <summary>
        /// <para>
        /// The element name.
        /// </para>
        /// <para></para>
        /// </summary>
        public const string ElementName = "gexf";
        /// <summary>
        /// <para>
        /// The namespace.
        /// </para>
        /// <para></para>
        /// </summary>
        public const string Namespace = "http://www.gexf.net/1.2draft";
        /// <summary>
        /// <para>
        /// The version attribute name.
        /// </para>
        /// <para></para>
        /// </summary>
        public const string VersionAttributeName = "version";
        /// <summary>
        /// <para>
        /// The graph element name.
        /// </para>
        /// <para></para>
        /// </summary>
        public const string GraphElementName = "graph";
        /// <summary>
        /// <para>
        /// The current version.
        /// </para>
        /// <para></para>
        /// </summary>
        public static readonly string CurrentVersion = "1.2";

        /// <summary>
        /// <para>
        /// Gets or sets the version value.
        /// </para>
        /// <para></para>
        /// </summary>
        [XmlAttribute(AttributeName = VersionAttributeName)]
        public string Version
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        /// <summary>
        /// <para>
        /// Gets or sets the graph value.
        /// </para>
        /// <para></para>
        /// </summary>
        [XmlElement(ElementName = GraphElementName)]
        public Graph Graph
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        /// <summary>
        /// <para>
        /// Initializes a new <see cref="Gexf"/> instance.
        /// </para>
        /// <para></para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Gexf() => (Version, Graph) = (CurrentVersion, new Graph());

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
        public void WriteXml(XmlWriter writer) => WriteXml(writer, () => Graph.WriteXml(writer), Version);

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
        /// <param name="writeGraph">
        /// <para>The write graph.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, Action writeGraph) => WriteXml(writer, writeGraph, CurrentVersion);

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
        /// <param name="writeGraph">
        /// <para>The write graph.</para>
        /// <para></para>
        /// </param>
        /// <param name="version">
        /// <para>The version.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, Action writeGraph, string version)
        {
            writer.WriteStartDocument();
            writer.WriteStartElement(ElementName, Namespace);
            writer.WriteAttributeString(VersionAttributeName, version);
            writeGraph();
            writer.WriteEndElement();
            writer.WriteEndDocument();
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
        /// <param name="writeNodes">
        /// <para>The write nodes.</para>
        /// <para></para>
        /// </param>
        /// <param name="writeEdges">
        /// <para>The write edges.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, Action writeNodes, Action writeEdges) => WriteXml(writer, writeNodes, writeEdges, CurrentVersion, GraphMode.Static, GraphDefaultEdgeType.Directed);

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
        /// <param name="writeNodes">
        /// <para>The write nodes.</para>
        /// <para></para>
        /// </param>
        /// <param name="writeEdges">
        /// <para>The write edges.</para>
        /// <para></para>
        /// </param>
        /// <param name="version">
        /// <para>The version.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, Action writeNodes, Action writeEdges, string version) => WriteXml(writer, writeNodes, writeEdges, version, GraphMode.Static, GraphDefaultEdgeType.Directed);

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
        /// <param name="writeNodes">
        /// <para>The write nodes.</para>
        /// <para></para>
        /// </param>
        /// <param name="writeEdges">
        /// <para>The write edges.</para>
        /// <para></para>
        /// </param>
        /// <param name="version">
        /// <para>The version.</para>
        /// <para></para>
        /// </param>
        /// <param name="mode">
        /// <para>The mode.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, Action writeNodes, Action writeEdges, string version, GraphMode mode) => WriteXml(writer, writeNodes, writeEdges, version, mode, GraphDefaultEdgeType.Directed);

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
        /// <param name="writeNodes">
        /// <para>The write nodes.</para>
        /// <para></para>
        /// </param>
        /// <param name="writeEdges">
        /// <para>The write edges.</para>
        /// <para></para>
        /// </param>
        /// <param name="version">
        /// <para>The version.</para>
        /// <para></para>
        /// </param>
        /// <param name="mode">
        /// <para>The mode.</para>
        /// <para></para>
        /// </param>
        /// <param name="defaultEdgeType">
        /// <para>The default edge type.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, Action writeNodes, Action writeEdges, string version, GraphMode mode, GraphDefaultEdgeType defaultEdgeType) => WriteXml(writer, () => Graph.WriteXml(writer, writeNodes, writeEdges, mode, defaultEdgeType), version);
    }
}
