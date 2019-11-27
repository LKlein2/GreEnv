using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreEnv;
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
        private readonly IDistribuidoraData distribuidoraData;

        public int id;
        public Casa Casa { get; set; }
        public IEnumerable<Equipamento> Equipamentos { get; set; }
        public IEnumerable<Distribuidora> Distribuidoras { get; set; }
        public IndexController indexController { get; set; } = new IndexController();

        [BindProperty]
        public EquipamentoCasa EquipamentoCasa { get; set; } = new EquipamentoCasa();

        [BindProperty]
        public int EquipamentoId { get; set; }
        [BindProperty]
        public int DistribuidoraId { get; set; }

        public IndexModel(ICasaData casaData,
                          IEquipamentoData equipamentoData,
                          IDistribuidoraData distribuidoraData)
        {
            this.casaData = casaData;
            this.equipamentoData = equipamentoData;
            this.distribuidoraData = distribuidoraData;
        }

        private void Initialize()
        {
            Equipamentos = equipamentoData.GetAll();
            Casa = casaData.GetById(1);
            Distribuidoras = distribuidoraData.GetAll();
        }

        public IActionResult OnGet()
        {
            Initialize();
            return Page();
        }

        public IActionResult OnPost()
        {
            Initialize();
            EquipamentoCasa.Equipamento = equipamentoData.GetById(EquipamentoId);
            indexController.InserirEletronico(EquipamentoCasa, Casa);
            return Page();
        }

        public ActionResult OnPostCalculate()
        {
            Initialize();
            
            return Page();
        }
    }
}
