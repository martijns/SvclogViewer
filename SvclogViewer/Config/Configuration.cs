using MsCommon.ClickOnce;
using System;
using System.Xml.Serialization;

namespace SvclogViewer.Config
{
    [Serializable]
    public class Configuration : AppConfiguration<Configuration>
    {
        public Configuration()
        {
        }

        [XmlElement]
        public bool AutoXmlFormatEnabled { get; set; }

        [XmlElement]
        public string LastSelectedSource { get; set; }

        [XmlElement]
        public bool HasRefusedSetAsDefault { get; set; }

        [XmlElement]
        public bool UseSyntaxColoring { get; set; }
    }
}
