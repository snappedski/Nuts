﻿using System;
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
        //public static string c_host = "localhost";
        public static string c_host = "192.168.1.19";
        public static string c_db = "handyjobs";
        public static string c_user = "hj_root";
        public static string c_pass = "4Xjf3SvVtrcR4hLW";
        public static int c_timeout = 10;

        public static SqlConnection con = new SqlConnection("user id=" + c_user + ";" + "password=" + c_pass + ";server=" + c_host + ";" + "Trusted_Connection=yes;" + "database=" + c_db + "; " + "connection timeout=" + c_timeout);

        public static Boolean connect(){
            Boolean r = true;
            try { con.Open(); } catch (Exception e) { r = false;
                inputCheck.msgBox(e.ToString(),"Cannot Connect!");
            }
            return r;
        }

        public static void disconnect(){
            try{ con.Close();}
            catch (Exception e){ inputCheck.msgBox(e.ToString(), "Database Error"); }
        }

        public static String dbStrAtoStr(String[] A)
        {
            String rString = null;
            if (string.Equals(A[0].ToString(), "*", StringComparison.OrdinalIgnoreCase)) {
                rString = "*";
            } else{
                rString = string.Join(", ", A);
            }
            return rString;
        }

        public static String dbWhere(string[] conditions, string[] values){
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

        public static string[] db_select(string table, string[] columns, string[] conditions, string[] values){
            string[] r = null;
            try {
                if (connect() == true){
                    SqlDataReader read = null;
                    SqlCommand cmd = new SqlCommand("select " + dbStrAtoStr(columns) + " from " + table + dbWhere(conditions, values), con);


                    read = cmd.ExecuteReader();
                    // rows = (Int32)cmd.ExecuteScalar();
                    if (read.HasRows)
                    {
                        int i = 0;
                        while (read.Read())
                        {
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
            catch (Exception e){ inputCheck.msgBox(e.ToString(), "Database Error"); }
            return r;
        }

        public static void db_insert(string table, string[] columns, string[] values){
            try {
                if (connect() == true){
                    SqlCommand insert = new SqlCommand("INSERT INTO " + table + " (" + string.Join(", ", columns) + ") " + "Values (" + String.Join(", ", values) + ")", con);
                    insert.ExecuteNonQuery();
                    disconnect();
                }
            } catch (Exception e) { inputCheck.msgBox(e.ToString(), "Database Error"); }
        }
    }
}