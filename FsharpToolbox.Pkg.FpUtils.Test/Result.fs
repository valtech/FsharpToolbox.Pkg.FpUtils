module FsharpToolbox.Pkg.FpUtils.Test.Result

open NUnit.Framework
open FsharpToolbox.Pkg.FpUtils

[<TestFixture>]
type ResultTest () =

  [<Test>]
  member _.``Use Result.map`` () =
    // Arrange
    let input = Ok 1
    // Act
    let result =
      input
      |>> fun x -> x + 2
    // Assert
    match result with
    | Ok result -> Assert.AreEqual(result, 3)
    | Error _ -> failwith "Should only run on Ok track"

  [<Test>]
  member _.``Use Result.mapError on Ok-track, nothing happens`` () =
    // Arrange
    let input = Ok 1
    // Act
    let result =
      input
      |>! fun x -> Error <| x + 2
    // Assert
    match result with
    | Ok result -> Assert.AreEqual(result, 1)
    | Error _ -> failwith "Should only run on Ok track"

  [<Test>]
  member _.``Use Result.bind`` () =
    // Arrange
    let input = Ok 1
    // Act
    let result =
      input
      >>= fun x -> Ok <| x + 2
    // Assert
    match result with
    | Ok result -> Assert.AreEqual(result, 3)
    | Error _ -> failwith "Should only run on Ok track"

  [<Test>]
  member _.``Use Result.bind to get from Ok to Error track`` () =
    // Arrange
    let input = Ok 1
    // Act
    let result =
      input
      >>= fun x -> Error x
    // Assert
    match result with
    | Ok _ -> failwith "Should move to Ok track"
    | Error _ -> Assert.Pass()

  [<Test>]
  member _.``Use Result.bindError`` () =
    // Arrange
    let input = Error 1
    // Act
    let result =
      input
      >>! fun x -> Error <| x + 2
    // Assert
    match result with
    | Error result -> Assert.AreEqual(result, 3)
    | Ok _ -> failwith "Should move to Ok track"


  [<Test>]
  member _.``Use monad computational expression`` () =
    // Arrange
    let testFunction a =
      result {
        let! a = a
        let b = 2 + a
        return {| a = a; b = b |}
      }
    // Act
    let result = testFunction (Ok 2)
    // Assert
    match result with
    | Ok data -> Assert.AreEqual(data.a, 2); Assert.AreEqual(data.b, 4)
    | Error _ -> failwith "Should not leave Ok track"

