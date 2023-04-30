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

    type Layout = {
        width : float
        height : float
        x : float
        y : float
    }

    type LayoutEvent = {
        layout : Layout
        target : int
    }

    type Point = {x:float; y:float}

    type Rect = {
        bottom : float option
        left : float option
        right : float option
        top : float option
    }

[<Erase>]
type activityIndicator =
    inherit Prop<IActivityIndicatorProp>
    static member inline animating (x:bool) = unbox ("animating", x)
    static member inline color (x:string) = unbox ("color", x)
    static member inline small x = unbox ("size", "small")
    static member inline large x = unbox ("size", "large")
    static member inline size (x:string) = unbox ("size", x)


[<Erase>]
type image =
    inherit Prop<IImageProp>
    static member inline accessibilityLabel (x:string) = unbox ("accessibilityLabel", x)
    static member inline alt (x:string) = unbox ("alt", x)
    static member inline blurRadius (x:float) = unbox ("blurRadius", x)
    static member inline blurRadius (x:int) = unbox ("blurRadius", x)
    static member inline fadeDuration (x:float) = unbox ("fadeDuration", x)
    static member inline fadeDuration (x:int) = unbox ("fadeDuration", x)
    static member inline height (x:int) = unbox ("height", x)
    static member inline onError (x:obj -> unit) = unbox ("onError", x)
    static member inline onLayout (x:obj -> unit) = unbox ("onLayout", x)
    static member inline onLayout (x:Types.LayoutEvent -> unit) = unbox ("onLayout", x)
    static member inline onLoad (x:obj -> unit) = unbox ("onLoad", x)
    static member inline onLoadEnd (x:unit -> unit) = unbox ("onLoadEnd", x)
    static member inline onLoadStart (x:unit -> unit) = unbox ("onLoadStart", x)
    static member inline onPartialLoad (x:unit -> unit) = unbox ("onPartialLoad", x)
    static member inline onProgress (x:obj -> unit) = unbox ("onProgress", x)
    static member inline onProgress (x:(int * int) -> unit) = unbox ("onProgress", x)
    static member inline progressiveRenderingEnabled (x:bool) = unbox ("progressiveRenderingEnabled", x)
    static member inline resizeMethod (x:string) = unbox ("resizeMethod", x)
    static member inline referrerPolicy (x:string) = unbox ("referrerPolicy", x)
    static member inline testID (x:string) = unbox ("testID", x)
    static member inline tintColor (x:string) = unbox ("tintColor", x)
    static member inline width (x:int) = unbox ("width", x)

    static member inline uriSource (x:string) = unbox ("source", {|uri = x|})
    [<Emit("require($0)")>]
    static member inline localImage (_path:string) : obj = jsNative 
    static member inline defaultSource (x:string) = unbox ("defaultSource", image.localImage x)
    static member inline source (x:string) = unbox ("source", image.localImage x)
    static member inline src (x:string) = unbox ("src", x)
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
    
    static member inline behavior (x:string) = unbox ("behavior", x)
    static member inline behavior (x:obj) = unbox ("behavior", x)
    static member inline enabled (x:bool) = unbox ("enabled", x)
    static member inline keyboardVerticalOffset (x:float) = unbox ("keyboardVerticalOffset", x)
    static member inline keyboardVerticalOffset (x:int) = unbox ("keyboardVerticalOffset", x)

