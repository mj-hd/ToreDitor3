using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NiL.JS;

namespace ToreDitorCore.Runtimes
{
    public class TypeScript : IRuntime
    {
        public TypeScript(ToreDitorCore host)
        {
            this._host = host;

            this._init();
        }

        ~TypeScript()
        {
        }

        public void Reset()
        {
            this._init();
        }

        public bool Supports(string fname)
        {
            var ext = Path.GetExtension(fname);
            return (ext == ".ts");
        }

        public void Execute(string source)
        {
            var transpile = this._context.GetVariable("ts").GetMember("transpile").Value as NiL.JS.BaseLibrary.Function;
            var result = transpile.Invoke(new NiL.JS.Core.Arguments { source });

            var js = result.ToString();
            this._context.Eval(js);
        }

        public void Dispatch(OnEvents e)
        {
            this._context.Eval(@"
(function (handlers) {{
    for (var i = 0; i < handlers.length; i++) {{
        handlers[i]();                
    }}
}})(Editor."+OnEventsExt.ToString(e)+@");
");
        }

        protected ToreDitorCore _host;
        protected NiL.JS.Core.Context _context;

        private void _init()
        {
            this._context = new NiL.JS.Core.Context();

            this._context.Eval(Properties.Resources.typescript);

            this._context.DefineVariable("_host").Assign(new NiL.JS.Core.JSObject(this._host));

            this._context.AttachModule(typeof(Lex));
            this._context.AttachModule(typeof(Syntax));
            this._context.AttachModule(typeof(Scheme));
            this._context.AttachModule(typeof(Dispatcher));

            this.Execute(Properties.Resources.TypeScriptRuntimeScript);
        }
    }
}
