using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyoceraVIPackingSystem.Business
{
    public interface IValidator
    {
        IEnumerable<string> GetMsgErr(string boardNo);
    }
}
