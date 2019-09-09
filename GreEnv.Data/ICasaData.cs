using GreEnv.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreEnv.Data
{
    public interface ICasaData
    {
        Casa GetById(int id);
    }

    public class InMemoryCasaData : ICasaData
    {
        public Casa Casa;

        public InMemoryCasaData()
        {
            Casa = new Casa()
            {
                Id = 1,
                Distribuidora = new InMemoryDistribuidoraData().GetById(1),
                EquipamentosCasa = new List<EquipamentoCasa>()
                {
                    new EquipamentoCasa {Equipamento = new InMemoryEquipamentoData().GetById(1), Quantidade = 2, HorasLigado = 6},
                    new EquipamentoCasa {Equipamento = new InMemoryEquipamentoData().GetById(2), Quantidade = 3, HorasLigado = 2},
                    new EquipamentoCasa {Equipamento = new InMemoryEquipamentoData().GetById(3), Quantidade = 1, HorasLigado = 8}
                }
            };
        }

        public Casa GetById(int id)
        {
            return Casa;
        }
    }
}
