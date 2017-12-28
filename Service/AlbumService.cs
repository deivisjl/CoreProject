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
    public interface IAlbumService {

        bool Create(Album model);
        IEnumerable<Album> GetAll();
        Album Get(int albumId);
    }
    public class AlbumService : IAlbumService
    {
        internal MyDbContext _context;

        public AlbumService() {
            _context = new MyDbContext();
        }

        public bool Create(Album model) {

            try {
                model.CreatedAt = DateTime.Now;
                _context.Entry(model).State = EntityState.Added;
                _context.SaveChanges();
            }
            catch (Exception e){
                return false;
            }
            return true;
        }

        public IEnumerable<Album> GetAll()
        {
            var result = new List<Album>();

            try
            {
                result = _context.Album.OrderByDescending(x => x.CreatedAt)
                              .ToList();
            }
            catch (Exception)
            {

            }

            return result;
        }

        public Album Get(int albumId)
        {
            var result = new Album();
            var phtos = new List<Photo>();

            try
            {

                result = _context.Album.Include("Photo")
                                       .Single(x => x.Id == albumId);

            }
            catch (Exception e)
            {

            }

            return result;
        }
    }
}
