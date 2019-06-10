using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
  public  class Usuario
    {

        #region atributos de la clase usuario
        private int          idUsuario;
        private string       nombre;
        private string   primerApellido;
        private string   segundoApellido;
        private string   ci;
        private int      telefono;
        private string   direccion;
        private string   email;
        private DateTime fechaRegistro;
        private string   rol;
        private string   nombreUsuario;
        private string   password;
        private byte            estado;
        private DateTime fechaActualizacion;
        
       
        #endregion

        #region todo ge y set de los atributos
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string PrimerApellido { get => primerApellido; set => primerApellido = value; }
        public string SegundoApellido { get => segundoApellido; set => segundoApellido = value; }
        public string Ci { get => ci; set => ci = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Email { get => email; set => email = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public string Rol { get => rol; set => rol = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Password { get => password; set => password = value; }

        public byte Estado { get => estado; set => estado = value; }
        public DateTime FechaActualizacion { get => fechaActualizacion; set => fechaActualizacion = value; }      
     
        #endregion

        #region sobre carga de constructores

        public Usuario()
        {
       
        }
        /// <summary>
        /// constructur completo
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="nombre"></param>
        /// <param name="primerApellido"></param>
        /// <param name="segundoApellido"></param>
        /// <param name="ci"></param>
        /// <param name="telefono"></param>
        /// <param name="direccion"></param>
        /// <param name="email"></param>
        /// <param name="fechaRegistro"></param>
        /// <param name="rol"></param>
        /// <param name="nombreUsuario"></param>
        /// <param name="password"></param>
        /// <param name="estado"></param>
        /// <param name="fechaActualizacion"></param>
        public Usuario(int idUsuario,  string nombre,  string primerApellido,  string segundoApellido, string ci, int telefono,string direccion,string email, DateTime fechaRegistro,     string rol,   string nombreUsuario    ,string password,          byte estado,     DateTime fechaActualizacion)
         {this.     idUsuario=     idUsuario;
          this.     nombre=     nombre;
          this. primerApellido= primerApellido;
          this. segundoApellido= segundoApellido;
          this. ci= ci;
          this. telefono= telefono;
          this. direccion= direccion;
          this. email= email;
          this. fechaRegistro= fechaRegistro;
          this. rol= rol;
          this. nombreUsuario= nombreUsuario;
          this. password= password;
          this.        estado=        estado;
          this.fechaActualizacion= fechaActualizacion;
         

        }
        /// <summary>
        /// constructor para  insert
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="primerApellido"></param>
        /// <param name="segundoApellido"></param>
        /// <param name="ci"></param>
        /// <param name="telefono"></param>
        /// <param name="direccion"></param>
        /// <param name="email"></param>
        /// <param name="fechaRegistro"></param>
        /// <param name="rol"></param>
        /// <param name="nombreUsuario"></param>
        /// <param name="password"></param>
        public Usuario( string nombre, string primerApellido, string segundoApellido, string ci, int telefono, string direccion, string email, DateTime fechaRegistro, string rol, string nombreUsuario, string password)
        {
         
            this.nombre = nombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.ci = ci;
            this.telefono = telefono;
            this.direccion = direccion;
            this.email = email;
            this.fechaRegistro = fechaRegistro;
            this.rol = rol;
            this.nombreUsuario = nombreUsuario;
            this.password = password;       
        }

        #endregion

    }


}
    











