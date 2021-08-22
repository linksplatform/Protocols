using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Communication.Protocol.Gexf
{
    /// <summary>
    /// <para>
    /// Represents the graph.
    /// </para>
    /// <para></para>
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// <para>
        /// The element name.
        /// </para>
        /// <para></para>
        /// </summary>
        public static readonly string ElementName = "graph";
        /// <summary>
        /// <para>
        /// The mode attribute name.
        /// </para>
        /// <para></para>
        /// </summary>
        public const string ModeAttributeName = "mode";
        /// <summary>
        /// <para>
        /// The default edge type attribute name.
        /// </para>
        /// <para></para>
        /// </summary>
        public const string DefaultEdgeTypeAttributeName = "defaultedgetype";
        /// <summary>
        /// <para>
        /// The nodes element name.
        /// </para>
        /// <para></para>
        /// </summary>
        public const string NodesElementName = "nodes";
        /// <summary>
        /// <para>
        /// The node element name.
        /// </para>
        /// <para></para>
        /// </summary>
        public const string NodeElementName = "node";
        /// <summary>
        /// <para>
        /// The edges element name.
        /// </para>
        /// <para></para>
        /// </summary>
        public const string EdgesElementName = "edges";
        /// <summary>
        /// <para>
        /// The edge element name.
        /// </para>
        /// <para></para>
        /// </summary>
        public const string EdgeElementName = "edge";

        /// <summary>
        /// <para>
        /// Gets or sets the mode value.
        /// </para>
        /// <para></para>
        /// </summary>
        [XmlAttribute(AttributeName = ModeAttributeName)]
        public GraphMode Mode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        /// <summary>
        /// <para>
        /// Gets or sets the default edge type value.
        /// </para>
        /// <para></para>
        /// </summary>
        [XmlAttribute(AttributeName = DefaultEdgeTypeAttributeName)]
        public GraphDefaultEdgeType DefaultEdgeType
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        /// <summary>
        /// <para>
        /// Gets or sets the nodes value.
        /// </para>
        /// <para></para>
        /// </summary>
        [XmlArray(ElementName = NodesElementName)]
        [XmlArrayItem(ElementName = NodeElementName)]
        public List<Node> Nodes
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        /// <summary>
        /// <para>
        /// Gets or sets the edges value.
        /// </para>
        /// <para></para>
        /// </summary>
        [XmlArray(ElementName = EdgesElementName)]
        [XmlArrayItem(ElementName = EdgeElementName)]
        public List<Edge> Edges
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        /// <summary>
        /// <para>
        /// Initializes a new <see cref="Graph"/> instance.
        /// </para>
        /// <para></para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Graph() => (Nodes, Edges) = (new List<Node>(), new List<Edge>());

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
        public void WriteXml(XmlWriter writer) => WriteXml(writer, () => WriteNodes(writer), () => WriteEdges(writer), Mode, DefaultEdgeType);

        /// <summary>
        /// <para>
        /// Writes the edges using the specified writer.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="writer">
        /// <para>The writer.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteEdges(XmlWriter writer)
        {
            for (var i = 0; i < Edges.Count; i++)
            {
                Edges[i].WriteXml(writer);
            }
        }

        /// <summary>
        /// <para>
        /// Writes the nodes using the specified writer.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="writer">
        /// <para>The writer.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteNodes(XmlWriter writer)
        {
            for (var i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].WriteXml(writer);
            }
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
        public static void WriteXml(XmlWriter writer, Action writeNodes, Action writeEdges) => WriteXml(writer, writeNodes, writeEdges, GraphMode.Static, GraphDefaultEdgeType.Directed);

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
        /// <param name="mode">
        /// <para>The mode.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, Action writeNodes, Action writeEdges, GraphMode mode) => WriteXml(writer, writeNodes, writeEdges, mode, GraphDefaultEdgeType.Directed);

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
        /// <param name="mode">
        /// <para>The mode.</para>
        /// <para></para>
        /// </param>
        /// <param name="defaultEdgeType">
        /// <para>The default edge type.</para>
        /// <para></para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, Action writeNodes, Action writeEdges, GraphMode mode, GraphDefaultEdgeType defaultEdgeType)
        {
            writer.WriteStartElement(ElementName);
            writer.WriteAttributeString(ModeAttributeName, mode.ToString().ToLower());
            writer.WriteAttributeString(DefaultEdgeTypeAttributeName, defaultEdgeType.ToString().ToLower());
            writer.WriteStartElement(NodesElementName);
            writeNodes();
            writer.WriteEndElement();
            writer.WriteStartElement(EdgesElementName);
            writeEdges();
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
