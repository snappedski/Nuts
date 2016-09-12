using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using MySQLDriverCS;

namespace Nuts
{
    class db
    {
        ////////////////////////////////////////////////////////////////////
        //Connection string and connection
        //public static string strCon = "server=" + nuts_session.db_host + ";uid=" + nuts_session.db_user + ";pwd=" + nuts_session.db_pass + ";database=" + nuts_session.db_db + ";";
        //public static string strCon = nuts_session.db_host , nuts_session.db_db , nuts_session.db_user , nuts_session.db_pass;
        //public static SqlConnection con;
        public static MySQLConnection con;
        //public static SqlConnection con = new SqlConnection("Data Source=" + c_host + ";Initial Catalog=" + c_db + ";User id=" + c_user + ";Password=" + c_pass + ";");
        //public static SqlConnection con = new SqlConnection("user id=" + c_user + ";" + "password=" + c_pass + ";server=" + c_host + ";" + "Trusted_Connection=yes;" + "database=" + c_db + "; " + "connection timeout=" + c_timeout);

        public static Boolean connect(){ //Connect
            //Console.WriteLine("!!!!! - " + db.strCon);
            Boolean r = true;
            //con = new SqlConnection(strCon);
            con = new MySQLConnection(new MySQLConnectionString(nuts_session.db_host, nuts_session.db_db, nuts_session.db_user, nuts_session.db_pass).AsString);
            try { con.Open(); } catch (Exception e) { r = false;
                hj_tools.msgBox(e.ToString(),"Cannot Connect!", "ERROR", true);
            }
            return r;
        }

        public static void disconnect(){ //Disconnect
            try{ con.Close();}
            catch (Exception e){ hj_tools.msgBox(e.ToString(), "Database Error", "ERROR", true); }
        }

        public static String dbStrAtoStr(string[] A, string type){ //asterisk exception / Array to string separated by comma
            string rString = null;
            if (string.Equals(A[0].ToString(), "*", StringComparison.OrdinalIgnoreCase)) {
                rString = "*";
            } else{
                if (hj_tools.compareStr(type, "values")){
                    rString = "'" + string.Join("', '", A) + "'";
                } else { rString = string.Join(", ", A);}
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
                //if (connect() == true){
                //SqlDataReader read = null;
                
                //SqlCommand cmd = new SqlCommand("select " + dbStrAtoStr(columns) + " from " + table + dbWhere(conditions, values) + ";", con);
                MySQLCommand cmd = new MySQLCommand("select " + dbStrAtoStr(columns, "columns") + " from " + table + dbWhere(conditions, values) + ";", con);
                MySQLDataReader reader = null;
                reader = cmd.ExecuteReaderEx();

                //read = cmd.ExecuteReader();
                //rows = (Int32)cmd.ExecuteScalar();
                if (reader.HasRows){
                    int i = 0;
                    while (reader.Read()){
                        string[] rows = null;
                        for (int j = 0; j < reader.FieldCount; j++){
                            rows[j] = reader[j].ToString();
                        }
                        r[i] = string.Join(",", rows);
                        i++;
                    }
                    reader.NextResult();
                 } reader.Close();
                 disconnect();
            } catch (Exception e){ hj_tools.msgBox(e.ToString(), "Database Error", "ERROR", true); }
            return r;
        }

        public static void db_insert(string table, string[] columns, string[] values){//SQL Insert
            try {
                if (connect() == true){
                    MySQLCommand cmd = new MySQLCommand("INSERT INTO " + table + " (" + dbStrAtoStr(columns, "columns") + ") " + "Values (" + dbStrAtoStr(values, "values") + ");", con);
                    cmd.ExecuteNonQuery();
                    disconnect();
                }
            } catch (Exception e) { hj_tools.msgBox(e.ToString(), "Database Error", "ERROR", true); }
        }
    }
}
