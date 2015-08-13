$_host = _host

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

class Buffer
	attr  :caret, :highlights

	def initialize
		@caret = Caret.new
		@highlights = Highlights.new
	end
end

class Caret
	def initialize
	end
end

class Document
	def initialize
	end
end

class Highlight
	attr_accessor	:name,  :pattern,
				:brush, :level
	def initialize(name, pattern="", brush="#000000", level=0)
		@name = name
		@pattern = pattern
		@brush = brush
		@level = level
	end
end

class Highlights
	def initialize
	end
	def add(highlight)
		$_host.Buffer.Aliases.Add(highlight.name, highlight.pattern, highlight.brush, highlight.level)
	end
end

# ‚â‚Á‚Ï‚è•Ï
class Highlighter
	def initialize
	end
	def remark_all
		$_host.Highlighter.RemarkAll
	end
end

class Scheme
	def initialize
	end
end

class Editor
	events	:onLoad, :onInit,
			:onFinish, :onLoad,
			:onOpen, :onSave
	attr		:buffer, :document,
				:scheme
	def initialize
		@buffer = Buffer.new
		@document = Document.new
		@scheme = Scheme.new
		super
	end
	
	def when_onLoad(e)
	end
	def when_onInit(e)
	end
	def when_onFinish(e)
	end
	def when_onOpen(e)
	end
	def when_onSave(e)
	end
end

$editor = Editor.new