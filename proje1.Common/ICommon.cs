using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Common
{
    public interface ICommon
    {
        long GetCurrentUsernameId();
        byte[] GetCurrentValue();
        string GetCurrentSizeValue();
        long GetUrunId();
    }
}
