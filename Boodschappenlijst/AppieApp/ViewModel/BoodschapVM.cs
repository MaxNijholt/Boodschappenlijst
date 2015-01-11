using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApp.ViewModel {

    public class BoodschapVM : ViewModelBase {

        private ObservableCollection<BoodschappenLijstViewModel> _boodschappen;

        public ObservableCollection<BoodschappenLijstViewModel> Boodschappen {
            get { return _boodschappen; }
            set {
                _boodschappen = value;
                RaisePropertyChanged("Boodschappen");
            }
        }

        public BoodschapVM(ObservableCollection<BoodschappenLijstViewModel> boodschappen) {
            Boodschappen = boodschappen;
            RaisePropertyChanged("Boodschappen");
        }

        public void AddProduct(ProductVM product) {
            if (product.ProductId > 0) {
                var temp = Boodschappen.FirstOrDefault(b => b.ProductVM.ProductId == product.ProductId);
                if (temp == null) {
                    Boodschappen.Add(new BoodschappenLijstViewModel(product, 1));
                }
                else {
                    temp.ProductVM = product;
                    temp.Aantal += 1;
                }
            }
        }

    }

}
