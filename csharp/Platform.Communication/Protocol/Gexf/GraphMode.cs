using System.Xml.Serialization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Communication.Protocol.Gexf
{
    /// <summary>
    /// <para>
    /// The graph mode enum.
    /// </para>
    /// <para></para>
    /// </summary>
    public enum GraphMode
    {
        /// <summary>
        /// <para>
        /// The static graph mode.
        /// </para>
        /// <para></para>
        /// </summary>
        [XmlEnum(Name = "static")]
        Static,

        /// <summary>
        /// <para>
        /// The dynamic graph mode.
        /// </para>
        /// <para></para>
        /// </summary>
        [XmlEnum(Name = "dynamic")]
        Dynamic
    }
}
