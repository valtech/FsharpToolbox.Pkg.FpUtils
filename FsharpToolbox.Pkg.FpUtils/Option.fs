namespace FsharpToolbox.Pkg.FpUtils

[<AutoOpen>]
module Option =
  type Option<'a>
  with
    static member ToResult (errorValue: 'b) (this: 'a option): Result<'a, 'b> =
      match this with
      | Some a -> Ok a
      | None -> Error errorValue

    static member MapToResult (f: 'a -> Result<'b, 'c>) (this: 'a option) : Result<'b option, 'c> =
      match this with
      | None -> None |> Ok
      | Some v -> f v |>> Some

    static member ToResultOption (optionOfResult: Option<Result<'a, 'terror>>) =
      match optionOfResult with
      | None -> Ok None
      | Some (Ok success) -> Ok (Some success)
      | Some (Error error) -> Error error


