using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Data
{
    public class Authorisation
    {
        private readonly ConnectionClass _connect;
        public Authorisation(ConnectionClass connect)
        {
            _connect = connect;
        }

        public string GetPassword(string Name)
        {
            string Password = "";
            try
            {
                _connect.Con.Open();

                string query = "SELECT `Password` FROM `User` WHERE `Name`=@Name";
                MySqlCommand cmd = new MySqlCommand(query, _connect.Con);
                cmd.Parameters.AddWithValue("@Name", Name);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Password = dataReader["Password"] + "";
                }
                dataReader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connect.Con.Close();
            }
            
            return Password;
        }

        public void AuthorisePerson(int UserID, int UniqueKey, DateTime Date)
        {
            _connect.Con.Open();
            try
            {
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "INSERT INTO `authorisationlist` (`idUser`, `UniqueKey`, `Date`) VALUES (@idUser, @UniqueKey, @Date)";
                cmd.Parameters.AddWithValue("@idUser", UserID);
                cmd.Parameters.AddWithValue("@UniqueKey", UniqueKey);
                cmd.Parameters.AddWithValue("@Date", Date);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connect.Con.Close();
            }
        }

        public void DeauthorisePerson(int UserID)
        {
            _connect.Con.Open();
            try
            {
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "DELETE FROM `authorisationlist` WHERE @idUser";
                cmd.Parameters.AddWithValue("@idUser", UserID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connect.Con.Close();
            }
        }

        public void AddUser(string Name, string Password)
        {
            _connect.Con.Open();
            try
            {
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "INSERT INTO `User` (`idUser`, `Name`, `Password`) VALUES (@idUser, @Name, @Password)";
                cmd.Parameters.AddWithValue("@idUser", null);
                cmd.Parameters.AddWithValue("@UniqueKey", Name);
                cmd.Parameters.AddWithValue("@Date", Password);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connect.Con.Close();
            }
        }

        public void DeleteUser(int UserID)
        {
            _connect.Con.Open();
            try
            {
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "DELETE FROM `User` WHERE @idUser";
                cmd.Parameters.AddWithValue("@idUser", UserID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connect.Con.Close();
            }
        }
    }
}
