
using Clase.Models;

namespace Clase.Services
{

    public interface IEnfermedadService
    {
        List<Enfermedades> GetAllEnfermedades(string filterProperty, string filterValue, string orderProperty, string order);
        Task<Enfermedades> GetEnfermedadById(int id);
        Task<Enfermedades> CreateEnfermedad(Enfermedades enfermedad);
        Task<Enfermedades> DeleteEnfermedadById(int id);
        Task<Enfermedades> EditEnfermedad(Enfermedades enfermedad);
    }
}