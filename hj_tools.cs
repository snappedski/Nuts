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
        /// 
        public static Boolean compareStr(string one, string two)
        { //Compares two strings
            Boolean m = false;
            if (string.Equals(one, two, StringComparison.OrdinalIgnoreCase)) { m = true; }
            return m;
        }

        public static int randH(int max, int min){ // Controlled Random Integer
            Random rn = new Random();
            int n = max - min + 1;
            int i = rn.Next() % n;
            int rN = min + i; return rN;
        }

        ///////////////////////////////////////////////////////////////////////
        /// ENCRYPTION

        public static string sbH(string[] input){ //String builder for encryption
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

        public static string ext_hash_sha1(string str1, string str2) { //Our hash
            string hash1 = hash_sha1(randH(999999, 0).ToString());
            string[] h = { str1, hash1, str2 };
            return hash_sha1(sbH(h));
        }

        static string hash_sha1(string input){ //SHA1 Encryption
            using (SHA1Managed sha1 = new SHA1Managed()){
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash){
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }


        ///////////////////////////////////////////////////////////////////////
        /// FILE MANAGEMENT

        public static void fileCreate(string dir, string name, string ext, string description){ //Create new file
            string path = dir + name + "." + ext;
            if (!File.Exists(path)){ // Creates file if not present
                string createText = "# " + name + "." + ext + Environment.NewLine + "# " + description + Environment.NewLine;
                File.WriteAllText(path, createText);
                hj_tools.msgBox(name + " was successfully created.", "File Created!", "ASTERISK", true);
            } else {
                //Message box for overwrite
            }
        }

        public static void fileAppend(string path, string[] lines, int[] r){
            if (File.Exists(path)) {
                for (int i = 0; i < r.Length; i++){
                    File.AppendAllText(path, lines[i] + Environment.NewLine);
                }
            }
            else { hj_tools.msgBox("File Not Found! Contact your administrator.", "File Not Found!", "ERROR", false); }
        }

        public static string fileReadAll(string path){
            string readText = null;
            if (File.Exists(path)){ readText = File.ReadAllText(path); }
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
