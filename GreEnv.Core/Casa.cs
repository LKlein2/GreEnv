using System;
using System.Collections.Generic;
using System.Text;

namespace GreEnv.Core
{
    public class Casa
    {
        public int Id { get; set; }
        public Distribuidora Distribuidora { get; set; }
        public List<EquipamentoCasa> EquipamentosCasa { get; set; }
    }
}
