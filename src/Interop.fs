namespace Feliz.Native

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Feliz.ReactApi

/// Describes an element property
type IReactProperty = interface end

/// Describes style attribute
type IStyleAttribute = interface end

/// Describes an SVG attribute
type ISvgAttribute = interface end 

type ReactElement = Fable.React.ReactElement
type IRefValue<'T> = Fable.React.IRefValue<'T>
