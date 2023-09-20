using System;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Database.Migrator.Sample;

public class Program
{
  public static void Main(string[] args)
  {
      var configuration = GetConfiguration(args);
      
      Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .CreateLogger();

      var connectionString = configuration.GetConnectionString("DefaultConnection");

      try
      {
          new SqlMigrator().Execute(connectionString);
      }
      catch (Exception ex)
      {
          Log.Fatal(ex, "An unexpected error has occurred");
      }
      finally
      {
          Log.CloseAndFlush();
      }
  }

  public static IConfiguration GetConfiguration(string[] args)
  {
    var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
      IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{environmentName}.json", optional: true,
          reloadOnChange: true)
        .AddEnvironmentVariables()
        .AddCommandLine(args)
        .Build();
      return configuration;
  }
}
