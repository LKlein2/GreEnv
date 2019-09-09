using GreEnv.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreEnv.Data
{
    public interface IEquipamentoData
    {
        Equipamento GetById(int id);
        IEnumerable<Equipamento> GetAll();
    }

    public class InMemoryEquipamentoData : IEquipamentoData
    {
        public List<Equipamento> Equipamentos;

        public InMemoryEquipamentoData()
        {
            Equipamentos = new List<Equipamento>()
            {
                new Equipamento { Id = 1, Nome = "Geladeira", Custo = 30.0f },
                new Equipamento { Id = 2, Nome = "Fritadeira", Custo = 50.0f },
                new Equipamento { Id = 3, Nome = "Lampada", Custo = 3.0f }
            };
        }

        public IEnumerable<Equipamento> GetAll()
        {
            return Equipamentos;
        }

        public Equipamento GetById(int id)
        {
            return Equipamentos.Where(e => e.Id == id).FirstOrDefault();
        }
    }
}
