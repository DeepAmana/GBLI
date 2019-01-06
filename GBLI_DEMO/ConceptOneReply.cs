using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace GBLI_DEMO
{
   [Serializable]
   public class ConceptOneReply
    {
        [XmlAttribute("Process_Status")]
        public string Process_status { get; set; }

        [XmlAttribute("Process_Message")]
        public string Process_Message { get; set; }

    }
}
