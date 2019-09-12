using GreEnv.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreEnv.Data
{
    public interface IEquipamentoCasaData
    {
        EquipamentoCasa Create(EquipamentoCasa equipamentoData);
    }

    public class InMemoryEquipamentoCasaData : IEquipamentoCasaData
    {
        public EquipamentoCasa Create(EquipamentoCasa equipamentoData)
        {
            throw new NotImplementedException();
        }
    }
}
