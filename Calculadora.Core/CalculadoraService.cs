namespace Calculadora.Core;

// Dependencia que vamos a simular (Mock)
public interface ILogger 
{ 
    void Log(string mensaje); 
}

// Nuestra clase a probar
public class CalculadoraService
{
    private readonly ILogger _logger;

    public CalculadoraService(ILogger logger) 
    { 
        _logger = logger; 
    }

    public int Sumar(int a, int b)
    {
        _logger.Log($"Sumando {a} y {b}");
        return a + b;
    }
}