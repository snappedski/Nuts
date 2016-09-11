using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuts
{
    class nuts_session{ //Global Variables

        ///////////////////////////////////////////////////////////////////////////
        // Main config file
        public static string config_dir = @"C:\HandyJobs\Nuts\"; //folder
        public static string config_name = "nuts"; //file name
        public static string config_ext = ".config"; //file extension
        public static string config_path = config_dir + config_name + config_ext; //full path
        public static string config_description = "Nuts main configuration file."; //description

        ///////////////////////////////////////////////////////////////////////////
        // Logged in user credentials and privileges
        public static string current_user = "";
    }
}
