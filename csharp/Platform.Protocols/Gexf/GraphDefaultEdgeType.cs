using System.Xml.Serialization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Protocols.Gexf
{
    /// <summary>
    /// <para>
    /// The graph default edge type enum.
    /// </para>
    /// <para></para>
    /// </summary>
    public enum GraphDefaultEdgeType
    {
        /// <summary>
        /// <para>
        /// The directed graph default edge type.
        /// </para>
        /// <para></para>
        /// </summary>
        [XmlEnum(Name = "directed")]
        Directed
    }
}
