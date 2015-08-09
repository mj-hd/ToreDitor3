using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToreDitorCore
{
    public class Dispatcher
    {
        public Dispatcher()
        {
        }

        public void Regist(IRuntime runtime) {
            this._runtimes.Add(runtime);
        }

        public void Dispatch(IEvent e)
        {
            throw new NotImplementedException();
        }

        private List<IRuntime> _runtimes;
    }
}
