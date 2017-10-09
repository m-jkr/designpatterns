using INSADesignPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern.Composite
{
    class Composite : IComposite
    {
        public List<IComposite> fils;
        public string keyword;
        public IObservable observable;
        public string description;


        public Composite(string desc, string kw, IObservable obs)
        {
            fils = new List<IComposite>();
            keyword = kw;
            description = desc;
            observable = obs;
        }

        public string GetDescription()
        {
            return description;
        }

        public string GetKeyWord()
        {
            return keyword;
        }

        public IObservable GetObservable()
        {
            return observable;
        }
    }
}
