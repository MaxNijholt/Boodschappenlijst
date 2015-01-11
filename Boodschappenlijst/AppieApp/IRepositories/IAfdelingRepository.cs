using AppieApp.Model;
using System.Collections.Generic;

namespace AppieApp.IRepositories {

    public interface IAfdelingRepository {

        Afdeling        Get(int afdelingId);
        List<Afdeling>  GetAll();
        Afdeling        Create(Afdeling afdeling);
        Afdeling        Update(Afdeling afdeling);
        void            Delete(Afdeling afdeling);

    }

}
