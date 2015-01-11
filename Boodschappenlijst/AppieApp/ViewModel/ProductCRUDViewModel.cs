using AppieApp.IRepositories;
using AppieApp.Repositories;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppieApp.ViewModel {

    public class ProductCRUDViewModel : ViewModelBase {

        private IProductRepository                  _productRepository;

        private ObservableCollection<ProductVM>     _producten;
        private ObservableCollection<AfdelingVM>    _afdelingen;
        private ObservableCollection<MerkVM>        _merken;

        private AfdelingVM                          _afdelingVM;
        private ProductVM                           _productVM;
        private MerkVM                              _merkVM;

        public ICommand CreateProduct               { get; set; }
        public ICommand EditProduct                 { get; set; }
        public ICommand ClearProduct                { get; set; }
        public ICommand DeleteProduct               { get; set; }

        public ICommand AddMerk                     { get; set; }
        public ICommand DeleteMerk                  { get; set; }

        public ObservableCollection<ProductVM> Producten {
            get { return _producten; }
            set {
                _producten = value;
                RaisePropertyChanged("Producten");
            }
        }

        public ObservableCollection<AfdelingVM> Afdelingen {
            get { return _afdelingen; }
            set {
                _afdelingen = value;
                RaisePropertyChanged("Afdelingen");
            }
        }

        public ObservableCollection<MerkVM> Merken {
            get { return _merken; }
            set {
                _merken = value;
                RaisePropertyChanged("Merken");
            }
        }

        public AfdelingVM AfdelingVM {
            get { return _afdelingVM; }
            set {
                _afdelingVM = value;
                RaisePropertyChanged("AfdelingVM");
            }
        }

        public MerkVM MerkVM {
            get { return _merkVM; }
            set {
                _merkVM = value;
                RaisePropertyChanged("MerkVM");
            }
        }

        public ProductVM ProductVM {
            get { return _productVM; }
            set {
                _productVM = value;
                RaisePropertyChanged("ProductVM");
                if (_productVM != null && _productVM.Afdeling != null) {
                    AfdelingVM = new AfdelingVM(_productVM.Afdeling);
                    RaisePropertyChanged("AfdelingVM");
                }
            }
        }

        public ProductCRUDViewModel() {
            _productRepository      = new EntityProductRepository();

            var productVM   = _productRepository.GetAll().Select(p => new ProductVM(p));
            var afdelingVM  = _productRepository.GetAllAfdelingen().Select(a => new AfdelingVM(a));
            var merkVM      = _productRepository.GetAllMerken().Select(m => new MerkVM(m));

            Producten       = new ObservableCollection<ProductVM>(productVM);
            Afdelingen      = new ObservableCollection<AfdelingVM>(afdelingVM);
            Merken          = new ObservableCollection<MerkVM>(merkVM);

            ProductVM       = new ProductVM();
            AfdelingVM      = new AfdelingVM();
            MerkVM          = new MerkVM();

            CreateProduct   = new RelayCommand(CreateNewProduct);
            EditProduct     = new RelayCommand(EditCurrProduct);
            ClearProduct    = new RelayCommand(ClearCurrProduct);
            DeleteProduct   = new RelayCommand(DeleteCurrProduct);
            AddMerk         = new RelayCommand(AddCurrMerk);
            DeleteMerk      = new RelayCommand(DeleteCurrMerk);

        }

        private void CreateNewProduct() {
            _productRepository.Create(ProductVM.Product);
            Producten.Add(ProductVM);

            ProductVM   = new ProductVM();
            AfdelingVM  = new AfdelingVM();
            MerkVM      = new MerkVM();
        }

        private void EditCurrProduct() {
            var product = ProductVM.Product;
            _productRepository.Update(ProductVM.Product);

            ProductVM   = new ProductVM();
            AfdelingVM  = new AfdelingVM();
            MerkVM      = new MerkVM();
        }

        private void ClearCurrProduct() {
            ProductVM   = new ProductVM();
            AfdelingVM  = new AfdelingVM();
            MerkVM      = new MerkVM();
        }

        private void DeleteCurrProduct() {
            _productRepository.Delete(ProductVM.Product);
            Producten.Remove(ProductVM);
            ProductVM   = new ProductVM();
            AfdelingVM  = new AfdelingVM();
            MerkVM      = new MerkVM();
        }

        private void AddCurrMerk() {
            if (ProductVM.MerkVMen == null) ProductVM.MerkVMen = new List<MerkVM>();
            ProductVM.MerkVMen.Add(MerkVM);
            ProductVM.Merken.Add(MerkVM.Merk);
        }

        private void DeleteCurrMerk() {
            ProductVM.Merken.Remove(MerkVM.Merk);
            ProductVM.MerkVMen.Remove(MerkVM);
            MerkVM = new MerkVM();
        }


    }

}
