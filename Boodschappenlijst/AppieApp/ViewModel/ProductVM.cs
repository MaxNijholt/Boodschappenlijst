using AppieApp.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApp.ViewModel {

    public class ProductVM : ViewModelBase {

        private Product _product;

        public Product Product     { get { return _product; } }
        public int ProductId       { get { return _product.ProductId; } }

        public string Naam {
            get { return _product.Naam; }
            set {
                _product.Naam = value;
                RaisePropertyChanged("Naam");
            }
        }

        public decimal Prijs {
            get { return _product.Prijs; }
            set {
                _product.Prijs = value;
                RaisePropertyChanged("Prijs");
                RaisePropertyChanged("PrijsMetKorting");
            }
        }

        public decimal PrijsMetKorting {
            get {
                var prijs = Prijs;
                if (Kortingen != null) {
                    if (Kortingen.Count > 0) {
                        foreach (var korting in Kortingen) {
                            if (korting.BeginDatum.Date <= DateTime.Now.Date && korting.EindDatum.Date >= DateTime.Now.Date) {
                                var temp = (100m - korting.Percentage) / 100m;
                                prijs -= (prijs - (prijs * temp));
                            }
                        }
                    }
                }
                return Math.Round(prijs, 2);
            }
        }

        public Afdeling Afdeling {
            get { return _product.Afdeling; }
            set {
                _product.Afdeling = value;
                RaisePropertyChanged("Afdeling");
            }
        }

        private AfdelingVM _afdeling;

        public AfdelingVM AfdelingVM {
            get { return _afdeling; }
            set {
                _afdeling = value;
                RaisePropertyChanged("AfdelingVM");
                if (value != null) {
                    Afdeling = value.Afdeling;
                    RaisePropertyChanged("Afdeling");
                }
            }
        }

        public ICollection<Merk> Merken {
            get { return _product.Merken; }
            set {
                _product.Merken = value;
                RaisePropertyChanged("Merken");
            }
        }

        public ICollection<Korting> Kortingen {
            get { return _product.Kortingen; }
            set {
                _product.Kortingen = value;
                RaisePropertyChanged("Kortingen");
            }
        }

        private ICollection<MerkVM> _merken;

        public ICollection<MerkVM> MerkVMen {
            get { return _merken; }
            set {
                _merken = value;
                RaisePropertyChanged("MerkVMen");
                if (value != null) {
                    Merken = value.Select(m => m.Merk).ToList();
                    RaisePropertyChanged("Merken");
                }
            }
        }

        public ProductVM(Product product) {
            _product = product;
            if (product.Afdeling != null) {
                Afdeling = product.Afdeling;
                RaisePropertyChanged("Afdeling");
                AfdelingVM = new AfdelingVM(product.Afdeling);
                RaisePropertyChanged("AfdelingVM");
            }
            if (product.Merken != null) {
                Merken = product.Merken;
                RaisePropertyChanged("Merken");
                MerkVMen = new ObservableCollection<MerkVM>(Merken.Select(m => new MerkVM(m)));
                RaisePropertyChanged("MerkVMen");
            }
        }

        public ProductVM() {
            _product = new Product();
        }

    }

}
