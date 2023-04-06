using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Reservation 
    {
        public int ReservationID { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }  //ad soyadları appuser dan çekicem
        public string PersonCount { get; set; }
        public string Destination { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Desctiption { get; set; }
        public string Status { get; set; }  //bool yapmadık.. kendi içinde rez onaylandı onaylanmadı , müşteriye teklif verielcek  vs.. gibi filtreleme işlemine tabii tutucam.
    }
}
