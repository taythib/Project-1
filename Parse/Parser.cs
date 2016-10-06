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
        
        // No lookahead
        protected Node parseRest() {
            return parseRest(scanner.getNextToken());
        }

        // 1 token lookahead
        protected Node parseRest(Token t)
        {
            //// TODO: write code for parsing a rest
            Token curToken = t;
            Token next = scanner.getNextToken();
            if (curToken.getType() == TokenType.LPAREN)
            {
                if (next.getType() == TokenType.RPAREN)
                {
                    return new Cons(new Nil(), parseRest());
                }
                else
                    return new Cons(new Cons(parseExp(next), parseRest()), parseRest());
            }
            else if (next.getType() == TokenType.RPAREN)
                return new Cons(parseExp(curToken), new Nil());
            else if (curToken.getType() == TokenType.DOT)
                return parseExp();
            else if (next.getType() == TokenType.DOT)
            {
                return new Cons(parseExp(curToken), parseRest());
            }
            else
                return new Cons(parseExp(curToken), new Cons(parseExp(next), parseRest()));
        }

        // Checks to see if lookahead token is a dot or a LPAREN for a new list
        public Node dotCheck(Token t, Token n)
        {
            if (n.getType() == TokenType.DOT)
            {
                return new Cons(parseExp(t), parseExp());
            }
            else if (t.getType() == TokenType.LPAREN)
            {
                return parseRest(n);
            }
            else if (t == null)
            {
                return null;
            }
            else
                return parseExp(t);

        }
        // TODO: Add any additional methods you might need.
    }
}

