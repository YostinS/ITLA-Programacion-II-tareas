using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroCapacitacionOficios.Infrastructure.Data.Repositories
{
    public class UnitOfWork
    {
        private readonly CentroCapacitacionOficiosDataContext _context;
        public UserRepository Users { get; set; }
        public InstructorRepository Instructors { get; set; }
        public VideoRepository Videos { get; set; }
        public CertificateRepository Certificates{ get; set; }
        public CourseRepository Courses { get; set; }

        public UnitOfWork(CentroCapacitacionOficiosDataContext context, 
            UserRepository userRepository, InstructorRepository instructorRepository, VideoRepository videoRepository, 
            CertificateRepository certificateRepository, CourseRepository courseRepository)
        {
            _context = context;
            Users = userRepository;
            Instructors = instructorRepository;
            Videos = videoRepository;
            Certificates = certificateRepository;
            Courses = courseRepository;
        }
        public Task CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
