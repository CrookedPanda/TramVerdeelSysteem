using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Model.DTOs;
using MySql.Data.MySqlClient;

namespace Data
{
    public class Authorisation : IDatabaseAccount
    {
        private readonly ConnectionClass _connect;
        public Authorisation(ConnectionClass connect)
        {
            _connect = connect;
        }

        public Authorisation()
        {
            _connect = new ConnectionClass();
        }

        public LoginDTO GetUser(string username)
        {
            LoginDTO account = new LoginDTO();
            try
            {
                _connect.Con.Open();

                string query = "SELECT user.idUser, user.Name, user.Password FROM User WHERE user.Name = @name";
                MySqlCommand cmd = new MySqlCommand(query, _connect.Con);
                cmd.Parameters.AddWithValue("@Name", username);
                var dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        account.ID = dataReader.GetInt32("idUser");
                        account.Username = dataReader.GetString("Name");
                        account.Password = dataReader.GetString("Password");

                    }
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
            
            return account;
        }

        public bool Login(string username, DateTime Date, string AuthKey)
        {
            try
            {
                _connect.Con.Open();
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "INSERT INTO `authorisationlist` (`idUser`, `UniqueKey`, `Date`) VALUES ((SELECT idUser FROM User WHERE Name = @Username), @UniqueKey, @Date)";
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@UniqueKey", AuthKey);
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
            return true;
        }

        public void Logout(int UserID)
        {
            _connect.Con.Open();
            try
            {
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "DELETE FROM `authorisationlist` WHERE idUser = @idUser";
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

        public void AddAccount(List<int> roles, string name, string password)
        {
            _connect.Con.Open();
            try
            {
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "INSERT INTO `User` (`idUser`, `Name`, `Password`) VALUES (@idUser, @Name, @Password)";
                cmd.Parameters.AddWithValue("@idUser", null);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Password", password);
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

        public void AddAccount(RegistrationDTO account)
        {
            _connect.Con.Open();
            try
            {
                //TODO add Roles
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "INSERT INTO `User` (`idUser`, `Name`, `Password`) VALUES (@idUser, @Name, @Password)";
                cmd.Parameters.AddWithValue("@idUser", null);
                cmd.Parameters.AddWithValue("@Name", account.Username);
                cmd.Parameters.AddWithValue("@Password", account.Password);
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

        public void RemoveAccount(int UserID)
        {
            _connect.Con.Open();
            try
            {
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "DELETE FROM `User` WHERE idUser = @idUser";
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
