﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void initializeConnectons(bool database,bool textFiles)
        {
            if (database)
            {
                //TODO -- set up the sql connector properly
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);

            }

            if (textFiles)
            {
                //TODO-- create text connection
                TextConnector text = new TextConnector();
                Connections.Add(text);

            }

        }

        public static string cnnString(String name)
        {
           return ConfigurationManager.ConnectionStrings[name].ConnectionString;
            
        }
    }
}
