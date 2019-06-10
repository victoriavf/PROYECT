using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public  class Methods
    {
        #region Atributos
        static string cadenaConexion = "server=localhost;database=bdFarmacia;Uid=root;pwd=;Port=3306";
        static MySqlConnection conexion;
        #endregion

        #region Metodos de Creacion de comandos
        public static MySqlCommand CreateBasicComand()
        {
            conexion = new MySqlConnection(cadenaConexion);
            MySqlCommand res = new MySqlCommand();
            res.Connection = conexion;
            return res;
        }
        public static MySqlCommand CreateBasicCommand(string query)
        {
            conexion = new MySqlConnection(cadenaConexion);
            MySqlCommand res = new MySqlCommand(query);
            res.Connection = conexion;
            return res;
         
        }

        public static List<MySqlCommand> CreateNBasicCommand(int n)
        {
            List<MySqlCommand> res = new List<MySqlCommand>();
            conexion = new MySqlConnection(cadenaConexion);

            for (int i = 0; i < n; i++)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.Text;
                res.Add(cmd);
            }

            return res;
        }

        #region Ejecucion de comandos
        public static void ExecuteBasicCommand(MySqlCommand cmd)
        {
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public static void ExecuteNBasicComand(List<MySqlCommand> cmds)
        {
            MySqlTransaction tran = null;
            try
            {
                cmds[0].Connection.Open();
                tran = cmds[0].Connection.BeginTransaction();
                foreach (MySqlCommand item in cmds)
                {
                    item.Transaction = tran;
                    item.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                cmds[0].Connection.Close();
            }
        }

        //llenar a dataTable

        public static DataTable  ExecuteTableCommand(MySqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }
         public static string ExecuteScalarCommand(MySqlCommand cmd)
        {
            string res =null;
            try
            {
                cmd.Connection.Open();
                res=cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return res;
        }

        #endregion

        public static int GetAutoIncrementTable(string tabla)
        {
            int res = 0 ;
            string query = @"select AUTO_INCREMENT
                        from information_schema.tables 
                       Where table_schema = 'bdfarvitality' 
                       and table_name = '"+tabla+"'";

            MySqlCommand cmd = CreateBasicCommand(query);


            try
            {
                res = int.Parse(ExecuteScalarCommand(cmd));
            }
            catch (Exception ex)
            {
             

                throw  ex;
            }
            return res;
        }
    
        public static  DataTable  ExecuteDataTableCommand(MySqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return dt;
        }

        public static MySqlDataReader ExecuteDataReaderCommand(MySqlCommand cmd)
        {
            MySqlDataReader res = null;
            try
            {
                cmd.Connection.Open();
                res = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return res;
        }

        #endregion
    }


}
