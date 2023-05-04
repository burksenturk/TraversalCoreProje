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
    public class CommentManager : ICommentService
    {
        ICommentDal _CommentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _CommentDal = commentDal;
        }

        public void TAdd(Comment t)
        {
            _CommentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _CommentDal.Delete(t);
        }

        public Comment TGetByID(int id)
        {
            return _CommentDal.GetByID(id);
        }

        public List<Comment> TGetList()
        {
            return _CommentDal.GetList();
        }

        public List<Comment> TGetDestinationByID(int id)
        {
            return _CommentDal.GetListByFilter(x => x.DestinationID == id);
        }

        public void TUpdate(Comment t)
        {
            throw new NotImplementedException();
        }

        public List<Comment> TGetListCommentWithDestination()
        {
            return _CommentDal.GetListCommentWithDestination();
        }

		public List<Comment> TGetListCommentWithDestinationAndUser(int id)
		{
            return _CommentDal.GetListCommentWithDestinationAndUser(id);
		}
	}
}
