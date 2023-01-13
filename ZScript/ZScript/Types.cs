namespace MSharp
{
    public enum TokenType
    {
        ILLEGAL,
        EOF,

        // Identifiers + DataTypes
        IDENT, // add, foobar, x, y, ...
        VAR,
        INT,
        STRING,
        BOOL,

        // Operators
        ASSIGN,
        PLUS,
        MINUS,
        BANG,
        ASTERISK,
        SLASH,
        MODULO,

        MULTI,
        DIV,
        MODULEQ,

        ADD,
        SUB,

        LT,
        GT,
        LTE,
        GTE,

        EQ,
        NEQ,

        // Delimiters
        COMMA,
        COLON,
        QUOTE,

        // Keywords
        FUNCTION,
        USE,
        TRUE,
        FALSE,
        IF,
        ELSE,
        FOR,
        WHILE,
        FOREACH,
        RETURN
    }


    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString()
        {
            return $"Type: {Type}, value: {Value}";

        }

        public class Function
        {
            public List<string> Parameters { get; }
            public List<Token> Code { get; }

            public Function(List<string> parameters, List<Token> code)
            {
                Parameters = parameters;
                Code = code;
            }
        }

        public class Variable
        {
            public object VarValue { get; }

            public Variable(object value)
            {
                VarValue = value;
            }
        }

        public enum ValueType
        {
            STRING,
            INT,
            DOUBLE,
            BOOL,
            NULL
        }
    }
}