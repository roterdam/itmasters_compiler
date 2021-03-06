﻿using SimpleLang.MiddleEnd;
using System;
using System.Collections.Generic;

namespace SimpleLang.Analysis
{
    using StringSet = SetAdapter<string>;

    public class DeadOrAlive
    {
        public static List<Tuple<string, string, int>> GenerateDefUse(List<CodeLine> l)
        {
            List<Tuple<string, string, int>> l2 = new List<Tuple<string, string, int>>();
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].First != null && SymbolTable.Contains(l[i].First))

                    if (l[i].Operator == OperatorType.If)
                    {
                        l2.Add(new Tuple<string, string, int>(l[i].First, "use", i));
                    }
                    else
                    {
                        l2.Add(new Tuple<string, string, int>(l[i].First, "def", i));
                    }

                if (l[i].Second != null && SymbolTable.Contains(l[i].Second))
                {
                    l2.Add(new Tuple<string, string, int>(l[i].Second, "use", i));
                }
                if (l[i].Third != null && SymbolTable.Contains(l[i].Third))
                {
                    l2.Add(new Tuple<string, string, int>(l[i].Third, "use", i));
                }
            }
            return l2;
        }

        public static bool IsDead(BaseBlock bl, string id, int line)
        {
            List<CodeLine> bl2 = new List<CodeLine>(bl.Code);
            bool aliveafter = !(id.Length >= 2 && id.Substring(0, 2).Equals("_t"));
            for (int i = bl2.Count - 1; i > line; i--)
            {
                if (bl2[i].Third != null && bl2[i].Third.Equals(id))
                {
                    aliveafter = true;
                }
                if (bl2[i].Second != null && bl2[i].Second.Equals(id))
                {
                    aliveafter = true;
                }
                if (bl2[i].First != null && bl2[i].First.Equals(id))
                {
                    if (bl2[i].Operator == OperatorType.If)
                    {
                        aliveafter = true;
                    }
                    else
                    {
                        aliveafter = false;
                    }

                }
            }
            return !aliveafter;
        }
    }
    public class DefUseContext : Context<Tuple<StringSet, StringSet>>
    {
        //Функция проверяет, что текущий операнд - это идентификатор, ещё не попавший в def
        private bool GoodOperand(BaseBlock block, string s)
        {
            return s != null && (Char.IsLetter(s[0]) || s[0] == '_') && !this[block].Item1.Contains(s);
        }

        public DefUseContext(ControlFlowGraph cfg)
            : base(cfg)
        {
            foreach (BaseBlock block in cfg.GetBlocks())
            {
                this[block] = new Tuple<StringSet, StringSet>(new StringSet(), new StringSet());
                foreach (CodeLine line in block.Code)
                {
                    //Использование переменной может встретиться в присваивании, условном операторе и операторе вывода
                    switch (line.Operator)
                    { 
                        case OperatorType.Assign:
                            if (GoodOperand(block, line.Second))
                                this[block].Item2.Add(line.Second);
                            if (GoodOperand(block, line.Third))
                                this[block].Item2.Add(line.Third);
                            this[block].Item1.Add(line.First);
                            break;
                        case OperatorType.If:
                            if (GoodOperand(block, line.First))
                                this[block].Item2.Add(line.First);
                            break;
                        case OperatorType.Write:
                            if (GoodOperand(block, line.First))
                                this[block].Item2.Add(line.First);
                            break;
                    }                       
                }
            }
        }

        public StringSet Def(BaseBlock bl)
        {
            return this[bl].Item1;
        }

        public StringSet Use(BaseBlock bl)
        {
            return this[bl].Item2;
        }
    }

    public class AliveVarsAlgorithm : DownTopAlgorithm<Tuple<StringSet, StringSet>, DefUseContext, StringSet>
    {
        public AliveVarsAlgorithm(ControlFlowGraph cfg)
            : base(cfg)
        {
            foreach (BaseBlock bl in cfg.GetBlocks())
            {
                In[bl] = new StringSet();
                Out[bl] = new StringSet();
                Func[bl] = new AliveVarsTransferFunction(Cont[bl]);
            }
        }

        public override Tuple<Dictionary<BaseBlock, StringSet>, Dictionary<BaseBlock, StringSet>> Apply()
        {
            return base.Apply(new StringSet(), new StringSet(), new StringSet(), StringSet.Union);
        }
    }

    public class AliveVarsTransferFunction : InfoProvidedTransferFunction<Tuple<StringSet, StringSet>, StringSet>
    {
        public AliveVarsTransferFunction(Tuple<StringSet, StringSet> info)
            : base(info)
        { }

        public override StringSet Transfer(StringSet input)
        {
            return StringSet.Union(Info.Item2, StringSet.Subtract(input, Info.Item1));
        }
    }
}