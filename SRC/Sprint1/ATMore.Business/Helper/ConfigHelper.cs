using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Xml;

namespace ATMore.Business.Helper
{
    public static class ConfigHelper
    {
        static ILog LOGGER = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static Configuration _CONFIG = null;
        public static void LoadWebConfig(string VirtualPath = "~/")
        {
            try
            {
                _CONFIG = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(VirtualPath);
            }
            catch (Exception ex) { LOGGER.Error(ex); }
        }

        public static string GetString(string Key)
        {
            return AppHelper.ToString(GetAppSettings()[Key].Value);
        }
        public static int GetInt(string Key)
        {
            return AppHelper.ToInt(GetString(Key));
        }

        public static string GetConnectionString(string Name)
        {
            return GetConnSettings()[Name].ConnectionString;
        }

        private static KeyValueConfigurationCollection GetAppSettings()
        {
            AppSettingsSection AppSection = GetConfig().AppSettings;
            if (AppSection == null) throw new ApplicationException("Can't find the app section.");

            KeyValueConfigurationCollection AppSettings = AppSection.Settings;
            if (AppSettings == null) throw new ApplicationException("Can't find the app settings.");
            return AppSettings;
        }

        private static ConnectionStringSettingsCollection GetConnSettings()
        {
            ConnectionStringsSection ConnectionSection = GetConfig().ConnectionStrings;
            if (ConnectionSection == null) throw new ApplicationException("Can't find the connection section.");

            ConnectionStringSettingsCollection ConnectionSetting = ConnectionSection.ConnectionStrings;
            if (ConnectionSetting == null) throw new ApplicationException("Can't find the connection settings.");
            return ConnectionSetting;
        }

        private static Configuration GetConfig()
        {
            if (_CONFIG == null) LoadWebConfig();
            if (_CONFIG == null) throw new ApplicationException("Can't find the configuration object.");
            return _CONFIG;
        }

        private static IDictionary<string, string> GetAppSettings(string cfgFilePath) 
        {
            Dictionary<string, string> AppSettings = new Dictionary<string, string>();
            const string appConfigNodeName = "appSettings";

            try
            {
                //string to hold the name of the   
                //config file for the assembly  
                //create a new XML Document  
                XmlDocument doc = new XmlDocument();
                //load an XML document by using the  
                //XMLTextReader class of the XML Namespace  
                //Now open the cfgFile  
                doc.Load(new XmlTextReader(cfgFilePath));
                //retrieve a list of nodes in the document  
                XmlNode configNode = doc.SelectSingleNode(string.Format("//{0}", appConfigNodeName));
                if (configNode != null)
                {
                    DictionarySectionHandler handler = new DictionarySectionHandler();
                    //return the new handler  
                    IDictionary configSection = (IDictionary)handler.Create(null, null, configNode);
                    foreach (string key in configSection.Keys)
                    {
                        AppSettings.Add(key, (string)configSection[key]);
                    }
                }
            }
            catch (Exception e)
            {
                LOGGER.Error(e);
            }
            return AppSettings;
        }
        
        public static void Main()
        {

            try

            {
                //const string appConfigNodeName = "appSettings";
                //Dictionary<string,string> dicData = new Dictionary<string, string>();

                ////string to hold the name of the   
                ////config file for the assembly  
                //string cfgFile = "E:\\Working\\Java\\acomsolutions\\solution-net\\CustomAcom\\CustomAcom.Stamford\\Web.config";
                ////create a new XML Document  
                //XmlDocument doc = new XmlDocument();
                ////load an XML document by using the  
                ////XMLTextReader class of the XML Namespace  
                ////Now open the cfgFile  
                //doc.Load(new XmlTextReader(cfgFile));
                ////retrieve a list of nodes in the document  
                //XmlNode configNode = doc.SelectSingleNode(string.Format("//{0}", appConfigNodeName));
                //if (configNode != null)
                //{
                //    DictionarySectionHandler handler = new DictionarySectionHandler();
                //    //return the new handler  
                //    IDictionary configSection = (IDictionary)handler.Create(null, null, configNode);
                //    foreach (string key in configSection.Keys)
                //    {
                //        dicData.Add(key, (string)configSection[key]);
                //    }
                //}

                //Console.WriteLine("TEST=" + dicData.Keys);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            //System.Configuration.ConfigurationFileMap fileMap = new ConfigurationFileMap("E:\\Working\\Java\\acomsolutions\\solution-net\\CustomAcom\\CustomAcom.Stamford\\Web.config"); //Path to your config file
            //System.Configuration.Configuration configuration = System.Configuration.ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
            //ConfigurationSection section = configuration.GetSection("ConnectionStrings");

            //Console.WriteLine("TEST=" + configuration.ConnectionStrings.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
    }    
}
