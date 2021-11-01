using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;


namespace K180274_Q2 {



    public partial class Form2 : Form
    {
        public string stationID;
        public Form2(string stationID)
        {
            InitializeComponent();
            this.stationID = stationID;
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            char[] delimitor = { ',', '\n' };
            var CandidateListPath = ConfigurationManager.AppSettings["CandidateListPath"];
            string candidateInfo = File.ReadAllText(CandidateListPath);
            string[] candidateInfoArr = candidateInfo.Split(delimitor);

            President.Items.Add("Ahmed Khan");
            President.Items.Add("Sarah");
            President.Items.Add("Khurram");

            VicePresident.Items.Add("Aslam Mehmood");
            VicePresident.Items.Add("Shameer");
            VicePresident.Items.Add("Rida");


            GenralSecratory.Items.Add("Kamran Akmal");
            GenralSecratory.Items.Add("Ahmed Khan");
            GenralSecratory.Items.Add("Mutahir");
  







        }

        private void GenralSecratory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void President_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void VicePresident_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Nic_TextChanged(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {


            char[] delimitor = { ',', '\n' };
            var VoterListPath = ConfigurationManager.AppSettings["VoterListPath"];
            string VoterListInfo = File.ReadAllText(VoterListPath);
            string[] VoterListInfoArr = VoterListInfo.Split(delimitor);

            var CheckListPath = ConfigurationManager.AppSettings["CheckList"];

            for (int i = 0; i < VoterListInfoArr.Length; i++)
            {


                if (Nic.Text == VoterListInfoArr[i].Trim())
                {
                    int check = 0;
                    if (!File.Exists(CheckListPath))
                    {
                        string NicInfo = Nic.Text + ",";
                        File.WriteAllText(CheckListPath, NicInfo);
                    }
                    else
                    {
                        string CheckString = File.ReadAllText(CheckListPath);
                        string[] CheckStringInfo = CheckString.Split(",");
                        for (int c = 0; c < CheckStringInfo.Length; c++)
                        {
                            if (Nic.Text == CheckStringInfo[c].Trim())
                            {
                                MessageBox.Show("Vote Already casted ");
                                check = 1;
                                break;

                            }
                            else if (c == CheckStringInfo.Length - 1)
                            {
                                string NicInfo = Nic.Text + ",";
                                File.AppendAllText(CheckListPath, NicInfo);
                            }
                        }
                        if (check == 1)
                        {
                            break;
                        }



                    }

                    var XMLFilePath = ConfigurationManager.AppSettings["XMLFilePath"];
                    DateTime currentTime = DateTime.Now;
                    string xmlFile = "AA_Elec" + "_" + stationID + "_" + currentTime.ToString("ddMMMMy_HH,mm") + ".xml";

                    string fileName = XMLFilePath + xmlFile;
                    if (!Directory.Exists(XMLFilePath))
                    {
                        Directory.CreateDirectory(XMLFilePath);
                    }
                  
                    if (Directory.GetFiles(XMLFilePath).Length == 0)
                    {
                        char[] del = { ',', '\n' };
                        var CandidateListPath = ConfigurationManager.AppSettings["CandidateListPath"];
                        string candidateInfo = File.ReadAllText(CandidateListPath);
                        string[] candidateInfoArr = candidateInfo.Split(del);

                        XmlTextWriter xmlWriter = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
                        xmlWriter.Formatting = Formatting.Indented;
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("Votes");

                        if (President.Text.Length != 0)
                        {
                            xmlWriter.WriteStartElement("Vote");
                            xmlWriter.WriteElementString("NIC", Nic.Text);
                            for (int c = 0; c < candidateInfoArr.Length; c++)
                            {
                                if (President.Text.Trim() == candidateInfoArr[c].Trim())
                                {
                                    xmlWriter.WriteElementString("Position", candidateInfoArr[c + 1]);
                                    xmlWriter.WriteElementString("CandidateID", candidateInfoArr[c - 1]);
                                    xmlWriter.WriteEndElement();
                                    break;

                                }
                                else
                                {
                                    continue;
                                }
                            }

                        }
                        else
                        {
                            goto ViceP;
                        }

                    ViceP: if (VicePresident.Text.Length != 0)
                        {
                            xmlWriter.WriteStartElement("Vote");
                            xmlWriter.WriteElementString("NIC", Nic.Text);
                            for (int c = 0; c < candidateInfoArr.Length; c++)
                            {
                                if (VicePresident.Text.Trim() == candidateInfoArr[c].Trim())
                                {
                                    xmlWriter.WriteElementString("Position", candidateInfoArr[c + 1]);
                                    xmlWriter.WriteElementString("CandidateID", candidateInfoArr[c - 1]);
                                    xmlWriter.WriteEndElement();
                                    break;

                                }
                                else
                                {
                                    continue;
                                }
                            }

                        }
                        else
                        {
                            goto GSec;
                        }


                    GSec: if (GenralSecratory.Text.Length != 0)
                        {
                            xmlWriter.WriteStartElement("Vote");
                            xmlWriter.WriteElementString("NIC", Nic.Text);
                            for (int c = 0; c < candidateInfoArr.Length; c++)
                            {
                                if (GenralSecratory.Text.Trim() == candidateInfoArr[c].Trim() && candidateInfoArr[c + 1].Trim() == "General Secretary")
                                {
                                    xmlWriter.WriteElementString("Position", candidateInfoArr[c + 1]);
                                    xmlWriter.WriteElementString("CandidateID", candidateInfoArr[c - 1]);
                                    xmlWriter.WriteEndElement();
                                    break;

                                }
                                else
                                {
                                    continue;
                                }
                            }

                        }
                        else
                        {
                            goto EndWrit;
                        }



                    EndWrit: xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                        xmlWriter.Flush();
                        xmlWriter.Close();

                        MessageBox.Show("Vote succesfully casted!!");
                    }
                
                else
                {
                    char[] del = { ',', '\n' };
                    var CandidateListPath = ConfigurationManager.AppSettings["CandidateListPath"];
                    string candidateInfo = File.ReadAllText(CandidateListPath);
                    string[] candidateInfoArr = candidateInfo.Split(del);
                    string[] fileNames = Directory.GetFiles(XMLFilePath);
                    XmlDocument doc = new XmlDocument();


                    for (int k = 0; k < fileNames.Length; k++)
                    {
                        if (fileName.Substring(0, fileName.IndexOf(",")) == fileNames[k].Substring(0, fileNames[k].IndexOf(",")))
                        {
                            doc.Load(fileNames[k]);
                            XmlNode root = doc.SelectSingleNode("Votes");

                            if (President.Text.Length != 0)
                            {
                                for (int a = 0; a < candidateInfoArr.Length; a++)
                                {
                                    if (President.Text.Trim() == candidateInfoArr[a].Trim() && candidateInfoArr[a + 1].Trim() == "President")
                                    {
                                        XmlElement vote = doc.CreateElement("Vote");
                                        root.AppendChild(vote);

                                        XmlElement NicNo = doc.CreateElement("NIC");
                                        NicNo.InnerText = Nic.Text;
                                        vote.AppendChild(NicNo);

                                        XmlElement position = doc.CreateElement("Position");
                                        position.InnerText = candidateInfoArr[a + 1];
                                        vote.AppendChild(position);

                                        XmlElement Candidateid = doc.CreateElement("CandidateID");
                                        Candidateid.InnerText = candidateInfoArr[a - 1];
                                        vote.AppendChild(Candidateid);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                goto VPres;
                            }

                        VPres: if (VicePresident.Text.Length != 0)
                            {
                                for (int a = 0; a < candidateInfoArr.Length; a++)
                                {
                                    if (VicePresident.Text.Trim() == candidateInfoArr[a].Trim())
                                    {
                                        XmlElement vote = doc.CreateElement("Vote");
                                        root.AppendChild(vote);

                                        XmlElement NicNo = doc.CreateElement("NIC");
                                        NicNo.InnerText = Nic.Text;
                                        vote.AppendChild(NicNo);

                                        XmlElement position = doc.CreateElement("Position");
                                        position.InnerText = candidateInfoArr[a + 1];
                                        vote.AppendChild(position);

                                        XmlElement Candidateid = doc.CreateElement("CandidateID");
                                        Candidateid.InnerText = candidateInfoArr[a - 1];
                                        vote.AppendChild(Candidateid);

                                        break;
                                    }
                                }
                            }
                            else
                            {
                                goto GenSec;
                            }

                        GenSec: if (GenralSecratory.Text.Length != 0)
                            {
                                for (int a = 0; a < candidateInfoArr.Length; a++)
                                {
                                    if (GenralSecratory.Text.Trim() == candidateInfoArr[a].Trim() && candidateInfoArr[a + 1].Trim() == "General Secretary")
                                    {
                                        XmlElement vote = doc.CreateElement("Vote");
                                        root.AppendChild(vote);

                                        XmlElement NicNo = doc.CreateElement("NIC");
                                        NicNo.InnerText = Nic.Text;
                                        vote.AppendChild(NicNo);

                                        XmlElement position = doc.CreateElement("Position");
                                        position.InnerText = candidateInfoArr[a + 1];
                                        vote.AppendChild(position);

                                        XmlElement Candidateid = doc.CreateElement("CandidateID");
                                        Candidateid.InnerText = candidateInfoArr[a - 1];
                                        vote.AppendChild(Candidateid);

                                        break;
                                    }
                                }
                            }
                            else
                            {
                                goto DocSave;
                            }


                        DocSave: doc.Save(fileNames[k]);
                            MessageBox.Show("Vote Casted Successfully!!");

                            break;

                        }
                        else if (k == fileNames.Length - 1)
                        {
                            XmlTextWriter xmlWriter = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
                            xmlWriter.Formatting = Formatting.Indented;
                            xmlWriter.WriteStartDocument();
                            xmlWriter.WriteStartElement("Votes");

                            if (President.Text.Length != 0)
                            {
                                xmlWriter.WriteStartElement("Vote");
                                xmlWriter.WriteElementString("NIC", Nic.Text);
                                for (int c = 0; c < candidateInfoArr.Length; c++)
                                {
                                    if (President.Text.Trim() == candidateInfoArr[c].Trim())
                                    {
                                        xmlWriter.WriteElementString("Position", candidateInfoArr[c + 1]);
                                        xmlWriter.WriteElementString("CandidateID", candidateInfoArr[c - 1]);
                                        xmlWriter.WriteEndElement();
                                        break;

                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }

                            }
                            else
                            {
                                goto VC;
                            }
                        VC: if (VicePresident.Text.Length != 0)
                            {
                                xmlWriter.WriteStartElement("Vote");
                                xmlWriter.WriteElementString("NIC", Nic.Text);
                                for (int c = 0; c < candidateInfoArr.Length; c++)
                                {
                                    if (VicePresident.Text.Trim() == candidateInfoArr[c].Trim())
                                    {
                                        xmlWriter.WriteElementString("Position", candidateInfoArr[c + 1]);
                                        xmlWriter.WriteElementString("CandidateID", candidateInfoArr[c - 1]);
                                        xmlWriter.WriteEndElement();
                                        break;

                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }

                            }
                            else
                            {
                                goto GC;
                            }
                        GC: if (GenralSecratory.Text.Length != 0)
                            {
                                xmlWriter.WriteStartElement("Vote");
                                xmlWriter.WriteElementString("NIC", Nic.Text);
                                for (int c = 0; c < candidateInfoArr.Length; c++)
                                {
                                    if (GenralSecratory.Text.Trim() == candidateInfoArr[c].Trim() && candidateInfoArr[c + 1].Trim() == "General Secretary")
                                    {
                                        xmlWriter.WriteElementString("Position", candidateInfoArr[c + 1]);
                                        xmlWriter.WriteElementString("CandidateID", candidateInfoArr[c - 1]);
                                        xmlWriter.WriteEndElement();
                                        break;

                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }

                            }
                            else
                            {
                                goto Write;
                            }


                        Write: xmlWriter.WriteEndElement();
                            xmlWriter.WriteEndDocument();
                            xmlWriter.Flush();
                            xmlWriter.Close();
                            MessageBox.Show("Vote Casted Successfully!!");
                            break;

                        }
                        else
                        {
                            continue;
                        }

                    }

                }



                    break;
                }

                else
                {
                    if (i == VoterListInfoArr.Length - 1)
                    {
                        MessageBox.Show("Not verified", "Wrong NIC");
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

