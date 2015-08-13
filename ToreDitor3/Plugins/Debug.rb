$editor.onInit.add_handler {
	puts "onInit.rb"

	world = Highlight.new("WorldHighlight", "World", "#FF0000", 1)
	$editor.buffer.highlights.add(world)
}

$editor.onFinish.add_handler {
	puts "onFinish.rb"
}

$editor.onLoad.add_handler {
	puts "onLoad.rb"
}

$editor.onOpen.add_handler {
	puts "onOpen.rb"
}

$editor.onSave.add_handler {
	puts "onSave.rb"
}