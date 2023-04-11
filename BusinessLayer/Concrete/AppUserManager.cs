using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _appUserdal;

        public AppUserManager(IAppUserDal appUserdal)
        {
            _appUserdal = appUserdal;
        }

        public void TAdd(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AppUser t)
        {
            _appUserdal.Delete(t);
        }

        public AppUser TGetByID(int id)
        {
           return _appUserdal.GetByID(id);
        }

        public List<AppUser> TGetList()
        {
            return _appUserdal.GetList();
        }

        public void TUpdate(AppUser t)
        {
            throw new NotImplementedException();
        }
    }
}
