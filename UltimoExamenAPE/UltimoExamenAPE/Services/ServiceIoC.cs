using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UltimoExamenAPE.ViewModels;

namespace UltimoExamenAPE.Services
{
    public class ServiceIoC
    {
        private IContainer container;
        public ServiceIoC()
        {
            this.RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<MainPage>().SingleInstance();
            builder.RegisterType<ServiceApiSeries>();
            
            builder.RegisterType<MenuSeriesViewModel>();
            builder.RegisterType<NuevoPersonajeViewModel>();
            builder.RegisterType<ListPersonajesViewModel>();
            builder.RegisterType<SeriesViewModel>();
            builder.RegisterType<SerieDetailViewModel>();

            // BUSCAMOS EL FICHERO DE SETTINGS
            string resourceName = "UltimoExamenAPE.appsettings.json";
            Stream stream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream(resourceName);

            // CREAMOS EL OBJETO ICONFIGURATION
            IConfiguration configuration = new ConfigurationBuilder().AddJsonStream(stream).Build();

            // INCLUIMOS EL OBJETO CONFIGURATION DENTRO DE LA INYECCIÓN DE DEPENDENCIAS
            builder.Register<IConfiguration>(x => configuration);

            // CREAMOS EL CONTENEDOR
            this.container = builder.Build();
        }
        public MenuSeriesViewModel MenuSeriesViewModel
        {
            get
            {
                return this.container.Resolve<MenuSeriesViewModel>();
            }
        }
        public NuevoPersonajeViewModel NuevoPersonajeViewModel
        {
            get
            {
                return this.container.Resolve<NuevoPersonajeViewModel>();
            }
        }
        public SeriesViewModel SeriesViewModel
        {
            get
            {
                return this.container.Resolve<SeriesViewModel>();
            }
        }
        public SerieDetailViewModel SerieDetailViewModel
        {
            get
            {
                return this.container.Resolve<SerieDetailViewModel>();
            }
        }
        public ListPersonajesViewModel ListPersonajesViewModel
        {
            get
            {
                return this.container.Resolve<ListPersonajesViewModel>();
            }
        }
    }
}