[<Erase>]
type pressable =
    inherit Prop<IPressableProp>
    static member inline delayLongPress (x:float) = unbox ("delayLongPress", x)
    static member inline delayLongPress (x:int) = unbox ("delayLongPress", x)
    static member inline disabled (x:bool) = unbox ("disabled", x)
    static member inline hitSlop (x:Types.Rect) = unbox ("hitSlop", x)
    static member inline hitSlop (x:float) = unbox ("hitSlop", x)
    static member inline hitSlop (x:int) = unbox ("hitSlop", x)
    static member inline onLongPress (x:Types.PressEvent -> unit) = unbox ("onLongPress", x)
    static member inline onPress (x:Types.PressEvent -> unit) = unbox ("onPress", x)
    static member inline onPress (x:unit -> unit) = unbox ("onPress", x)
    static member inline onPressIn (x:Types.PressEvent -> unit) = unbox ("onPressIn", x)
    static member inline onPressOut (x:Types.PressEvent -> unit) = unbox ("onPressOut", x)
    static member inline pressRetentionOffset (x:Types.Rect) = unbox ("pressRetentionOffset", x)
    static member inline pressRetentionOffset (x:float) = unbox ("pressRetentionOffset", x)
    static member inline pressRetentionOffset (x:int) = unbox ("pressRetentionOffset", x)
    static member inline testOnlyPressed (x:bool) = unbox ("testOnly_pressed", x)
    static member inline unstablePressDelay (x:float) = unbox ("unstable_pressDelay", x)
    static member inline unstablePressDelay (x:int) = unbox ("unstable_pressDelay", x)
    

[<Erase>]
type safeAreaView =
    inherit Prop<ISafeAreaViewProp>
    static member inline emulateUnlessSupported (value:bool) = unbox ("emulateUnlessSupported", value)

[<Erase>]
type scrollView =
    inherit Prop<IScrollViewProp>
    static member inline alwaysBounceHorizontal (x:bool) = unbox ("alwaysBounceHorizontal", x)
    static member inline alwaysBounceVertical (x:bool) = unbox ("alwaysBounceVertical", x)
    static member inline automaticallyAdjustContentInsets (x:bool) = unbox ("automaticallyAdjustContentInsets", x)
    static member inline automaticallyAdjustKeyboardInsets (x:bool) = unbox ("automaticallyAdjustKeyboardInsets", x)
    static member inline automaticallyAdjustsScrollIndicatorInsets (x:bool) = unbox ("automaticallyAdjustsScrollIndicatorInsets", x)
    static member inline bounces (x:bool) = unbox ("bounces", x)
    static member inline bouncesZoom (x:bool) = unbox ("bouncesZoom", x)
    static member inline contentOffset (x:Types.Point) = unbox ("contentOffset", x)
    static member inline contentOffset (x:obj) = unbox ("contentOffset", x)
    static member inline decelerationRate (x:string) = unbox ("decelerationRate", x)
    static member inline disableIntervalMomentum (x:bool) = unbox ("disableIntervalMomentum", x)
    static member inline disableScrollViewPanResponder (x:bool) = unbox ("disableScrollViewPanResponder", x)
    static member inline horizontal (value:bool) = unbox ("horizontal", value)
    static member inline invertStickyHeaders (x:bool) = unbox ("invertStickyHeaders", x)
    static member inline keyboardDismissMode (x:string) = unbox ("keyboardDismissMode", x)
    static member inline keyboardShouldPersistTaps (x:string) = unbox ("keyboardShouldPersistTaps", x)
    static member inline onScroll (x:obj -> unit) = unbox ("onScroll", x)
    static member inline onScrollBeginDrag (x:obj -> unit) = unbox ("onScrollBeginDrag", x)
    static member inline onScrollEndDrag (x:obj -> unit) = unbox ("onScrollEndDrag", x)
    static member inline onScrollToTop (x:obj -> unit) = unbox ("onScrollToTop", x)
    static member inline overScrollMode (x:string) = unbox ("overScrollMode", x)
    static member inline pagingEnabled (x:bool) = unbox ("pagingEnabled", x)
    static member inline persistentScrollbar (x:bool) = unbox ("persistentScrollbar", x)
    static member inline pinchGestureEnabled (x:bool) = unbox ("pinchGestureEnabled", x)
    static member inline removeClippedSubviews (x:bool) = unbox ("removeClippedSubviews", x)
    static member inline scrollEnabled (x:bool) = unbox ("scrollEnabled", x)
    static member inline showsHorizontalScrollIndicator (x:bool) = unbox ("showsHorizontalScrollIndicator", x)
    static member inline showsVerticalScrollIndicator (x:bool) = unbox ("showsVerticalScrollIndicator", x)
    static member inline snapToEnd (x:bool) = unbox ("snapToEnd", x)
    static member inline snapToInterval (x:float) = unbox ("snapToInterval", x)
    static member inline snapToInterval (x:int) = unbox ("snapToInterval", x)
    static member inline snapToOffsets (x:int []) = unbox ("snapToOffsets", x)
    static member inline snapToOffsets (x:float []) = unbox ("snapToOffsets", x)
    static member inline snapToStart (x:bool) = unbox ("snapToStart", x)
    static member inline stickyHeaderHiddenOnScroll (x:bool) = unbox ("stickyHeaderHiddenOnScroll", x)
    static member inline stickyHeaderIndices (x:float []) = unbox ("stickyHeaderIndices", x)
    static member inline stickyHeaderIndices (x:int []) = unbox ("stickyHeaderIndices", x)



