using System;
using System.Collections.Generic;
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
        public GraphMode Mode { get; set; }

        [XmlAttribute(AttributeName = DefaultEdgeTypeAttributeName)]
        public GraphDefaultEdgeType DefaultEdgeType { get; set; }

        [XmlArray(ElementName = NodesElementName)]
        [XmlArrayItem(ElementName = NodeElementName)]
        public List<Node> Nodes { get; set; }

        [XmlArray(ElementName = EdgesElementName)]
        [XmlArrayItem(ElementName = EdgeElementName)]
        public List<Edge> Edges { get; set; }

        public Graph() => (Nodes, Edges) = (new List<Node>(), new List<Edge>());

        public void WriteXml(XmlWriter writer) => WriteXml(writer, () => WriteNodes(writer), () => WriteEdges(writer), Mode, DefaultEdgeType);

        private void WriteEdges(XmlWriter writer)
        {
            for (var i = 0; i < Edges.Count; i++)
            {
                Edges[i].WriteXml(writer);
            }
        }

        private void WriteNodes(XmlWriter writer)
        {
            for (var i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].WriteXml(writer);
            }
        }

        public static void WriteXml(XmlWriter writer, Action writeNodes, Action writeEdges) => WriteXml(writer, writeNodes, writeEdges, GraphMode.Static, GraphDefaultEdgeType.Directed);

        public static void WriteXml(XmlWriter writer, Action writeNodes, Action writeEdges, GraphMode mode) => WriteXml(writer, writeNodes, writeEdges, mode, GraphDefaultEdgeType.Directed);

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
