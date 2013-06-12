module FooBarQixTest

open System
open NUnit.Framework
open FsUnit
open FooBarQix

[<TestFixture>]
type ``Given a foobarqix`` ()=
    
    [<Test>] member test.
     ``List is 1 result 1`` ()=
            foobarqix 1 |> should equal "1"
 
    [<Test>] member test.
     ``List is 6 result Foo`` ()=
            foobarqix 6 |> should equal "Foo"
                       
    [<Test>] member test.
     ``List is 10 result Bar`` ()=
            foobarqix 10 |> should equal "Bar"
                         
    [<Test>] member test.
     ``List is 21 result FooQix`` ()=
            foobarqix 21 |> should equal "FooQix"
                        
    [<Test>] member test.
     ``List is 35 result BarQix`` ()=
            foobarqix 35 |> should equal "BarQixFooBar"
            
    [<Test>] member test.
     ``List is 15 result FooBarBar`` ()=
            foobarqix 15 |> should equal "FooBarBar"
            
    [<Test>] member test.
     ``List is 33 result FooFooFoo`` ()=
            foobarqix 33 |> should equal "FooFooFoo"


     [<Test>] member test.
     ``all`` ()=
           List.iter (fun x -> Console.WriteLine (foobarqix x)) [1..100]