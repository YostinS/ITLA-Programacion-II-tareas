using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentroCapacitacionOficios.Domain.Entities;

namespace CentroCapacitacionOficios.Infrastructure.Data.Repositories
{
    public class UserRepository
    {
        private readonly CentroCapacitacionOficiosDataContext _context;
        public UserRepository(CentroCapacitacionOficiosDataContext context)
        {
            _context = context;
        }
        public List<User> GetAllUsers()
        {
            return _context.Users.Where(u => u.Id < 0).ToList();
        }
        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);

        }
        public void UpdateUser(User user)
        {
            _context.Users.Update(user);

        }
        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);

            }
        }
    }
}
