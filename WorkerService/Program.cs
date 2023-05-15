using WorkerService;
using Datalayer;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddDbContext<WeatherContext>(x => x.UseSqlServer(hostContext.Configuration.GetConnectionString("BigData")));
    })
    .Build();

host.Run();
