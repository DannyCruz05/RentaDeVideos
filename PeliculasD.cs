using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class PeliculasD
    {
        Core.Repository<PeliculasModel> _repository;
        public PeliculasD()
        {
            _repository = new Core.Repository<PeliculasModel>();
        }
        public int PeliculaId { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Autores { get; set; }
        public int Existencia { get; set; }
        public decimal PrecioRenta { get; set; }
        public bool Estado { get; set; }

        public List<PeliculasModel> TodasLasPeliculas()
        {
            return _repository.Consulta().ToList();
        }

        public int Agregar(PeliculasModel Pelicula)
        {
            Pelicula.FechaCreacion = DateTime.Now;
            Pelicula.FechaModificacion = DateTime.Now;
            _repository.Agregar(Pelicula);

            return 1;
        }

        public int Editar(PeliculasModel Pelicula)
        {
            var PeliculaInDb = _repository.Consulta().FirstOrDefault(C => C.PeliculaId == Pelicula.PeliculaId);

            if (PeliculaInDb != null)
            {
                PeliculaInDb.FechaModificacion = DateTime.Now;
                PeliculaInDb.Nombre = Pelicula.Nombre;
                PeliculaInDb.Autores = Pelicula.Autores;
                PeliculaInDb.Existencia = Pelicula.Existencia;
                PeliculaInDb.PrecioRenta = Pelicula.PrecioRenta;
                PeliculaInDb.Estado = Pelicula.Estado;
                _repository.Editar(PeliculaInDb);
                return 1;

            }
            return 0;
        }

        public int Eliminar(int PeliculaId)
        {
            var PeliculaInDb = _repository.Consulta().FirstOrDefault(C => C.PeliculaId == PeliculaId);
            if (PeliculaInDb != null)
            {
                _repository.Eliminar(PeliculaInDb);
                return 1;
            }
            return 0;
        }

    }
}
