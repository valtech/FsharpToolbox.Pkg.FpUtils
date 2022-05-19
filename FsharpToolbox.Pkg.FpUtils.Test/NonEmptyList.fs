module FsharpToolbox.Pkg.FpUtils.Test.Collections

open NUnit.Framework
open FsharpToolbox.Pkg.FpUtils

[<TestFixture>]
type NonEmptyListTypeTests () =

  [<Test>]
  member _.``NonEmptyList record`` () =
    // Arrange
    // Act
    let l = {Head = 1; Tail = [2; 3]}: NonEmptyList<int>
    // Assert
    Assert.AreEqual(1, l.Head)
    Assert.AreEqual([2; 3], l.Tail)

  [<Test>]
  member _.``NonEmptyList nelist type alias`` () =
    // Arrange
    let nel = NonEmptyList.create 1 [1; 1]
    // Act
    let length (numbers: int nelist) = numbers.Length
    let nelLength = length nel
    // Assert
    Assert.AreEqual(3, nelLength)


//[<TestFixture>]
//type NonEmptyListBuilderTests () =
//
//  [<Test>]
//  member _.``nelist builder`` () =
//    // Arrange
//    // Act
//    let nel1 = nelist { 1; 2; 3 }
//    // Assert
//    Assert.AreEqual(1, nel1.Head)
//    Assert.AreEqual([2; 3], nel1.Tail)


[<TestFixture>]
type NonEmptyListModuleTests () =

  // NOTE: There are many module functions, we only test one to make sure that
  // calling a module function using FsharpToolbox.Pkg.FpUtils.NonEmptyList works.

  [<Test>]
  member _.``NonEmptyList.create`` () =
    // Arrange
    // Act
    let l = NonEmptyList.create 1 [2; 3]
    // Assert
    Assert.AreEqual(1, l.Head)
    Assert.AreEqual([2; 3], l.Tail)
