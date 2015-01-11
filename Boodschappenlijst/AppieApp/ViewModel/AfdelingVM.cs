using AppieApp.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApp.ViewModel {

    public class AfdelingVM : ViewModelBase {

        private Afdeling _afdeling;

        public Afdeling Afdeling    { get { return _afdeling; } }
        public int AfdelingId       { get { return _afdeling.AfdelingId; } }

        public string Naam { 
            get { return _afdeling.Naam; }
            set { 
                _afdeling.Naam = value;
                RaisePropertyChanged("Naam");
            }
        }

        public ICollection<Product> Producten {
            get { return _afdeling.Producten; }
            set { 
                _afdeling.Producten = value;
                RaisePropertyChanged("Producten");
            }
        }

        public AfdelingVM(Afdeling afdeling) {
            _afdeling = afdeling;
            if (afdeling.Producten != null) {
                Producten = afdeling.Producten;
                RaisePropertyChanged("Producten");
            }
        }

        public AfdelingVM() {
            _afdeling = new Afdeling();
        }

    }

}
