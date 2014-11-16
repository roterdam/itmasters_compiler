﻿using System;
using System.Linq;
using System.Collections.Generic;

using SimpleLang.MiddleEnd;

namespace SimpleLang.Analysis
{
    using TripleSet = SetAdapter<Expression>;

    public class Expression
    {
        public string Op1, Op2, Operation;

        public Expression(string op1, string op2, string oper)
        {
            Op1 = op1;
            Op2 = op2;
            Operation = oper;
        }

        public Expression()
        {
            Op1 = Op2 = Operation = null;
        }

        public override bool Equals(object obj)
        {
            if (obj is Expression)
            {
                Expression Other = (Expression)obj;
                return Other.Operation == this.Operation &&
                    (Other.Op1 == this.Op1 && Other.Op2 == this.Op2 ||
                    Other.Op1 == this.Op2 && Other.Op2 == this.Op1);
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Op1.GetHashCode() * 3 + Op2.GetHashCode() * 7;
        }

        public override string ToString()
        {
            return Op1 + " " + Operation + " " + Op2;
        }
    }

    public class ExprDefUseContext : Context<Tuple<TripleSet, TripleSet>>
    {
        public TripleSet AllExprs { get; protected set; }

        public ExprDefUseContext(ControlFlowGraph cfg)
            : base(cfg)
        {
            AllExprs = new TripleSet();
            //И вот тут надо собрать нужную информацию и всё заработает, по идее...
        }

        public TripleSet EDef(BaseBlock bl)
        {
            return this[bl].Item1;
        }

        public TripleSet EUse(BaseBlock bl)
        {
            return this[bl].Item2;
        }
    }

    public class AvailableExprsTransferFunction : InfoProvidedTransferFunction<Tuple<TripleSet, TripleSet>, TripleSet>
    {
        public AvailableExprsTransferFunction(Tuple<TripleSet, TripleSet> info)
            : base(info)
        { }

        public override TripleSet Transfer(TripleSet input)
        {
            return TripleSet.Union(Info.Item2, TripleSet.Subtract(input, Info.Item1));
        }
    }

    public class AvailableExprsAlgorithm : TopDownAlgorithm<Tuple<TripleSet, TripleSet>, ExprDefUseContext, TripleSet>
    {
        public AvailableExprsAlgorithm(ControlFlowGraph cfg)
            : base(cfg)
        {
            foreach (BaseBlock bl in cfg.GetBlocks())
            {
                In[bl] = new TripleSet();
                Out[bl] = new TripleSet();
                Func[bl] = new AvailableExprsTransferFunction(Cont[bl]);
            }
        }

        public override Tuple<Dictionary<BaseBlock, TripleSet>, Dictionary<BaseBlock, TripleSet>> Apply()
        {
            return base.Apply(new TripleSet(), Cont.AllExprs, Cont.AllExprs, TripleSet.Intersect);
        }
    }
}