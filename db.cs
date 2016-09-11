using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;

namespace Nuts
{
    class db
    {
        //Testing purposes, will move to flat file
        ////////////////////////////////////////////////////////////////////

        public static string c_host = "localhost";
        //public static string c_host = "192.168.1.19";
        public static string c_db = "handyjobs";
        public static string c_user = "hj_root";
        public static string c_pass = "4Xjf3SvVtrcR4hLW"; //AD.Tr]gi]5,K
        //public static int c_timeout = 10;

        //public static string c_host = "149.56.142.21";
        //public static string c_db = "ski_nuts";
        //public static string c_user = "ski_root";
        //public static string c_pass = "AD.Tr]gi]5,K";
        //public static int c_timeout = 10;

        ////////////////////////////////////////////////////////////////////
        //Connection string
        public static SqlConnection con = new SqlConnection("Server=" + c_host + ";Database=" + c_db + ";Uid=" + c_user + ";Pwd=" + c_pass + ";");
        //public static SqlConnection con = new SqlConnection("user id=" + c_user + ";" + "password=" + c_pass + ";server=" + c_host + ";" + "Trusted_Connection=yes;" + "database=" + c_db + "; " + "connection timeout=" + c_timeout);

        public static Boolean connect(){ //Connect
            Boolean r = true;
            try { con.Open(); } catch (Exception e) { r = false;
                hj_tools.msgBox(e.ToString(),"Cannot Connect!", "ERROR", true);
            }
            return r;
        }

        public static void disconnect(){ //Disconnect
            try{ con.Close();}
            catch (Exception e){ hj_tools.msgBox(e.ToString(), "Database Error", "ERROR", true); }
        }

        public static String dbStrAtoStr(String[] A){ //asterisk exception / Array to string separated by comma
            String rString = null;
            if (string.Equals(A[0].ToString(), "*", StringComparison.OrdinalIgnoreCase)) {
                rString = "*";
            } else{
                rString = string.Join(", ", A);
            }
            return rString;
        }

        public static string dbWhere(string[] conditions, string[] values){ //Where extension in query
            string rWhere = "";
            if ((conditions != null) && (values != null)){
                string[] whereA = null;
                for (int i = 0; i < conditions.Length; i++){
                    whereA[i] = " where " + conditions[i] + "='" + values[i] + "'";
                }
                rWhere = string.Join(" &&", whereA);
            }
            return rWhere;
        }

        public static string[] db_select(string table, string[] columns, string[] conditions, string[] values){//SQL Select
            string[] r = null;
            try {
                if (connect() == true){
                    SqlDataReader read = null;
                    SqlCommand cmd = new SqlCommand("select " + dbStrAtoStr(columns) + " from " + table + dbWhere(conditions, values) + ";", con);

                    read = cmd.ExecuteReader();
                    // rows = (Int32)cmd.ExecuteScalar();
                    if (read.HasRows){
                        int i = 0;
                        while (read.Read()){
                            string[] rows = null;
                            for (int j = 0; j < read.FieldCount; j++)
                            {
                                rows[j] = read[j].ToString();
                            }
                            r[i] = string.Join(",", rows);
                            i++;
                        }
                        read.NextResult();
                    }
                    disconnect();
                }
            }
            catch (Exception e){ hj_tools.msgBox(e.ToString(), "Database Error", "ERROR", true); }
            return r;
        }

        public static void db_insert(string table, string[] columns, string[] values){//SQL Insert
            try {
                if (connect() == true){
                    SqlCommand insert = new SqlCommand("INSERT INTO " + table + " (" + dbStrAtoStr(columns) + ") " + "Values (" + dbStrAtoStr(values) + ");", con);
                    insert.ExecuteNonQuery();
                    disconnect();
                }
            } catch (Exception e) { hj_tools.msgBox(e.ToString(), "Database Error", "ERROR", true); }
        }
    }
}
