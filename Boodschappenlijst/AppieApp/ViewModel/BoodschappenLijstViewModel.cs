using AppieApp.IRepositories;
using AppieApp.Model;
using AppieApp.Repositories;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApp.ViewModel {

    public class BoodschappenLijstViewModel : ViewModelBase {

        private ProductVM   _product;
        private int         _aantal;
        private string      _naam;
        private decimal     _prijs;

        public ProductVM ProductVM {
            get { return _product; }
            set {
                _product = value;
                RaisePropertyChanged("ProductVM");
                RaisePropertyChanged("Prijs");
            }
        }

        public int Aantal {
            get { return _aantal; }
            set {
                _aantal = value;
                RaisePropertyChanged("Aantal");
                RaisePropertyChanged("Prijs");
            }
        }

        public string Naam {
            get { return _naam; }
        }

        public decimal Prijs {
            get { return _prijs * _aantal; }
        }

        public BoodschappenLijstViewModel(ProductVM product, int aantal) {
            ProductVM = product;
            RaisePropertyChanged("Product");
            Aantal = aantal;
            RaisePropertyChanged("Aantal");
        }
        
    }

}
