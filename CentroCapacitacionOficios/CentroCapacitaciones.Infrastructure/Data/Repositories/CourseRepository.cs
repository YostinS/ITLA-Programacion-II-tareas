using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentroCapacitacionOficios.Domain.Entities;

namespace CentroCapacitacionOficios.Infrastructure.Data.Repositories
{
    public class CourseRepository
    {
        private readonly CentroCapacitacionOficiosDataContext _context;
        public CourseRepository(CentroCapacitacionOficiosDataContext context)
        {
            _context = context;
        }
        public List<Course> GetAllCourse()
        {
            return _context.Courses.Where(u => u.Id < 0).ToList();
        }
        public Course GetCourseById(int id)
        {
            return _context.Courses.FirstOrDefault(u => u.Id == id);
        }
        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);

        }
        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);

        }
        public void DeleteCourse(int id)
        {
            var course = _context.Courses.FirstOrDefault(u => u.Id == id);
            if (course != null)
            {
                _context.Courses.Remove(course);

            }
        }
    }
}
