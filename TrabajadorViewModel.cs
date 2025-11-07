using MantenimientoTrabajadores.Models;
using System.Collections.Generic;

namespace MantenimientoTrabajadores.ViewModels
{
    public class TrabajadorViewModel
    {
        public Trabajador NuevoTrabajador { get; set; } = new Trabajador();
        public IEnumerable<Trabajador> ListaTrabajadores { get; set; }
    }
}
