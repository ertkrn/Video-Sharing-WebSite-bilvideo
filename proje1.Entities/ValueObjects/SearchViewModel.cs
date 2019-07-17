using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1.Entities.ValueObjects
{
    public class SearchViewModel
    {
        public string searchedWord { get; set; }

        public string content { get; set; }

        public string approved { get; set; }

        public string videoNo { get; set; }
    }
}
