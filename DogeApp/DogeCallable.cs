using System.Collections.Generic;

namespace cdoge
{
    interface DogeCallable
    {
        int arity();
        object call(Interpreter interpreter, List<object> arguments);
    }
}
