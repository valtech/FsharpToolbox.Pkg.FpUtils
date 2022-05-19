module FsharpToolbox.Pkg.FpUtils.Test.Option

open NUnit.Framework
open FsharpToolbox.Pkg.FpUtils

[<TestFixture>]
type OptionTest () =

  [<Test>]
  member _.``Use Option.ToResult`` () =
    // Arrange
    let input = Some "body"
    // Act
    let result = Option.ToResult "once told me" input
    // Assert
    match result with
    | Ok result -> Assert.AreEqual("body", result)
    | Error _ -> failwith "Should only run on Ok track"

  [<Test>]
  member _.``Use Option.ToResult with a None input`` () =
    // Arrange
    let input = None
    // Act
    let result = Option.ToResult "once told me" input
    // Assert
    match result with
    | Ok _ -> failwith "Should only run on Error track"
    | Error e -> Assert.AreEqual("once told me", e)

  [<Test>]
  member _.``Use Option.MapToResult`` () =
    // Arrange
    let input = Some "body"
    let f = fun x -> Ok (x + " once told me")
    // Act
    let result = Option.MapToResult f input
    // Assert
    match result with
    | Ok str -> Assert.AreEqual(Some "body once told me", str)
    | Error e -> failwith "Should only run on Error track"

  [<Test>]
  member _.``Use Option.MapToResult with a None input`` () =
    // Arrange
    let input = None
    let f = fun x -> Ok (x + " once told me")
    // Act
    let result = Option.MapToResult f input
    // Assert
    match result with
    | Ok strOpt -> Assert.AreEqual(None, strOpt)
    | Error e -> failwith "Should only run on Error track"

  [<Test>]
  member _.``Use Option.MapToResult with a failing function`` () =
    // Arrange
    let input = Some "body"
    let f = fun x -> Error "once told me"
    // Act
    let result = Option.MapToResult f input
    // Assert
    match result with
    | Ok strOpt -> failwith "Should only run on Error track"
    | Error e -> Assert.AreEqual("once told me", e)

  [<Test>]
  member _.``Use Option.ToResultOption with None should return Ok None`` () =
    // Arrange
    let input = None
    // Act
    let result = Option.ToResultOption input
    // Assert
    match result with
    | Ok None -> Assert.Pass ()
    | Ok (Some _) -> Assert.Fail "Should return Ok None"
    | Error _ -> Assert.Fail "Should return Ok None"

  [<Test>]
  member _.``Use Option.ToResultOption with option result ok should return Ok (Some v)`` () =
    // Arrange
    let input = Some (Ok "success")
    // Act
    let result = Option.ToResultOption input
    // Assert
    match result with
    | Ok None -> Assert.Fail "Should return Ok (Some v)"
    | Ok (Some _) -> Assert.Pass ()
    | Error _ -> Assert.Fail "Should return Ok (Some v)"

  [<Test>]
  member _.``Use Option.ToResultOption with option result error should return Error`` () =
    // Arrange
    let input = Some (Error "fail")
    // Act
    let result = Option.ToResultOption input
    // Assert
    match result with
    | Ok None -> Assert.Fail "Should return Error e"
    | Ok (Some _) -> Assert.Fail "Should return Error e"
    | Error v -> Assert.Pass ()
