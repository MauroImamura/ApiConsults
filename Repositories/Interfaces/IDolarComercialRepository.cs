namespace App.DolarComercial.Models
{
    public interface IDolarComercialRepository
    {
        Cotacao GetCotacoes(DateOnly data);
    }
}