namespace UnitTests.Tests

open NUnit.Framework
open FsUnit

    

[<TestFixture>] 
type ``Given List function`` ()=


    [<Test>] member test.
     `` Cons`` ()=
            List.Cons (1, [2;3;4;5]) |> should equal [1;2;3;4;5]

    [<Test>] member test.
     `` append`` ()=
            List.append [1;2;3] [4;5;6] |> should equal [1;2;3;4;5;6]

    [<Test>] member test.
     `` average`` ()=
            List.average [3m;4m;5m]|> should equal 4

    [<Test>] member test.
     `` averageBy`` ()=
            List.averageBy (fun x -> x*2m)  [1.5m;2m;2.5m]|> should equal 4

    [<Test>] member test.
     `` choose`` ()=(
            let chooseFun x =
                match x with
                | a  when a%2=0 -> Some(2*a)
                | _ -> None
            List.choose chooseFun [1;2;3;4]|> should equal [4;8])

    [<Test>] member test.
     `` collect`` ()=
        List.collect (fun x -> [x;x*2]) [1;2;3] |> should equal [1;2;2;4;3;6]

    [<Test>] member test.
     `` concat`` ()=(
        let seq1 = seq {for i in 1..2 -> [1;2;3]}        
        List.concat seq1 |> should equal [1;2;3;1;2;3])

    [<Test>] member test.
     `` exists`` ()=(
        List.exists (fun x-> x=3) [1;2;3] |> should equal true
        List.exists (fun x-> x=4) [1;2;3] |> should equal false)

    [<Test>] member test.
     `` exists2`` ()=(
        List.exists2 (fun x y -> x*y = 6) [1;2;3] [6;2;6] |> should equal true
        List.exists2 (fun x y -> x*y = 6) [1;2;3] [4;2;6] |> should equal false)

    [<Test>] member test.
     ``filter`` ()=
        List.filter (fun x -> x%3 = 0) [0..9] |> should equal [0;3;6;9]
        
    [<Test>] member test.
        find ()=(
            List.find (fun x-> x%3=0) [1;2;3;4;5;6] |> should equal 3
            (fun () -> (List.find (fun x-> x%3=0) [1;2;] |> ignore )) |> should throw typeof<System.Collections.Generic.KeyNotFoundException>)

    [<Test>] member test.
        findIndex ()=(
            List.findIndex (fun x-> x%3=0) [1;1;1;2;3;4;5;6] |> should equal 4
            (fun () -> (List.find (fun x-> x%3=0) [1;2;] |> ignore )) |> should throw typeof<System.Collections.Generic.KeyNotFoundException>)

    [<Test>] member test.
        fold ()=
            List.fold (fun state i-> state + i.ToString()) "Hello " [1;2;3;4;5;6;] |> should equal "Hello 123456"
      
    [<Test>] member test.
        fold2 ()=
            List.fold2 (fun state id i -> state + " " + id + "=" + i.ToString()) "Hello" ["Alpha";"Tango";"Charlie"] [1;2;3;] |> should equal "Hello Alpha=1 Tango=2 Charlie=3"

    [<Test>] member test.
        foldBack ()=
            List.foldBack (fun i state-> state + i.ToString()) [1;2;3;4;5;6;] "Hello "  |> should equal "Hello 654321"

    [<Test>] member test.
        foldBack2 ()=
            List.foldBack2 (fun id i state -> state + " " + id + "=" + i.ToString()) ["Alpha";"Tango";"Charlie"] [1;2;3;] "Hello" |> should equal "Hello Charlie=3 Tango=2 Alpha=1"

    [<Test>] member test.
        forall ()=(
            List.forall (fun i -> i%3=0) [0;3;6] |> should equal true
            List.forall (fun i -> i%3=0) [0;1;3;6] |> should equal false)

    [<Test>] member test.
        forall2 ()=(
            List.forall2 (fun i j -> (i*j)%3=0) [0;3;6] [0;1;2] |> should equal true
            List.forall2 (fun i j -> (i*j)%3=0) [1;1;6] [3;1;2] |> should equal false)
    
    [<Test>] member test.
        head ()=(
            List.head [17;3;6]  |> should equal 17
            (fun () -> List.head [] |>ignore)  |> should throw typeof<System.ArgumentException>)

    [<Test>] member test.
        init ()=
            List.init 5 (fun x -> x*5) |> should equal [0;5;10;15;20;]
    
    [<Test>] member test.
        isEmpty ()=(
            List.isEmpty [] |> should equal true
            List.isEmpty [1] |> should equal false)

    [<Test>] member test.
        length ()=(
            List.length [] |> should equal 0
            List.length [1] |> should equal 1)

    [<Test>] member test.
        map ()=
            List.map (fun i -> i.ToString ()) [1;2;3] |> should equal ["1";"2";"3"]
    
    [<Test>] member test.
        map2 ()=
            List.map2 (fun i j -> (i * j ).ToString ()) [1;2;3] [4;5;6] |> should equal ["4";"10";"18"]

    [<Test>] member test.
        mapi ()=
            List.mapi (fun i j -> (i * j ).ToString ()) [1;2;3] |> should equal ["0";"2";"6"]

    [<Test>] member test.
        max ()=
            List.max [1;2;3] |> should equal 3

    [<Test>] member test.
        maxBy ()=
            List.maxBy (fun x -> 1m/(decimal x))  [1;2;3] |> should equal 1

    [<Test>] member test.
        min ()=
            List.min [1;2;3] |> should equal 1

    [<Test>] member test.
        minBy ()=
            List.minBy (fun x -> 1m / (decimal x))  [1;2;3] |> should equal 3

    [<Test>] member test.
        nth ()=(
            List.nth [1;2;3] 2 |> should equal 3       
            (fun () -> List.nth [1;2;3] 3 |> should equal 3 |> ignore) |> should throw typeof<System.ArgumentException>)

    [<Test>] member test.
        ofSeq ()=
            List.ofSeq(seq{for i in 0..2 -> i}) |> should equal [0;1;2]

    [<Test>] member test.
        partition ()=
            List.partition (fun x -> x%2=0) [0;1;2;3;4]  |> should equal ([0;2;4],[1;3])

    [<Test>] member test.
        permute ()=(
            let permute numberOfElement i = (numberOfElement-1) - i
            let permutelistwith3 = permute 4
            List.permute permutelistwith3 [0;1;2;3] |> should equal [3;2;1;0])

    [<Test>] member test.
        pick ()=(
            let pickFun x =
                match x with
                | a  when a%2=0 -> Some(2*a)
                | _ -> None
            List.pick pickFun [1;2;3] |> should equal 4)

    [<Test>] member test.
        reduce ()=
            List.reduce (fun state i-> state + i) ["1";"2";"3";"4";"5";"6";] |> should equal "123456"
        
    [<Test>] member test.
        reduceBack ()=
            List.reduceBack (fun i state-> state + i) ["1";"2";"3";"4";"5";"6";] |> should equal "654321"

    [<Test>] member test.
        replicate ()=
            List.replicate 3 "1" |> should equal ["1";"1";"1";]

    [<Test>] member test.
        rev ()=
            List.rev [0;1;2] |> should equal [2;1;0;]

    [<Test>] member test.
        scan ()=
            List.scan (fun state i-> state + i.ToString()) "Hello " [1;2;] |> should equal ["Hello ";"Hello 1";"Hello 12"]

    [<Test>] member test.
        scanBack ()=
            List.scanBack (fun i state-> state + i.ToString()) [1;2;] "Hello " |> should equal ["Hello 21";"Hello 2";"Hello "]

    [<Test>] member test.
        sort ()=
            List.sort [3;1;0] |> should equal [0;1;3]