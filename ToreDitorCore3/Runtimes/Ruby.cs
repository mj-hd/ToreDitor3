using System;
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
        public Ruby()
        {
            this._engine = IronRuby.Ruby.CreateEngine();
            this._scope = this._engine.CreateScope();

            this._init();
        }

        public ~Ruby()
        {
        }

        public void Reset()
        {
            this._init();
        }

        public void Dispatch(IEvent e)
        {
            throw new NotImplementedException();
        }

        public void Execute(string source)
        {
            this._engine.Execute(source, this._scope);
        }

        private ScriptEngine _engine;
        private ScriptScope _scope;

        private void _init()
        {
            this._scope = this._engine.CreateScope();

            this._engine.Execute(@"
class Buffer

end

class Caret

end

class Dispatcher

end

class Document

end

class Highlighter

end

class Highlights

end

class Scheme

end
",          this._scope);
        }
    }
}
