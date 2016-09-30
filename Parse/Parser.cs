// Parser -- the parser for the Scheme printer and interpreter
//
// Defines
//
//   class Parser;
//
// Parses the language
//
//   exp  ->  ( rest
//         |  #f
//         |  #t
//         |  ' exp
//         |  integer_constant
//         |  string_constant
//         |  identifier
//    rest -> )
//         |  exp+ [. exp] )
//
// and builds a parse tree.  Lists of the form (rest) are further
// `parsed' into regular lists and special forms in the constructor
// for the parse tree node class Cons.  See Cons.parseList() for
// more information.
//
// The parser is implemented as an LL(0) recursive descent parser.
// I.e., parseExp() expects that the first token of an exp has not
// been read yet.  If parseRest() reads the first token of an exp
// before calling parseExp(), that token must be put back so that
// it can be reread by parseExp() or an alternative version of
// parseExp() must be called.
//
// If EOF is reached (i.e., if the scanner returns a NULL) token,
// the parser returns a NULL tree.  In case of a parse error, the
// parser discards the offending token (which probably was a DOT
// or an RPAREN) and attempts to continue parsing with the next token.

using System;
using Tokens;
using Tree;

namespace Parse
{
    public class Parser {
	
        private Scanner scanner;

        public Parser(Scanner s) { scanner = s; }
  
        public Node parseExp()
        {
            return parseExp(scanner.getNextToken());
        }

        public Node parseExp(Token curToken)
        {
            // TODO: write code for parsing an exp
            if(curToken.getType() == TokenType.LPAREN)
            {
                parseRest(scanner.getNextToken());
            }
            else if(curToken.getType() == TokenType.TRUE)
            {
                return new BoolLit(true);
            }
            else if (curToken.getType() == TokenType.FALSE)
            {
                return new BoolLit(false);
            }
            else if (curToken.getType() == TokenType.QUOTE)
            {
                return new Cons(new Ident("'"), parseExp());
            }
            else if (curToken.getType() == TokenType.INT)
            {
                return new IntLit(curToken.getIntVal());
            }
            else if (curToken.getType() == TokenType.STRING)
            {
                return new StringLit(curToken.getStringVal());
            }
            else if (curToken.getType() == TokenType.IDENT)
            {
                return new Ident(curToken.getName());
            }
            return null;
        }

        protected Node parseRest() {
            return parseRest(scanner.getNextToken());
        }

        protected Node parseRest(Token t)
        {
            // TODO: write code for parsing a rest
            Token curToken = t;
            if (curToken.getType() == TokenType.RPAREN)
                return new Nil();
            else if(curToken == null)
            {
                return null;
            }
            else
            {
                return new Cons(parseExp(curToken), dotCheck(scanner.getNextToken()));
            }
            
        }
        public Node dotCheck(Token t)
        {
            if (t.getType() == TokenType.RPAREN)
            {
                return new Nil();
            }
            else if (t.getType() == TokenType.DOT)
            {
                return new Cons(parseExp(scanner.getNextToken()), dotCheck(scanner.getNextToken()));
            }
            else if (t == null)
            {
                return null;
            }
        }
        // TODO: Add any additional methods you might need.
    }
}

