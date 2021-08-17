using MVCWebMotors.Models;
using MVCWebMotors.Service;
using System.Web.Mvc;

namespace MVCWebMotors.Controllers
{
    public class AnuncioController : Controller
    {
        private IAnuncioService anuncioService = new AnuncioService();
        
        public ActionResult Index()
        {
            AnuncioModel model = new AnuncioModel();
            model.Anuncios = anuncioService.ListarAnunciosBancoDeDados();
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public string InserirAnuncio(Anuncio anuncio)
        {
            var result = string.Empty;
            if (anuncioService.InserirAnuncio(anuncio))
            {
                result = "Anuncio Inserido com Sucesso";
            }
            else
            {
                result = "Não foi possível realizar o cadastro do seu anuncio";
            }
            return result;
        }

        [AllowAnonymous]
        [HttpPut]
        public string EditarAnuncio(Anuncio anuncio)
        {
            var result = string.Empty;
            if (anuncioService.InserirAnuncio(anuncio))
            {
                result = "Anuncio Atualizado com Sucesso";
            }
            else
            {
                result = "Não foi possível atualizar o seu anuncio";
            }
            return result;
        }

        [AllowAnonymous]
        [HttpDelete]
        public string RemoverAnuncio(Anuncio anuncio)
        {
            var result = string.Empty;
            if (anuncioService.InserirAnuncio(anuncio))
            {
                result = "Anuncio Removido com Sucesso";
            }
            else
            {
                result = "Não foi possível remover o cadastro do seu anuncio";
            }
            return result;
        }
    }
}