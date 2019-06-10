using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class Medicamento
    {


        #region atributos de la clase Medicamento
        private int idMedicamento;
        private string nombreMedicamento;
        private DateTime fechaVencimiento;
        private double precioUnitario;
        private DateTime fechaActualizacion;
        private byte estado;
        private string tipoMedicamento;
        private byte cantidadMedicamentos;
     

        public int IdMedicamento { get => idMedicamento; set => idMedicamento = value; }
        public string NombreMedicamento { get => nombreMedicamento; set => nombreMedicamento = value; }
        public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public DateTime FechaActualizacion { get => fechaActualizacion; set => fechaActualizacion = value; }
        public byte Estado { get => estado; set => estado = value; }
        public string TipoMedicamento { get => tipoMedicamento; set => tipoMedicamento = value; }
        public byte CantidadMedicamentos { get => cantidadMedicamentos; set => cantidadMedicamentos = value; }
     

        #endregion

        #region  sobre carga de constructor
        public Medicamento()
        {

        }
        /// <summary>
        /// constructor para el metodo get
        /// </summary>
        /// <param name="idMedicamento"></param>
        /// <param name="nombreMedicamento"></param>
        /// <param name="fechaVencimiento"></param>
        /// <param name="PrecioUnitario"></param>
        /// <param name="fechaActualizacion"></param>
        /// <param name="Estado"></param>
        /// <param name="tipoMedicamento"></param>
        /// <param name="cantidadMedicamentos"></param>

        public Medicamento(int idMedicamento,  string           nombreMedicamento ,     DateTime         fechaVencimiento  ,    double            PrecioUnitario   ,      DateTime         fechaActualizacion,     byte          Estado  ,  string        tipoMedicamento     ,     byte         cantidadMedicamentos    )
        {
            this.    IdMedicamento       =    idMedicamento       ;
            this.      NombreMedicamento =      nombreMedicamento ;
            this.      FechaVencimiento  =      fechaVencimiento  ;
            this.       PrecioUnitario   =       PrecioUnitario   ;
            this.      FechaActualizacion=      fechaActualizacion;
            this.   Estado               =   Estado               ;
            this.   TipoMedicamento      =   tipoMedicamento      ;
            this.  CantidadMedicamentos  =  cantidadMedicamentos  ;
          
          
        }
        /// <summary>
        /// constructor para insert
        /// </summary>
        /// <param name="nombreMedicamento"></param>
        /// <param name="fechaVencimiento"></param>
        /// <param name="PrecioUnitario"></param>
        /// <param name="tipoMedicamento"></param>
        /// <param name="cantidadMedicamentos"></param>
        
        public Medicamento(string nombreMedicamento, DateTime fechaVencimiento, double PrecioUnitario, string tipoMedicamento, byte cantidadMedicamentos)
        {
           
            this.NombreMedicamento = nombreMedicamento;
            this.FechaVencimiento = fechaVencimiento;
            this.PrecioUnitario = PrecioUnitario;
            this.TipoMedicamento = tipoMedicamento;
            this.CantidadMedicamentos = cantidadMedicamentos;
         

        }
        #endregion
    }
}






