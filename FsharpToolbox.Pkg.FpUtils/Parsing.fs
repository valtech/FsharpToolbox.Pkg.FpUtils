namespace FsharpToolbox.Pkg.FpUtils.Parsing

open System

module Boolean =
  let parseOption (boolCandidate : string) =
    match Boolean.TryParse boolCandidate with
    | (true, v) -> Some v
    | (false, _) -> None

module Int =
  let parseOption (intCandidate : string) =
    match Int32.TryParse intCandidate with
    | (true, v) -> Some v
    | (false, _) -> None

module Int64 =
  let parseOption (intCandidate : string) =
    match Int64.TryParse intCandidate with
    | (true, v) -> Some v
    | (false, _) -> None
