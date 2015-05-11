// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

namespace Microsoft.FSharp.Collections

open System
open System.Runtime.CompilerServices
open System.Collections

module IEnumerableExtensions = 
    type System.Collections.IEnumerable with 
        member this.sortWithValue (first:'T * int) (second:'T * int) = 
            (snd first, snd second)
            |> fun (x, y) ->
                match x <> y with
                | true when x > y -> 1
                | true  -> -1
                | false -> 0

        member this.shuffle (input:'T list) = 
            let random = new Random()
            this.shuffle (input, random)

        member this.shuffle ((input:'T list), (seed:int)) =
            let random = new Random(seed)
            this.shuffle (input, random)

        member this.shuffle ((input:'T list), (rand:Random)) = 
            input 
            |> List.map (fun x -> x, rand.Next())
            |> List.sortWith this.sortWithValue
            |> List.map (fun (x, y) -> x)

//
//[<EntryPoint>]
//let main argv = 
//    printfn "%A" argv
//    0 // return an integer exit code
//
//    // things to test
//    // different seeds shuffle differently
//    // same seeds shuffle the same
//    // sorting works properly
