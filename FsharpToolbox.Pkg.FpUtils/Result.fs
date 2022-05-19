namespace FsharpToolbox.Pkg.FpUtils

open FSharpPlus.Data

[<AutoOpen>]
module Result =

  let map = Result.map
  /// Result.map
  let ( |>> ) x f = map f x

  let mapError = Result.mapError
  /// Result.mapError
  let ( |>! ) x f = mapError f x

  let bind = Result.bind
  /// Result.bind
  let ( >>= ) x f = bind f x

  let bindError f = function
    | Ok a -> Ok a
    | Error b -> f b
  /// Result.bindError
  let ( >>! ) x f = bindError f x

  let teeOk f = function
    | Ok a -> f a; Ok a
    | Error e -> Error e
  /// Result.teeOk
  let ( |== ) x f = teeOk f x

  let teeError f = function
    | Ok a -> Ok a
    | Error e -> f e; Error e
  /// Result.teeError
  let ( |=! ) x f = teeError f x

  let filter predicate onFalse = function
    | Ok a -> if predicate a then Ok a else onFalse a
    | Error err -> Error err

  let unlift = function
    | Ok a -> a
    | Error a -> a

  // Pipe a Result value through f, useful when applying rReturn at the end of a bind chain.
  let ( >>| ) x f = f x

  let someOk value = Ok (Some value)
  let noneOk = Ok None

[<AutoOpen>]
module MonadCE =
  let result<'T, 'E> = FSharpPlus.GenericBuilders.monad<Result<'T, 'E>>
