using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Common
{
    public class DefaultCommon : ICommon
    {
        public long GetCurrentUsernameId()
        {
            return 0;
        }
        public byte[] GetCurrentValue()
        {
            return null;
        }
        public string GetCurrentSizeValue()
        {
            return null;
        }
        public long GetUrunId()
        {
            return 1;
        }
    }
}
