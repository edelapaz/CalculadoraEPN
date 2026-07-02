using Calculadora.Core;

namespace Calculadora.App.Logging;

static class ConsoleLogger
{
    public static void Log(string mensaje) => Console.WriteLine($"[LOG] {mensaje}");
}

public class ConsoleLoggerAdapter : ILogger
{
    public void Log(string mensaje) => ConsoleLogger.Log(mensaje);
}
