namespace Expression
{
    public class EspressioneLetterale: EspressioneBase
    {
        private Token _tokenLetterale;

        public EspressioneLetterale(Token tokenLetterale)
        {
            _tokenLetterale = tokenLetterale;
        }

        public Token TokenLetterale => _tokenLetterale;
        public override TipoToken TipoToken => TipoToken.EspressioneLetterale;

        public override IEnumerable<TokenBase> GetFigli()
        {
            yield return _tokenLetterale;
        }
    }
}

