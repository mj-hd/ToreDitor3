Editor.onInitApp.push(function () {
    console.log('onInitApp.html.ts');

    var elements = ['a', 'abbr', 'acronym', 'address', 'applet', 'area', 'b', 'base', 'basefont', 'bdo', 'big', 'blockquote',
        'body', 'br', 'button', 'caption', 'center', 'cite', 'code', 'col', 'colgroup', 'dd', 'del', 'dfn', 'dir',
        'div', 'dl', 'dt', 'em', 'fieldset', 'font', 'form', 'frame', 'frameset', 'head', 'hr', 'html', 'i',
        'h1', 'h2', 'h3', 'h4', 'h5', 'h6',
        'iframe', 'img', 'input', 'ins', 'isindex', 'kbd', 'label', 'legend', 'li', 'link', 'map', 'menu', 'meta',
        'noframes', 'noscript', 'object', 'ol', 'optgroup', 'option', 'p', 'param', 'pre', 'q', 'rb', 'rbc', 'rp',
        'rt', 'rtc', 'ruby', 's', 'samp', 'script', 'select', 'small', 'span', 'strike', 'strong', 'style', 'sub',
        'sup', 'table', 'tbody', 'td', 'textarea', 'tfoot', 'th', 'thead', 'title', 'tr', 'tt', 'u', 'ul', 'var'];

    var attributes = ['abbr', 'accept', 'accept-charset', 'accesskey', 'action', 'align', 'alt', 'archive',
        'axis', 'border', 'cellpadding', 'cellspacing', 'charset', 'checked', 'cite', 'class', 'classid',
        'codebase', 'codetype', 'cols', 'colspan', 'content', 'coords', 'data', 'datetime', 'declare',
        'defer', 'dir', 'disabled', 'enctype', 'for', 'frame', 'headers', 'height', 'href', 'hreflang', 'ismap',
        'id', 'http-equiv', 'label', 'long', 'maxlength', 'media', 'method', 'multiple', 'name', 'nohref',
        'onblur', 'onchange', 'onclick', 'ondblclick', 'onfocus', 'onkeydown', 'onkeypress', 'onkeyup',
        'onload', 'onmousedown', 'onmousemove', 'onmouseout', 'onmouseover', 'onmouseup', 'onreset',
        'onselect', 'onsubmit', 'onunload', 'rbspan', 'readonly', 'rel', 'rev', 'rows', 'rowspan', 'rules',
        'scheme', 'scope', 'selected', 'shape', 'size', 'span', 'src', 'standby', 'summary', 'tabindex', 'title',
        'type', 'usemap', 'valign', 'value', 'valuetype', 'version', 'width', 'xmlns', 'xml:lang', 'xml:space'];
    console.log("lex initializing");

    var lex = new Lex('html', '\\.(htm|html)$');
    console.log("lex initialized");
    Editor.Lexes.Add(lex);

    lex.DefaultStyle(1, 'exstyle:Default;');
    lex.DefaultStyle(2, 'exstyle:Default;');
    lex.DefaultStyle(3, 'exstyle:Default;');
    lex.DefaultStyle(4, 'exstyle:Comment;font:italic;');
    lex.DefaultStyle(5, 'exstyle:String;');

    lex.Add(new Syntax('comment', '1,2/<!--/', 'state:4;'));
    lex.Add(new Syntax('mark', '1/<!(?!--)/', 'state:4;'));
    lex.Add(new Syntax('tag', '1/</', 'next-state:2;'));
    lex.Add(new Syntax('php', '1/<(%|\\?php)/', 'transit:php;next-state:1;'));
    lex.Add(new Syntax('entity', '/&[^;]*;/', 'exstyle:Identifier;'));
    lex.Add(new Syntax('tag end', '2..3/\\/?>/', 'state:1;'));
    lex.Add(new Syntax('comment end', '4/(--)?>/', 'next-state:1;'));

    lex.Add(new Syntax('element', '2/\\b(' + elements.join('|') + ')\\b/', 'exstyle:Keyword;state:3;'));
    lex.Add(new Syntax('unknown element', '2/\\b[^(' + elements.join('|') + '|\\/>| =\\\\/>)]\\b/', 'decoration:underline;state:3;'));
    lex.Add(new Syntax('attribute', '3/\\b(' + attributes.join('|') + ')/', 'exstyle:Identifier;'));
    lex.Add(new Syntax('equal', '3/=/', 'exstyle:Operator;'));
    lex.Add(new Syntax('string', '3/"/', 'state:5;'));
    lex.Add(new Syntax('string end', '5/"/', 'next-state:3'));

    lex.Add(new Syntax('css', '1/<\\bstyle\\b.*>/', 'exstyle:Keyword;transit:css;next-state:1;'));

    var php_lex = new Lex('php', '\\.php$');
    Editor.Lexes.Add(php_lex);

    php_lex.Add(new Syntax('variable', '1/\\$[a-zA-Z][0-9a-zA-z]*\\b/', 'exstyle:Identifier;'));
    php_lex.Add(new Syntax('html', '/\\?>/', 'transit:*return*;next-state:1;'));

    var css_lex = new Lex('css', '\\.css$');
    Editor.Lexes.Add(css_lex);

    var css_styles = ['azimuth', 'background', 'background-attachment', 'background-color', 'background-image',
        'background-position', 'background-repeat', 'behavior', 'border', 'border-bottom',
        'border-bottom-color', 'border-bottom-style', 'border-bottom-width', 'border-collapse',
        'border-color', 'border-left', 'border-left-color', 'border-left-style', 'border-left-width',
        'border-right', 'border-right-color', 'border-right-style', 'border-right-width',
        'border-spacing', 'border-style', 'border-top', 'border-top-color', 'border-top-style',
        'border-top-width', 'border-width', 'bottom', 'caption-side', 'clear', 'clip', 'color', 'content',
        'counter-increment', 'counter-reset', 'cue', 'cue-after', 'cue-before', 'cursor', 'direction',
        'display', 'elevation', 'empty-cells', 'filter', 'float', 'font', 'font-family', 'font-size-adjust',
        'font-size', 'font-stretch', 'font-style', 'font-variant', 'font-weight', 'height', 'ime-mode',
        'layout-grid', 'layout-grid-char', 'layout-grid-line', 'layout-grid-mode',
        'layout-grid-type', 'left', 'letter-spacing', 'line-break', 'line-height',
        'list-style', 'list-style-image', 'list-style-position', 'list-style-type', 'margin',
        'margin-bottom', 'margin-left', 'margin-right', 'margin-top', 'marker-offset', 'marks',
        'max-height', 'max-width', 'min-height', 'min-width', 'orphans', 'outline', 'outline-color',
        'outline-style', 'outline-width', 'overflow', 'overflow-x', 'overflow-y', 'padding',
        'padding-bottom', 'padding-left', 'padding-right', 'padding-top', 'page', 'page-break-after',
        'page-break-before', 'page-break-inside', 'pause', 'pause-after', 'pause-before', 'pitch',
        'pitch-range', 'play-during', 'position', 'quotes', 'richness', 'right', 'ruby-align', 'ruby-overhang',
        'ruby-position', 'scrollbar-3dlight-color', 'scrollbar-arrow-color',
        'scrollbar-base-color', 'scrollbar-darkshadow-color', 'scrollbar-face-color',
        'scrollbar-highlight-color', 'scrollbar-shadow-color', 'scrollbar-track-color', 'size',
        'speak', 'speak-header', 'speak-numeral', 'speak-punctuation', 'speech-rate', 'stress',
        'table-layout', 'text-align', 'text-autospace', 'text-decoration', 'text-indent', 'text-justify',
        'text-kashida-space', 'text-shadow', 'text-transform', 'text-underline-position', 'top',
        'unicode-bidi', 'vertical-align', 'visibility', 'voice-family', 'volume', 'white-space', 'width',
        'widows', 'word-break', 'word-spacing', 'writing-mode', 'z-index'];


    css_lex.Add(new Syntax('selector', '1/^\\s*\S*/', 'exstyle:Identifier;next-state:2;'));
    css_lex.Add(new Syntax('directives', '2/{/', 'next-state:3;'));
    css_lex.Add(new Syntax('directives end', '3/}/', 'state:1'));
    css_lex.Add(new Syntax('style', '3/\\b(' + css_styles.join('|') + ')\\b/', 'exstyle:Keyword;next-state:4;'));
    css_lex.Add(new Syntax('style sep', '4/:/', 'next-state:5;'));
    css_lex.Add(new Syntax('delimiter', '5/;/', 'state:3'));
    css_lex.Add(new Syntax('unit', '5/\\b(px|em|\\%)\\b/', 'exstyle:Operator;'));
    css_lex.Add(new Syntax('html', '/<\\/\\s*style\\s*>/', 'transit:*return*;'));
});