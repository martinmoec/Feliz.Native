namespace Feliz.Native

open Fable.Core
open Fable.Core.JsInterop

[<Erase>] type IViewProp = interface end
[<Erase>] type IImageProp = interface end
[<Erase>] type IImageBackgroundProp = interface end
[<Erase>] type IKeyboardAvoidingViewProp = interface end
[<Erase>] type ISafeAreaViewProp = interface end
[<Erase>] type IScrollViewProp = interface end
[<Erase>] type ITextProp = interface end
[<Erase>] type ITextInputProp = interface end
[<Erase>] type ITouchableHighlightProp = interface end
[<Erase>] type ITouchableOpacityProp = interface end
[<Erase>] type IPressableProp = interface end
[<Erase>] type IActivityIndicatorProp = interface end
[<Erase>] type ISwitchProp = interface end

type length =
    inherit Feliz.length
    static member inline dip (value: double) : Feliz.Styles.ICssUnit = unbox ((unbox<string>value))
    static member inline dip (value: int) : Feliz.Styles.ICssUnit = unbox ((unbox<string>value))

type style =
    inherit Feliz.style
    static member inline borderTopLeftRadius (x:int) = unbox ("borderTopLeftRadius", x)
    static member inline borderTopRightRadius (x:int) = unbox ("borderTopRightRadius", x)
    static member inline borderBottomLeftRadius (x:int) = unbox ("borderBottomLeftRadius", x)
    static member inline borderBottomRightRadius (x:int) = unbox ("borderBottomRightRadius", x)
    
    static member inline flex (x:float) = unbox ("flex", x)
    static member inline shadowRadius (x:int) = unbox ("shadowRadius", x)
    static member inline shadowRadius (x:float) = unbox ("shadowRadius", x)
    static member inline shadowOpacity (x:float) = unbox ("shadowOpacity", x)
    static member inline shadowOffset (x:{|width:int; height:int|}) = unbox ("shadowOffset", x)
    static member inline shadowColor (x:string) = unbox ("shadowColor", x)
    
[<Erase>]
type Prop<'a> =
    static member inline attribution (value: string) = unbox<'a> ("attribution", value)
    // static member inline ref (value: (obj -> unit)) = unbox<'a> ("ref", value)
    static member inline key (value: string) = unbox<'a> ("key", value)
    static member inline key (value: int) = unbox<'a> ("key", value)
    static member inline custom (key: string, value: obj) = unbox<'a> (key, value)
    static member inline style (x:seq<Feliz.IStyleAttribute>) = !!("style", keyValueList CaseRules.LowerFirst x)
    static member inline onLayout (x:obj -> unit) = unbox<'a>("onLayout", x)
    static member inline children (elements: ReactElement list) = unbox<'a> (Feliz.prop.children elements)

module Types =
    type PressEvent = {
        changedTouches: PressEvent []
        force : float option
        identifier: float
        locationX: float
        locationY: float
        pageX: float
        pageY: float
        target: float option
        timestamp: float
        touches: PressEvent []
    }


[<Erase>]
type view =
    inherit Prop<IViewProp>
    static member inline source (value : {|uri : string|}) = unbox ("source", value)


[<Erase>]
type image =
    inherit Prop<IImageProp>
    static member inline uriSource (x:string) = unbox ("source", {|uri = x|})
    [<Emit("require($0)")>]
    static member inline localImage (_path:string) : obj = jsNative 
    static member inline defaultSource (x:string) = unbox ("defaultSource", image.localImage x)
    static member inline source (x:string) = unbox ("source", image.localImage x)
    static member inline resizeMode (x:string) = unbox ("resizeMode", x)

[<Erase>]
type imageBackground =
    inherit Prop<IImageBackgroundProp>
    static member inline defaultSource (x:string) = unbox ("defaultSource", image.localImage x)
    static member inline source (x:string) = unbox ("source", image.localImage x)
    static member inline resizeMode (x:string) = unbox ("resizeMode", x)
    static member inline imageStyle (x:seq<Feliz.IStyleAttribute>) = !!("imageStyle", keyValueList CaseRules.LowerFirst x)

[<Erase>]
type keyboardAvoidingView =
    inherit Prop<IKeyboardAvoidingViewProp>
    static member inline behavior (x:obj) = unbox ("behavior", x)

[<Erase>]
type safeAreaView =
    inherit Prop<ISafeAreaViewProp>
    static member inline emulateUnlessSupported (value:bool) = unbox ("emulateUnlessSupported", value)

[<Erase>]
type scrollView =
    inherit Prop<IScrollViewProp>
    static member inline horizontal (value:bool) = unbox ("horizontal", value)

[<Erase>]
type text =
    inherit Prop<ITextProp>
    static member inline allowFontScaling (x:bool) = unbox ("allowFontScaling", x)
    static member inline adjustsFontSizeToFit (x:bool) = unbox ("adjustsFontSizeToFit", x)
    static member inline maxFontSizeMultiplier (x:int) = unbox ("maxFontSizeMultiplier", x)
    static member inline maxFontSizeMultiplier (x:float) = unbox ("maxFontSizeMultiplier", x)
    static member inline minFontSizeMultiplier (x:int) = unbox ("minFontSizeMultiplier", x)
    static member inline minFontSizeMultiplier (x:float) = unbox ("minFontSizeMultiplier", x)
    static member inline nativeId (x:string) = unbox ("nativeID", x)
    static member inline numberOfLines (x:int) = unbox ("numberOfLines", x)
    static member inline onLongPress (x:Types.PressEvent -> unit) = unbox ("onLongPress", x)
    static member inline onPress (x:Types.PressEvent -> unit) = unbox ("onPress", x)
    static member inline text (x:string) = unbox ("children", unbox (x))

