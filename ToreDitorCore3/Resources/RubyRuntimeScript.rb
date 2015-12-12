$_host = _host
$_scheme = _scheme
$_dispatcher = _dispatcher

class Event
	attr_writer :handled
	def initialize(sender)
		@sender = @sender
		@handled = false
	end
	def handled?; @handled; end
end

class EventHandlerArray < Array
	def add_handler(code=nil, &block)
		if(code)
			push(code)
		else
			push(block)
		end
	end
	def add
		raise "error"
	end
	def remove_handler(code)
		delete(code)
	end
	def dispatch(e)
		reverse_each { | handler | handler.call(e) }
	end
end

class Class
	def events(*symbols)
		modName = name+"Events"
		initStr = Array.new
		readerStr = Array.new
		methodsStr = Array.new
		symbols.each { | sym |
			name = sym.to_s
			initStr << %Q{
				@#{name} = EventHandlerArray.new
			}
			readerStr << ":#{name}"
			methodsStr << %Q{
			def dispatch_#{name}(e)
				@#{name}.dispatch(e)
				when_#{name}(e) if(!e.handled?)
			end
			def when_#{name}(e)
			end
			}
		}
		eval %Q{
			module #{modName}
				def initialize(*args)
					begin
						super(*args)
						rescue NoMethodError; end
						#{initStr.join}
					end
					#{"attr_reader "+readerStr.join(', ')}
					#{methodsStr.join}
				end
			include #{modName}
		}
	end
end


class Editor
	events	:onInitProp, :onInitApp,
			:onCreate, :onLoad,
			:onSaving, :onSave,
			:onDestroy, :onTimer,
			:onEvaluate, :onFindRequest,
			:onReplaceRequest, :onKeyPrintable,
			:onMultiStroke, :onComposition,
			:onQuitApp, :onMenuRequest,
			:onKeyCompleteRequest, :onKeyCompletion,
			:onMouseClick, :onKeyPress
	attr		:buffer, :document,
				:scheme
	def initialize
		@buffers = $_host.Buffers
		@scheme = $_scheme 
		@lexes = $_scheme.Dynamic.Lexes
		@dispatcher = $_dispatcher 
		super
	end
end

$editor = Editor.new