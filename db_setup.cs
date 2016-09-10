using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuts
{
    class db_setup
    {
        public static string db_initialize(){
            string r = null;
            if (db.connect() == true){
                try {
                    string coll = "'utf8_unicode_ci'";
                    string cTbl_nuts_inventory = "CREATE TABLE IF NOT EXISTS `nuts_inventory` (" +
                    "`sku` int(11) NOT NULL," +
                    "`name` varchar(32) collate " + coll + " NOT NULL," +
                    "PRIMARY KEY  (`sku`)) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=" + coll + ";";
                    SqlCommand sqlCreate = new SqlCommand(cTbl_nuts_inventory, db.con);
                    SqlDataReader reader = sqlCreate.ExecuteReader();
                } catch (Exception e) {
                    inputCheck.msgBox(e.ToString(), "Database Error");
                    r = e.ToString();
                } finally { db.disconnect(); }
            }
            return r;
        }
        //"`uuid` varchar(40) collate " + coll + " NOT NULL,"+
        //"`time` timestamp collate " + coll + " NOT NULL,"+
        //"`default_balance` decimal(65,2) collate " + coll + " NOT NULL,"+
        //"PRIMARY KEY  (`loc`)) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE="+coll+";";
        //"`sku` int(11) NOT NULL AUTO_INCREMENT," +

    }
}
