using Model;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IPhotoService{
        bool Create(Photo model);
    }

    public class PhotoService : IPhotoService
    {
        internal MyDbContext _context;

        public PhotoService(){
            _context = new MyDbContext();    
        }

        public bool Create(Photo model)
        {
            try
            {
                model.CreatedAt = DateTime.Now;
                _context.Entry(model).State = EntityState.Added;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
