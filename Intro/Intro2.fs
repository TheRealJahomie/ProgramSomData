(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;


(* Object language expressions with variables *)


type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr


let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;

let e4 = Prim("max", CstI 3, CstI 2);;

let e5 = Prim("min", CstI 3, CstI 2);;

let e6 = Prim("==", CstI 3, CstI 2);;



(* Evaluation within an environment *)

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i-> i
    | Var x -> lookup env x 
    | If(e1, e2, e3 ) ->
      let u1 = eval e1 env
      match u1 with 
      |0 -> eval e2 env
      |_ -> eval e3 env
    | Prim(ope, e1, e2) -> 
      let i1 = eval e1 env 
      let i2 = eval e2 env
      match ope with 
      | "+" -> i1 + i2
      | "-" -> i1 - i2
      | "*" -> i1 * i2 
      | "max" -> if i1 > i2 then i1 else i2 
      | "min" -> if i1 < i2 then i1 else i2
      | "==" -> if i1 = i2 then 1 else 0 
      | _ -> failwith "unknown";;

(*
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim("max",e1, e2) -> if eval e1 env > eval e2 env then eval e1 env else eval e2 env    
    | Prim("min",e1, e2) -> if eval e1 env < eval e2 env then eval e1 env else eval e2 env 
    | Prim("==",e1, e2) -> if eval e1 env = eval e2 env then 1 else 0       
    | Prim _            -> failwith "unknown primitive";;
*)


let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;

let e4v = eval e4 env;; 
let e5v = eval e5 [("t", 200)];; 
let e6v = eval e6 env;; 



(* AEXPRESSIONS FROM HERE *)

type aexpr =
  | CstI of int
  | Var of string
  | Add of aexpr * aexpr
  | Mul of aexpr * aexpr
  | Sub of aexpr * aexpr

let ae1 = Sub(Var "v", Add(Var "w", Var "z"))
let ae2 = Mul(CstI 2, Sub(Var "v",(Add(Var "w", Var "z"))))
let ae3 = Add(Var "x", Add(Var "y", Add(Var "z", Var "v")))

let aeTest = Sub(Var "x", CstI 34)

let rec fmt (ae: aexpr) : string =
    match ae with
    | CstI i -> i.ToString()
    | Var s -> s
    | Add(ae1, ae2) -> "(" + fmt ae1 + "+" + fmt ae2 + ")"
    | Sub(ae1, ae2) -> "(" + fmt ae1 + "-" + fmt ae2 + ")"
    | Mul(ae1, ae2) -> "(" + fmt ae1 + "*" + fmt ae2 + ")"
    
let rec simplify (ae: aexpr) : aexpr =
    match ae with
    | Add(CstI 0,ae1) -> ae1
    | Add(ae1,CstI 0) -> ae1
    | Sub(ae1,CstI 0) -> ae1
    | Mul(CstI 1,ae1) -> ae1
    | Mul(ae1,CstI 1) -> ae1
    | Mul(ae1,CstI 0) -> CstI 0
    | Mul(CstI 0,ae1) -> CstI 0
    | Sub(ae1,ae0) -> CstI 0
    | _ -> failwith "cannot be simplified"
    
let rec symbDiff ae var =
    match ae with
    | CstI _ -> CstI 0
    | Var x -> if x = var then CstI 1 else CstI 0
    | Add(ae1, ae2) -> Add(symbDiff ae1 var, symbDiff ae2 var)
    | Sub(ae1, ae2) -> Sub(symbDiff ae1 var, symbDiff ae2 var)
    | Mul(ae1, ae2) -> Mul(symbDiff ae1 var, symbDiff ae2 var)