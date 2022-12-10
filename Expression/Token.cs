namespace Expression
{
    public class Token: TokenBase
    {
        private TipoToken _tipoToken;
        private string _text;

        public Token(TipoToken tipoToken, string text)
        {
            _tipoToken = tipoToken;
            _text = text;
        }

        public bool IsOperator()
        {
            switch (_tipoToken)
            {
                case TipoToken.Plus:
                case TipoToken.Minus:
                case TipoToken.Star:
                case TipoToken.Slash:
                    return true;
            }

            return false;
        }

        public override IEnumerable<TokenBase> GetFigli()
        {
            return new List<TokenBase>();
        }

        public override TipoToken TipoToken => _tipoToken;
        public string Text => _text;
    }
}

