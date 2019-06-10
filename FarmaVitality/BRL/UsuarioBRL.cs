using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL;


namespace BRL
{
    public class UsuarioBRL : AbstractBRL
    {

        Usuario usuario;
        private UsuarioDAL Dal;
        public Usuario Usuario { get => usuario; set => usuario = value; }
        public UsuarioDAL Dal1 { get => Dal; set => Dal = value; }

        public UsuarioBRL()
        {
            Dal = new UsuarioDAL();
        }
        public UsuarioBRL(Usuario usuario)
        {
            this.usuario = usuario;
            Dal = new UsuarioDAL(usuario);
        }

        public override void Delete()
        {
            Dal.Delete();
        }

        public override void Insert()
        {
            Dal.Insert();
        }

        public override DataTable Select()
        {
            return Dal.Select();
        }

        public override void Update()
        {
            Dal.Update();
        }
     
        }
        // public Usuario Get(int IdUsuario)
        // {
        //    return Dal.Get(IdUsuario);
        //}
       
    }

