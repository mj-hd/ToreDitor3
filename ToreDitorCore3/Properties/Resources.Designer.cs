﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToreDitorCore.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ToreDitorCore.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   $_host = _host
        ///
        ///class Event
        ///	attr_writer :handled
        ///	def initialize(sender)
        ///		@sender = @sender
        ///		@handled = false
        ///	end
        ///	def handled?; @handled; end
        ///end
        ///
        ///class EventHandlerArray &lt; Array
        ///	def add_handler(code=nil, &amp;block)
        ///		if(code)
        ///			push(code)
        ///		else
        ///			push(block)
        ///		end
        ///	end
        ///	def add
        ///		raise &quot;error&quot;
        ///	end
        ///	def remove_handler(code)
        ///		delete(code)
        ///	end
        ///	def dispatch(e)
        ///		reverse_each { | handler | handler.call(e) }
        ///	end
        ///end
        ///
        ///class Class
        ///	def events(*symbols)
        ///		modName = name+&quot;E [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string RubyRuntimeScript {
            get {
                return ResourceManager.GetString("RubyRuntimeScript", resourceCulture);
            }
        }
        
        /// <summary>
        ///   var ts;
        ///(function (ts) {
        ///    // token &gt; SyntaxKind.Identifer =&gt; token is a keyword
        ///    // Also, If you add a new SyntaxKind be sure to keep the `Markers` section at the bottom in sync
        ///    (function (SyntaxKind) {
        ///        SyntaxKind[SyntaxKind[&quot;Unknown&quot;] = 0] = &quot;Unknown&quot;;
        ///        SyntaxKind[SyntaxKind[&quot;EndOfFileToken&quot;] = 1] = &quot;EndOfFileToken&quot;;
        ///        SyntaxKind[SyntaxKind[&quot;SingleLineCommentTrivia&quot;] = 2] = &quot;SingleLineCommentTrivia&quot;;
        ///        SyntaxKind[SyntaxKind[&quot;MultiLineCommentTrivia&quot;] = 3] = &quot;MultiLineCom [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string typescript {
            get {
                return ResourceManager.GetString("typescript", resourceCulture);
            }
        }
        
        /// <summary>
        ///   class Buffer {
        ///	caret: Caret = new Caret();
        ///	highlights: Highlights = new Highlights();
        ///}
        ///
        ///class Caret {
        ///}
        ///
        ///class Document {
        ///}
        ///
        ///class Highlight {
        ///	name: string;
        ///	pattern: string;
        ///	brush: string;
        ///	level: number;
        ///}
        ///
        ///class Highlights {
        ///	add(highlight: Highlight) {
        ///		
        ///	}
        ///}
        ///
        ///class Highlighter {
        ///	remark_all() {
        ///	
        ///	}
        ///}
        ///
        ///class Editor {
        ///	buffer: Buffer = new Buffer();
        ///	document: Document = new Document();
        ///	scheme: Scheme = new Scheme();
        ///
        ///	onInitProp: {(): void;}[] = [];
        ///	onInitApp [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string TypeScriptRuntimeScript {
            get {
                return ResourceManager.GetString("TypeScriptRuntimeScript", resourceCulture);
            }
        }
    }
}
