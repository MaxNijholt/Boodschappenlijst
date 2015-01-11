using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using AppieApp.View;

namespace AppieApp.ViewModel 
{
    public class MainViewModel : ViewModelBase {

        private ViewModelBase _currentViewModel;


        public ViewModelBase CurrentViewModel {
            get { return _currentViewModel; }
            set { 
                if (_currentViewModel == value) return;
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        public MainViewModel() {
            ExitTheProgram = new RelayCommand(Exit);
            CurrentViewModel = GetCurrentView("ProductenLijst");
            Boodschappen = new ObservableCollection<BoodschappenLijstViewModel>();
            BoodschapVMen = new ObservableCollection<ProductVM>();
        }

        private ObservableCollection<BoodschappenLijstViewModel> _boodschappen;

        public ObservableCollection<BoodschappenLijstViewModel> Boodschappen {
            get { return _boodschappen; }
            set {
                _boodschappen = value;
                RaisePropertyChanged("Boodschappen");
            }
        }

        private ObservableCollection<ProductVM> _boodschapVMen;

        public ObservableCollection<ProductVM> BoodschapVMen {
            get { return _boodschapVMen; }
            set {
                _boodschapVMen = value;
                RaisePropertyChanged("BoodschapVMen");
            }
        }

        public ICommand CommandButton {
            get { return new RelayCommand<object>(ExecuteCommandButton); }
        }

        public ICommand ExitTheProgram { get; set; }

        private void ExecuteCommandButton(object param) {
            CurrentViewModel = GetCurrentView((string) param);
        }

        private ViewModelBase GetCurrentView(string name) {
            switch (name) {
                case "Afdeling":
                    return new AfdelingCRUDViewModel();
                case "Korting":
                    return new KortingCRUDViewModel();
                case "Merk":
                    return new MerkCRUDViewModel();
                case "Product":
                    return new ProductCRUDViewModel();
                case "ProductenLijst":
                    return new ProductenLijstViewModel(BoodschapVMen);
                case "AfdelingLijst":
                    return new ProductenVoorAfdeling();
            }

            return new AfdelingCRUDViewModel();
        }

        private void Exit() {
            Application.Current.Shutdown();
        }


    }
}