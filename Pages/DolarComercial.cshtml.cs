using App.DolarComercial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.DolarComercial
{
    public class DolarComercialHistoricoModel : PageModel
    {
        private readonly IDolarComercialRepository _dolarComercialRepository;

        public Cotacao DadosReq {get; set;} = new Cotacao(DateTime.Today.AddDays(-1));
        public ETipoResposta TipoResposta { get; set; }
        public DateOnly DataRef = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

        public DolarComercialHistoricoModel(IDolarComercialRepository dolarComercialRepository)
        {
            _dolarComercialRepository = dolarComercialRepository;
        }

        public void OnGet(string dataSlc)
        {
            var _dataRef = DateOnly.FromDateTime(Convert.ToDateTime(dataSlc));
            DataRef = _dataRef;
            DadosReq = _dolarComercialRepository.GetCotacoes(_dataRef);
        }
    }
}
