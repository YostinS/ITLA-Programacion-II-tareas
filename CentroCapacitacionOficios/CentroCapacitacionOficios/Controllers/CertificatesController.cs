using Microsoft.AspNetCore.Mvc;
using CentroCapacitacionOficios.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using Microsoft.VisualBasic;
using CentroCapacitacionOficios.Data;
using CentroCapacitacionOficios.DTOs;

namespace CentroCapacitacionOficios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificatesController : ControllerBase
    {
        private readonly CentroCapacitacionOficiosDataContext _context;
        public CertificatesController(CentroCapacitacionOficiosDataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetCertificates(int id)
        {
            var certificate = _context.Certificates.Where(p => p.Id == id).FirstOrDefault();
            return Ok(certificate);
        }

        [HttpPost]
        public IActionResult CreateCertificates([FromBody] CreateCertificateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Certicate cannot be null.");
            }
            var certificate = new Certificate
            {
                UserId = dto.UserId,
                CourseId = dto.CourseId,
                IssuedDate = DateTime.UtcNow
            };
            _context.Add(certificate);
            _context.SaveChanges();
            return Ok(new { id = certificate.Id });
        }

        [HttpPut]
        public IActionResult UpdateCertificates([FromBody] UpdateCertificateDto dto)
        {
            if (dto == null || dto.Id <= 0)
            {
                return BadRequest("invalid certificate data");
            }
            var existingCertificate = _context.Certificates.FirstOrDefault(d => d.Id == dto.Id);
            if (existingCertificate == null)
            {
                return NotFound("Certificate no found");
            }
            existingCertificate.UserId = dto.UserId;
            existingCertificate.CourseId = dto.CourseId;
            
            _context.Certificates.Update(existingCertificate);
            _context.SaveChanges();

            return NoContent();

        }

        [HttpDelete]
        public IActionResult DeleteCertificates(int id)
        {
            var certificate = _context.Certificates.FirstOrDefault(d => d.Id == id);
            if (certificate == null)
            {
                return NotFound("Certificate no found");
            }
            _context.Certificates.Remove(certificate);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
