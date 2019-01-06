using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace GBLI_DEMO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading Xml Files ...........");
            ReadXmlFiles();
            Console.ReadKey();
        }
        /// <summary>
        /// Reading Xml Files
        /// </summary>
        public static void ReadXmlFiles()
        {

            string XmlFilePath = string.Empty;
            string TxtFile = string.Empty;
            try
            {
                XmlFilePath = @"G:\KMG\GBLI_NEW_MAPPING\XMLRead";
                


                foreach (var XmlFilName in Directory.GetFiles(XmlFilePath,"*.xml"))
                {

                    ConceptOneReply conceptOneReply = SerializeInputXml(XmlFilName);
                    Console.WriteLine("Process_message=" + conceptOneReply.Process_Message);
                    Console.WriteLine("Process_status=" + conceptOneReply.Process_status);
                    writeTofile(conceptOneReply);
                    
                }


            }
            catch (Exception ex)
            {
                Console.Write("Exception:" + ex.Message);
            }
        }
        /// <summary>
        /// For serializing Object
        /// </summary>

        public static ConceptOneReply SerializeInputXml(string XmlFilePath)
        {
            TextReader reader = null;

            ConceptOneReply XmlObject = null;
            try
            {

                XmlSerializer deserializer = new XmlSerializer(typeof(ConceptOneReply));
                reader = new StreamReader(XmlFilePath);
                var objDeserialize = deserializer.Deserialize(reader);
                XmlObject = (ConceptOneReply)objDeserialize;


            }
            catch (Exception ex)
            {
                Console.Write("Exception:" + ex);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return XmlObject;
        }

        public static void writeTofile(ConceptOneReply c)
        {
            string TxtFile = @"C:\hjk\TEST.txt";

            using (StreamWriter sw = File.CreateText(TxtFile))
            {
                sw.WriteLine(c.Process_Message + "-------- " + c.Process_status);
            }
        }
    }
}
