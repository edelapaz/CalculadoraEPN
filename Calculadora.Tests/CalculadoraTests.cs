using Xunit;
using Moq;
using Calculadora.Core;

namespace Calculadora.Tests;

public class CalculadoraTests
{
    [Fact]
    public void Sumar_DosNumeros_RetornaSumaYRegistraLog()
    {
        // Arrange (Preparar)
        var mockLogger = new Mock<ILogger>();
        var calc = new CalculadoraService(mockLogger.Object);

        // Act (Actuar)
        var resultado = calc.Sumar(5, 5);

        // Assert (Afirmar)
        Assert.Equal(10, resultado);
        // Verificamos que el mock fue llamado exactamente una vez con ese mensaje
        mockLogger.Verify(logger => logger.Log("Sumando 5 y 5"), Times.Once);
    }
}