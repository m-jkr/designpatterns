using INSADesignPattern.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Contexte
{
    class Context
    {
        public string Username { get; set; }
        public IComposite CurrentComposite { get; set; }
        
        public Context()
        {
            Username = "< User >";
            CurrentComposite = null;
        }
    }
}
