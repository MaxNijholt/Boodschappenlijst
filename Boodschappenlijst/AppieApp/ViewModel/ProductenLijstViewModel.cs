using AppieApp.IRepositories;
using AppieApp.Repositories;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppieApp.ViewModel {

    public class ProductenLijstViewModel : ViewModelBase {

        private IProductRepository                  _productRepository;
        private ObservableCollection<ProductVM>     _boodschappen;
        private ProductVM                           _product;
        private ProductVM                           _boodschap;
        private MerkVM                              _merk;
        private ObservableCollection<MerkVM>        _merken;
        private ObservableCollection<ProductVM>     _producten;

        public ICommand AddProduct      { get; set; }
        public ICommand AddMerk         { get; set; }
        public ICommand RemoveProduct   { get; set; }
        public ICommand CreatePDF       { get; set; }

        public MerkVM MerkVM {
            get { return _merk; }
            set {
                _merk = value;
                RaisePropertyChanged("MerkVM");
            }
        }

        public ObservableCollection<MerkVM> MerkVMen {
            get { return _merken; }
            set {
                _merken = value;
                RaisePropertyChanged("MerkVMen");
            }
        }

        public decimal Prijs {
            get {
                decimal price = 0;
                foreach (ProductVM p in Boodschappen) {
                    price += p.PrijsMetKorting;
                }
                return price;
            }
        }

        public ProductVM BoodschapVM {
            get { return _boodschap; }
            set {
                _boodschap = value;
                RaisePropertyChanged("BoodschapVM");
            }
        }

        public ProductVM ProductVM {
            get { return _product; }
            set {
                _product = value;
                RaisePropertyChanged("ProductVM");
                RaisePropertyChanged("Prijs");
            }
        }

        public ObservableCollection<ProductVM> ProductVMen {
            get { return _producten; }
            set {
                _producten = value;
                RaisePropertyChanged("ProductVMen");
            }
        }

        public ObservableCollection<ProductVM> Boodschappen {
            get { return _boodschappen; }
            set {
                _boodschappen = value;
                RaisePropertyChanged("Boodschappen");
                RaisePropertyChanged("Prijs");
            }
        }

        public ProductenLijstViewModel(ObservableCollection<ProductVM> boodschappen) {
            _productRepository = new EntityProductRepository();
            var temp = _productRepository.GetAll().Select(p => new ProductVM(p));
            var pemt = _productRepository.GetAllMerken().Select(m => new MerkVM(m));
            MerkVMen = new ObservableCollection<MerkVM>(pemt);
            ProductVMen = new ObservableCollection<ProductVM>(temp);
            Boodschappen = new ObservableCollection<ProductVM>();
            AddProduct = new RelayCommand(AddBoodschap);
            AddMerk = new RelayCommand(AddAllProducts);
            RemoveProduct = new RelayCommand(RemoveBoodschap);
            CreatePDF = new RelayCommand(CreateAPDF);
        }

        private void AddBoodschap() {
            Boodschappen.Add(ProductVM);
            RaisePropertyChanged("Boodschappen");
            RaisePropertyChanged("Prijs");
        }

        private void RemoveBoodschap() {
            Boodschappen.Remove(ProductVM);
            RaisePropertyChanged("Boodschappen");
            RaisePropertyChanged("Prijs");
        }

        private void AddAllProducts() {
            var temp = MerkVM.Producten.Select(p => new ProductVM(p));
            foreach (ProductVM p in temp) {
                Boodschappen.Add(p);
                RaisePropertyChanged("Boodschappen");
                RaisePropertyChanged("Prijs");
            }
        }

        private void CreateAPDF() {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Boodschappenlijst.pdf";
            Document DC = new Document();
            FileStream fs = File.Create(path);
            PdfWriter.GetInstance(DC, fs);
            DC.Open();
            foreach (ProductVM p in Boodschappen) {
                DC.Add(new iTextSharp.text.Paragraph(p.Naam + " : " + p.PrijsMetKorting));
            }
            DC.Close();
        }

    }

}
