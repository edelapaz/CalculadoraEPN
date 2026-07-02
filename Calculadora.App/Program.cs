using Calculadora.Core;
using Calculadora.App.Logging;

var logger = new ConsoleLoggerAdapter();
var calculadora = new CalculadoraService(logger);

Console.WriteLine("=== Calculadora EPN ===");
Console.WriteLine($"Suma de 3 + 5 = {calculadora.Sumar(3, 5)}");
Console.WriteLine($"Suma de 10 + 20 = {calculadora.Sumar(10, 20)}");
