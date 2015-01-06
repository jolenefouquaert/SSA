using ITBedrijfProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ITBedrijfProject.DataAcces
{
    public class DARegister
    {
        public static List<Register> GetRegisters()
        {
            string sql = "SELECT * FROM Register";
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql);
            List<Register> Registers = new List<Register>();
            while (reader.Read())
            {
                Register register = new Register();
                register.Id = (int)reader["ID"];
                register.RegisterName = reader["RegisterName"].ToString();
                register.Device = reader["Device"].ToString();
                register.PurchaseDate = (DateTime)reader["PurchaseDate"];
                register.ExpiresDate = (DateTime)reader["ExpiresDate"];


                Registers.Add(register);
            }
            return Registers;
        }

        internal static int InsertRegister(Register register)
        {
            string sql = "INSERT INTO Register VALUES(@RegisterName,@Device,@PurchaseDate,@ExpiresDate)";
            DbParameter par1 = Database.AddParameter("AdminDB", "@RegisterName", register.RegisterName);
            DbParameter par2 = Database.AddParameter("AdminDB", "@Device", register.Device);
            DbParameter par3 = Database.AddParameter("AdminDB", "@PurchaseDate", register.PurchaseDate);
            DbParameter par4 = Database.AddParameter("AdminDB", "@ExpiresDate", register.ExpiresDate);


            return Database.InsertData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4);
        }

        public static Register GetRegisterById(int id)
        {
            string sql = "SELECT * FROM Register WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@ID", id);
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1);
            Register register = new Register();
            while (reader.Read())
            {
                register.Id = (int)reader["ID"];
                register.RegisterName = reader["RegisterName"].ToString();
                register.Device = reader["Device"].ToString();
                register.PurchaseDate = (DateTime)reader["PurchaseDate"];
                register.ExpiresDate = (DateTime)reader["ExpiresDate"];

            }
            return register;
        }

        public static int UpdateRegister(int id, Register register)
        {
            string sql = "UPDATE Register SET RegisterName=@RegisternName, Device=@Device, PurchaseDate=@PurchaseDate, ExpiresDate=@ExpiresDate WHERE RegisterID=@RegisterID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@RegisterID", register.Id);
            DbParameter par2 = Database.AddParameter("AdminDB", "@RegisterName", register.RegisterName);
            DbParameter par3 = Database.AddParameter("AdminDB", "@Device", register.Device);
            DbParameter par4 = Database.AddParameter("AdminDB", "@PurchaseDate", register.PurchaseDate);
            DbParameter par5 = Database.AddParameter("AdminDB", "@ExpiresDate", register.ExpiresDate);

            return Database.ModifyData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4, par5);
        }

        public static int DeleteRegister(int id)
        {
            string sql = "Delete From Register WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@ID", id);
            return Database.ModifyData(Database.GetConnection("AdminDB"), sql, par1);
        }
    }
}