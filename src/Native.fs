namespace Feliz.Native


open Fable.React
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type Native =
    static member inline view (props: seq<IViewProp>) =
        let x =  Feliz.Interop.reactApi.createElement (import "View" "react-native", createObj !!props)
        //Fable.Core.JS.console.log x
        x
    static member inline view (x:#seq<ReactElement>) =
        let x =  Feliz.Interop.reactApi.createElement (import "View" "react-native", (createObj [ "children" ==> Feliz.Interop.reactApi.Children.toArray (Array.ofSeq x) ]))
        //Fable.Core.JS.console.log x
        x
    static member inline safeAreaView (props: seq<ISafeAreaViewProp>) =
        let x =  Feliz.Interop.reactApi.createElement (import "SafeAreaView" "react-native", createObj !!props)
        //Fable.Core.JS.console.log x
        x
    
    static member inline keyboardAvoidingView (props: seq<IKeyboardAvoidingViewProp>) =
        let x = Feliz.Interop.reactApi.createElement (import "KeyboardAvoidingView" "react-native", (createObj !!props))
        Fable.Core.JS.console.log x
        x

    static member inline stylesheet : obj = (import "StyleSheet" "react-native")
    
    static member inline scrollView (props: seq<IScrollViewProp>) =
        let x =  Feliz.Interop.reactApi.createElement (import "ScrollView" "react-native", createObj !!props)
        //Fable.Core.JS.console.log x
        x
    
    static member inline text (props:seq<ITextProp>) =
        let x =  Feliz.Interop.reactApi.createElement (import "Text" "react-native", createObj !!props)
        //Fable.Core.JS.console.log x
        x
    static member inline rawText (x:string) = unbox x

    static member inline touchableHighlight (props:seq<ITouchableHighlightProp>) =
        let x =  Feliz.Interop.reactApi.createElement (import "TouchableHighlight" "react-native", createObj !!props)
        //Fable.Core.JS.console.log x
        x
    
    static member inline touchableOpacity (props:seq<ITouchableOpacityProp>) =
        let x =  Feliz.Interop.reactApi.createElement (import "TouchableOpacity" "react-native", createObj !!props)
        //Fable.Core.JS.console.log x
        x
    
    static member inline textInput (props:seq<ITextInputProp>) =
        let x =  Feliz.Interop.reactApi.createElement (import "TextInput" "react-native", createObj !!props)
        Fable.Core.JS.console.log x
        x
    
    static member inline pressable (props:seq<IPressableProp>) =
        let x =  Feliz.Interop.reactApi.createElement (import "Pressable" "react-native", createObj !!props)
        //Fable.Core.JS.console.log x
        x

    static member inline image (props:seq<IImageProp>) =
        let x =  Feliz.Interop.reactApi.createElement (import "Image" "react-native", createObj !!props)
        //Fable.Core.JS.console.log x
        x
    
    static member inline imageBackground (props:seq<IImageBackgroundProp>) =
        let x =  Feliz.Interop.reactApi.createElement (import "ImageBackground" "react-native", createObj !!props)
        //Fable.Core.JS.console.log x
        x
    
    static member inline activityIndicator (props:seq<IActivityIndicatorProp>) =
        let x =  Feliz.Interop.reactApi.createElement (import "ActivityIndicator" "react-native", createObj !!props)
        //Fable.Core.JS.console.log x
        x
    
    static member inline switch (props:seq<ISwitchProp>) =
        let x = Feliz.Interop.reactApi.createElement (import "Switch" "react-native", createObj !!props)
        //Fable.Core.JS.console.log x
        x

module Keyboard =
    type IKeyboard = 
        abstract ``dismiss``    : unit -> unit

    let Keyboard : IKeyboard = import "Keyboard" "react-native"

module Platform =
    type IPlatform =
        abstract ``select``<'a> : obj -> 'a
    
    let Platform : IPlatform = import "Platform" "react-native"

module Alert =
    type IAlert =
        abstract ``alert`` : (string * string) -> unit
    
    let Alert : IAlert = import "Alert" "react-native"

module Dimensions =
    type DimensionsInfo = {
        ``fontScale`` : int 
        ``height`` : int
        ``scale`` : int
        ``width`` : int
    }

    let useWindowDimensions : unit -> DimensionsInfo = import "useWindowDimensions" "react-native"

    type IDimensions =
        abstract ``get`` : string -> DimensionsInfo
    
    let Dimensions : IDimensions = import "Dimensions" "react-native"


module Animated =

    type IValueXY =
        abstract x : int
        abstract y : int

        abstract member setOffset : int * int -> unit
        abstract member setOffset : obj -> unit
        abstract member flattenOffset : unit -> unit

    type IAnimated =
        [<Emit("new $0.ValueXY")>]
        abstract ValueXY : unit -> IValueXY
    
    let Animated : IAnimated = import "Animated" "react-native"

module PanResponder =
    type IPanResponder =
        //[<AbstractClass; Erase>]
        [<Emit("Object.entries($0.panHandlers)")>]
        abstract member panHandlers : IViewProp seq

    type IPanResponderStatic =
        abstract ``create`` : obj -> IPanResponder

    let PanResponder : IPanResponderStatic = import "PanResponder" "react-native"

module AppState =
    type IEventSubscription =
        abstract ``remove`` : unit -> unit
        

    type IAppState =
        abstract ``currentState`` : string option with get, set
        abstract ``addEventListener`` : string * (string -> unit) -> IEventSubscription

    let AppState : IAppState = import "AppState" "react-native"

module Linking =

    type ILinking =
        abstract member ``openSettings`` : unit -> unit

    let Linking : ILinking = import "Linking" "react-native"

module PermissionsAndroid =

    module Permissions =
        [<Literal>]
        let POST_NOTIFICATIONS = "POST_NOTIFICATIONS"
    
    module Results =
        [<Literal>]
        let GRANTED = "granted"

        [<Literal>]
        let DENIED = "denied"

        [<Literal>]
        let NEVER_ASK_AGAIN = "never_ask_again"

    type IPermissionsAndroid =
        abstract member check : string -> JS.Promise<bool>
        abstract member request : string * obj -> JS.Promise<string>
        abstract member request : string -> JS.Promise<string>
    
    let PermissionsAndroid : IPermissionsAndroid = import "PermissionsAndroid" "react-native"
