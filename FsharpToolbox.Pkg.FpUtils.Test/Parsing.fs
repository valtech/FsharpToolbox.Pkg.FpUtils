module FsharpToolbox.Pkg.FpUtils.Test.Parsing

open NUnit.Framework
open FsharpToolbox.Pkg.FpUtils.Parsing

[<TestFixture>]
type ParsingTest () =
  member _.``Parse true bool`` =
    // Arrange
    let input = "true"
    // Act
    let result = input |> Boolean.parseOption
    // Assert
    match result with
    | Some result -> Assert.IsTrue(result)
    | None -> failwith "Should be able to parse bool"

  member _.``Parse false bool`` =
    // Arrange
    let input = "false"
    // Act
    let result = input |> Boolean.parseOption
    // Assert
    match result with
    | Some result -> Assert.IsFalse(result)
    | None -> failwith "Should be able to parse bool"

  member _.``Parse int`` =
    // Arrange
    let input = "1"
    // Act
    let result = input |> Int.parseOption
    // Assert
    match result with
    | Some (_ : int) -> Assert.Pass()
    | _ -> failwith "Should only run on Ok track"

  member _.``Parse int64`` =
    // Arrange
    let input = "1"
    // Act
    let result = input |> Int64.parseOption
    // Assert
    match result with
    | Some (_ : int64) -> Assert.Pass()
    | _ -> failwith "Should only run on Ok track"
