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
    public class SerieDetailViewModel : ViewModelBase
    {
        private ServiceApiSeries service;

        public SerieDetailViewModel(ServiceApiSeries service)
        {
            this.service = service;
        }
        private Serie _Series;
        public Serie Series
        {
            get { return this._Series; }
            set
            {
                this._Series = value;
                OnPropertyChanged("Series");
            }
        }
        private List<Personaje> _Personajes;
        public List<Personaje> Personajes
        {
            get { return this._Personajes; }
            set
            {
                this._Personajes = value;
                OnPropertyChanged("Personajes");
            }
        }
        //public Command ShowPersonajes
        //{
        //    get
        //    {
        //        return new Command(async (IdSerie) =>
        //        {
        //            ListPersonajesView view = new ListPersonajesView();
        //            ListPersonajesViewModel viewmodel = App.ServiceLocator.ListPersonajesViewModel;
        //            List<Personaje> personajes = await this.service.GetPersonajes(IdSerie.ToString());
        //            viewmodel.Personajes = personajes;
        //            view.BindingContext = viewmodel;
        //            await Application.Current.MainPage.Navigation.PushModalAsync(view);
        //        });
        //    }
        //}
    }
}
