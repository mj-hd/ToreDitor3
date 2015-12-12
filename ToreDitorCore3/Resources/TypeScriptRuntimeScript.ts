class Editor {
	static Buffers: any = _host.Buffers;
	static Scheme: any = Scheme.GetInstance();
    static Lexes: any = Scheme.GetInstance().Dynamic.Lexes;
    static Dispatcher: any = Dispatcher.GetInstance();

	static onInitProp: {(): void;}[] = [];
	static onInitApp: {(): void;}[] = [];
	static onCreate: {(): void;}[] = [];
	static onLoad: {(): void;}[] = [];
	static onSaving: {(filename: string): void;}[] = [];
	static onSave: {(): void;}[] = [];
	static onDestroy: {(): void;}[] = [];
	static onTimer: {(): void;}[] = [];
	static onEvaluate: {(code: string): void;}[] = [];
	static onFindRequest: {(find: string, option: string[]): void;}[] = [];
	static onReplaceRequest: {(find: string, replace: string, option: string[]): void;}[] = [];
	static onKeyPrintable: {(character: string): void;}[] = [];
	static onMultiStroke: {(str: string): void;}[] = [];
	static onComposition: {(str: string): void;}[] = [];
	static onQuitApp: {(): void;}[] = [];
	static onMenuRequest: {(): void;}[] = [];
	static onKeyCompleteRequest: {(): void;}[] = [];
	static onKeyCompletion: {(key: string, modifier: number): void;}[] = [];
	static onMouseClick: {(modifier: number, screen_x: number, 
		screen_y: number, client_x: number, client_y: number,
		target: string, count: number): void;}[] = [];
	static onKeyPress: {(modifier: number): void;}[] = [];
}