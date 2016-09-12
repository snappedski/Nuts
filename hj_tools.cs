using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nuts
{
    class hj_tools
    {
        ///////////////////////////////////////////////////////////////////////
        /// MISC
        
        public static Boolean compareStr(string one, string two){ //Compares two strings
            Boolean m = false;
            if (string.Equals(one, two, StringComparison.OrdinalIgnoreCase)) { m = true; }
            return m;
        }

        public static int stringToInt(string input){
            int n = 9999999;
            try { n = Int32.Parse(input); } catch (Exception) { /*Console.WriteLine("!!!!! - " + e);*/ }
            return n;
        }

        public static int randH(int max, int min){ // Controlled Random Integer
            Random rn = new Random();
            int n = max - min + 1;
            int i = rn.Next() % n;
            int rN = min + i; return rN;
        }

        ///////////////////////////////////////////////////////////////////////
        /// ENCRYPTION

        public static string sbH(string[] input){ //String builder for ext_hash_sha1
            int inL = input.Length;
            StringBuilder sbList = new StringBuilder();
            for (int i = 1; i <= inL; i++){
                int im = i - 1;
                if (i == inL){
                    sbList.Append(input[im]);
                }else{
                    sbList.Append(input[im]); sbList.Append("#");
                }
            }
            return sbList.ToString();
        }

        public static string ext_hash_sha1(string str1, string str2) { //Hashes the sequence of a string, a number between 0 and 999999, and another string seperated by #
            string hash1 = hash_sha1(randH(999999, 0).ToString());
            string[] h = { str1, hash1, str2 };
            return hash_sha1(sbH(h));
        }

        static string hash_sha1(string input){ //SHA1 Encryption
            using (SHA1Managed sha1 = new SHA1Managed()){
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);
                foreach (byte b in hash){ sb.Append(b.ToString("X2")); }
                return sb.ToString();
            }
        }


        ///////////////////////////////////////////////////////////////////////
        /// FILE MANAGEMENT

        public static void fileCreate(string dir, string name, string ext, string description){ //Create new file
            string path = dir + name + ext;
            if (!File.Exists(path)){ // Creates file if not present
                string createText = "# " + name + ext + Environment.NewLine + "# " + description + Environment.NewLine + "########################################################################" + Environment.NewLine;
                File.WriteAllText(path, createText);
                hj_tools.msgBox(name + " was successfully created.", "File Created!", "ASTERISK", true);
            } else {
                //Message box for overwrite
            }
        }

        public static void fileAppend(string path, string[] lines){ //Append lines to a file
            if (File.Exists(path)) {
                for (int i = 0; i < lines.Length; i++){
                    File.AppendAllText(path, lines[i] + Environment.NewLine);
                }
            }
            else { hj_tools.msgBox("File Not Found! Contact your administrator.", "File Not Found!", "ERROR", false); }
        }

        public static string[] writeConfig(string[] settings, string[] values){ //formats settings and values for file writing
            string[] lines = settings;
            for (int i = 0; i < settings.Length; i++){
                int n = hj_tools.stringToInt(values[i]);
                if (n != 9999999){ lines[i] = settings[i] + ": " + values[i]; //integers
                } else { lines[i] = settings[i] + ": '" + values[i] + "'"; //strings
                }
            }
            return lines;
        }

        public static string fileGetLine(string path, string contains) { //Gets line that contains character sequence
            string line = null;
            if (File.Exists(path)) {
                string[] fileLines = System.IO.File.ReadAllLines(path);
                for (int i = 0; i < fileLines.Length; i++){
                    if (fileLines[i].Contains(contains)){
                        string[] lineB = fileLines[i].Split(' ');
                        string value = lineB[1].Replace("'", string.Empty);
                        line = value; break;
                    }
                }
            } else {hj_tools.msgBox("File Not Found! Contact your administrator.", "File Not Found!", "ERROR", false);
            }
            if (hj_tools.compareStr(line, null)) { hj_tools.msgBox("The '" + contains + "' setting in your nuts.config file is missing or doesn't have a value!", "Missing Setting", "ERROR", true); }
            return line;
        }

        public static string[] fileGetEachLine(string path, string contains){ //Reads each line of a file except those that begin with # and those that contain sequence unless null
            string[] dataLines = null;
            if (File.Exists(path)){
                string[] fileLines = System.IO.File.ReadAllLines(path);
                int c = 0;
                for (int i = 0; i < fileLines.Length; i++){
                    int index = 0;
                    if (fileLines[i].Contains('#')) { index = fileLines[i].IndexOf("#"); }
                    if (index != 1){
                        if (contains == null){
                            dataLines[c] = fileLines[i]; c++;
                        } else if (fileLines[i].Contains(contains)){
                            dataLines[c] = fileLines[i]; c++;
                        }
                    }
                }
            }
            else { hj_tools.msgBox("File Not Found! Contact your administrator.", "File Not Found!", "ERROR", false); }
            return dataLines;
        }

        public static string[] fileGetAllData(string[] lines){ //When given lines from a config file, returns all settings and values separated by a comma ex. "hostname,localhost"
            string[] data = null;
            for (int i = 0; i < lines.Length; i++){
                string[] b = lines[i].Split(' '); //Splits line in half
                string setting = b[0].Replace(":", string.Empty); //removes colon
                string value = b[1].Replace("'", string.Empty); //removes single quotes
                data[i] = setting + "," + value;
            }
            return data;
        }

        public static string fileReadAll(string path){ //Reads an entire file
            string readText = null;
            if (File.Exists(path)){ readText = File.ReadAllText(path); }
            else { hj_tools.msgBox("File Not Found! Contact your administrator.", "File Not Found!", "ERROR", false); }
            return readText;
        }

        ///////////////////////////////////////////////////////////////////////
        /// MESSAGE BOXES / ALERTS

        public static void msgBox(string msg, string title, string type, Boolean writeConsole){
            if (msg != null){
                if (compareStr(type, "ERROR")){ MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else if (compareStr(type, "EXCLAMATION")) { MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                else if (compareStr(type, "INFORMATION")) { MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else if (compareStr(type, "HAND")) { MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Hand); }
                else if (compareStr(type, "QUESTION")) { MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Question); }
                else if (compareStr(type, "STOP")) { MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                else if (compareStr(type, "WARNING")) { MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else if (compareStr(type, "ASTERISK")) { MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                else { MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.None); }

                if (writeConsole == true){ //Write to console if true
                    Console.WriteLine("- " + type + ": " + msg.ToString());
                }
            }
        }
    }
}
