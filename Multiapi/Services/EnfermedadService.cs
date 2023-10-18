using Clase.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.ComponentModel;


namespace Clase.Services
{
    public class EnfermedadService : IEnfermedadService
    {
        private readonly UsersContextMySql _context;

        public EnfermedadService(UsersContextMySql context)
        {
            _context = context;
        }

        public List<Enfermedades> GetAllEnfermedades(string filterProperty, string filterValue, string orderProperty, string order)
        {
            var query = _context.Enfermedades;
            IEnumerable<Enfermedades> q1 = query.AsEnumerable();
            IQueryable<Enfermedades> q2 = query;
            if (!string.IsNullOrEmpty(filterProperty) && !string.IsNullOrEmpty(filterValue))
            {
                q2 = q1.Where(j => j.GetType().GetProperty(filterProperty).GetValue(j).ToString().ToLower().Contains(filterValue?.ToLower())).AsQueryable();
            }
            if (string.IsNullOrEmpty(orderProperty))
            {
                orderProperty = "Nombre";
            }
            var parameter = Expression.Parameter(typeof(Enfermedades), "j");
            var property = Expression.Property(parameter, orderProperty);
            var lambda = Expression.Lambda<Func<Enfermedades, object>>(Expression.Convert(property, typeof(object)), parameter);

            switch (order?.ToLower())
            {
                case "descendente":
                    return q2.OrderByDescending(lambda).Select(j => new Enfermedades
                    {
                        Id = j.Id,
                        Nombre = j.Nombre,
                        Peligrosidad = j.Peligrosidad,
                        Estado = j.Estado,
                        FechaDescubrimiento = j.FechaDescubrimiento
                    }).ToList();
                case "ascendente":
                default:
                    return q2.OrderBy(lambda).Select(j => new Enfermedades
                    {
                        Id = j.Id,
                        Nombre = j.Nombre,
                        Peligrosidad = j.Peligrosidad,
                        Estado = j.Estado,
                        FechaDescubrimiento = j.FechaDescubrimiento
                    }).ToList();
            }
        }
        public async Task<Enfermedades> GetEnfermedadById(int id)
        {
            var enfermedad = await _context.Enfermedades
                .FirstOrDefaultAsync(j => j.Id == id);

            if (enfermedad == null)
            {
                return null;
            }

            return enfermedad;
        }
        public async Task<Enfermedades> CreateEnfermedad(Enfermedades enfermedad)
        {
            var nuevaEnfermedad = new Enfermedades
            {
                Id = enfermedad.Id,
                Nombre = enfermedad.Nombre,
                Peligrosidad = enfermedad.Peligrosidad,
                Estado = enfermedad.Estado,
                FechaDescubrimiento = enfermedad.FechaDescubrimiento
            };
            await _context.Enfermedades.AddAsync(nuevaEnfermedad);
            await _context.SaveChangesAsync();
            return nuevaEnfermedad;
        }
        public async Task<Enfermedades> DeleteEnfermedadById(int id)
        {
            var enfermedad = await _context.Enfermedades.FirstOrDefaultAsync(j => j.Id == id);
            _context.Enfermedades.Remove(enfermedad);
            await _context.SaveChangesAsync();
            return enfermedad;
        }
        public async Task<Enfermedades> EditEnfermedad(Enfermedades enfermedad)
        {
            _context.Enfermedades.Update(enfermedad);
            await _context.SaveChangesAsync();
            return enfermedad;
        }
    }
}