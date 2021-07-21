using System;

namespace TruYumRepository
{
    public class TruYumException : Exception
    {
        public TruYumException(string errMsg) : base(errMsg)
        {

        }
    }
}
