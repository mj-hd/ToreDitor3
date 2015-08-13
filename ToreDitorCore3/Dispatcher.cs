using System;
using System.IO;
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

        public void Dispatch(OnEvents e)
        {
            foreach (var runtime in this._runtimes)
            {
                runtime.Dispatch(e);
            }
        }

        public void ImportDirectory(string path)
        {
            foreach(var file in Directory.EnumerateFiles(path))
            {
                foreach(var runtime in this._runtimes)
                {
                    if (runtime.Supports(file))
                    {
                        using (var r = new StreamReader(file))
                        {
                            runtime.Execute(r.ReadToEnd());
                        }

                        goto nextFile;
                    }
                }

            nextFile:;
            }
        }

        private List<IRuntime> _runtimes = new List<IRuntime>();
    }
}
