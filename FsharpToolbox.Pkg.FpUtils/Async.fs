namespace FsharpToolbox.Pkg.FpUtils

[<RequireQualifiedAccess>]
module Async =
  let inline retn (value: 'a) : Async<'a> = value |> async.Return

  let inline bind (f: 'a -> Async<'b>) (x: Async<'a>) : Async<'b> = async.Bind(x, f)

  let inline map (f: 'a -> 'b) (x: Async<'a>) : Async<'b> = x |> bind (f >> retn)