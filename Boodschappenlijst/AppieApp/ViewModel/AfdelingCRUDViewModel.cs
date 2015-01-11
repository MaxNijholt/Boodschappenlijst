using AppieApp.IRepositories;
using AppieApp.Repositories;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace AppieApp.ViewModel {

    public class AfdelingCRUDViewModel : ViewModelBase {

        private IAfdelingRepository                 _afdelingRepository;
        private ObservableCollection<AfdelingVM>    _afdelingen;
        private AfdelingVM                          _afdelingVM;

        public ICommand CreateAfdeling              { get; set; }
        public ICommand EditAfdeling                { get; set; }
        public ICommand ClearAfdeling               { get; set; }
        public ICommand DeleteAfdeling              { get; set; }

        public ObservableCollection<AfdelingVM> Afdelingen {
            get { return _afdelingen; }
            set {
                _afdelingen = value;
                RaisePropertyChanged("Afdelingen");
            }
        }

        public AfdelingVM AfdelingVM {
            get { return _afdelingVM; }
            set {
                _afdelingVM = value;
                RaisePropertyChanged("AfdelingVM");
            }
        }

        // Constructor
        public AfdelingCRUDViewModel() {
            _afdelingRepository = new EntityAfdelingRepository();

            var afdelingen      = _afdelingRepository.GetAll();
            var afdelingenVM    = afdelingen.Select(a => new AfdelingVM(a));

            Afdelingen          = new ObservableCollection<AfdelingVM>(afdelingenVM);
            _afdelingVM         = new AfdelingVM();

            CreateAfdeling      = new RelayCommand(CreateNewAfdeling);
            EditAfdeling        = new RelayCommand(EditCurrAfdeling);
            ClearAfdeling       = new RelayCommand(ClearCurrAfdeling);
            DeleteAfdeling      = new RelayCommand(DeleteCurrAfdeling);
        }

        private void CreateNewAfdeling() {
            var temp = AfdelingVM.Afdeling;
            if (temp == null) return;
            if (temp.Naam == null) return;
            var afdeling = _afdelingRepository.Create(AfdelingVM.Afdeling);
            Afdelingen.Add(new AfdelingVM(afdeling));
            AfdelingVM = new AfdelingVM();
        }

        private void ClearCurrAfdeling() {
            AfdelingVM = new AfdelingVM();
        }

        private void EditCurrAfdeling() {
            if (AfdelingVM.Afdeling == null) return;
            if (AfdelingVM.Naam == null) return;
            _afdelingRepository.Update(AfdelingVM.Afdeling);
            AfdelingVM = new AfdelingVM();
        }

        private void DeleteCurrAfdeling() {
            if (AfdelingVM.Afdeling == null) return;
            if (AfdelingVM.Naam == null) return;
            _afdelingRepository.Delete(AfdelingVM.Afdeling);
            Afdelingen.Remove(AfdelingVM);
            AfdelingVM = new AfdelingVM();
        }

    }

}
