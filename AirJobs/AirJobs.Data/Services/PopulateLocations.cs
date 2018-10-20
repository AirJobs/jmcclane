using System.Collections.Generic;
using System.Threading.Tasks;
using AirJobs.Domain.Entities.Address;
using AirJobs.Domain.Interfaces.Data.UnitOfWork;
using RestSharp;

namespace AirJobs.Data.Services
{
    public class PopulateLocations
    {
        private readonly IUnitOfWork unitOfWork;

        public PopulateLocations(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Populate()
        {
            var brasil = await unitOfWork.Country.Get(x => x.Name == "Brasil");
            if (brasil == null)
                brasil = await unitOfWork.Country.Add(new Country
                {
                    Name = "Brasil"
                });

            var apiUrl = "http://servicodados.ibge.gov.br/";
            var client = new RestClient(apiUrl);
            var estadoRequest = new RestRequest("api/v1/localidades/estados", Method.GET);

            var ufResponse = client.Execute<List<UF>>(estadoRequest);

            foreach (var estado in ufResponse.Data)
            {
                var state = await unitOfWork.State.Add(new State
                {
                    Name = estado.nome,
                    UF = estado.sigla,
                    Country = brasil
                });

                var municipioRequest =
                    new RestRequest($"api/v1/localidades/estados/{estado.id}/municipios", Method.GET);
                var municioResponse = client.Execute<List<Municipio>>(municipioRequest);
                foreach (var municipio in municioResponse.Data)
                    await unitOfWork.City.Add(new City
                    {
                        Name = municipio.nome,
                        State = state
                    });
            }

            unitOfWork.Save();
        }

        #region Models

        public class Municipio
        {
            public int id { get; set; }
            public string nome { get; set; }
            public Microrregiao microrregiao { get; set; }
        }

        public class Microrregiao
        {
            public int id { get; set; }
            public string nome { get; set; }
            public Mesorregiao mesorregiao { get; set; }
        }

        public class Mesorregiao
        {
            public int id { get; set; }
            public string nome { get; set; }
            public UF UF { get; set; }
        }

        public class UF
        {
            public int id { get; set; }
            public string sigla { get; set; }
            public string nome { get; set; }
            public Regiao regiao { get; set; }
        }

        public class Regiao
        {
            public int id { get; set; }
            public string sigla { get; set; }
            public string nome { get; set; }
        }

        #endregion
    }
}