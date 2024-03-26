using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class RentaVideosD
    {
        Core.Repository<RentaModel> _repository;
        public RentaVideosD()
        {
            _repository = new Core.Repository<RentaModel>();
        }
        public int RentaId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public List<RentaModel> TodasLasRentas()
        {
            return _repository.Consulta().ToList();
        }

        public int Agregar(RentaModel Renta)
        {
            Renta.FechaCreacion = DateTime.Now;
            Renta.FechaModificacion = DateTime.Now;
            _repository.Agregar(Renta);

            return 1;
        }

        public int Editar(RentaModel Renta)
        {
            var RentaInDb = _repository.Consulta().FirstOrDefault(C => C.RentaId == Renta.RentaId);

            if (RentaInDb != null)
            {
                RentaInDb.FechaModificacion = DateTime.Now;
                RentaInDb.ClienteId = Renta.ClienteId;
                RentaInDb.PeliculaId = Renta.PeliculaId;
                RentaInDb.FechaRenta = Renta.FechaRenta;
                RentaInDb.FechaRetorno = Renta.FechaRetorno;
                RentaInDb.Cantidad = Renta.Cantidad;
                RentaInDb.PrecioRenta = Renta.PrecioRenta;
                _repository.Editar(RentaInDb);
                return 1;

            }
            return 0;
        }

        public int Eliminar(int RentaId)
        {
            var RentaInDb = _repository.Consulta().FirstOrDefault(C => C.RentaId == RentaId);
            if (RentaInDb != null)
            {
                _repository.Eliminar(RentaInDb);
                return 1;
            }
            return 0;
        }
    }
}
