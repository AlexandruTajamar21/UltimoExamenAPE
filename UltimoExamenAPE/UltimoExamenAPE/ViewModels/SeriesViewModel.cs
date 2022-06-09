using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimoExamenAPE.Base;
using UltimoExamenAPE.Models;
using UltimoExamenAPE.Services;
using UltimoExamenAPE.Views;
using Xamarin.Forms;

namespace UltimoExamenAPE.ViewModels
{
    public class SeriesViewModel : ViewModelBase
    {
        private ServiceApiSeries service;

        public SeriesViewModel(ServiceApiSeries service)
        {
            this.service = service;
            Task.Run(async () =>
            {
                this.Series = await this.service.GetSeries();
            });
        }
        private List<Serie> _Series;
        public List<Serie> Series
        {
            get { return this._Series; }
            set
            {
                this._Series = value;
                OnPropertyChanged("Series");
            }
        }
        public Command ShowSerie
        {
            get
            {
                return new Command(async (IdSerie) =>
                {
                    SerieDetail view = new SerieDetail();
                    SerieDetailViewModel viewmodel = App.ServiceLocator.SerieDetailViewModel;
                    Serie serie = await this.service.FindSerie(IdSerie.ToString());
                    List<Personaje> Personajes = await this.service.GetPersonajes(int.Parse(IdSerie.ToString()));
                    viewmodel.Personajes = Personajes;
                    viewmodel.Series = serie;
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
    }
}
