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

    public class MerkCRUDViewModel : ViewModelBase {

        private IMerkRepository                 _merkRepository;
        private ObservableCollection<MerkVM>    _merken;
        private MerkVM                          _merkVM;

        public ICommand CreateMerk              { get; set; }
        public ICommand EditMerk                { get; set; }
        public ICommand ClearMerk               { get; set; }
        public ICommand DeleteMerk              { get; set; }

        public ObservableCollection<MerkVM> Merken {
            get { return _merken; }
            set {
                _merken = value;
                RaisePropertyChanged("Merken");
            }
        }

        public MerkVM MerkVM {
            get { return _merkVM; }
            set {
                _merkVM = value;
                RaisePropertyChanged("MerkVM");
            }
        }

        // Constructor
        public MerkCRUDViewModel() {
            _merkRepository = new EntityMerkRepository();

            var merken = _merkRepository.GetAll();
            var merkenVM = merken.Select(m => new MerkVM(m));

            Merken = new ObservableCollection<MerkVM>(merkenVM);
            _merkVM = new MerkVM();

            CreateMerk  = new RelayCommand(CreateNewMerk);
            EditMerk    = new RelayCommand(EditCurrMerk);
            ClearMerk   = new RelayCommand(ClearCurrMerk);
            DeleteMerk  = new RelayCommand(DeleteCurrMerk);
        }

        private void CreateNewMerk() {
            var temp = MerkVM.Merk;
            if (temp == null) return;
            if (temp.Naam == null) return;
            var merk = _merkRepository.Create(MerkVM.Merk);
            Merken.Add(new MerkVM(merk));
            MerkVM = new MerkVM();
        }

        private void EditCurrMerk() {
            if (MerkVM.Merk == null) return;
            if (MerkVM.Naam == null) return;
            _merkRepository.Update(MerkVM.Merk);
            MerkVM = new MerkVM();
        }

        private void ClearCurrMerk() {
            MerkVM = new MerkVM();
        }

        private void DeleteCurrMerk() {
            if (MerkVM.Merk== null) return;
            if (MerkVM.Naam == null) return;
            _merkRepository.Delete(MerkVM.Merk);
            Merken.Remove(MerkVM);
            MerkVM = new MerkVM();
        }

    }

}
