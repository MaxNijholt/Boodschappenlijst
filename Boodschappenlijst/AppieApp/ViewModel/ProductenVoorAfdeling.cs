using AppieApp.IRepositories;
using AppieApp.Repositories;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieApp.ViewModel {

    public class ProductenVoorAfdeling : ViewModelBase {

        private IProductRepository                  _productRepository;
        private AfdelingVM                          _afdeling;
        private ObservableCollection<AfdelingVM>    _afdelingen;

        public AfdelingVM AfdelingVM {
            get { return _afdeling; }
            set {
                _afdeling = value;
                RaisePropertyChanged("AfdelingVM");
            }
        }

        public ObservableCollection<AfdelingVM> AfdelingVMen {
            get { return _afdelingen; }
            set {
                _afdelingen = value;
                RaisePropertyChanged("AfdelingVMen");
            }
        }

        public ProductenVoorAfdeling() {
            _productRepository = new EntityProductRepository();
            var temp = _productRepository.GetAllAfdelingen().Select(a => new AfdelingVM(a));
            AfdelingVMen = new ObservableCollection<AfdelingVM>(temp);
        }

       

    }

}
