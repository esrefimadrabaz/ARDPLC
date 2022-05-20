using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace WindowsFormsApp1
{
    class KeyPrinter : GrammarBaseListener
    {
        private int Tabs = 1;
        public string Text
        {
            get { return FixEquals(_text.ToString().Replace("<>", " != ")); }
        }
        private StringBuilder _text = new StringBuilder();
        // override default listener behavior
        #region init-variable_declaration
        public override void EnterFunctionHeading([NotNull] GrammarParser.FunctionHeadingContext context)
        {
            _text.Append("void " + context.identifier().GetText() + "(){\n");
            _text.Append('\t', Tabs);
        }
        public override void ExitFunction([NotNull] GrammarParser.FunctionContext context)
        {
            _text.Append("}");
        }

        public override void EnterVariableDeclaration([NotNull] GrammarParser.VariableDeclarationContext context)
        {
            if (context.type_().GetText().ToLower() == "integer")
            {
                _text.Append("int ");
            }
            else if (context.type_().GetText().ToLower() == "real")
            {
                _text.Append("float ");
            }
            else if (context.type_().GetText().ToLower() == "boolean")
            {
                _text.Append("bool ");
            }
            else
            {
                _text.Append(context.type_().GetText() + " ");
            }

            _text.Append(context.identifierList().identifier()[0].GetText());
            var x = context.factor()?.GetText() ?? "NotDeclared_";
            if (!(x == "NotDeclared_"))
            {
                _text.Append(" = " + x);
            }
            _text.Append(";\n");
            _text.Append('\t', Tabs);
        }
        #endregion


        public override void EnterSimpleStatement([NotNull] GrammarParser.SimpleStatementContext context)
        {
            _text.Append(context.assignmentStatement()?.GetText().Replace(":=", " = ") ?? context.GetText());
            _text.Append(";");
        }
        public override void ExitSimpleStatement([NotNull] GrammarParser.SimpleStatementContext context)
        {
            _text.Append('\n');
            _text.Append('\t', Tabs);
        }
        public override void EnterElseStatement([NotNull] GrammarParser.ElseStatementContext context)
        {
            _text.Append("else {\n");
            _text.Append('\t', Tabs);
        }
        public override void ExitElseStatement([NotNull] GrammarParser.ElseStatementContext context)
        {
            _text.Append("}\n");
            _text.Append('\t', Tabs);
        }

        #region StructuredStatements
        public override void EnterIfStatement(GrammarParser.IfStatementContext context)
        {
            _text.Append("if (" + context.expression().GetText() + ") {\n");
            Tabs++;
            _text.Append('\t', Tabs);
        }
        public override void ExitIfStatement([NotNull] GrammarParser.IfStatementContext context)
        {
            _text.Append("\n");
            _text.Append('\t', Tabs);
            _text.Append("}\n");
            Tabs--;
            _text.Append('\t', Tabs);
        }


        public override void EnterWhileStatement(GrammarParser.WhileStatementContext context)
        {
            _text.Append("while (" + context.expression().GetText() + ") {\n");
            Tabs++;
            _text.Append('\t', Tabs);
        }
        public override void ExitWhileStatement([NotNull] GrammarParser.WhileStatementContext context)
        {
            _text.Append("}\n");
            Tabs--;
            _text.Append('\t', Tabs);
        }


        public override void EnterCaseStatement([NotNull] GrammarParser.CaseStatementContext context)
        {
            _text.Append("switch (" + context.expression().GetText() + ") {\n");
            Tabs++;
            _text.Append('\t', Tabs);
        }
        public override void EnterCaseListElement([NotNull] GrammarParser.CaseListElementContext context)
        {
            _text.Append("case (" + context.constList().GetText() + "):");
        }
        public override void ExitCaseListElement([NotNull] GrammarParser.CaseListElementContext context)
        {
            _text.Append("break;\n");
            _text.Append('\t', Tabs);
        }
        public override void EnterElseCaseEnd([NotNull] GrammarParser.ElseCaseEndContext context)
        {
            _text.Append("default: \n");
            _text.Append('\t', Tabs);
            string endcase = context.statements()?.GetText() ?? "break;";
            if (endcase == "break;")
            {
                _text.Append("break;");
            }
        }
        public override void ExitElseCaseEnd([NotNull] GrammarParser.ElseCaseEndContext context)
        {
            _text.Append("}\n");
            Tabs--;
            _text.Append('\t', Tabs);
        }


        public override void EnterRepeatStatement([NotNull] GrammarParser.RepeatStatementContext context)
        {
            _text.Append("do {\n");
            Tabs++;
            _text.Append('\t', Tabs);
        }
        public override void ExitRepeatStatement([NotNull] GrammarParser.RepeatStatementContext context)
        {
            _text.Append("\n");
            _text.Append('\t', Tabs);
            _text.Append("} while (" + context.expression().GetText() + ");\n");
            Tabs--;
            _text.Append('\t', Tabs);
        }


        public override void EnterForStatement([NotNull] GrammarParser.ForStatementContext context)
        {
            string ident = context.identifier().GetText();
            string first = context.forList().initialValue().GetText();
            string second = context.forList().finalValue().GetText();
            string by = context.forList().NUM_REAL()?.GetText() ?? "1";
            _text.Append("for (" + ident + " = " + first + ";"
                + ident + "<=" + second + ";"
                + ident + " = " + ident + "+" + by + ")\n");
            Tabs++;
            _text.Append('\t', Tabs);
            _text.Append("{\n");
            _text.Append('\t', Tabs);
        }
        public override void ExitForStatement([NotNull] GrammarParser.ForStatementContext context)
        {
            _text.Append("\n");
            _text.Append('\t', Tabs);
            Tabs--;
            _text.Append("}\n");
            _text.Append('\t', Tabs);
        }


        public override void EnterExitStatement([NotNull] GrammarParser.ExitStatementContext context)
        {
            _text.Append("break;");
        }
        #endregion


        public string FixEquals(string Final)
        {
            var chars = Final.ToList();
            for (int i = 10; i < chars.Count; i++)
            {
                if (chars[i] != '=') { continue; }
                if (chars[i - 1] == '<' || chars[i + 1] == '>') { continue; }
                if (chars[i - 1] == ' ' || chars[i + 1] == ' ') { continue; }
                chars.Insert(i, '=');
                i = i + 2;
            }
            return string.Join("", chars);
        }
    }
}
