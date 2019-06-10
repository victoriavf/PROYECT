using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class MedicamentoDAL : AbstractDAL
    {

        Common.Medicamento med;
        public MedicamentoDAL (Medicamento med )
        {
            this.med = med;
        }
        public MedicamentoDAL()
        {

        }

        public Medicamento Med { get => med; set => med = value; }

        public override void Delete()
        {
            string query = @"update medicamento set estado=0 , fechaActualizacion=current_timestamp
                           
                             where idMedicamento=@idMedicamento";
            MySqlCommand cmd;
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idMedicamento", med.IdMedicamento);

                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override void Insert()

        {
            string query = @"insert into medicamento(nombreMedicamento,fechaVencimiento,PrecioUnitario,tipoMedicamento,cantidadMedicamentos)
                            values(@nombreMedicamento,@fechaVencimiento,@PrecioUnitario,@tipoMedicamento,@cantidadMedicamentos)";

            MySqlCommand cmd;
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@nombreMedicamento", med.NombreMedicamento);
                cmd.Parameters.AddWithValue("@fechaVencimiento", med.FechaVencimiento);
                cmd.Parameters.AddWithValue("@PrecioUnitario", med.PrecioUnitario);
                cmd.Parameters.AddWithValue("@tipoMedicamento", med.TipoMedicamento);
                cmd.Parameters.AddWithValue("@cantidadMedicamentos", med.CantidadMedicamentos);
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

            
            string query = @"SELECT idMedicamento, nombreMedicamento AS 'NOMBRE DEL MEDICAMENTO' ,fechaVencimiento AS 'FECHA DE VENCIMIENTO',PrecioUnitario AS 'PRECIO UNITARIO',tipoMedicamento AS 'TIPO DE MEDICAMENTO' , cantidadMedicamentos AS 'CANTIDAD DE MEDICAMENTOS',fechaActualizacion AS 'FECHA DE MODIFICACION'
                        FROM medicamento
                         where estado=1";
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
            //nombreMedicamento,fechaVencimiento,PrecioUnitario,tipoMedicamento,cantidadMedicamentos
            string query = @"update medicamento set   nombreMedicamento = @nombreMedicamento,fechaVencimiento = @fechaVencimiento,PrecioUnitario = @PrecioUnitario,tipoMedicamento = @tipoMedicamento,cantidadMedicamentos = @cantidadMedicamentos,fechaActualizacion=current_timestamp
                                where idMedicamento = @id";
            MySqlCommand cmd;
            try
            {
                cmd = Methods.CreateBasicCommand(query);


                cmd.Parameters.AddWithValue("@nombreMedicamento", med.NombreMedicamento);
                cmd.Parameters.AddWithValue("@fechaVencimiento", med.FechaVencimiento);
                cmd.Parameters.AddWithValue("@PrecioUnitario", med.PrecioUnitario);
                cmd.Parameters.AddWithValue("@tipoMedicamento", med.TipoMedicamento);
                cmd.Parameters.AddWithValue("@cantidadMedicamentos", med.CantidadMedicamentos);
                cmd.Parameters.AddWithValue("@id", med.IdMedicamento);
            



                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Medicamento Get(int idMedicamento)
        {
            Medicamento res = null;

            string query = @"SELECT idMedicamento,nombreMedicamento,fechaVencimiento,PrecioUnitario,fechaActualizacion,estado,tipoMedicamento,cantidadMedicamentos
                                   from	 medicamento 
                                    where idMedicamento=@idMedicamento";

            MySqlCommand cmd = null;
            MySqlDataReader dr = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idMedicamento", idMedicamento);
                dr = Methods.ex(cmd);

                while (dr.Read())
                {
                    res = new Medicamento(int.Parse(dr[0].ToString()), dr[1].ToString(),DateTime.Parse( dr[2].ToString()), double.Parse(dr[3].ToString()), DateTime.Parse(dr[4].ToString()),);
                }

            }
            catch (Exception ex)
            {


                throw ex;
            }
            finally
            {
                dr.Close();
                cmd.Connection.Close();
            }

            return res;

        }
        //public DataTable SelectIDName()
        //{

        //    DataTable res = new DataTable();
        //    string query = @"select  idCategoria,Nombre
        //                    from categoria
        //                    where estado = 1
        //                    order by 2; ";
        //    MySqlCommand cmd;
        //    try
        //    {
        //        cmd = Methods.CreateBasicCommand(query);
        //        res = Methods.ExecuteDataTableCommand(cmd);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }


        //    return res;
        //}
    }
}
