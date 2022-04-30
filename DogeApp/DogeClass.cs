using System.Collections.Generic;

namespace cdoge
{
    class DogeClass : DogeCallable
    {
        public readonly string name;
        public readonly DogeClass superclass;
        private readonly Dictionary<string, DogeFunction> methods;

        public DogeClass(string name, DogeClass superclass, Dictionary<string, DogeFunction> methods)
        {
            this.superclass = superclass;
            this.name = name;
            this.methods = methods;
        }

        public DogeFunction findMethod(string name)
        {
            if (methods.ContainsKey(name))
            {
                return methods[name];
            }

            if(superclass != null)
            {
                return superclass.findMethod(name);
            }

            return null;
        }

        public override string ToString()
        {
            return name;
        }

        public object call(Interpreter interpreter, List<object> arguments)
        {
            DogeInstance instance = new DogeInstance(this);
            DogeFunction initializer = findMethod("init");
            if (initializer != null)
            {
                initializer.bind(instance).call(interpreter, arguments);
            }

            return instance;
        }

        public int arity()
        {
            DogeFunction initializer = findMethod("init");
            if (initializer == null)
                return 0;

            return initializer.arity();
        }
    }
}
