using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltimoExamenAPE.Base;
using UltimoExamenAPE.Models;
using UltimoExamenAPE.Services;

namespace UltimoExamenAPE.ViewModels
{
    public class NuevoPersonajeViewModel : ViewModelBase
    {
        private ServiceApiSeries service;

        public NuevoPersonajeViewModel(ServiceApiSeries service)
        {
            this.service = service;
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
    }
}