type TrackColor = {``false``:string; ``true``:string}

[<Erase>]
type switch =
    inherit Prop<ISwitchProp>
    static member inline disabled (x:bool) = unbox ("disabled", x)
    static member inline onChange (x:obj -> unit) = unbox ("onChange", x)
    static member inline onValueChange (x:bool -> unit) = unbox ("onValueChange", x)
    static member inline thumbColor (x:string) = unbox ("thumbColor", x)
    static member inline trackColor (x:TrackColor) = unbox ("trackColor", x)
    static member inline value (x:bool) = unbox ("value", x)
    static member inline value (x:string) = unbox ("value", x)

[<Erase>]
type text =
    inherit Prop<ITextProp>
    static member inline accessibilityHint (x:string) = unbox ("accessibilityHint", x)
    static member inline accessibilityLabel (x:string) = unbox ("accessibilityLabel", x)
    static member inline accessible (x:bool) = unbox ("accessible", x)
    static member inline adjustsFontSizeToFit (x:bool) = unbox ("adjustsFontSizeToFit", x)
    static member inline allowFontScaling (x:bool) = unbox ("allowFontScaling", x)
    static member inline ellipsizeMode (x:string) = unbox ("ellipsizeMode", x)
    static member inline maxFontSizeMultiplier (x:int) = unbox ("maxFontSizeMultiplier", x)
    static member inline maxFontSizeMultiplier (x:float) = unbox ("maxFontSizeMultiplier", x)
    static member inline minFontSizeMultiplier (x:int) = unbox ("minFontSizeMultiplier", x)
    static member inline minFontSizeMultiplier (x:float) = unbox ("minFontSizeMultiplier", x)
    static member inline nativeId (x:string) = unbox ("nativeID", x)
    static member inline numberOfLines (x:int) = unbox ("numberOfLines", x)
    static member inline onLayout (x:Types.LayoutEvent -> unit) = unbox ("onLayout", x)
    static member inline onLongPress (x:Types.PressEvent -> unit) = unbox ("onLongPress", x)
    static member inline onMoveShouldSetResponder (x:Types.PressEvent -> unit) = ("onMoveShouldSetResponder", x)
    static member inline onPress (x:Types.PressEvent -> unit) = unbox ("onPress", x)
    static member inline onPressIn (x:Types.PressEvent -> unit) = unbox ("onPressIn", x)
    static member inline onPressOut (x:Types.PressEvent -> unit) = unbox ("onPressOut", x)
    static member inline onResponderGrant (x:Types.PressEvent -> unit) = unbox ("onResponderGrant", x)
    static member inline onResponderGrant (x:obj -> unit) = unbox ("onResponderGrant", x)
    static member inline onResponderMove (x:Types.PressEvent -> unit) = unbox ("onResponderMove", x)
    static member inline selectable (x:bool) = unbox ("selectable", x)
    static member inline testID (x:string) = unbox ("testID", x)
    static member inline text (x:string) = unbox ("children", unbox (x))
    static member inline text (x:int) = unbox ("children", unbox(string x))
    static member inline userSelect (x:string) = unbox ("userSelect", x)

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
type view =
    inherit Prop<IViewProp>
    static member inline accessibilityElementsHidden (x:bool) = unbox ("accessibilityElementsHidden", x)
    static member inline accessibilityHint (x:string) = unbox ("accessibilityHint", x)
    static member inline accessibilityLanguage (x:string) = unbox ("accessibilityLanguage", x)
    static member inline accessibilityIgnoresInvertColors (x:bool) = unbox ("accessibilityIgnoresInvertColors", x)
    static member inline accessibilityLabel (x:string) = unbox ("accessibilityLabel", x)
    static member inline accessible (x:bool) = unbox ("accessible", x)
    static member inline ariaBusy (x:bool) = unbox ("aria-busy", x)
    static member inline ariaChecked (x:bool) = unbox ("aria-checked", x)
    static member inline ariaDisabled (x:bool) = unbox ("aria-disabled", x)
    static member inline ariaLabel (x:string) = unbox ("aria-label", x)
    static member inline ariaLabelledBy (x:string) = unbox ("aria-labelledby", x)
    static member inline nativeID (x:string) = unbox ("nativeID", x)
    static member inline needsOffscreenAlphaCompositing (x:string) = unbox ("needsOffscreenAlphaCompositing", x)
    static member inline onAccessibilityAction (x:obj -> unit) = unbox ("onAccessibilityAction", x)
    static member inline onAccessibilityTap (x:obj -> unit) = unbox ("onAccessibilityTap", x)
    static member inline onLayout (x:obj -> unit) = unbox ("onLayout", x)
    static member inline onLayout (x:Types.LayoutEvent -> unit) = unbox ("onLayout", x)
    static member inline onMoveShouldSetResponder (x:Types.PressEvent -> bool) = unbox ("onMoveShouldSetResponder", x)
    static member inline onMoveShouldSetResponder (x:obj -> bool) = unbox ("onMoveShouldSetResponder", x)
    static member inline onMoveShouldSetResponderCapture (x:Types.PressEvent -> bool) = unbox ("onMoveShouldSetResponderCapture", x)
    static member inline onMoveShouldSetResponderCapture (x:obj -> bool) = unbox ("onMoveShouldSetResponderCapture", x)
    static member inline onResponderGrant (x:Types.PressEvent -> unit) = unbox ("onResponderGrant", x)
    static member inline onResponderGrant (x:obj -> unit) = unbox ("onResponderGrant", x)
    static member inline onResponderMove (x:Types.PressEvent -> unit) = unbox ("onResponderMove", x)
    static member inline onResponderReject (x:Types.PressEvent -> unit) = unbox ("onResponderReject", x)
    static member inline onResponderRelease (x:Types.PressEvent -> unit) = unbox ("onResponderRelease", x)
    static member inline onResponderTerminate (x:Types.PressEvent -> unit) = unbox ("onResponderTerminate", x)
    static member inline onResponderTerminationRequest (x:Types.PressEvent -> unit) = unbox ("onResponderTerminationRequest", x)
    static member inline onStartShouldSetResponder (x:Types.PressEvent -> bool) = unbox ("onStartShouldSetResponder", x)
    static member inline onStartShouldSetResponderCapture (x:Types.PressEvent -> bool) = unbox ("onStartShouldSetResponderCapture", x)
    static member inline removeClippedSubviews (x:bool) = unbox ("removeClippedSubviews", x)
    static member inline testID (x:string) = unbox ("testID", x)
    static member inline source (value : {|uri : string|}) = unbox ("source", value)