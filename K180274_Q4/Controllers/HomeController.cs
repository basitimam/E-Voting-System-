using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;
using K180274_Q4.Models;
using System.Xml;


namespace K180274_Q4.Controllers
{
    public class HomeController : Controller
    {

        public static string XMLMerged = ConfigurationManager.AppSettings.Get("XmlMerged");
        public static string CandidateInfo = ConfigurationManager.AppSettings.Get("CandidateInfo") + "/" + "CandidateList.txt";



        public static Dictionary<string, PostElectionInfo> President = new Dictionary<string, PostElectionInfo>();
        public static Dictionary<string, PostElectionInfo> VPresident = new Dictionary<string, PostElectionInfo>();
        public static Dictionary<string, PostElectionInfo> GSecretary = new Dictionary<string, PostElectionInfo>();


        private static void ReadXml()
        {
            if (Directory.Exists(XMLMerged))
            {
                string[] AllXmlFiles = Directory.GetFiles(XMLMerged);

                foreach(string file in AllXmlFiles)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(file);
                    XmlNodeList nodes = doc.SelectNodes("/Votes/Vote");
                    string Position = "";
                    string CandidateID = "";

                    foreach(XmlNode node in nodes)
                    {
                        Position = node["Position"].InnerText;
                        CandidateID = node["CandidateID"].InnerText;

                        if(Position.Trim() == "President")
                        {
                            PostElectionInfo count = President[CandidateID];
                            System.Diagnostics.Debug.WriteLine(President[CandidateID]);

                            int vote = count.VoteCounts;
                            vote++;
                            count.VoteCounts = vote;
                            President[CandidateID] = count;
                        }

                        else if(Position.Trim()== "Vice President")
                        {
                            PostElectionInfo count = VPresident[CandidateID];
                   

                            int vote = count.VoteCounts;
                            vote++;
                            count.VoteCounts = vote;
                            VPresident[CandidateID] = count;
                        }
                        else if (Position.Trim() == "General Secretary")
                        {
                            PostElectionInfo count = GSecretary[CandidateID];

                            int vote = count.VoteCounts;
                            vote++;
                            count.VoteCounts = vote;
                            GSecretary[CandidateID] = count;
                        }
                    }


                }
            }
            else
            {
                Console.WriteLine("Directory NOT Found!!");
            }
        }
     
        private static void Main()
        {

            if (System.IO.File.Exists(CandidateInfo))
            {
                string CandidateInformation = System.IO.File.ReadAllText(CandidateInfo);
                string[] CandidateInfoArr = CandidateInformation.Split(',', '\n');

                for(int i=0; i<CandidateInfoArr.Length;i++)
                {
                    if(CandidateInfoArr[i].Trim() == "President")
                    {
                        President.Add(CandidateInfoArr[i-2].Trim(), new PostElectionInfo(CandidateInfoArr[i-1].Trim(), 0));
                    }
                    else if(CandidateInfoArr[i].Trim() == "Vice President")
                    {
                        VPresident.Add(CandidateInfoArr[i-2].Trim(), new PostElectionInfo(CandidateInfoArr[i-1].Trim(), 0));
                    }
                     else if(CandidateInfoArr[i].Trim() == "General Secretary")
                    {
                        GSecretary.Add(CandidateInfoArr[i-2].Trim(), new PostElectionInfo(CandidateInfoArr[i-1].Trim(), 0));
                    }

                }


                }
            else
            {
                Console.WriteLine("File not Found");
            }

          

            }
   
        public ActionResult Index()
        {

            Main();
            ReadXml();

            Console.WriteLine(VPresident);

            ViewBag.GSecretary = GSecretary;
            ViewBag.VPresident = VPresident;
            ViewBag.President = President;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
