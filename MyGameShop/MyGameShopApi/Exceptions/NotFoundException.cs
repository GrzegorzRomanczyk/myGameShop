using System;

namespace MyGameShopApi.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) 
        {
        }
    }
}
