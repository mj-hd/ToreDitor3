using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Scripting.Hosting;
using IronRuby;
using IronRuby.Hosting;

namespace ToreDitorCore.Runtimes
{
    class Ruby : IRuntime
    {
        public Ruby(ToreDitorCore host)
        {
            this._engine = IronRuby.Ruby.CreateEngine();
            this._scope = this._engine.CreateScope();

            this._host = host;

            this._init();
        }

        ~Ruby()
        {
        }

        public void Reset()
        {
            this._init();
        }

        public bool Supports(string fname)
        {
            var ext = Path.GetExtension(fname);
            return (ext == ".rb");
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

            this._engine.Execute($"$editor.dispatch_{name}(Event.new(self))", this._scope);
        }

        public void Execute(string source)
        {
            this._engine.Execute(source, this._scope);
        }

        protected ToreDitorCore _host;

        private ScriptEngine _engine;
        private ScriptScope _scope;

        private void _init()
        {
            this._scope = this._engine.CreateScope();

            this._scope.SetVariable("_host", this._host);

            this._engine.Execute(Properties.Resources.RubyRuntimeScript, this._scope);
        }
    }
}
