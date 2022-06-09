using System;
using System.Collections.Generic;
using System.Text;
using UltimoExamenAPE.Base;
using UltimoExamenAPE.Views;
using Xamarin.Forms;

namespace UltimoExamenAPE.ViewModels
{
    public class MenuSeriesViewModel : ViewModelBase
    {

        public MenuSeriesViewModel()
        {

        }
        public Command NuevoPersonaje
        {
            get
            {
                return new Command(async () =>
                {
                    NuevoPersonajeView view = new NuevoPersonajeView();
                    NuevoPersonajeViewModel viewmodel = App.ServiceLocator.NuevoPersonajeViewModel;
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
        //public Command ModificarPersonaje
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            NuevoPersonajeView view = new NuevoPersonajeView();
        //            NuevoPersonajeViewModel viewmodel = App.ServiceLocator.NuevoPersonajeViewModel;
        //            view.BindingContext = viewmodel;
        //            await Application.Current.MainPage.Navigation.PushModalAsync(view);
        //        });
        //    }
        //}
        public Command MostrarSeries
        {
            get
            {
                return new Command(async () =>
                {
                    SeriesView view = new SeriesView();
                    SeriesViewModel viewmodel = App.ServiceLocator.SeriesViewModel;
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
    }
}
