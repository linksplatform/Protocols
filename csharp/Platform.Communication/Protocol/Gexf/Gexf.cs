using System;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Communication.Protocol.Gexf
{
    [XmlRoot(ElementName = ElementName, Namespace = Namespace)]
    public class Gexf
    {
        public const string ElementName = "gexf";
        public const string Namespace = "http://www.gexf.net/1.2draft";
        public const string VersionAttributeName = "version";
        public const string GraphElementName = "graph";
        public static readonly string CurrentVersion = "1.2";

        [XmlAttribute(AttributeName = VersionAttributeName)]
        public string Version
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        [XmlElement(ElementName = GraphElementName)]
        public Graph Graph
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Gexf() => (Version, Graph) = (CurrentVersion, new Graph());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteXml(XmlWriter writer) => WriteXml(writer, () => Graph.WriteXml(writer), Version);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, Action writeGraph) => WriteXml(writer, writeGraph, CurrentVersion);

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, Action writeNodes, Action writeEdges) => WriteXml(writer, writeNodes, writeEdges, CurrentVersion, GraphMode.Static, GraphDefaultEdgeType.Directed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, Action writeNodes, Action writeEdges, string version) => WriteXml(writer, writeNodes, writeEdges, version, GraphMode.Static, GraphDefaultEdgeType.Directed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, Action writeNodes, Action writeEdges, string version, GraphMode mode) => WriteXml(writer, writeNodes, writeEdges, version, mode, GraphDefaultEdgeType.Directed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteXml(XmlWriter writer, Action writeNodes, Action writeEdges, string version, GraphMode mode, GraphDefaultEdgeType defaultEdgeType) => WriteXml(writer, () => Graph.WriteXml(writer, writeNodes, writeEdges, mode, defaultEdgeType), version);
    }
}
