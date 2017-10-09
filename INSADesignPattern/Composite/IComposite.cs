using INSADesignPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Composite
{
    interface IComposite
    {
        string GetDescription();
        IObservable GetObservable();
        string GetKeyWord();
    }
}
