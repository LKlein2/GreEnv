using GreEnv.Core;
using GreEnv.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreEnv
{
    public class IndexController
    {
        public float ConsumoTotal { get; set; }
        public float ConsumoMedioTotal { get; set; }
        public EquipamentoCasa EquipamentoMaisConsome { get; set; }
        public EquipamentoCasa EquipamentoMenosConsome { get; set; }
        //public Dictionary<string, Equipamento> 

        public IndexController()
        {

        }

        public void InserirEletronico(EquipamentoCasa equipamento, Casa casa)
        {
            casa.EquipamentosCasa.Add(equipamento);
        }

        public void CalcularConsumo(Casa casa, IEquipamentoData equipamentoData)
        {
            float total = 0, horas = 0, horasTotal = 0, preco = 0, precoTotal = 0;
            int qtdeTotal = 0, qtde = 0;

            foreach (EquipamentoCasa equipamento in casa.EquipamentosCasa)
            {
                preco = equipamentoData.GetById(equipamento.Equipamento.Id).Custo;
                horas = equipamento.HorasLigado;
                qtde = equipamento.Quantidade;

                total = preco * horas * qtde;

                qtdeTotal += qtde;
                precoTotal += total;
                horasTotal += horas;
            }

            var result = casa.EquipamentosCasa.GroupBy(eq => eq.Equipamento.Id).Select(equip => new EquipamentoSum
            {
                Id = equip.First().Equipamento.Id,
                Qtde = equip.Count(),
                Custo = equip.Sum(custo => custo.HorasLigado * preco)
            }).ToList();

        }
    }

    public class EquipamentoSum
    {
        public int Id { get; set; }
        public float Custo { get; set; }
        public int Qtde { get; set; }
    }
}
