using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.ComponentModel;
using System.Windows;
using System.Runtime.Serialization;

namespace xml_control
{
    public class xml
    {
        public XElement Car_Root { get; set; }
        public String Car_Path { get; set; }
        public XElement Client_Root { get; set; }
        public String Client_Path { get; set; }
        public XElement Fault_Root { get; set; }
        public String Fault_Path { get; set; }
        public XElement Renting_Root { get; set; }
        public String Renting_Path { get; set; }
        public XElement Car_Fault_Root { get; set; }
        public String Car_Fault_Path { get; set; }
        public string Config_path { get; set; }
        public XElement Config_Root { get; set; }
        public void LoadCarFaultData()
        {
            try
            {
                if (File.Exists(Car_Fault_Path))
                    Car_Fault_Root = XElement.Load(Car_Fault_Path);
            }
            catch
            {
                throw new Exception("אי אפשר לפתוח את הקובץ");
            }
        }
        public xml()
        {
            Car_Root = new XElement("Cars");
            Car_Path = Directory.GetCurrentDirectory() + @"\Cars.Xml";
            Client_Root = new XElement("Clients");
            Client_Path = Directory.GetCurrentDirectory() + @"\Clients.Xml";
            Fault_Root = new XElement("Fault");
            Fault_Path = Directory.GetCurrentDirectory() + @"\Fault.Xml";
            Renting_Root = new XElement("Renting");
            Renting_Path = Directory.GetCurrentDirectory() + @"\Renting.Xml";
            Car_Fault_Root = new XElement("CarFault");
            Car_Fault_Path = Directory.GetCurrentDirectory() + @"\CarFault" + ".Xml";
            if (!File.Exists(Config_path))
            {
                  Config_Root = new XElement("run_code", 10000000);
            Config_path = Directory.GetCurrentDirectory() + @"\config" + ".Xml";
            Config_Root.Save(Config_path);
            }
            
        }
        public void LoadCarData()
        {
            try
            {
                if (File.Exists(Car_Path))
                    Car_Root = XElement.Load(Car_Path);
            }
            catch
            {
                throw new Exception("אי אפשר לפתוח את הקובץ");
            }
        }
        public void LoadClientData()
        {
            try
            {
                if (File.Exists(Client_Path))
                    Client_Root = XElement.Load(Client_Path);
            }
            catch
            {
                throw new Exception("אי אפשר לפתוח את הקובץ");
            }
        }
        public void LoadFaultData()
        {
            try
            {
                if (File.Exists(Fault_Path))
                    Fault_Root = XElement.Load(Fault_Path);
            }
            catch
            {
                throw new Exception("אי אפשר לפתוח את הקובץ");
            }
        }
        public void LoadRentingData()
        {
            try
            {
                if (File.Exists(Renting_Path))
                    Renting_Root = XElement.Load(Renting_Path);
            }
            catch
            {
                throw new Exception("אי אפשר לפתוח את הקובץ");
            }
        }
        public void LoadConfigData()
        {
            try
            {
                if (File.Exists(Config_path))
                    Config_Root = XElement.Load(Config_path);
            }
            catch
            {
                throw new Exception("אי אפשר לפתוח את הקובץ");
            }
        }

    }
   
}
