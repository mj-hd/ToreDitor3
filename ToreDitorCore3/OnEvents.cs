using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToreDitorCore
{
    public enum OnEvents
    {
        Unknown = -1,
        OnInitProp,
        OnInitApp,
        OnCreate,
        OnLoad,
        OnSaving,
        OnSave,
        OnDestroy,
        OnTimer,
        OnEvaluate,
        OnFindRequest,
        OnReplaceRequest,
        OnKeyPrintable,
        OnMultiStroke,
        OnComposition,
        OnQuitApp,
        OnMenuRequest,
        OnKeyCompleteRequest,
        OnKeyCompletion,
        OnMouseClick,
        OnKeyPress
    }

    static class OnEventsExt
    {
        public static string ToString(OnEvents e)
        {
            return OnEventsExt._eventNames[(int)e];
        }
        
        public static OnEvents ToOnEvents(string e)
        {
            return (OnEvents)Array.IndexOf(OnEventsExt._eventNames, e);
        }

        private static string[] _eventNames = {
           "onInitProp",
     	   "onInitApp",
     	   "onCreate",
     	   "onLoad",
     	   "onSaving",
     	   "onSave",
     	   "onDestroy",
     	   "onTimer",
     	   "onEvaluate",
     	   "onFindRequest",
     	   "onReplaceRequest",
     	   "onKeyPrintable",
     	   "onMultiStroke",
     	   "onComposition",
     	   "onQuitApp",
     	   "onMenuRequest",
     	   "onKeyCompleteRequest",
     	   "onKeyCompletion",
     	   "onMouseClick",
     	   "onKeyPress"
        };
    }
}
