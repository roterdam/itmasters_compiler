// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, QUT 2005-2010
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.3.6
// Machine:  BASE-PC
// DateTime: 06.10.2014 20:51:34
// UserName: Admin
// Input file <SimpleYacc.y>

// options: no-lines gplex

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using QUT.Gppg;
using ProgramTree;

namespace SimpleParser
{
public enum Tokens {
    error=1,EOF=2,BEGIN=3,END=4,CYCLE=5,WHILE=6,
    IF=7,ELSE=8,ASSIGN=9,SEMICOLON=10,WRITE=11,COLON=12,
    COMMA=13,VAR=14,PLUS=15,MINUS=16,MULT=17,DIV=18,
    LBR=19,RBR=20,LESS=21,GREATER=22,EQUAL=23,NEQUAL=24,
    LEQUAL=25,GEQUAL=26,INUM=27,RNUM=28,ID=29};

public partial struct ValueType
{ 
			public double dVal; 
			public int iVal; 
			public string sVal; 
			public Node nVal;
			public ExprNode eVal;
			public StatementNode stVal;
			public BlockNode blVal;
       }
// Abstract base class for GPLEX scanners
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

public partial class Parser: ShiftReduceParser<ValueType, LexLocation>
{
  // Verbatim content from SimpleYacc.y
// ��� ���������� ����������� � ����� GPPGParser, �������������� ����� ������, ������������ �������� gppg
    public BlockNode root; // �������� ���� ��������������� ������ 
    public Parser(AbstractScanner<ValueType, LexLocation> scanner) : base(scanner) { }
  // End verbatim content from SimpleYacc.y

#pragma warning disable 649
  private static Dictionary<int, string> aliasses;
#pragma warning restore 649
  private static Rule[] rules = new Rule[42];
  private static State[] states = new State[81];
  private static string[] nonTerms = new string[] {
      "num_expr", "comp_expr", "ident", "T", "F", "expr", "assign", "statement", 
      "cycle", "while", "if", "write", "vardef", "idlist", "stlist", "block", 
      "progr", "$accept", };

