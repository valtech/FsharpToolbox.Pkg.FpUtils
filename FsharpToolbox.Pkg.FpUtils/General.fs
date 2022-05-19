namespace FsharpToolbox.Pkg.FpUtils

[<AutoOpen>]
module General =
  /// Substitute a for b, that is, throw away b and use a instead
  let substitute a _b = a

  let tee f a =
    f a
    a
  /// tee
  let ( |= ) x f = tee f x