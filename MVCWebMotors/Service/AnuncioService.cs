using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json;
using MVCWebMotors.Models;

namespace MVCWebMotors.Service
{
    public class AnuncioService : IAnuncioService
    {
        public AnuncioService() { }
        public List<Anuncio> ListarAnunciosApi()
        {
            var client = new RestClient();
            var request = new RestRequest();
            List<Anuncio> result = new List<Anuncio>();
            request.Resource = "https://desafioonline.webmotors.com.br/api/OnlineChallenge/Vehicles?Page=1";
            result = JsonConvert.DeserializeObject<List<Anuncio>>(client.Execute(request).Content);
            return result;
        }

        public List<Anuncio> ListarAnunciosBancoDeDados()
        {
            DAO.DAO dao = new DAO.DAO();
            return dao.ListarAnuncios();
        }

        public bool InserirAnuncio(Anuncio anuncio)
        {
            DAO.DAO dao = new DAO.DAO();
            return dao.InserirAnuncio(anuncio);
        }

        public bool EditarAnuncio(Anuncio anuncio)
        {
            DAO.DAO dao = new DAO.DAO();
            return dao.EditarAnuncio(anuncio);
        }

        public bool RemoverAnuncio(Anuncio anuncio)
        {
            DAO.DAO dao = new DAO.DAO();
            return dao.RemoverAnuncio(anuncio);
        }
    }
}