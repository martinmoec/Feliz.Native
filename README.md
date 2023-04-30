# Feliz.Native

F# binding for writing React Native apps with [Fable](https://github.com/fable-compiler/Fable), based on [Feliz](https://github.com/Zaid-Ajaj/Feliz).


Currently in a prerelease status at Nuget. Updated as I'm using components in own apps, but feel free to provide a pull request.

## Usage and syntax

```dotnet add package Feliz.Native --version 0.0.2-alpha```

```fsharp
open Feliz
open Feliz.Native

[<ReactComponent>]
let Render () =
    let counter, updateCounter = React.useState 0
    Native.safeAreaView [
        safeAreaView.style [
            style.backgroundColor "#f1f1f1"
        ]
        safeAreaView.children [
            Native.text [text.text "Hello world"]

            // show counter
            Native.text [
                text.children [
                    Native.rawText "Counter:"
                    Native.text [
                        text.style [
                            style.fontSize (length.dip 25)
                            style.color.red
                        ]
                        text.text counter
                    ]
                ]
            ]

            // flex view for buttons
            Native.view [
                view.style [
                    style.flexDirection.row
                    style.alignItems.center
                ]
                view.children [
                    // increment button
                    Native.touchableOpacity [
                        touchableOpacity.onPress (fun () ->
                            counter + 1 |> updateCounter
                        )
                        touchableOpacity.children (
                            Native.text [text.text "+"]
                        )
                    ]

                    // decrement button
                    Native.touchableOpacity [
                        touchableOpacity.style [
                            style.marginLeft (length.dip 10)
                        ]
                        touchableOpacity.onPress (fun () ->
                            counter - 1 |> updateCounter
                        )
                        touchableOpacity.children (
                            Native.text [text.text "+"]
                        )
                    ]
                ]
            ]
        ]
    ]


Helpers.registerApp "DemoApp" (Render ())
```


See the [Fable React Native how-to](https://github.com/martinmoec/fable-react-native-how-to) for an example React Native app with F# and Fable.

## Notes

As these bindings are based upon Feliz and `prop`-layout, using the default value (not providing a `length`) for pixel based props will cause an error, as Feliz adds `px`. Use `lenght.dip` for density independent pixels.

```fsharp
style.fontSize 15 // error, will parse as 15px
style.fontSize (length.dip 15) // ok

style.width 200 // error, will parse as 200px
style.width (length.dip 200) // ok
style.width (length.percent 50) // ok
```