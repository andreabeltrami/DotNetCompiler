namespace Expression
{
    public class Token
    {
        private TipoToken _tipoToken;
        private string _text;

        public Token(TipoToken tipoToken, string text)
        {
            TipoToken = tipoToken;
            Text = text;
        }

        public bool IsOperator()
        {
            switch (_tipoToken)
            {
                case TipoToken.Piu:
                case TipoToken.Meno:
                case TipoToken.Per:
                case TipoToken.Diviso:
                    return true;
            }

            return false;
        }

        public TipoToken TipoToken { get => _tipoToken; set => _tipoToken = value; }
        public string Text { get => _text; set => _text = value; }
    }
}

