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
        private static Dispatcher _instance = null;
        public static Dispatcher GetInstance()
        {
            _instance = _instance ?? new Dispatcher();
            return _instance;
        }

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

        public void ImportFile(string file)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException($"ファイル{file}が見つかりませんでした。");
            }

            foreach(var runtime in this._runtimes)
            {
                if (runtime.Supports(file))
                {
                    try {
                        using (var r = new StreamReader(file))
                        {
                            runtime.Execute(r.ReadToEnd());
                        }
                    }
                    catch (NiL.JS.Core.JSException e)
                    {
                        System.Windows.Forms.MessageBox.Show($"Error {file}\n" + e.Message, "エラー");
                    }
                    catch (ArgumentException e)
                    {
                        System.Windows.Forms.MessageBox.Show($"Error {file}\n"+e.Message, "エラー");
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show($"Error {file}\n"+e.Message, "エラー");
                    }

                    return;
                }
            }
        }

        public void ImportDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                return;
            }

            foreach(var file in Directory.EnumerateFiles(path))
            {
                this.ImportFile(file);
            }
        }

        private List<IRuntime> _runtimes = new List<IRuntime>();
    }
}
