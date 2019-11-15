using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreEnv.Core;
using GreEnv.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICasaData casaData;
        private readonly IEquipamentoData equipamentoData;

        public int id;
        public Casa Casa { get; set; }
        public IEnumerable<Equipamento> Equipamentos { get; set; }

        [BindProperty]
        public EquipamentoCasa EquipamentoCasa { get; set; } = new EquipamentoCasa();

        [BindProperty]
        public int EquipamentoId { get; set; }

        public IndexModel(ICasaData casaData,
                          IEquipamentoData equipamentoData)
        {
            this.casaData = casaData;
            this.equipamentoData = equipamentoData;
        }

        public IActionResult OnGet()
        {
            Equipamentos = equipamentoData.GetAll();
            Casa = casaData.GetById(1);
            return Page();
        }

        public IActionResult OnPost()
        {
            Casa = casaData.GetById(1);
            Equipamentos = equipamentoData.GetAll();
            EquipamentoCasa.Equipamento = equipamentoData.GetById(EquipamentoId);
            Casa.EquipamentosCasa.Add(EquipamentoCasa);

            return Page();
        }
    }
}
