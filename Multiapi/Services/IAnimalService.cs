
using Clase.Models;

namespace Clase.Services
{

    public interface IAnimalService
    {
        List<Animales> GetAllAnimales(string filterProperty, string filterValue, string orderProperty, string order);
        Task<Animales> GetAnimalById(int id);
        Task<Animales> CreateAnimal(Animales animal);
        Task<Animales> DeleteAnimalById(int id);
        Task<Animales> EditAnimal(Animales animal);
    }
}