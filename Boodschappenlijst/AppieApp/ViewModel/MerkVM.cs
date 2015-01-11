using AppieApp.Model;
using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace AppieApp.ViewModel {

    public class MerkVM : ViewModelBase {

        private Merk _merk;

        public Merk Merk    { get { return _merk; } }
        public int MerkID   { get { return _merk.MerkId; } }

        public string Naam {
            get { return _merk.Naam; }
            set {
                _merk.Naam = value;
                RaisePropertyChanged("Naam");
            }
        }

        public ICollection<Product> Producten {
            get { return _merk.Producten; }
            set {
                _merk.Producten = value;
                RaisePropertyChanged("Producten");
            }
        }

        public MerkVM(Merk merk) {
            _merk = merk;
        }

        public MerkVM() {
            _merk = new Merk();
        }

    }

}
