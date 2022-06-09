using System;
using System.Collections.Generic;
using System.Text;
using UltimoExamenAPE.Base;
using UltimoExamenAPE.Models;

namespace UltimoExamenAPE.ViewModels
{
    public class ListPersonajesViewModel : ViewModelBase
    {
        public ListPersonajesViewModel()
        {

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
    }
}
