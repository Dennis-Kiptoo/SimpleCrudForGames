using System;

namespace CarSales.Exceptions
{
    public class GameNotFoundException : Exception
    {
        public GameNotFoundException(string message) : base(message) { }
    }
}