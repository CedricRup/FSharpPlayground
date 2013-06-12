module FooBarQix
open System

let toMeta x =
    match x with
    | 3 -> Some "Foo"
    | 5 -> Some "Bar"
    | 7 -> Some "Qix"
    | _ -> None

let ifDivisibleTransformDivisorToMeta toTest divisor =
    if ( toTest % divisor = 0) then toMeta (divisor) else None 

let toFooBarQixByDivisorRule x = List.map (ifDivisibleTransformDivisorToMeta x) [3;5;7]

let toFooBarQixByDigitRule (x:int) = x.ToString () |>  List.ofSeq  |> List.map (fun x -> int(Char.GetNumericValue x)) |> List.map toMeta 
       
let foobarqix x = 
    let transfo = List.append (toFooBarQixByDivisorRule x) (toFooBarQixByDigitRule x) |> List.choose id 
    if List.isEmpty transfo then x.ToString () else String.Concat (transfo)