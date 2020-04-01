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

        public AccountDTO GetUser(string username)
        {
            AccountDTO account = new AccountDTO();
            try
            {
                _connect.Con.Open();

                string query = "SELECT user.idUser, user.Name, user.Password, role.Name as Role FROM `userrole`" 
                    + " INNER JOIN `user` ON userrole.idUser = user.idUser" 
                    + " INNER JOIN `role` ON userrole.idRole = role.idRole WHERE user.Name = @Name";
                MySqlCommand cmd = new MySqlCommand(query, _connect.Con);
                cmd.Parameters.AddWithValue("@Name", username);
                var dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        account.UserId = dataReader.GetInt32("idUser");
                        account.Username = dataReader.GetString("Name");
                        account.HashedPassword = dataReader.GetString("Password");
                        account.UserRole = dataReader.GetString("Role");
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

        public void Login(string username, DateTime Date)
        {
            int UserId = 0;
            int UniqueKey = 0;
            _connect.Con.Open();
            try
            {
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "INSERT INTO `authorisationlist` (`idUser`, `UniqueKey`, `Date`) VALUES (@idUser, @UniqueKey, @Date)";
                cmd.Parameters.AddWithValue("@idUser", UserId);
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

        public void AddAccount(int role, string name, string password)
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

        public void AddAccount(AccountDTO account)
        {
            _connect.Con.Open();
            try
            {
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "INSERT INTO `User` (`idUser`, `Name`, `Password`) VALUES (@idUser, @Name, @Password)";
                cmd.Parameters.AddWithValue("@idUser", null);
                cmd.Parameters.AddWithValue("@Name", account.Username);
                cmd.Parameters.AddWithValue("@Password", account.HashedPassword);
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
