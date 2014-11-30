﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLang.MiddleEnd;
using SimpleLang.Optimizations;
using SimpleLang.Visitors;
using SimpleParser;
using SimpleScanner;
using System.IO;

namespace simplelangTests
{
    [TestClass]
    public class Smeshariki
    {
        [TestMethod]
        public void TestCSE()
        {
            string FileName = @"..\..\Test4.txt";
            string Text = File.ReadAllText(FileName);
            Scanner scanner = new Scanner();
            scanner.SetSource(Text, 0);
            Parser parser = new Parser(scanner);
            var b = parser.Parse();
            var sne = new CheckVariablesVisitor();
            parser.root.Visit(sne);
            GenCodeVisitor gcv = new GenCodeVisitor();
            parser.root.Visit(gcv);
            gcv.RemoveEmptyLabels();
            ControlFlowGraph CFG = new ControlFlowGraph(gcv.Code);
            CSE cse = new CSE();
            string f = CFG.GetBlocks().First.Next.Value.Code.First.Value.First;
            Assert.IsTrue(f.StartsWith("_t"));
            Assert.IsTrue(CFG.GetBlocks().First.Next.Value.Code.First.Value.Second.Equals("b"));
            Assert.IsTrue(CFG.GetBlocks().First.Next.Value.Code.First.Value.Third.Equals("c"));
        }
    }
}