using Amazon.ECR.Model;
using CapaDatos.Modelos;
using CapaDatos.Core;
using LibGit2Sharp;
using NuGet.Protocol.Core.Types;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CapaDatos
{
    public class ClientesD
    {
        Core.Repository<ClientesModel> _repository;
        public ClientesD()
        {
            _repository = new Core.Repository<ClientesModel>();
        }
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }
        public int ClasificacionClienteId { get; set; }

        public List<ClientesModel> TodosLosClientes()
        {
            return _repository.Consulta().ToList();
        }

        public int Agregar(ClientesModel cliente)
        {
            cliente.FechaCreacion = DateTime.Now;
            cliente.FechaModificacion = DateTime.Now;
            _repository.Agregar(cliente);

            return 1;
        }

        public int Editar(ClientesModel cliente)
        {
            var clienteInDb = _repository.Consulta().FirstOrDefault(C => C.ClienteId == cliente.ClienteId);

            if (clienteInDb != null)
            {
                clienteInDb.FechaModificacion = DateTime.Now;
                clienteInDb.Nombres = cliente.Nombres;
                clienteInDb.Apellidos = cliente.Apellidos;
                clienteInDb.FechaIngreso = cliente.FechaIngreso;
                clienteInDb.Estado = cliente.Estado;
                _repository.Editar(clienteInDb);
                return 1;

            }
            return 0;
        }

        public int Eliminar(int clienteId)
        {
            var clienteInDb = _repository.Consulta().FirstOrDefault(C => C.ClienteId == clienteId);
            if (clienteInDb != null)
            {
                _repository.Eliminar(clienteInDb);
                return 1;
            }
            return 0;
        }
    }
}
