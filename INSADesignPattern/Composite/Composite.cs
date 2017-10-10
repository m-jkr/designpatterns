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
        public List<IComposite> children;
        public string keyword;
        public IObservable observable;
        public string description;

        public IComposite Parent { get; set; }


        public Composite(string desc, string kw, IObservable obs)
        {
            children = new List<IComposite>();
            keyword = kw;
            description = desc;
            observable = obs;
            Parent = null;
        }

        public bool AddChild(IComposite child)
        {
            children.Add(child);
            return true;
        }



        public bool DisplayChildren()
        {
            if (children.Count > 0)
            {
                foreach (IComposite child in children)
                {
                    Console.WriteLine(" ¤¤¤¤ " + child.GetDescription() + " < " + child.GetKeyWord() + " >");
                }
            }
            else
            {
                Console.WriteLine("Leaf");
            }
            return true;
            
        }

        public List<IComposite> GetChildren()
        {
            return children;
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
