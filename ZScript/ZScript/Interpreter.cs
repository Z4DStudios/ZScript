using MSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZScript
{
    internal class Interpreter
    {
        private Dictionary<string, object> _variables = new Dictionary<string, object>();
        private Token _currentToken;
        private Token _peekToken;
        private int i = 0;
        private Token[] Tokens;

        private Lexer _Lexer;

        public Interpreter(Lexer lexer) 
        {
            _Lexer = lexer;
        }
        
        public void interpret(Token[] tokens)
        {
            Tokens = tokens;
            for (i = 0; i <= Tokens.Length; i++)
            {
                NextToken();
                switch (_currentToken.Type)
                {
                    case TokenType.FUNCTION:

                        break;

                    case TokenType.VAR: // Type: VAR Value: {Name} = or += or -= etc {Value} // wouldnt it be easier if this was just a normal declaration
                        string[] subtokens = _currentToken.Value.Split(' ');
                        DeclareVar(subtokens[0].Remove('{').Remove('}'), subtokens[1], subtokens[2].Remove('{').Remove('}'));
                        break;

                    case TokenType.IF:
                        break;

                    case TokenType.FOR:
                        break;

                    case TokenType.WHILE:
                        break;

                    case TokenType.FOREACH:
                        break;
                }
            }
        }

        private void DeclareVar(string name, string operand, object value)
        {
            if (operand != "=")
            {
                switch (operand)
                {
                    case "+=": // add ret: number, string
                        break;
                    case "-=": // sub ret: number, string
                        break;
                    case "%=": // modoleq ret: number
                        break;
                    case "!=": // neq ret: bool
                        break;
                    case "==": // eq ret: bool
                        break;
                    case "*=": // multi ret: number
                        break;
                    case "/=": // div ret: number
                        break;
                }
            }
            else if (_variables.ContainsKey(name)) _variables[name] = value;
            else _variables.Add(name, value);

        }

        private void NextToken()
        {
            i++; _currentToken = Tokens[i--]; _peekToken = Tokens[i];
        }
        private void JumpToken(int count)
        {
            i += count; _currentToken = Tokens[count--]; _peekToken = Tokens[count];
        }
    }
}
