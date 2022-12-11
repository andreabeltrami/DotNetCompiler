namespace Expression
{
    public class EspressioneLetterale: EspressioneBase
    {
        private Token _tokenLetterale;
        private object _value;

        public EspressioneLetterale(Token tokenLetterale, object value)
        {
            _tokenLetterale = tokenLetterale;
            _value = value;
        }

        public object Value => _value;
        public Token TokenLetterale => _tokenLetterale;
        public override TipoToken TipoToken => TipoToken.EspressioneLetterale;

        public override IEnumerable<TokenBase> GetFigli()
        {
            yield return _tokenLetterale;
        }
    }
}

