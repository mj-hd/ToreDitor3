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
        public Javascript()
        {
            this._init();
        }

        public ~Javascript()
        {
        }

        public void Reset()
        {
            this._init();
        }

        public void Execute(string source)
        {
            this._context.Execute(source);
        }

        public void Dispatch(IEvent e)
        {
            throw new NotImplementedException();
        }

        private CSharp.Context _context;

        private void _init()
        {
            this._context = new CSharp.Context();

            this._context.Execute(Properties.Resources.jQuery);

            this._context.Execute(@"
var Buffer = {};
var Caret  = {};
var Dispatcher = {};
var Document = {};
var Highlighter = {};
var Scheme = {};
"           );
        }
    }
}
