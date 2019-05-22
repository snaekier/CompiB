using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiB
{
    [Serializable]
    struct ActionLog
    {
        public string Stack { get; set; }
        public string Input { get; set; }
        public string Action { get; set; }
    }
}
