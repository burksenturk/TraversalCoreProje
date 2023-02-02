using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Reservation //rezervasyon tablosu için
    {
        public int ReservationID { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }  //ad soyadları appuser dan çekicez
        public string PersonCount { get; set; }
        public string Destination { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Desctiption { get; set; }
        public string Status { get; set; }  //bool yapmadık.. kendi içinde rez onaylandı onaylanmadı , müşteriye teklif verielcek  vs..
    }
}
