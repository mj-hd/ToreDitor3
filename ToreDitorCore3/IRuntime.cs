using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToreDitorCore
{
    public interface IRuntime
    {
        void Reset();
        void Execute(string source);
        void Dispatch(IEvent e);
    }
}
