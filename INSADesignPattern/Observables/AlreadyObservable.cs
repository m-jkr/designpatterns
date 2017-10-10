using INSADesignPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Observables
{
    class AlreadyObservable : IObservable
    {
        public bool Execute()
        {
            Console.WriteLine(" You already are in that section O_o " + Program.context.CurrentComposite.GetDescription());
            return true;
        }
    }
}
