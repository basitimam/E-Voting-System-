using System.Configuration;
using System.IO;
using System.Xml.Linq;
using System;


namespace K180274_Q3
{
    class Program
    {


        static void Merge()
        {
            var XmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];
            var MergedFiles = ConfigurationManager.AppSettings["MergedFiles"];

            string stationId1 = "210001";
            string stationId2 = "210002";

            string xmlFile1 = "AA_Elec" + "_" + stationId1 + ".xml";

            string xmlFile2 = "AA_Elec" + "_" + stationId2 + ".xml";

            if (!Directory.Exists(MergedFiles))
            {
                Directory.CreateDirectory(MergedFiles);
            }

            string[] MergedFilePath = Directory.GetFiles(MergedFiles);
            foreach(string file in MergedFilePath)
            {
                File.Delete(file);
            }
            string[] AllXmlFiles = Directory.GetFiles(XmlFilePath);
            XDocument doc = new XDocument();
            XElement votes = new XElement("Votes");
            doc.Add(votes);
            
            foreach(var file in AllXmlFiles)
            {
                if (file.Contains(stationId1))
                {
                    XDocument fileDoc = XDocument.Load(file);
                    doc.Root.Add(fileDoc.Descendants("Vote"));
                }
                else
                {
                    continue;
                }
            }
            doc.Save(MergedFiles + "/" + xmlFile1);

            XDocument doc2 = new XDocument();
            XElement votes2 = new XElement("Votes");
            doc2.Add(votes2);

            foreach(var file in AllXmlFiles)
            {
                if (file.Contains(stationId2))
                {
                    XDocument fileDoc = XDocument.Load(file);
                    doc2.Root.Add(fileDoc.Descendants("Vote"));
                }
                else
                {
                    continue;
                }
            }
            doc2.Save(MergedFiles + "/" + xmlFile2);

        }
        static void Main(string[] args)
        {
            Merge();
        }
    }
}
