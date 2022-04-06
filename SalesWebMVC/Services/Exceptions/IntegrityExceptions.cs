using System;

namespace SalesWebMVC.Services.Exceptions
{
    public class IntegrityExceptions : ApplicationException
    {
        public IntegrityExceptions(string message): base(message)
        {
        }
    }
}
