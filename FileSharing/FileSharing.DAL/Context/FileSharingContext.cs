using FileSharing.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.DAL.Context
{
    public class FileSharingContext : IContext
    {
        private string ConnectionString { get; set; }

        public FileSharingContext()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["FileSharingConnection"].ToString();
        }

        public void CloseConnection(SqlConnection connection)
        {
            connection.Close();
        }

        public SqlParameter CreateParameter(string name, object value, DbType dbType)
        {
            return CreateParameter(name, 0, value, dbType, ParameterDirection.Input);
        }

        public SqlParameter CreateParameter(string name, int size, object value, DbType dbType)
        {
            return CreateParameter(name, size, value, dbType, ParameterDirection.Input);
        }

        public SqlParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new SqlParameter
            {
                DbType = dbType,
                ParameterName = name,
                Size = size,
                Direction = direction,
                Value = value
            };
        }

        public void Delete(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataSet GetDataSet(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    var dataset = new DataSet();
                    var dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataset);
                    return dataset;
                }
            }
        }

        public DataTable GetDataTable(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    var dataset = new DataSet();
                    var dataAdaper = new SqlDataAdapter(command);
                    dataAdaper.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }
        public void Insert(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            using(var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command =new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if(parameters != null)
                    {
                        foreach(var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
