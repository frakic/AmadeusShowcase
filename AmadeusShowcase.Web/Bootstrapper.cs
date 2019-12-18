using AmadeusShowcase.DAL.Repositories;
using AmadeusShowcase.Service;
using AmadeusShowcase.Service.Services;
using AmadeusShowcase.Web.Controllers;
using AutoMapper;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using Unity.Mvc3;

namespace AmadeusShowcase.Web
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            RegisterAutoMapper(container);

            RegisterRepositories(container);

            RegisterServices(container);

            RegisterControllers(container);

            return container;
        }

        private static void RegisterAutoMapper(UnityContainer container)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperBootstrap());
            });

            config.AssertConfigurationIsValid();

            IMapper mapper = config.CreateMapper();

            container.RegisterInstance(mapper);
        }

        private static void RegisterRepositories(UnityContainer container)
        {
            container.RegisterType<IAirportRepository, AirportRepository>();
            container.RegisterType<ICurrencyRepository, CurrencyRepository>();
            container.RegisterType<IFlightRepository, FlightRepository>();
            container.RegisterType<ISearchRepository, SearchRepository>();
        }

        private static void RegisterServices(UnityContainer container)
        {
            container.RegisterType<IAirportService, AirportService>();
            container.RegisterType<ICurrencyService, CurrencyService>();
            container.RegisterType<IFlightService, FlightService>();
        }

        private static void RegisterControllers(UnityContainer container)
        {
            container.RegisterType<IController, SearchController>("Search");
        }
    }
}