﻿using System.Collections.Generic;

namespace cdoge
{
    /*
     * Csharp had some problems defining the clockFunction
     * directly in Interpreter.globals.define's arugments
     */
    class NativeFunctions // can also just be a namespace?
    {
        public class clockFunction : DogeCallable
        {
            public int arity()
            {
                return 0;
            }
            public object call(Interpreter interprter, List<object> arguments)
            {
                return (double)System.Environment.TickCount / 1000.0;
            }
            public override string ToString()
            {
                return "<native fn>";
            }
        }
    }
}
