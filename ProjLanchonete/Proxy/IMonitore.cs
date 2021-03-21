using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Data;

namespace Proxy
{
    public interface IMonitore
    {
        void SaveLog(string msg);

        List<Log> Select();
    }
}
