using Datalayer;
using Datalayer.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Net.Http.Json;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            this.serviceProvider = serviceProvider;
        }




        public async Task GetData()
        {
            //  Using Httpclient to get api data 
            HttpClient apiClient = new HttpClient();
            DataSet json = await apiClient.GetFromJsonAsync<DataSet>("https://dmigw.govcloud.dk/v2/metObs/collections/observation/items?period=latest-10-minutes&api-key=1fa153cf-5edb-40f7-996b-14adcdc497f4");


            // mapping everything
            List<Features> feat = json.Features.Select(x => new Features { Properties = new Properties { Created = x.Properties.Created, Observed = x.Properties.Observed, ParameterId = x.Properties.ParameterId, StationId = x.Properties.StationId, Value = x.Properties.Value }, Geometry = new Geometry { Coordinates = x.Geometry.Coordinates.Select(y => new Cords { Value = y }).ToList(), Type = x.Geometry.Type }, Type = x.Type, Id = x.Id }).ToList();
            Application app = new Application { Features = feat, Type = json.Type };
           
            
            // saving
            using (WeatherContext context = serviceProvider.CreateAsyncScope().ServiceProvider.GetService<WeatherContext>())
            {
                await context.AddAsync<Application>(app);
                await context.SaveChangesAsync();
            }
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // stopwatch because we need this to run only every 10 minutes
            bool IsStart = true;
            Stopwatch stopwatch = new();
            while (!stoppingToken.IsCancellationRequested)
            {
                
                if (stopwatch.Elapsed.TotalMinutes >= 10 || IsStart)
                {
                    IsStart = false;
                    stopwatch.Restart();
                    await GetData();
                }
            }
        }
    }
}