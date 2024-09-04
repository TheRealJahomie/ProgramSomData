using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;


// OUR SOLUTION FOR 1.4
abstract class Expr
{
    public abstract override string ToString();
    public abstract int Eval(Dictionary<string, int> env);
    public abstract Expr Simplify(); 

}

class CstI : Expr
{
    private int value;

    public CstI(int value)
    {
        this.value = value;
    }
      public override int Eval(Dictionary<string, int> env)
    {
        return value;
    }
    public override Expr Simplify()
    {
        return this;
    }

    public override string ToString()
    {
        return value.ToString();
    }
}

class Var : Expr
{
    private string name;

    public Var(string name)
    {
        this.name = name;
    }

      public override int Eval(Dictionary<string, int> env)
    {
        if (env.ContainsKey(name))
        {
            return env[name];
        }
        else
        {
            throw new Exception($"Variable {name} not found in the environment.");
        }
    }

    public override Expr Simplify()
    {
        return this;
    }

    public override string ToString()
    {
        return name;
    }
}

abstract class Binop : Expr
{
    protected Expr left;
    protected Expr right;

    public Binop(Expr left, Expr right)
    {
        this.left = left;
        this.right = right;
    }
}

class Add : Binop
{
    public Add(Expr left, Expr right) : base(left, right) {}

     public override int Eval(Dictionary<string, int> env)
    {
        return left.Eval(env) + right.Eval(env);
    }

        public override Expr Simplify()
    {
        Expr leftSimplified = left.Simplify();
        Expr rightSimplified = right.Simplify();

        // Simplification rules for addition
        if (leftSimplified is CstI l && l.Eval(null) == 0) return rightSimplified;
        if (rightSimplified is CstI r && r.Eval(null) == 0) return leftSimplified;

        return new Add(leftSimplified, rightSimplified);
    }
   

    public override string ToString()
    {
        return $"({left.ToString()} + {right.ToString()})";
    }
}

class Mul : Binop
{
    public Mul(Expr left, Expr right) : base(left, right) {}

       public override int Eval(Dictionary<string, int> env)
    {
        return left.Eval(env) + right.Eval(env);
    }

      public override Expr Simplify()
    {
        Expr leftSimplified = left.Simplify();
        Expr rightSimplified = right.Simplify();

        // Simplification rules for multiplication
        if (leftSimplified is CstI l)
        {
            if (l.Eval(null) == 0) return new CstI(0);
            if (l.Eval(null) == 1) return rightSimplified;
        }
        if (rightSimplified is CstI r)
        {
            if (r.Eval(null) == 0) return new CstI(0);
            if (r.Eval(null) == 1) return leftSimplified;
        }

        return new Mul(leftSimplified, rightSimplified);
    }

    public override string ToString()
    {
        return $"({left.ToString()} * {right.ToString()})";
    }
}

class Sub : Binop
{
    public Sub(Expr left, Expr right) : base(left, right) {}

        public override int Eval(Dictionary<string, int> env)
    {
        return left.Eval(env) + right.Eval(env);
    }

    public override Expr Simplify()
    {
        Expr leftSimplified = left.Simplify();
        Expr rightSimplified = right.Simplify();

        // Simplification rules for subtraction
        if (rightSimplified is CstI r && r.Eval(null) == 0) return leftSimplified;
        if (leftSimplified is CstI l && rightSimplified is CstI r2 && l.Eval(null) == r2.Eval(null)) return new CstI(0);

        return new Sub(leftSimplified, rightSimplified);
    }

    public override string ToString()
    {
        return $"({left.ToString()} - {right.ToString()})";
    }
}

class Program
{
    static void Main(string[] args)
    {
        var env = new Dictionary<string, int> { { "Z", 5 } };

        Expr e1 = new Add(new CstI(17), new Var("Z"));

        Expr e2 = new Sub(new Var("A"), new Var("B"));
        Expr e3 = new Sub(new Var("F"), new Add(new CstI(12), new Var("L")));
        Expr e4 = new Mul(new CstI(100), new Sub(new Var("P"), new Var("R")));

        Expr simpleExp = new Mul(new CstI(0), new Var("Q")).Simplify();


        Console.WriteLine(e1.ToString());  
        Console.WriteLine(e2.ToString());
        Console.WriteLine(e3.ToString());
        Console.WriteLine(e4.ToString());

        int result1 = e1.Eval(env);

        Console.WriteLine(result1);

        Console.WriteLine(simpleExp.ToString());



    }
}
