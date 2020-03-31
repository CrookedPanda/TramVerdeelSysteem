using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Data
{
    public class Class1
    {
        private readonly ConnectionClass _connect;
        public Class1(ConnectionClass connect)
        {
            _connect = connect;
        }


        public string GetPassword(string Name)
        {
            _connect.Con.Open();
            string Password = "";

            string query = "SELECT `Password` FROM `Accounts` WHERE `Name`=@Name";
            MySqlCommand cmd = new MySqlCommand(query, _connect.Con);
            cmd.Parameters.AddWithValue("@Name", Name);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Password = dataReader["Password"] + "";
            }
            dataReader.Close();

            _connect.Con.Close();
            return Password;
        }

        public void AuthorisePerson(string UserID, int UniqueKey, DateTime Date)
        {
            _connect.Con.Open();

            MySqlCommand cmd = _connect.Con.CreateCommand();
            cmd.CommandText = "INSERT INTO `AuthorisationList` VALUES(@idAuthorisationList, @idUser, @UniqueKey, @Date)";
            cmd.Parameters.AddWithValue("@idAuthorisationList", null);
            cmd.Parameters.AddWithValue("@idUser", UserID);
            cmd.Parameters.AddWithValue("@UniqueKey", UniqueKey);
            cmd.Parameters.AddWithValue("@Date ", Date);
            cmd.ExecuteNonQuery();

            _connect.Con.Close();
        }

        public void DeauthorisePerson(string UserID)
        {
            _connect.Con.Open();

            MySqlCommand cmd = _connect.Con.CreateCommand();
            cmd.CommandText = "DELETE FROM `AuthorisationList` WHERE @idUser";
            cmd.Parameters.AddWithValue("@idUser", UserID);
            cmd.ExecuteNonQuery();

            _connect.Con.Close();
        }
    }
}
