using MVCWebMotors.Models;
using System.Collections.Generic;

namespace MVCWebMotors.Service
{
    public interface IAnuncioService
    {
        List<Anuncio> ListarAnunciosApi();

        List<Anuncio> ListarAnunciosBancoDeDados();

        bool InserirAnuncio(Anuncio anuncio);

        bool EditarAnuncio(Anuncio anuncio);

        bool RemoverAnuncio(Anuncio anuncio);
        
    }
}
