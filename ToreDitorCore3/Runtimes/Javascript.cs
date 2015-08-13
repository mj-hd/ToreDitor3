using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronJS;
using IronJS.Hosting;

namespace ToreDitorCore.Runtimes
{
    public class Javascript : IRuntime
    {
        public Javascript(ToreDitorCore host)
        {
            this._host = host;

            this._init();
        }

        ~Javascript()
        {
        }

        public void Reset()
        {
            this._init();
        }

        public bool Supports(string fname)
        {
            var ext = Path.GetExtension(fname);
            return (ext == ".js");
        }

        public void Execute(string source)
        {
            this._context.Execute(source);
        }

        public void Dispatch(OnEvents e)
        {
            var name = "";

            switch (e)
            {
                case OnEvents.OnFinish:
                    name = "onFinish";
                    break;
                case OnEvents.OnInit:
                    name = "onInit";
                    break;
                case OnEvents.OnLoad:
                    name = "onLoad";
                    break;
                case OnEvents.OnOpen:
                    name = "onOpen";
                    break;
                case OnEvents.OnSave:
                    name = "onSave";
                    break;
                default:
                    name = "";
                    return;
            }

            this._context.Execute($@"
function dispatch(handlers) {{
    for (var i = 0; i < handlers.length; i++) {{
        handlers[i]();                
    }}
}};
dispatch(Editor.{name});
");
        }

        protected ToreDitorCore _host;

        private CSharp.Context _context;

        private void _init()
        {
            this._context = new CSharp.Context();

            this._context.SetGlobal<FunctionObject>("print",
                IronJS.Native.Utils.CreateFunction<Action<string>>(this._context.Environment, 1, (text) => { Console.WriteLine(text); }));

            this._context.Execute(Properties.Resources.JavascriptRuntimeScript);
        }
    }
}
