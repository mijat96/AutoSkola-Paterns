using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface ILogger
    {
        [OperationContract]
        void LogKlijent(string text, DateTime time);

        [OperationContract]
        void LogServer(string text, DateTime time);
    }
}
