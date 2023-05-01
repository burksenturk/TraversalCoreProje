using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAccountDal : GenericUowRepository<Account>,IAccountDal
    {
        //GenericUowRepository de ctor açtığım için burada da injecte edebilmek için ctor açtım.
        //GenericUowRepository içersiinde tanımldaığımız ctor yapıyı buraya enjekte etmiş olduk base ile
        public EfAccountDal(Context context): base(context) 
        {
            
        }
    }
}
