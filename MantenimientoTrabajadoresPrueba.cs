using Xunit;
using MantenimientoTrabajadores.Controllers;
using MantenimientoTrabajadores.Models;
using MantenimientoTrabajadores.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class TrabajadoresControllerTests
{
    private readonly AppDbContext _context;
    private readonly TrabajadoresController _controller;

    public TrabajadoresControllerTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;
        _context = new AppDbContext(options);
        _controller = new TrabajadoresController(_context);
    }

    [Fact]
    public async Task Create_AddsNewTrabajador()
    {
        // Arrange
        var trabajador = new Trabajador
        {
            Nombres = "Luis",
            Apellidos = "Castillo",
            TipoDocumento = "DNI",
            NumeroDocumento = "99999999",
            Sexo = "Masculino"
        };

        // Act
        await _controller.Create(trabajador);
        var result = await _context.Trabajadores.FirstOrDefaultAsync(t => t.NumeroDocumento == "99999999");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Luis", result.Nombres);
    }
}
