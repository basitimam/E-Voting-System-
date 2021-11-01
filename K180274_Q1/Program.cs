using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace K180274_Q1
{
    class Program
    {

        static void InputEncryption(string[] args)
        {
            var dataPath = ConfigurationManager.AppSettings["dataPath"];
            var filePath = dataPath + "/" + "cList.dat";
            if (!Directory.Exists(dataPath))
                    {
                        Directory.CreateDirectory(dataPath);
                    }

            if (!File.Exists(filePath))
            {
                if (args[2] == "210001" || args[2] == "210002")
                {

                    string argument1 = Convert.ToBase64String(Encoding.UTF8.GetBytes(args[1]));
                    string Info = args[0] + "," + argument1 + "," + args[2] + ",";
                    File.WriteAllText(filePath, Info);

                }
                else
                {
                    Console.WriteLine("Invalid Station Id");
                }



            }
            else
            {
                if (args[2] == "210001" || args[2] == "210002")
                {


                    string argument1 = Convert.ToBase64String(Encoding.UTF8.GetBytes(args[1]));

                    string Info = args[0] + "," + argument1 + "," + args[2] + ",";
                    string data = File.ReadAllText(filePath);
                    string[] InfoArr = data.Split(",");
                    int flag = 0;

                    for (int i = 0; i < InfoArr.Length; i++)
                    {
                        if (args[0] == InfoArr[i])
                        {

                            flag = 1;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (flag == 0)
                    {
                        File.AppendAllText(filePath, Info);
                    }
                    else
                    {
                        Console.WriteLine("Email already exists");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid Station Id");
                }
            }
        }
        static void Main(string[] args)
        {

            InputEncryption(args);

        }
    }
}
