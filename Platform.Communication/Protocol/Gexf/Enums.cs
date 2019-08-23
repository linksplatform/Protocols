using System.Xml.Serialization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Communication.Protocol.Gexf
{
    public enum GraphMode
    {
        [XmlEnum(Name = "static")]
        Static,

        [XmlEnum(Name = "dynamic")]
        Dynamic
    }

    public enum GraphDefaultEdgeType
    {
        [XmlEnum(Name = "directed")]
        Directed
    }
}
