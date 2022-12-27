namespace PhraseFinder.Core

open System
open System.Diagnostics

type Result = string * string

module Finder =

    ///Split text on phrases
    let split (text: string) : string list = text.Split('.', '?', '!') |> List.ofSeq


    ///Cleanup text from special symbols
    let cleanup (text: string) : string =
        let mutable result = text
        let symbols = [ ','; ','; '['; ']'; '''; '.'; ')'; '('; ',' ]

        for symbol in symbols do
            result <- result.Replace(symbol, ' ')

        text


    let filter (line: string, pi: string) : bool =
        let elements: int list =
            pi.Replace(".", "").Replace(",", "").ToCharArray()
            |> List.ofSeq
            |> List.map (fun x -> x.ToString())
            |> List.map Int32.Parse

        let words = line.Split(' ') |> List.ofSeq
        
        if (words.Length < elements.Length) then
            false
        else
                
            let wordsLength: int list = words |> List.take elements.Length |> List.map (fun x -> x.Length)
            
            let result = List.forall2 (=) wordsLength elements
            
            result

    let find (text: string, pi: string) : string list =

        // 1. split on phrase
        // 2. Check every phrase on rule

        let filterPi (line: string) = filter (line, pi)

        let phrases = text |> split |> List.map cleanup |> List.filter filterPi

        phrases
