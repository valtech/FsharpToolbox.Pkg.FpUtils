module FsharpToolbox.Pkg.FpUtils.Test.AsyncResult


open System.Threading.Tasks
open NUnit.Framework
open FsharpToolbox.Pkg.FpUtils

[<TestFixture>]
type AsyncResultTest () =

  [<Test>]
  member _.``Use AsyncResult.map`` () =
    // Arrange
    let input = async { return Ok 1 }
    // Act
    let result =
      input
      |> AsyncResult.map (fun x -> x + 2)

    // Assert
    match result |> Async.RunSynchronously with
    | Ok result -> Assert.AreEqual(result, 3)
    | Error _ -> failwith "Should only run on Ok track"

  [<Test>]
  member _.``Use AsyncResult.map operator`` () =
    // Arrange
    let input = async { return Ok 1 }
    // Act
    let result =
      input
      %|>> (fun x -> x + 2)
      %|>> (fun x -> x)

    // Assert
    match result |> Async.RunSynchronously with
    | Ok result -> Assert.AreEqual(result, 3)
    | Error _ -> failwith "Should only run on Ok track"

  [<Test>]
  member _.``Use AsyncResult.bind`` () =
    // Arrange
    let input = async { return Ok 1 }
    // Act
    let result =
      input
      %>>= fun x -> async { return Ok <| x + 2}

    // Assert
    match result |> Async.RunSynchronously with
    | Ok result -> Assert.AreEqual(result, 3)
    | Error _ -> failwith "Should only run on Ok track"

  [<Test>]
  member _.``Use asyncResult computational expression`` () =
    // Arrange
    let testFunction (a : Async<Result<int, _>>) =
      asyncResult {
        let! a = a
        let b = 2 + a
        return {| a = a; b = b |}
      }
    // Act
    let result = testFunction (async { return (Ok 2) })
    // Assert
    match result |> Async.RunSynchronously with
    | Ok data -> Assert.AreEqual(data.a, 2); Assert.AreEqual(data.b, 4)
    | Error _ -> failwith "Should not leave Ok track"
