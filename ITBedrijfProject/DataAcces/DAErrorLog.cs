using ITBedrijfProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ITBedrijfProject.DataAcces
{
    public class DAErrorLog
    {


        //errors opvragen er zit hier niets in want ik heb de module bap niet
        public static List<Errorlog> GetErrorlog()
        {
            string sql = "SELECT * FROM Errorlog";
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql);
            List<Errorlog> Errorlog = new List<Errorlog>();
            while (reader.Read())
            {
                Errorlog errorlog = new Errorlog();
                errorlog.RegisterID = (int)reader["RegisterID"];
                errorlog.Timestamp = (DateTime)reader["Timestamp"];
                errorlog.Message = reader["Message"].ToString();
                errorlog.Stacktrace = reader["Stacktrace"].ToString();


                Errorlog.Add(errorlog);
            }
            return Errorlog;
        }

        public static List<Errorlog> GetLogsById(int id)
        {
            string sql = "SELECT * FROM Errorlog WHERE RegisterID=@ID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@ID", id);
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1);
            List<Errorlog> log = new List<Errorlog>();
            while (reader.Read())
            {
                Errorlog errorlog = new Errorlog();
                errorlog.RegisterID = (int)reader["RegisterID"];
                errorlog.Timestamp = (DateTime)reader["Timestamp"];
                errorlog.Message = reader["Message"].ToString();
                errorlog.Stacktrace = reader["Stacktrace"].ToString();

                log.Add(errorlog);
            }
            return log;
        }
    }
}