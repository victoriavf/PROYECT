using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Common;
using DAL;



namespace DAL
{
    public class UsuarioDAL : AbstractDAL
    {
        private Usuario usuario;

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public UsuarioDAL(Usuario usuario)
        {
            this.usuario = usuario;
        }
        public UsuarioDAL()
        {

        }
       
        public override void Delete()
        {
            string query = @"update usuario set estado =0,fechaActualizacion=CURRENT_TIMESTAMP 
                            where idUsuario=@id";
            MySqlCommand cmd;
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", usuario.IdUsuario);

                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

      

        public override void Insert()

        {
                  
            string query = @"INSERT INTO usuario (nombre,primerApellido,segundoApellido,ci,telefono,direccion,email,fechaRegistro,rol,nombreUsuario,password)
                                           VALUES(@nombre, @primerApellido, @segundoApellido, @ci,@telefono, @direccion,@email,@fechaRegistro,@rol,@nombreUsuario,md5(@Password))";
            MySqlCommand cmd;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@primerApellido", usuario.PrimerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", usuario.SegundoApellido);
                cmd.Parameters.AddWithValue("@ci", usuario.Ci);
                cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);         
                cmd.Parameters.AddWithValue("@direccion", usuario.Direccion);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@fechaRegistro", usuario.FechaRegistro);
                cmd.Parameters.AddWithValue("@rol", usuario.Rol);
                cmd.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@Password", usuario.Password);
    

                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public override DataTable Select()
        {
            DataTable res = new DataTable();
            string query = @"   SELECT idUsuario , CONCAT( nombre  ,'',primerApellido , '',segundoApellido) AS 'NOMBRE COMPLETO' ,ci AS 'C.I.',telefono AS 'NUMERO DE TELEFONO',direccion AS 'DIRECCION',email as 'CORREO ELECTRONICO', fechaRegistro AS 'FECHA DE INGRESO',rol AS 'ROL',nombreUsuario,fechaActualizacion AS 'FECHA DE ACTUALIZACION'
                             FROM usuario
                             WHERE Estado=1";
            MySqlCommand cmd;
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                res = Methods.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return res;
        }

        public override void Update()
        {


         //        nombre primerApellido segundoApellido ci telefono direccion email fechaRegistro rol nombreUsuario password
            string query = @"update usuario set nombre = @nombre, primerApellido = @primerApellido, segundoApellido = @segundoApellido, ci = @ci, telefono = @telefono, direccion = @direccion,femail=@email,fechaRegistro=@fechaRegistro, rol = @rol,nombreUsuario=@nombreUsuario, password = @password,FechaActualizacion=CURRENT_TIMESTAMP
                            WHERE idUsuario=@id";
            MySqlCommand cmd;
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@primerApellido", usuario.PrimerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", usuario.SegundoApellido);
                cmd.Parameters.AddWithValue("@ci", usuario.Ci);
                cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@direccion", usuario.Direccion);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@fechaRegistro", usuario.FechaRegistro);
                cmd.Parameters.AddWithValue("@rol", usuario.Rol);
                cmd.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@Password", usuario.Password);          
            
                cmd.Parameters.AddWithValue("@id", usuario.IdUsuario);

                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Usuario Get(int IdUsuario)
        {
            Usuario res = null;

            string query = @"select idUsuario,nombre,primerApellido,segundoApellido,ci,telefono,direccion,rol,password,estado,fechaActualizacion,email
                                   from	 usuario 
                                    where IdUsario=@id";

            MySqlCommand cmd = null;
            MySqlDataReader dr = null;

            //try
            //{
            //    cmd = Methods.CreateBasicCommand(query);
            //    cmd.Parameters.AddWithValue("@id", IdUsuario);
            //    dr = Methods.ExecuteDataReaderCommand(cmd);

            //    //while (dr.Read(cmd))
            //    //{
            //    //    res = new Usuario(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),int.Parse(dr[5].ToString()), dr[6].ToString(), dr[7].ToString(), int.Parse(dr[8].ToString()), dr[9].ToString() DateTime.Parse(dr[10].ToString()), DateTime.Parse(dr[11].ToString()), dr[12].ToString());
            //    //}

            //}
            //catch (Exception ex)
            //{


            //    throw ex;
            //}
            //finally
            //{
            //    //dr.Close();
            //    cmd.Connection.Close();
            //}

            return res;

        }
       
    }
}