  static Parser() {
    states[0] = new State(new int[]{3,4},new int[]{-17,1,-16,3});
    states[1] = new State(new int[]{2,2});
    states[2] = new State(-1);
    states[3] = new State(-2);
    states[4] = new State(new int[]{14,10,29,19,3,4,5,43,6,47,7,51,11,57},new int[]{-15,5,-8,80,-13,9,-7,18,-3,38,-16,41,-9,42,-10,46,-11,50,-12,56});
    states[5] = new State(new int[]{4,6,10,7});
    states[6] = new State(-18);
    states[7] = new State(new int[]{14,10,29,19,3,4,5,43,6,47,7,51,11,57},new int[]{-8,8,-13,9,-7,18,-3,38,-16,41,-9,42,-10,46,-11,50,-12,56});
    states[8] = new State(-4);
    states[9] = new State(-5);
    states[10] = new State(new int[]{29,14},new int[]{-14,11,-3,17});
    states[11] = new State(new int[]{12,12,13,15});
    states[12] = new State(new int[]{29,14},new int[]{-3,13});
    states[13] = new State(-17);
    states[14] = new State(-12);
    states[15] = new State(new int[]{29,14},new int[]{-3,16});
    states[16] = new State(-14);
    states[17] = new State(-13);
    states[18] = new State(-6);
    states[19] = new State(new int[]{29,14,9,-12},new int[]{-3,20});
    states[20] = new State(new int[]{9,21});
    states[21] = new State(new int[]{29,14,27,28,19,29},new int[]{-1,22,-4,37,-5,36,-3,27});
    states[22] = new State(new int[]{15,23,16,32,4,-15,10,-15,8,-15});
    states[23] = new State(new int[]{29,14,27,28,19,29},new int[]{-4,24,-5,36,-3,27});
    states[24] = new State(new int[]{17,25,18,34,15,-34,16,-34,4,-34,10,-34,8,-34,20,-34,14,-34,29,-34,3,-34,5,-34,6,-34,7,-34,11,-34,21,-34,22,-34,23,-34,24,-34,25,-34,26,-34});
    states[25] = new State(new int[]{29,14,27,28,19,29},new int[]{-5,26,-3,27});
    states[26] = new State(-37);
    states[27] = new State(-39);
    states[28] = new State(-40);
    states[29] = new State(new int[]{29,14,27,28,19,29},new int[]{-1,30,-4,37,-5,36,-3,27});
    states[30] = new State(new int[]{20,31,15,23,16,32});
    states[31] = new State(-41);
    states[32] = new State(new int[]{29,14,27,28,19,29},new int[]{-4,33,-5,36,-3,27});
    states[33] = new State(new int[]{17,25,18,34,15,-35,16,-35,4,-35,10,-35,8,-35,20,-35,14,-35,29,-35,3,-35,5,-35,6,-35,7,-35,11,-35,21,-35,22,-35,23,-35,24,-35,25,-35,26,-35});
    states[34] = new State(new int[]{29,14,27,28,19,29},new int[]{-5,35,-3,27});
    states[35] = new State(-38);
    states[36] = new State(-36);
    states[37] = new State(new int[]{17,25,18,34,15,-33,16,-33,4,-33,10,-33,8,-33,20,-33,14,-33,29,-33,3,-33,5,-33,6,-33,7,-33,11,-33,21,-33,22,-33,23,-33,24,-33,25,-33,26,-33});
    states[38] = new State(new int[]{9,39});
    states[39] = new State(new int[]{29,14,27,28,19,29},new int[]{-1,40,-4,37,-5,36,-3,27});
    states[40] = new State(new int[]{15,23,16,32,4,-16,10,-16,8,-16});
    states[41] = new State(-7);
    states[42] = new State(-8);
    states[43] = new State(new int[]{29,14,27,28,19,29},new int[]{-1,44,-4,37,-5,36,-3,27});
    states[44] = new State(new int[]{15,23,16,32,14,10,29,19,3,4,5,43,6,47,7,51,11,57},new int[]{-8,45,-13,9,-7,18,-3,38,-16,41,-9,42,-10,46,-11,50,-12,56});
    states[45] = new State(-19);
    states[46] = new State(-9);
    states[47] = new State(new int[]{29,14,27,28,19,75},new int[]{-2,48,-1,79,-4,37,-5,36,-3,27});
    states[48] = new State(new int[]{14,10,29,19,3,4,5,43,6,47,7,51,11,57},new int[]{-8,49,-13,9,-7,18,-3,38,-16,41,-9,42,-10,46,-11,50,-12,56});
    states[49] = new State(-20);
    states[50] = new State(-10);
    states[51] = new State(new int[]{29,14,27,28,19,75},new int[]{-2,52,-1,79,-4,37,-5,36,-3,27});
    states[52] = new State(new int[]{14,10,29,19,3,4,5,43,6,47,7,51,11,57},new int[]{-8,53,-13,9,-7,18,-3,38,-16,41,-9,42,-10,46,-11,50,-12,56});
    states[53] = new State(new int[]{8,54,4,-21,10,-21});
    states[54] = new State(new int[]{14,10,29,19,3,4,5,43,6,47,7,51,11,57},new int[]{-8,55,-13,9,-7,18,-3,38,-16,41,-9,42,-10,46,-11,50,-12,56});
    states[55] = new State(-22);
    states[56] = new State(-11);
    states[57] = new State(new int[]{19,58});
    states[58] = new State(new int[]{29,14,27,28,19,75},new int[]{-6,59,-2,61,-1,62,-4,37,-5,36,-3,27});
    states[59] = new State(new int[]{20,60});
    states[60] = new State(-23);
    states[61] = new State(-24);
    states[62] = new State(new int[]{21,63,15,23,16,32,22,65,23,67,24,69,25,71,26,73,20,-25});
    states[63] = new State(new int[]{29,14,27,28,19,29},new int[]{-1,64,-4,37,-5,36,-3,27});
    states[64] = new State(new int[]{15,23,16,32,14,-26,29,-26,3,-26,5,-26,6,-26,7,-26,11,-26,20,-26});
    states[65] = new State(new int[]{29,14,27,28,19,29},new int[]{-1,66,-4,37,-5,36,-3,27});
    states[66] = new State(new int[]{15,23,16,32,14,-27,29,-27,3,-27,5,-27,6,-27,7,-27,11,-27,20,-27});
    states[67] = new State(new int[]{29,14,27,28,19,29},new int[]{-1,68,-4,37,-5,36,-3,27});
    states[68] = new State(new int[]{15,23,16,32,14,-28,29,-28,3,-28,5,-28,6,-28,7,-28,11,-28,20,-28});
    states[69] = new State(new int[]{29,14,27,28,19,29},new int[]{-1,70,-4,37,-5,36,-3,27});
    states[70] = new State(new int[]{15,23,16,32,14,-29,29,-29,3,-29,5,-29,6,-29,7,-29,11,-29,20,-29});
    states[71] = new State(new int[]{29,14,27,28,19,29},new int[]{-1,72,-4,37,-5,36,-3,27});
    states[72] = new State(new int[]{15,23,16,32,14,-30,29,-30,3,-30,5,-30,6,-30,7,-30,11,-30,20,-30});
    states[73] = new State(new int[]{29,14,27,28,19,29},new int[]{-1,74,-4,37,-5,36,-3,27});
    states[74] = new State(new int[]{15,23,16,32,14,-31,29,-31,3,-31,5,-31,6,-31,7,-31,11,-31,20,-31});
    states[75] = new State(new int[]{29,14,27,28,19,75},new int[]{-1,76,-2,77,-4,37,-5,36,-3,27});
    states[76] = new State(new int[]{20,31,15,23,16,32,21,63,22,65,23,67,24,69,25,71,26,73});
    states[77] = new State(new int[]{20,78});
    states[78] = new State(-32);
    states[79] = new State(new int[]{21,63,15,23,16,32,22,65,23,67,24,69,25,71,26,73});
    states[80] = new State(-3);

    rules[1] = new Rule(-18, new int[]{-17,2});
    rules[2] = new Rule(-17, new int[]{-16});
    rules[3] = new Rule(-15, new int[]{-8});
    rules[4] = new Rule(-15, new int[]{-15,10,-8});
    rules[5] = new Rule(-8, new int[]{-13});
    rules[6] = new Rule(-8, new int[]{-7});
    rules[7] = new Rule(-8, new int[]{-16});
    rules[8] = new Rule(-8, new int[]{-9});
    rules[9] = new Rule(-8, new int[]{-10});
    rules[10] = new Rule(-8, new int[]{-11});
    rules[11] = new Rule(-8, new int[]{-12});
    rules[12] = new Rule(-3, new int[]{29});
    rules[13] = new Rule(-14, new int[]{-3});
    rules[14] = new Rule(-14, new int[]{-14,13,-3});
    rules[15] = new Rule(-7, new int[]{29,-3,9,-1});
    rules[16] = new Rule(-7, new int[]{-3,9,-1});
    rules[17] = new Rule(-13, new int[]{14,-14,12,-3});
    rules[18] = new Rule(-16, new int[]{3,-15,4});
    rules[19] = new Rule(-9, new int[]{5,-1,-8});
    rules[20] = new Rule(-10, new int[]{6,-2,-8});
    rules[21] = new Rule(-11, new int[]{7,-2,-8});
    rules[22] = new Rule(-11, new int[]{7,-2,-8,8,-8});
    rules[23] = new Rule(-12, new int[]{11,19,-6,20});
    rules[24] = new Rule(-6, new int[]{-2});
    rules[25] = new Rule(-6, new int[]{-1});
    rules[26] = new Rule(-2, new int[]{-1,21,-1});
    rules[27] = new Rule(-2, new int[]{-1,22,-1});
    rules[28] = new Rule(-2, new int[]{-1,23,-1});
    rules[29] = new Rule(-2, new int[]{-1,24,-1});
    rules[30] = new Rule(-2, new int[]{-1,25,-1});
    rules[31] = new Rule(-2, new int[]{-1,26,-1});
    rules[32] = new Rule(-2, new int[]{19,-2,20});
    rules[33] = new Rule(-1, new int[]{-4});
    rules[34] = new Rule(-1, new int[]{-1,15,-4});
    rules[35] = new Rule(-1, new int[]{-1,16,-4});
    rules[36] = new Rule(-4, new int[]{-5});
    rules[37] = new Rule(-4, new int[]{-4,17,-5});
    rules[38] = new Rule(-4, new int[]{-4,18,-5});
    rules[39] = new Rule(-5, new int[]{-3});
    rules[40] = new Rule(-5, new int[]{27});
    rules[41] = new Rule(-5, new int[]{19,-1,20});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
    switch (action)
    {
      case 2: // progr -> block
{ root = ValueStack[ValueStack.Depth-1].blVal; }
        break;
      case 3: // stlist -> statement
{ CurrentSemanticValue.blVal = new BlockNode(ValueStack[ValueStack.Depth-1].stVal); }
        break;
      case 4: // stlist -> stlist, SEMICOLON, statement
{ 
			ValueStack[ValueStack.Depth-3].blVal.Add(ValueStack[ValueStack.Depth-1].stVal); 
			CurrentSemanticValue.blVal = ValueStack[ValueStack.Depth-3].blVal; 
		}
        break;
      case 5: // statement -> vardef
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 6: // statement -> assign
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 7: // statement -> block
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].blVal; }
        break;
      case 8: // statement -> cycle
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 9: // statement -> while
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 10: // statement -> if
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 11: // statement -> write
{ CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-1].stVal; }
        break;
      case 12: // ident -> ID
{ CurrentSemanticValue.eVal = new IdNode(ValueStack[ValueStack.Depth-1].sVal); }
        break;
      case 13: // idlist -> ident
{ CurrentSemanticValue.stVal = new VarDefNode(ValueStack[ValueStack.Depth-1].eVal as IdNode); }
        break;
      case 14: // idlist -> idlist, COMMA, ident
{ 
			(ValueStack[ValueStack.Depth-3].stVal as VarDefNode).Add(ValueStack[ValueStack.Depth-1].eVal as IdNode);
			CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-3].stVal;
		}
        break;
      case 15: // assign -> ID, ident, ASSIGN, num_expr
{ CurrentSemanticValue.stVal = new AssignNode(ValueStack[ValueStack.Depth-3].eVal as IdNode, ValueStack[ValueStack.Depth-1].eVal); }
        break;
      case 16: // assign -> ident, ASSIGN, num_expr
{ CurrentSemanticValue.stVal = new AssignNode(ValueStack[ValueStack.Depth-3].eVal as IdNode, ValueStack[ValueStack.Depth-1].eVal); }
        break;
      case 17: // vardef -> VAR, idlist, COLON, ident
{ 
			CurrentSemanticValue.stVal = ValueStack[ValueStack.Depth-3].stVal; 
			(CurrentSemanticValue.stVal as VarDefNode).TypeIdent = ValueStack[ValueStack.Depth-1].eVal as IdNode;
		}
        break;
      case 18: // block -> BEGIN, stlist, END
{ CurrentSemanticValue.blVal = ValueStack[ValueStack.Depth-2].blVal; }
        break;
      case 19: // cycle -> CYCLE, num_expr, statement
{ CurrentSemanticValue.stVal = new CycleNode(ValueStack[ValueStack.Depth-2].eVal, ValueStack[ValueStack.Depth-1].stVal); }
        break;
      case 20: // while -> WHILE, comp_expr, statement
{ CurrentSemanticValue.stVal = new WhileNode(ValueStack[ValueStack.Depth-2].eVal, ValueStack[ValueStack.Depth-1].stVal); }
        break;
      case 21: // if -> IF, comp_expr, statement
{ CurrentSemanticValue.stVal = new IfNode(ValueStack[ValueStack.Depth-2].eVal, ValueStack[ValueStack.Depth-1].stVal); }
        break;
      case 22: // if -> IF, comp_expr, statement, ELSE, statement
{ CurrentSemanticValue.stVal = new IfNode(ValueStack[ValueStack.Depth-4].eVal, ValueStack[ValueStack.Depth-3].stVal, ValueStack[ValueStack.Depth-1].stVal); }
        break;
      case 23: // write -> WRITE, LBR, expr, RBR
{ CurrentSemanticValue.stVal = new WriteNode(ValueStack[ValueStack.Depth-2].eVal); }
        break;
      case 24: // expr -> comp_expr
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal; }
        break;
      case 25: // expr -> num_expr
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal; }
        break;
      case 26: // comp_expr -> num_expr, LESS, num_expr
{ CurrentSemanticValue.eVal = new BinOpNode(ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-1].eVal, BinOpType.Less); }
        break;
      case 27: // comp_expr -> num_expr, GREATER, num_expr
{ CurrentSemanticValue.eVal = new BinOpNode(ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-1].eVal, BinOpType.Greater); }
        break;
      case 28: // comp_expr -> num_expr, EQUAL, num_expr
{ CurrentSemanticValue.eVal = new BinOpNode(ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-1].eVal, BinOpType.Equal); }
        break;
      case 29: // comp_expr -> num_expr, NEQUAL, num_expr
{ CurrentSemanticValue.eVal = new BinOpNode(ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-1].eVal, BinOpType.NEqual); }
        break;
      case 30: // comp_expr -> num_expr, LEQUAL, num_expr
{ CurrentSemanticValue.eVal = new BinOpNode(ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-1].eVal, BinOpType.LEqual); }
        break;
      case 31: // comp_expr -> num_expr, GEQUAL, num_expr
{ CurrentSemanticValue.eVal = new BinOpNode(ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-1].eVal, BinOpType.GEqual); }
        break;
      case 32: // comp_expr -> LBR, comp_expr, RBR
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-2].eVal; }
        break;
      case 33: // num_expr -> T
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal; }
        break;
      case 34: // num_expr -> num_expr, PLUS, T
{ CurrentSemanticValue.eVal = new BinOpNode(ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-1].eVal, BinOpType.Plus); }
        break;
      case 35: // num_expr -> num_expr, MINUS, T
{ CurrentSemanticValue.eVal = new BinOpNode(ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-1].eVal, BinOpType.Minus); }
        break;
      case 36: // T -> F
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal; }
        break;
      case 37: // T -> T, MULT, F
{ CurrentSemanticValue.eVal = new BinOpNode(ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-1].eVal, BinOpType.Mult); }
        break;
      case 38: // T -> T, DIV, F
{ CurrentSemanticValue.eVal = new BinOpNode(ValueStack[ValueStack.Depth-3].eVal, ValueStack[ValueStack.Depth-1].eVal, BinOpType.Div); }
        break;
      case 39: // F -> ident
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-1].eVal as IdNode; }
        break;
      case 40: // F -> INUM
{ CurrentSemanticValue.eVal = new IntNumNode(ValueStack[ValueStack.Depth-1].iVal); }
        break;
      case 41: // F -> LBR, num_expr, RBR
{ CurrentSemanticValue.eVal = ValueStack[ValueStack.Depth-2].eVal; }
        break;
    }
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliasses != null && aliasses.ContainsKey(terminal))
        return aliasses[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

}
}
