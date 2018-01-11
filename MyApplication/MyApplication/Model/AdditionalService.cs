using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Model
{
    public class AdditionalService : Product
    {
        public override string ToString()
        {
            return this.Name;
        }
    }
}
