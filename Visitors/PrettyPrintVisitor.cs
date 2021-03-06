﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SimpleLang.MiddleEnd;

namespace SimpleLang.Visitors
{
    class PrettyPrintVisitor: Visitor
    {
        public string Text = "";
        private int Indent = 0;

        private string IndentStr()
        {
            return new string(' ', Indent);
        }
        private void IndentPlus()
        {
            Indent += 2;
        }
        private void IndentMinus()
        {
            Indent -= 2;
        }
        public override void VisitIdNode(IdNode id) 
        {
            Text += id.Name;
        }
        public override void VisitFloatNumNode(FloatNumNode num) 
        {
            Text += num.Num.ToString();
        }
        public override void VisitIntNumNode(IntNumNode num)
        {
            Text += num.Num.ToString();
        }
        public override void VisitBoolNode(BoolNode val)
        {
            Text += val.Val.ToString();
        }
        public override void VisitStringNode(StringNode val)
        {
            Text += val.Val;
        }
        public override void VisitBinOpNode(BinOpNode binop) 
        {
            Text += "(";
            binop.Left.Visit(this);
            Text += " " + binop.Op + " ";
            binop.Right.Visit(this);
            Text += ")";
        }
        public override void VisitAssignNode(AssignNode a) 
        {
            Text += IndentStr();
            a.Id.Visit(this);
            Text += " := ";
            a.Expr.Visit(this);
        }

        private void PrintLineOrBlockBody(StatementNode node)
        {
            if (!(node is BlockNode))
            {
                IndentPlus();
                node.Visit(this);
                IndentMinus();
            }
            else
                node.Visit(this);
        }

        public override void VisitCycleNode(CycleNode c) 
        {
            Text += IndentStr() + "cycle ";
            c.Expr.Visit(this);
            Text += Environment.NewLine;
            PrintLineOrBlockBody(c.Stat);
        }
        public override void VisitBlockNode(BlockNode bl) 
        {
            Text += IndentStr() + "begin" + Environment.NewLine;
            IndentPlus();

            var Count = bl.StList.Count;

            if (Count>0)
                bl.StList[0].Visit(this);
            for (var i = 1; i < Count; i++)
            {
                Text += ';';
                if (!(bl.StList[i] is EmptyNode))
                    Text += Environment.NewLine;
                bl.StList[i].Visit(this);
            }
            IndentMinus();
            Text += Environment.NewLine + IndentStr() + "end";
        }
        public override void VisitWriteNode(WriteNode w) 
        {
            Text += IndentStr() + "write(";
            w.Expr.Visit(this);
            Text += ")";
        }
        public override void VisitVarDefNode(VarDefNode w) 
        {
            Text += IndentStr() + "var " + w.Idents[0].Name;
            for (int i = 1; i < w.Idents.Count; i++)
                Text += ',' + w.Idents[i].Name;
            Text += ": " + w.TypeIdent.Name;
        }
        public override void VisitWhileNode(WhileNode w)
        {
            Text+= IndentStr() + "while";
            w.Expr.Visit(this);
            Text += Environment.NewLine;
            PrintLineOrBlockBody(w.Stat);
        }
        public override void VisitIfNode(IfNode w)
        {
            Text += IndentStr() + "if";
            w.Expr.Visit(this);
            Text += Environment.NewLine;
            PrintLineOrBlockBody(w.StatIf);
            if (!(w.StatElse is EmptyNode))
            {
                Text += Environment.NewLine + IndentStr() + "else" + Environment.NewLine;
                PrintLineOrBlockBody(w.StatElse);
            }
        }
    } 
}
