// Scanner -- The lexical analyzer for the Scheme printer and interpreter

using System;
using System.IO;
using Tokens;

namespace Parse
{
    public class Scanner
    {
        private TextReader In;

        // maximum length of strings and identifier
        private const int BUFSIZE = 1000;
        private char[] buf = new char[BUFSIZE];

        public Scanner(TextReader i) { In = i; }
  
        // TODO: Add any other methods you need

        public Token getNextToken()
        {
            int ch;

            try
            {
                // It would be more efficient if we'd maintain our own
                // input buffer and read characters out of that
                // buffer, but reading individual characters from the
                // input stream is easier.
                ch = In.Read();

                // TODO: skip white space and comments
                while (ch == '\n' | ch == ' ' | ch == '\t' | ch == '\r' | ch == '\f')
                {
                    ch = In.Read();
                }

                if (ch == -1)
                    return null;
        
                // Special characters
                else if (ch == '\'')
                    return new Token(TokenType.QUOTE);
                else if (ch == '(')
                    return new Token(TokenType.LPAREN);
                else if (ch == ')')
                    return new Token(TokenType.RPAREN);
                else if (ch == '.')
                    // We ignore the special identifier `...'.
                    return new Token(TokenType.DOT);
                
                // Boolean constants
                else if (ch == '#')
                {
                    ch = In.Read();

                    if (ch == 't')
                        return new Token(TokenType.TRUE);
                    else if (ch == 'f')
                        return new Token(TokenType.FALSE);
                    else if (ch == -1)
                    {
                        Console.Error.WriteLine("Unexpected EOF following #");
                        return null;
                    }
                    else
                    {
                        Console.Error.WriteLine("Illegal character '" +
                                                (char)ch + "' following #");
                        return getNextToken();
                    }
                }

                // String constants
                else if (ch == '"')
                {
                    // TODO: scan a string into the buffer variable buf
                    int bufIndex = 0;
                    ch = In.Read();
                    do
                    {
                        //Console.Write((char)ch);
                        buf[bufIndex] = (char)ch;
                        ch = In.Read();
                        bufIndex++;
                    } while ((char)ch != '"');
                    return new StringToken(new String(buf, 0, bufIndex));
                }

    
                // Integer constants
                else if (ch >= '0' && ch <= '9')
                {
                    int i = ch - '0';
                    // TODO: scan the number and convert it to an integer
                    int chr = In.Read();
                    while(chr >= '0' && chr <= '9')
                    {
                        i *= 10;
                        chr = chr - '0';
                        i = i + chr;
                        chr = In.Read();
                    }
                    // make sure that the character following the integer
                    // is not removed from the input stream
                    return new IntToken(i);
                }
        
                // Identifiers
                else if (ch >= 'A' && ch <= 'Z' || ch >= 'a' && ch <= 'z' || ch == '!' || ch == '$' || ch == '%'
                         || ch == '&' || ch == '*' || ch == '+' || ch == '-' || ch == '.' || ch == '/' || ch == ':'
                         || ch == '<' || ch == '=' || ch == '>' || ch == '?' || ch == '@' || ch == '^' || ch == '_'
                         || ch == '~'
                         // or ch is some other valid first character
                         // for an identifier
                         ) {
                    // TODO: scan an identifier into the buffer
                    int bufIndex = 0;
                    do
                    {
                        //Console.Write((char)ch);
                        buf[bufIndex] = (char)ch;
                        ch = In.Read();
                        bufIndex++;
                    } while ((char)ch != ' ');
                    return new IdentToken(new String(buf, 0, bufIndex));
                    // make sure that the character following the integer
                    // is not removed from the input stream

                }
    
                // Illegal character
                else
                {
                    Console.Error.WriteLine("Illegal input character '"
                                            + (char)ch + '\'');
                    return getNextToken();
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("IOException: " + e.Message);
                return null;
            }
        }
    }

}

