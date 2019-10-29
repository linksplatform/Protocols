using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Communication.Protocol.Gexf
{
    public class Graph
    {
        public static readonly string ElementName = "graph";
        public const string ModeAttributeName = "mode";
        public const string DefaultEdgeTypeAttributeName = "defaultedgetype";
        public const string NodesElementName = "nodes";
        public const string NodeElementName = "node";
        public const string EdgesElementName = "edges";
        public const string EdgeElementName = "edge";

        [XmlAttribute(AttributeName = ModeAttributeName)]
        public GraphMode Mode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        [XmlAttribute(AttributeName = DefaultEdgeTypeAttributeName)]
        public GraphDefaultEdgeType DefaultEdgeType
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        [XmlArray(ElementName = NodesElementName)]
        [XmlArrayItem(ElementName = NodeElementName)]
        public List<Node> Nodes
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        [XmlArray(ElementName = EdgesElementName)]
        [XmlArrayItem(ElementName = EdgeElementName)]
        public List<Edge> Edges
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Graph() => (Nodes, Edges) = (new List<Node>(), new List<Edge>());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteXml(XmlWriter writer) => WriteXml(writer, () => WriteNodes(writer), () => WriteEdges(writer), Mode, DefaultEdgeType);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteEdges(XmlWriter writer)
        {
            for (var i = 0; i < Edges.Count; i++)
            {
                Edges[i].WriteXml(writer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteNodes(XmlWriter writer)
        {
            for (var i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].WriteXml(writer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, Action writeNodes, Action writeEdges) => WriteXml(writer, writeNodes, writeEdges, GraphMode.Static, GraphDefaultEdgeType.Directed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, Action writeNodes, Action writeEdges, GraphMode mode) => WriteXml(writer, writeNodes, writeEdges, mode, GraphDefaultEdgeType.Directed);

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
