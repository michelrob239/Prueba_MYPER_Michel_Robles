using System;

namespace MantenimientoTrabajadores.Models
{
    public class Trabajador
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string TipoDocumento { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }

        // Campos que pueden ser NULL en la base de datos
        public byte[]? Foto { get; set; }
        public string? Direccion { get; set; }
    }
}
