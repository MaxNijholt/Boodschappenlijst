using AppieApp.Model;
using System.Collections.Generic;

namespace AppieApp.IRepositories {

    public interface IMerkRepository {

        Merk        Get(int merkId);
        List<Merk>  GetAll();
        Merk        Create(Merk merk);
        Merk        Update(Merk merk);
        void        Delete(Merk merk);

    }

}
