using AppieApp.Model;
using System.Collections.Generic;

namespace AppieApp.IRepositories {

    public interface IProductRepository {

        Product         Get(int productId);
        List<Product>   GetAll();
        Product         Create(Product product);
        Product         Update(Product product);
        void            Delete(Product product);

        List<Afdeling>  GetAllAfdelingen();
        List<Merk>      GetAllMerken();

    }

}
