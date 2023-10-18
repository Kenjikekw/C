
using Clase.Models;

namespace Clase.Services
{

    public interface IJuegoService
    {
        List<Juegos> GetAllJuegos(string filterProperty, string filterValue, string orderProperty, string order);
        Task<Juegos> GetJuegoById(int id);
        Task<Juegos> CreateJuego(Juegos juego);
        Task<Juegos> DeleteJuegoById(int id);
        Task<Juegos> EditJuego(Juegos juego);
    }
}