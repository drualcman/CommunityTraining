using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityTraining.Common.Exceptions
{
    public class GeneralException : Exception
    {
        public GeneralException(): base() { }
        public GeneralException(string message): base(message){ }
        public GeneralException(string message, Exception innerException) : base(message, innerException) { }

        public override string ToString() =>
            this.Message;

    }
}
