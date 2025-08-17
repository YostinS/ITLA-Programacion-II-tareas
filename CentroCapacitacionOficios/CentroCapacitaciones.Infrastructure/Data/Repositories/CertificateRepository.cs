using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentroCapacitacionOficios.Domain.Entities;

namespace CentroCapacitacionOficios.Infrastructure.Data.Repositories
{
    public class CertificateRepository
    {
        private readonly CentroCapacitacionOficiosDataContext _context;
        public CertificateRepository(CentroCapacitacionOficiosDataContext context)
        {
            _context = context;
        }
        public List<Certificate> GetAllCertificate()
        {
            return _context.Certificates.Where(u => u.Id < 0).ToList();
        }
        public Certificate GetCertificateById(int id)
        {
            return _context.Certificates.FirstOrDefault(u => u.Id == id);
        }
        public void AddCertificate(Certificate certificate)
        {
            _context.Certificates.Add(certificate);
            _context.SaveChanges();
        }
        public void UpdateCertificate(Certificate certificate)
        {
            _context.Certificates.Update(certificate);
            _context.SaveChanges();
        }
        public void DeleteCertificate(int id)
        {
            var certificate = _context.Certificates.FirstOrDefault(u => u.Id == id);
            if (certificate != null)
            {
                _context.Certificates.Remove(certificate);
                _context.SaveChanges();
            }
        }
    }
}
