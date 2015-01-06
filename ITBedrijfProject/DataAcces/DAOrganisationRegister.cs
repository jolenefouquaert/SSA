using ITBedrijfProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ITBedrijfProject.DataAcces
{
    public class DAOrganisationRegister
    {
        //alle sql statements om te pushen naar de database

        

       

        public static List<OrganisationRegister> GetOrganisationRegisters()
        {
            string sql = "SELECT * FROM OrganisationRegister";
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql);
            List<OrganisationRegister> OrganisationRegisters = new List<OrganisationRegister>();
            while (reader.Read())
            {
                OrganisationRegister organisationregister = new OrganisationRegister();
                organisationregister.OrganisationID = (int)reader["OrganisationID"];
                organisationregister.RegisterID = (int)reader["RegisterID"];
                organisationregister.FromDate = (DateTime)reader["FromDate"];
                organisationregister.UntilDate = (DateTime)reader["UntilDate"];


                OrganisationRegisters.Add(organisationregister);
            }
            return OrganisationRegisters;
        }


      

       

        public static List<OrganisationRegister> GetOrganisationRegisterById(int id)
        {
            string sql = "SELECT Organisation.OrganisationName, Organisation.Login, OrganisationRegister.OrganisationID, Register.RegisterName, Register.Device, OrganisationRegister.RegisterID, OrganisationRegister.FromDate, OrganisationRegister.UntilDate";
            sql += " FROM OrganisationRegister";
            sql += " INNER JOIN Organisation";
            sql += " ON OrganisationRegister.OrganisationID=Organisation.ID";
            sql += " INNER JOIN Register";
            sql += " ON OrganisationRegister.RegisterID=Register.ID";
            sql += " WHERE OrganisationID=@OrganisationID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@OrganisationID", id);
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1);
            List<OrganisationRegister> organisationRegisters = new List<OrganisationRegister>();
            while (reader.Read())
            {
                OrganisationRegister organisationRegister = new OrganisationRegister();
                organisationRegister.OrganisationID = (int)reader["OrganisationID"];
                organisationRegister.RegisterID = (int)reader["RegisterID"];
                organisationRegister.FromDate = (DateTime)reader["FromDate"];
                organisationRegister.UntilDate = (DateTime)reader["UntilDate"];
                organisationRegister.RegisterName = reader["RegisterName"].ToString();
                organisationRegister.OrganisationName = reader["OrganisationName"].ToString();
                organisationRegister.Login = reader["Login"].ToString();
                organisationRegister.Device = reader["Device"].ToString();
                organisationRegisters.Add(organisationRegister);
            }
            return organisationRegisters;
        }

        public static OrganisationRegister GetOrganisationRegisterByIds(int OrganisationID, int RegisterID)
        {
            string sql = "SELECT Organisation.OrganisationName, Organisation.Login, OrganisationRegister.OrganisationID, Register.RegisterName, Register.Device, OrganisationRegister.RegisterID, OrganisationsRegister.FromDate, OrganisationRegister.UntilDate";
            sql += " FROM OrganisationRegister";
            sql += " INNER JOIN Organisation";
            sql += " ON OrganisationRegister.OrganisationID=Organisations.ID";
            sql += " INNER JOIN Register";
            sql += " ON OrganisationRegister.RegisterID=Registers.ID";
            sql += " WHERE OrganisationID=@OrganisationID AND RegisterID=@RegisterID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@OrganisationID", OrganisationID);
            DbParameter par2 = Database.AddParameter("AdminDB", "@RegisterID", RegisterID);
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1, par2);
            OrganisationRegister organisationRegister = new OrganisationRegister();
            while (reader.Read())
            {
                organisationRegister.OrganisationID = (int)reader["OrganisationID"];
                organisationRegister.RegisterID = (int)reader["RegisterID"];
                organisationRegister.FromDate = (DateTime)reader["FromDate"];
                organisationRegister.UntilDate = (DateTime)reader["UntilDate"];
                organisationRegister.RegisterName = reader["RegisterName"].ToString();
                organisationRegister.OrganisationName = reader["OrganisationName"].ToString();
                organisationRegister.Login = reader["Login"].ToString();
                organisationRegister.Device = reader["Device"].ToString();
            }
            return organisationRegister;
        }

        public static int InsertOrganisationRegister(OrganisationRegister organisationRegister)
        {
            string sql = "INSERT INTO OrganisationRegister VALUES(@OrganisationID,@RegisterID,@FromDate,@UntilDate)";
            DbParameter par1 = Database.AddParameter("AdminDB", "@OrganisationID", organisationRegister.OrganisationID);
            DbParameter par2 = Database.AddParameter("AdminDB", "@RegisterID", organisationRegister.RegisterID);
            DbParameter par3 = Database.AddParameter("AdminDB", "@FromDate", organisationRegister.FromDate);
            DbParameter par4 = Database.AddParameter("AdminDB", "@UntilDate", organisationRegister.UntilDate);

            return Database.InsertData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4);
        }

        public static int UpdateOrganisationRegister(int oldOrganisationID, OrganisationRegister organisationRegister)
        {
            string sql = "UPDATE OrganisationRegister SET OrganisationID=@OrganisationID, RegisterID=@RegisterID, FromDate=@FromDate, UntilDate=@UntilDate WHERE OrganisationID=@OrganisationIDold AND RegisterID=@RegisterID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@OrganisationID", organisationRegister.OrganisationID);
            DbParameter par2 = Database.AddParameter("AdminDB", "@RegisterID", organisationRegister.RegisterID);
            DbParameter par3 = Database.AddParameter("AdminDB", "@FromDate", organisationRegister.FromDate);
            DbParameter par4 = Database.AddParameter("AdminDB", "@UntilDate", organisationRegister.UntilDate);
            DbParameter par5 = Database.AddParameter("AdminDB", "@OrganisationIDold", oldOrganisationID);

            return Database.ModifyData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4, par5);
        }
    }
}