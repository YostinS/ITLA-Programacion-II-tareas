using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentroCapacitacionOficios.Domain.Entities;

namespace CentroCapacitacionOficios.Infrastructure.Data.Repositories
{
    public class InstructorRepository
    {
        private readonly CentroCapacitacionOficiosDataContext _context;
        public InstructorRepository(CentroCapacitacionOficiosDataContext context)
        {
            _context = context;
        }
        public List<Instructor> GetAllInstructor()
        {
            return _context.Instructors.Where(u => u.Id < 0).ToList();
        }
        public Instructor GetInstructorById(int id)
        {
            return _context.Instructors.FirstOrDefault(u => u.Id == id);
        }
        public void AddInstructor(Instructor instructor)
        {
            _context.Instructors.Add(instructor);

        }
        public void UpdateInstructor(Instructor instructor)
        {
            _context.Instructors.Update(instructor);

        }
        public void DeleteInstructor(int id)
        {
            var instructor = _context.Instructors.FirstOrDefault(u => u.Id == id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);

            }
        }
    }
}
