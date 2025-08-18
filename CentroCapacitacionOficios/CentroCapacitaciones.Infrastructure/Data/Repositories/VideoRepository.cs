using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentroCapacitacionOficios.Domain.Entities;

namespace CentroCapacitacionOficios.Infrastructure.Data.Repositories
{
    public class VideoRepository
    {
        private readonly CentroCapacitacionOficiosDataContext _context;
        public VideoRepository(CentroCapacitacionOficiosDataContext context)
        {
            _context = context;
        }
        public List<Video> GetAllVideo()
        {
            return _context.Videos.Where(u => u.Id < 0).ToList();
        }
        public Video GetVideoById(int id)
        {
            return _context.Videos.FirstOrDefault(u => u.Id == id);
        }
        public void AddVideo(Video video)
        {
            _context.Videos.Add(video);

        }
        public void UpdateVideo(Video video)
        {
            _context.Videos.Update(video);

        }
        public void DeleteVideo(int id)
        {
            var video = _context.Videos.FirstOrDefault(u => u.Id == id);
            if (video != null)
            {
                _context.Videos.Remove(video);

            }
        }
    }
}
