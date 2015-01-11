using AppieApp.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApp.ViewModel {

    public class KortingVM : ViewModelBase {

        private Korting                 _korting;
        public Korting                  Korting         { get { return _korting; } }
        public int                      KortingId       { get { return _korting.KortingId; } }
        private ICollection<ProductVM> _producten;

        public string Naam {
            get { return _korting.Naam; }
            set {
                _korting.Naam = value;
                RaisePropertyChanged("Naam");
            }
        }

        public decimal Percentage {
            get { return _korting.Percentage; }
            set {
                _korting.Percentage = value;
                RaisePropertyChanged("Percentage");
            }
        }

        public DateTime BeginDatum {
            get { return _korting.BeginDatum; }
            set {
                _korting.BeginDatum = value;
                RaisePropertyChanged("BeginDatum");
            }
        }

        public DateTime EindDatum {
            get { return _korting.EindDatum; }
            set {
                _korting.EindDatum = value;
                RaisePropertyChanged("EindDatum");
            }
        }

        public ICollection<Product> Producten {
            get { return _korting.Producten; }
            set {
                _korting.Producten = value;
                RaisePropertyChanged("Producten");
            }
        }

        public ICollection<ProductVM> ProductVMen {
            get { return _producten; }
            set {
                _producten = value;
                RaisePropertyChanged("ProductVMen");
                if (value != null) {
                    Producten = value.Select(p => p.Product).ToList();
                    RaisePropertyChanged("Producten");
                }
            }
        }

        public KortingVM(Korting korting) {
            _korting = korting;
            if (korting.Producten != null) {
                Producten = korting.Producten;
                RaisePropertyChanged("Producten");
                ProductVMen = new ObservableCollection<ProductVM>(Producten.Select(m => new ProductVM(m)));
                RaisePropertyChanged("ProductVMen");
            }
        }

        public KortingVM() {
            _korting = new Korting();
            _korting.BeginDatum = DateTime.Now;
            _korting.EindDatum = DateTime.Now;
        }

    }

}
