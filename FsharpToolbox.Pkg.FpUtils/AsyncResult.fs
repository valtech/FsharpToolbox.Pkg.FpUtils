namespace FsharpToolbox.Pkg.FpUtils

open FsToolkit.ErrorHandling

[<AutoOpen>]
module AsyncResult =
  let map = AsyncResult.map
  /// AsyncResult.map
  let ( %|>> ) x f = map f x

  let mapError = AsyncResult.mapError
  /// AsyncResult.mapError
  let ( %|>! ) x f = mapError f x

  let bind = AsyncResult.bind
  /// AsyncResult.bind
  let ( %>>= ) x f = bind f x

  let bindError f input =
    async {
      let! result = input
      let t =
        match result with
        | Ok x ->  async { return Ok x }
        | Error e -> f e
      return! t
    }
  /// AsyncResult.bindError
  let ( %>>! ) x f = bindError f x

  let teeOk = AsyncResult.tee
  /// AsyncResult.teeOk
  let ( %|== ) x f = teeOk f x

  let teeError = AsyncResult.teeError
  /// AsyncResult.teeError
  let ( %|=! ) x f = teeError f x

  let ofTask = AsyncResult.ofTask
  let ofTaskAction = AsyncResult.ofTaskAction

[<AutoOpen>]
module AsyncResultCE =
  let AsyncResultBuilder = AsyncResultCE.AsyncResultBuilder
  let asyncResult = AsyncResultCE.asyncResult
