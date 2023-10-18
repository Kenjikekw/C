using Clase.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.ComponentModel;


namespace Clase.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly UsersContextPostgres _context;

        public AnimalService(UsersContextPostgres context)
        {
            _context = context;
        }

        public List<Animales> GetAllAnimales(string filterProperty, string filterValue, string orderProperty, string order)
        {
            var query = _context.Animales;
            IEnumerable<Animales> q1 = query.AsEnumerable();
            IQueryable<Animales> q2 = query;
            if (!string.IsNullOrEmpty(filterProperty) && !string.IsNullOrEmpty(filterValue))
            {
                q2 = q1.Where(j => j.GetType().GetProperty(filterProperty).GetValue(j).ToString().ToLower().Contains(filterValue?.ToLower())).AsQueryable();
            }
            if (string.IsNullOrEmpty(orderProperty))
            {
                orderProperty = "Nombre";
            }
            var parameter = Expression.Parameter(typeof(Animales), "j");
            var property = Expression.Property(parameter, orderProperty);
            var lambda = Expression.Lambda<Func<Animales, object>>(Expression.Convert(property, typeof(object)), parameter);

            switch (order?.ToLower())
            {
                case "descendente":
                    return q2.OrderByDescending(lambda).Select(j => new Animales
                    {
                        Id = j.Id,
                        Nombre = j.Nombre,
                        Edad = j.Edad,
                        Estado = j.Estado,
                        FechaNacimiento = j.FechaNacimiento
                    }).ToList();
                case "ascendente":
                default:
                    return q2.OrderBy(lambda).Select(j => new Animales
                    {
                        Id = j.Id,
                        Nombre = j.Nombre,
                        Edad = j.Edad,
                        Estado = j.Estado,
                        FechaNacimiento = j.FechaNacimiento
                    }).ToList();
            }
        }
        public async Task<Animales> GetAnimalById(int id)
        {
            var animal = await _context.Animales
                .FirstOrDefaultAsync(j => j.Id == id);

            if (animal == null)
            {
                return null;
            }

            return animal;
        }
        public async Task<Animales> CreateAnimal(Animales animal)
        {
            var nuevoAnimal = new Animales
            {
                Id = animal.Id,
                Nombre = animal.Nombre,
                Edad = animal.Edad,
                Estado = animal.Estado,
                FechaNacimiento = animal.FechaNacimiento
            };
            await _context.Animales.AddAsync(nuevoAnimal);
            await _context.SaveChangesAsync();
            return nuevoAnimal;
        }
        public async Task<Animales> DeleteAnimalById(int id)
        {
            var animal = await _context.Animales.FirstOrDefaultAsync(j => j.Id == id);
            _context.Animales.Remove(animal);
            await _context.SaveChangesAsync();
            return animal;
        }
        public async Task<Animales> EditAnimal(Animales animal)
        {
            _context.Animales.Update(animal);
            await _context.SaveChangesAsync();
            return animal;
        }
    }
}