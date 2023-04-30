namespace Feliz.Native


open Fable.React
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type Native =
    static member inline view (props: seq<IViewProp>) =
        Feliz.Interop.reactApi.createElement (import "View" "react-native", createObj !!props)
        
    static member inline view (x:#seq<ReactElement>) =
        Feliz.Interop.reactApi.createElement (import "View" "react-native", (createObj [ "children" ==> Feliz.Interop.reactApi.Children.toArray (Array.ofSeq x) ]))
        
    static member inline safeAreaView (props: seq<ISafeAreaViewProp>) =
        Feliz.Interop.reactApi.createElement (import "SafeAreaView" "react-native", createObj !!props)
    
    static member inline keyboardAvoidingView (props: seq<IKeyboardAvoidingViewProp>) =
        Feliz.Interop.reactApi.createElement (import "KeyboardAvoidingView" "react-native", (createObj !!props))

    static member inline stylesheet : obj = (import "StyleSheet" "react-native")
    
    static member inline scrollView (props: seq<IScrollViewProp>) =
        Feliz.Interop.reactApi.createElement (import "ScrollView" "react-native", createObj !!props)
    
    static member inline text (props:seq<ITextProp>) =
        Feliz.Interop.reactApi.createElement (import "Text" "react-native", createObj !!props)
        
    static member inline rawText (x:string) = unbox x

    static member inline touchableHighlight (props:seq<ITouchableHighlightProp>) =
        Feliz.Interop.reactApi.createElement (import "TouchableHighlight" "react-native", createObj !!props)
    
    static member inline touchableOpacity (props:seq<ITouchableOpacityProp>) =
        Feliz.Interop.reactApi.createElement (import "TouchableOpacity" "react-native", createObj !!props)
    
    static member inline textInput (props:seq<ITextInputProp>) =
        Feliz.Interop.reactApi.createElement (import "TextInput" "react-native", createObj !!props)
    
    static member inline pressable (props:seq<IPressableProp>) =
        Feliz.Interop.reactApi.createElement (import "Pressable" "react-native", createObj !!props)

    static member inline image (props:seq<IImageProp>) =
        Feliz.Interop.reactApi.createElement (import "Image" "react-native", createObj !!props)
    
    static member inline imageBackground (props:seq<IImageBackgroundProp>) =
        Feliz.Interop.reactApi.createElement (import "ImageBackground" "react-native", createObj !!props)
    
    static member inline activityIndicator (props:seq<IActivityIndicatorProp>) =
        Feliz.Interop.reactApi.createElement (import "ActivityIndicator" "react-native", createObj !!props)
    
    static member inline switch (props:seq<ISwitchProp>) =
        Feliz.Interop.reactApi.createElement (import "Switch" "react-native", createObj !!props)

module Alert =
    type IAlert =
        abstract ``alert`` : (string * string) -> unit
    
    let Alert : IAlert = import "Alert" "react-native"

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

module AppState =
    type IEventSubscription =
        abstract ``remove`` : unit -> unit

    type IAppState =
        abstract ``currentState`` : string option with get, set
        abstract ``addEventListener`` : string * (string -> unit) -> IEventSubscription

    let AppState : IAppState = import "AppState" "react-native"

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

module Keyboard =
    type IKeyboard = 
        abstract ``dismiss`` : unit -> unit
        abstract ``isVisible`` : unit -> bool

    let Keyboard : IKeyboard = import "Keyboard" "react-native"

module Linking =

    type ILinking =
        abstract member ``canOpenURL`` : string -> JS.Promise<bool>
        abstract member ``getInitialURL`` : unit -> JS.Promise<string option>
        abstract member ``openSettings`` : unit -> unit
        abstract member ``openURL``<'a> : string -> JS.Promise<'a>

    let Linking : ILinking = import "Linking" "react-native"

module PanResponder =
    type IPanResponder =
        [<Emit("Object.entries($0.panHandlers)")>]
        abstract member panHandlers : IViewProp seq

    type IPanResponderStatic =
        abstract ``create`` : obj -> IPanResponder

    let PanResponder : IPanResponderStatic = import "PanResponder" "react-native"

module PermissionsAndroid =

    module Permissions =
        [<Literal>]
        let READ_CALENDAR = "android.permission.READ_CALENDAR"
        [<Literal>]
        let WRITE_CALENDAR = "android.permission.WRITE_CALENDAR"
        [<Literal>]
        let CAMERA = "android.permission.CAMERA"
        [<Literal>]
        let READ_CONTACTS = "android.permission.READ_CONTACTS"
        [<Literal>]
        let WRITE_CONTACTS = "android.permission.WRITE_CONTACTS"
        [<Literal>]
        let GET_ACCOUNTS = "android.permission.GET_ACCOUNTS"
        [<Literal>]
        let ACCESS_FINE_LOCATION = "android.permission.ACCESS_FINE_LOCATION"
        [<Literal>]
        let ACCESS_COARSE_LOCATION = "android.permission.ACCESS_COARSE_LOCATION"
        [<Literal>]
        let ACCESS_BACKGROUND_LOCATION = "android.permission.ACCESS_BACKGROUND_LOCATION"
        [<Literal>]
        let RECORD_AUDIO = "android.permission.RECORD_AUDIO"
        [<Literal>]
        let READ_PHONE_STATE = "android.permission.READ_PHONE_STATE"
        [<Literal>]
        let READ_EXTERNAL_STORAGE = "android.permission.READ_EXTERNAL_STORAGE"
        [<Literal>]
        let WRITE_EXTERNAL_STORAGE = "android.permission.WRITE_EXTERNAL_STORAGE"
        [<Literal>]
        let POST_NOTIFICATIONS = "android.permission.POST_NOTIFICATIONS"
        [<Literal>]
        let NEARBY_WIFI_DEVICES = "android.permission.NEARBY_WIFI_DEVICES"
    
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

module Platform =
    type IPlatform =
        abstract ``select``<'a> : obj -> 'a
    
    let Platform : IPlatform = import "Platform" "react-native"