type textInput =
    inherit Prop<ITextInputProp>
    static member inline autoCapitalize (x:string) = unbox ("autoCapitalize", x)
    static member inline autoCorrect (x:bool) = unbox ("autoCorrect", x)
    static member inline autoFocus (x:bool) = unbox ("autoFocus", x)
    static member inline blurOnSubmit (x:bool) = unbox ("blurOnSubmit", x)
    static member inline caretHidden (x:bool) = unbox ("caretHidden", x)
    static member inline editable (x:bool) = unbox ("editable", x)
    static member inline defaultValue (x:string) = unbox ("defaultValue", x)
    static member inline keyboardType (x:string) = unbox ("keyboardType", x)
    static member inline maxLength (x:int) = unbox ("maxLength", x)
    static member inline multiline (x:bool) = unbox ("multiline", x)
    static member inline onChange (x:obj -> unit) = unbox ("onChange", x)
    static member inline onChangeText (x:string -> unit) = unbox ("onChangeText", x)
    static member inline onPressIn (x:Types.PressEvent -> unit) = unbox ("onPressIn", x)
    static member inline onPressOut (x:Types.PressEvent -> unit) = unbox ("onPressOut", x)
    static member inline onSubmitEditing (x:obj -> unit) = unbox ("onSubmitEditing", x)
    static member inline placeholder (x:string) = unbox ("placeholder", x)
    static member inline placeholderTextColor (x:string) = unbox ("placeholderTextColor", x)
    static member inline returnKeyType (x:string) = unbox ("returnKeyType", x)
    static member inline secureTextEntry (x:bool) = unbox ("secureTextEntry", x)
    static member inline textAlign (x:string) = unbox ("textAlign", x)
    static member inline value (x:string) = unbox ("value", x)

[<Erase>]
type touchableHighligh =
    inherit Prop<ITouchableHighlightProp>
    static member inline activeOpacity (x:float) = unbox ("activeOpacity", x)
    static member inline disabled (x:bool) = unbox ("disabled", x)
    static member inline onLongPress (x:Types.PressEvent -> unit) = unbox ("onLongPress", x)
    static member inline onPress (x:Types.PressEvent -> unit) = unbox ("onPress", x)
    static member inline onPress (x:unit -> unit) = unbox ("onPress", x)
    static member inline nativeId (x:string) = unbox ("nativeID", x)
    static member inline underlayColor (x:string) = unbox ("underlayColor", x)
    static member inline children (x:'a) = unbox ("children", x)

[<Erase>]
type touchableOpacity =
    inherit Prop<ITouchableOpacityProp>
    static member inline activeOpacity (x:float) = unbox ("activeOpacity", x)
    static member inline disabled (x:bool) = unbox ("disabled", x)
    static member inline onLongPress (x:Types.PressEvent -> unit) = unbox ("onLongPress", x)
    static member inline onPress (x:Types.PressEvent -> unit) = unbox ("onPress", x)
    static member inline onPress (x:unit -> unit) = unbox ("onPress", x)
    static member inline nativeId (x:string) = unbox ("nativeID", x)
    static member inline children (x:'a) = unbox ("children", x)


[<Erase>]
type pressable =
    inherit Prop<IPressableProp>
    static member inline disabled (x:bool) = unbox ("disabled", x)
    static member inline onLongPress (x:Types.PressEvent -> unit) = unbox ("onLongPress", x)
    static member inline onPress (x:Types.PressEvent -> unit) = unbox ("onPress", x)
    static member inline onPress (x:unit -> unit) = unbox ("onPress", x)
    static member inline onPressIn (x:Types.PressEvent -> unit) = unbox ("onPressIn", x)
    static member inline onPressOut (x:Types.PressEvent -> unit) = unbox ("onPressOut", x)
    
[<Erase>]
type activityIndicator =
    inherit Prop<IActivityIndicatorProp>
    static member inline animating (x:bool) = unbox ("animating", x)
    static member inline color (x:string) = unbox ("color", x)
    static member inline small x = unbox ("size", "small")
    static member inline large x = unbox ("size", "large")
    static member inline size (x:string) = unbox ("size", x)

type TrackColor = {``false``:string; ``true``:string}

[<Erase>]
type switch =
    inherit Prop<ISwitchProp>
    static member inline trackColor (x:TrackColor) = unbox ("trackColor", x)
    static member inline thumbColor (x:string) = unbox ("thumbColor", x)
    static member inline onValueChange (x:bool -> unit) = unbox ("onValueChange", x)
    static member inline value (x:bool) = unbox ("value", x)
    static member inline value (x:string) = unbox ("value", x)
    static member inline disabled (x:bool) = unbox ("disabled", x)
