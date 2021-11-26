using Base.DAO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base
{
    class Program
    {
        static void Main(string[] args)
        {


            aaa();
            
        }

        public static async Task aaa()
        {

            DbHotelEContext context = new DbHotelEContext();
            ControllerTipoQuarto daoTipoQuarto = new ControllerTipoQuarto();
            TipoQuarto quarto = new TipoQuarto();
            List<TipoQuarto> quartos = new List<TipoQuarto>();
            int id;
            quarto.Img1 = "Teste";
            quarto.Img2 = "Teste";
            quarto.Img3 = "Teste";
            quarto.Nome = "Aquele";
             daoTipoQuarto.Create(quarto);

           // context.TbTipoQuartos.Add(quarto);
            //context.SaveChanges();
            quartos.AddRange( daoTipoQuarto.Get());
            Console.WriteLine(Convert.ToString(quartos.Count));
        }

    }
}
