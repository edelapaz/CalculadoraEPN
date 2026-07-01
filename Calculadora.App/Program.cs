using Calculadora.Core;

var logger = new ConsoleLogger();
var calculadora = new CalculadoraService(logger);

Console.WriteLine("=== Calculadora EPN ===");
Console.WriteLine($"Suma de 3 + 5 = {calculadora.Sumar(3, 5)}");
Console.WriteLine($"Suma de 10 + 20 = {calculadora.Sumar(10, 20)}");

class ConsoleLogger : ILogger
{
    public void Log(string mensaje) => Console.WriteLine($"[LOG] {mensaje}");
}
