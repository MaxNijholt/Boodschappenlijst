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

    public class KortingCRUDViewModel : ViewModelBase {

        private IKortingRepository _kortingRepository;

        private ObservableCollection<KortingVM> _kortingen;
        private ObservableCollection<ProductVM> _producten;

        private KortingVM _kortingVM;
        private ProductVM _productVM;

        public ICommand CreateKorting   { get; set; }
        public ICommand EditKorting     { get; set; }
        public ICommand ClearKorting    { get; set; }
        public ICommand AddProduct      { get; set; }
        public ICommand RemoveProduct   { get; set; }
        public ICommand RemoveKorting   { get; set; }

        public ObservableCollection<KortingVM> Kortingen {
            get { return _kortingen; }
            set {
                _kortingen = value;
                RaisePropertyChanged("Kortingen");
            }
        }

        public ObservableCollection<ProductVM> Producten {
            get { return _producten; }
            set {
                _producten = value;
                RaisePropertyChanged("Producten");
            }
        }

        public KortingVM KortingVM {
            get { return _kortingVM; }
            set {
                _kortingVM = value;
                RaisePropertyChanged("KortingVM");
            }
        }

        public ProductVM ProductVM {
            get { return _productVM; }
            set {
                _productVM = value;
                RaisePropertyChanged("ProductVM");
            }
        }

        public KortingCRUDViewModel() {
            _kortingRepository = new EntityKortingRepository();

            var kortingen = _kortingRepository.GetAll().Select(k => new KortingVM(k));
            var producten = _kortingRepository.GetAllProducten().Select(p => new ProductVM(p));

            Kortingen = new ObservableCollection<KortingVM>(kortingen);
            Producten = new ObservableCollection<ProductVM>(producten);

            KortingVM = new KortingVM();
            ProductVM = new ProductVM();

            CreateKorting   = new RelayCommand(CreateNewKorting);
            EditKorting     = new RelayCommand(EditCurrKorting);
            ClearKorting    = new RelayCommand(ClearCurrKorting);
            AddProduct      = new RelayCommand(AddCurrProduct);
            RemoveProduct   = new RelayCommand(RemoveCurrProduct);
            RemoveKorting   = new RelayCommand(RemoveCurrKorting);
        }

        private void CreateNewKorting() {
            var korting = _kortingRepository.Create(KortingVM.Korting);
            Kortingen.Add(new KortingVM(korting));
            KortingVM = new KortingVM();
            ProductVM = new ProductVM();
        }

        private void EditCurrKorting() {
            _kortingRepository.Update(KortingVM.Korting);
            KortingVM = new KortingVM();
            ProductVM = new ProductVM();
        }

        private void ClearCurrKorting() {
            KortingVM = new KortingVM();
            ProductVM = new ProductVM();
        }

        private void AddCurrProduct() {
            if (KortingVM.ProductVMen == null) KortingVM.ProductVMen = new List<ProductVM>();
            KortingVM.ProductVMen.Add(ProductVM);
            KortingVM.Producten.Add(ProductVM.Product);
        }

        private void RemoveCurrProduct() {
            KortingVM.Producten.Remove(ProductVM.Product);
            KortingVM.ProductVMen.Remove(ProductVM);
            ProductVM = new ProductVM();
        }

        private void RemoveCurrKorting() {
            _kortingRepository.Delete(KortingVM.Korting);
            Kortingen.Remove(KortingVM);
            KortingVM = new KortingVM();
            ProductVM = new ProductVM();
        }

    }

}
