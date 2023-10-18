using Clase.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Clase.Services
{
    public class JuegoService : IJuegoService
    {
        private readonly UsersContextSqlServer _context;

        public JuegoService(UsersContextSqlServer context)
        {
            _context = context;
        }

        public List<Juegos> GetAllJuegos(string filterProperty, string filterValue, string orderProperty, string order)
        {
            var query = _context.Juegos;
            IEnumerable<Juegos> q1 = query.AsEnumerable();
            IQueryable<Juegos> q2 = query;
            if (!string.IsNullOrEmpty(filterProperty) && !string.IsNullOrEmpty(filterValue))
            {
                q2 = q1.Where(j => j.GetType().GetProperty(filterProperty).GetValue(j).ToString().ToLower().Contains(filterValue?.ToLower())).AsQueryable();
            }
            if (string.IsNullOrEmpty(orderProperty))
            {
                orderProperty = "Nombre";
            }
            var parameter = Expression.Parameter(typeof(Juegos), "j");
            var property = Expression.Property(parameter, orderProperty);
            var lambda = Expression.Lambda<Func<Juegos, object>>(Expression.Convert(property, typeof(object)), parameter);

            switch (order?.ToLower())
            {
                case "descendente":
                    return q2.OrderByDescending(lambda).Select(j => new Juegos
                    {
                        Id = j.Id,
                        Nombre = j.Nombre,
                        Puntuacion = j.Puntuacion,
                        Estado = j.Estado,
                        FechaCreacion = j.FechaCreacion
                    }).ToList();
                case "ascendente":
                default:
                    return q2.OrderBy(lambda).Select(j => new Juegos
                    {
                        Id = j.Id,
                        Nombre = j.Nombre,
                        Puntuacion = j.Puntuacion,
                        Estado = j.Estado,
                        FechaCreacion = j.FechaCreacion
                    }).ToList();
            }
        }
        public async Task<Juegos> GetJuegoById(int id)
        {
            var juego = await _context.Juegos
                .FirstOrDefaultAsync(j => j.Id == id);

            if (juego == null)
            {
                return null;
            }

            var juegoDTO = new Juegos
            {
                Id = juego.Id,
                        Nombre = juego.Nombre,
                        Puntuacion = juego.Puntuacion,
                        Estado = juego.Estado,
                        FechaCreacion = juego.FechaCreacion
            };

            return juegoDTO;
        }
        public async Task<Juegos> CreateJuego(Juegos juego)
        {
            var nuevoJuego = new Juegos
            {
                Id = juego.Id,
                        Nombre = juego.Nombre,
                        Puntuacion = juego.Puntuacion,
                        Estado = juego.Estado,
                        FechaCreacion = juego.FechaCreacion
            };
            await _context.Juegos.AddAsync(nuevoJuego);
            await _context.SaveChangesAsync();
            return nuevoJuego;
        }
        public async Task<Juegos> DeleteJuegoById(int id)
        {
            var juego = await _context.Juegos.FirstOrDefaultAsync(j => j.Id == id);
            _context.Juegos.Remove(juego);
            await _context.SaveChangesAsync();
            return juego;
        }
        public async Task<Juegos> EditJuego(Juegos juego)
        {
            _context.Juegos.Update(juego);
            await _context.SaveChangesAsync();
            return juego;
        }
    }
}