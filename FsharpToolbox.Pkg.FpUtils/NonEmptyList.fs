namespace FsharpToolbox.Pkg.FpUtils
open FSharpPlus.Data

type NonEmptyList<'t> = FSharpPlus.Data.NonEmptyList<'t>
type nelist<'t> = FSharpPlus.Data.NonEmptyList<'t>

[<AutoOpen>]
[<RequireQualifiedAccess>]
module NonEmptyList =
    let create = NonEmptyList.create
    let singleton = NonEmptyList.singleton
    let toList = NonEmptyList.toList
    let toSeq = NonEmptyList.toSeq
    let toArray = NonEmptyList.toArray
    let ofArray = NonEmptyList.ofArray
    let ofList = NonEmptyList.ofList
    let ofSeq = NonEmptyList.ofSeq
    let length = NonEmptyList.length
    let map = NonEmptyList.map
    let unzip = NonEmptyList.unzip
    let zip = NonEmptyList.zip
    let cons = NonEmptyList.cons
    let head {Head = x; Tail = _ } = x
    let tail {Head = _; Tail = xs } = ofList xs
    let tails = NonEmptyList.tails

#if !FABLE_COMPILER
    let inline traverse (f: 'T->'``Functor<'U>``) (s: NonEmptyList<'T>) = NonEmptyList.traverse f s
#endif

    let inline average (list: FSharpPlus.Data.NonEmptyList<'t>) = NonEmptyList.average list
    let inline averageBy (projection: 'T -> ^U) list = NonEmptyList.averageBy projection list
    let reduce = NonEmptyList.reduce
    let reduceBack = NonEmptyList.reduceBack
    let max = NonEmptyList.max
    let maxBy = NonEmptyList.maxBy
    let min = NonEmptyList.min
    let minBy = NonEmptyList.minBy
    let inline range start stop = NonEmptyList.range start stop

#if !FABLE_COMPILER
    let inline choice (list: NonEmptyList<'``Alt<'T>``>) = NonEmptyList.choice list
#endif

    let tryOfList = NonEmptyList.tryOfList

[<AutoOpen>]
module NonEmptyListBuilder =
  let nelist = nelist

