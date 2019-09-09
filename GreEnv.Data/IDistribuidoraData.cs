using GreEnv.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreEnv.Data
{
    interface IDistribuidoraData
    {
        Distribuidora GetById(int id);
    }

    public class InMemoryDistribuidoraData : IDistribuidoraData
    {
        public Casa Casa;
        public List<Distribuidora> Distribuidoras;

        public InMemoryDistribuidoraData()
        {
            Distribuidoras = new List<Distribuidora>()
            {
                new Distribuidora { Id = 1, Nome = "RGE", Preco = 0.50f },
                new Distribuidora { Id = 2, Nome = "RGE Sul", Preco = 0.45f }
            };
        }

        public Distribuidora GetById(int id)
        {
            return Distribuidoras.Where(d => d.Id == id).FirstOrDefault();
        }
    }


}
