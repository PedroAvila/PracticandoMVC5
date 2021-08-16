using Repaso.EntidadesDominio;
using Repaso.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso.ServiciosDominio
{
    public class SdEmpleado
    {
        private readonly EmpleadoRepository _empleadoRepository = new EmpleadoRepository();
        public List<Empleado> GetAll()
        {
            return _empleadoRepository.GetAll();
        }

        public void Create(Empleado entity)
        {
            if (entity.EmpleadoId == 0)
            {
                _empleadoRepository.Create(entity);
            }
            else
            {
                _empleadoRepository.Update(entity);
            }
        }

        public Empleado Single(int id)
        {
            return _empleadoRepository.Single(id);
        }

        public void Delete(int id)
        {
            _empleadoRepository.Delete(id);
        }
    }
}
