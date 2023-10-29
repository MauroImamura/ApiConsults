using System.Net.Http.Headers;

namespace App.DolarComercial.Models
{
    public class DolarComercialRepository : IDolarComercialRepository
    {
        private readonly string sourceRoot;

        public DolarComercialRepository()
        {
            sourceRoot = "https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/";
        }
        public Cotacao GetCotacoes(DateOnly data)
        {
            string? param = $"CotacaoDolarDia(dataCotacao=@dataCotacao)?%40dataCotacao='{data.ToString("MM-dd-yyyy")}'";

            var client = new HttpClient();
            client.BaseAddress = new Uri(sourceRoot);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = client.GetAsync(param).Result;

                if(response.IsSuccessStatusCode)
                {
                    var retorno = new Cotacao(data);
                    var content = response.Content.ReadAsStringAsync().Result;
                    retorno.SetTipoResposta(ETipoResposta.valido);
                    retorno.SetCotacoes(content);

                    return retorno;
                }

                return new Cotacao(data);
            }
            catch (Exception)
            {
                return new Cotacao(data);
            }
        }
    }
}