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
    public class MedicamentoBRL : AbstractBRL
    {
        Common.Medicamento med;

        public Medicamento Med { get => med; set => med = value; }
        public MedicamentoDAL Dal1 { get => Dal; set => Dal = value; }

        MedicamentoDAL Dal;



      public  MedicamentoBRL()
        {
            Dal = new MedicamentoDAL();
        }
        public MedicamentoBRL( Medicamento med)
        {
            this.med = med;
            Dal = new MedicamentoDAL(med);
            
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
       //public Categoria Get(int idCategoria)
        //{
        //    return dal.Get(idCategoria);
        //}
        //public override void Update()
        //{
        //    dal.Update();
        //}
    }
}
