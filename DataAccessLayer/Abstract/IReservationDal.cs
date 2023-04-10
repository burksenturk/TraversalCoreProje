using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal :IGenericDal<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitApproval(int id); //tabloda lokasyon adını falan göstermek için ektra tanımladım
        List<Reservation> GetListWithReservationByAccepted(int id);
        List<Reservation> GetListWithReservationByprevious(int id);
    }
}
