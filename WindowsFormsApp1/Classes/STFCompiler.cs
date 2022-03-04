using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class STFCompiler
    {
        public string Input { get; set; }

        public string Translate()
        {
            ICharStream stream = CharStreams.fromString(Input);
            ITokenSource lexer = new GrammarLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            parser.BuildParseTree = true;
            IParseTree tree = parser.function(); // -> BoilerPlate

            KeyPrinter printer = new KeyPrinter();
            ParseTreeWalker.Default.Walk(printer, tree);

            return printer.Text;
        }
    }
}