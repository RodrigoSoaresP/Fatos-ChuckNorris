using AutoMapper;
using Fatos.Modelo;
using Fatos.Service.Model;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Fatos.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public Worker(ILogger<Worker> logger, IHttpClientFactory httpClient, IMapper mapper)
        {
            _logger = logger;
            _httpClient = httpClient.CreateClient();
            _mapper = mapper;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {


                _logger.LogInformation($"Serviço executado às {DateTime.Now}");


                FatosModelRetorno fatosRetorno = await ObterFatos();
                FatosModel fatos = ConverterRetornoParaFatos (fatosRetorno);
                //FatosModel fatos = _mapper.Map<FatosModel>(fatosRetorno);
                await InserirDbInterno(fatos);
                await Task.Delay(20000, stoppingToken);
            }
        }
        private async Task<FatosModelRetorno> ObterFatos()
        {
            HttpResponseMessage retorno = await _httpClient.GetAsync($"https://api.chucknorris.io/jokes/random");

            if (retorno.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<FatosModelRetorno>(await retorno.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(retorno.ReasonPhrase);
            }

        }
        private async Task InserirDbInterno(FatosModel fatosModel)
        {
            HttpResponseMessage retorno = await _httpClient.PostAsJsonAsync($"https://localhost:7092/api/Fatos", fatosModel);
            if (retorno.IsSuccessStatusCode)
            {

            }
            else
            {
                throw new Exception(retorno.ReasonPhrase);
            }
        }

        private FatosModel ConverterRetornoParaFatos(FatosModelRetorno fatosRetorno)
        {
            FatosModel fatos = new FatosModel();
            fatos.FatosChuckNorris = fatosRetorno.value;
            fatos.DataCriacao = DateTime.Now;

            return fatos;

        }

    }
}