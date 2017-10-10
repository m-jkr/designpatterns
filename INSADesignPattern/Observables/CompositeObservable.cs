using INSADesignPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Observables
{
    class CompositeObservable : IObservable
    {
        //Lui il fait le displayChildren du CurrentComposite
        public bool Execute()
        {
            Program.context.CurrentComposite.DisplayChildren();
            return true;
        }


    }
}
