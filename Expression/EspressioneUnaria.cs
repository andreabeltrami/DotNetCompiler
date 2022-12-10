namespace Expression
{
    public class EspressioneUnaria : EspressioneBase
    {
        private Token _operando;
        private EspressioneBase _espressione;

        public EspressioneUnaria(Token operando, EspressioneBase espressione)
        {
            _operando = operando;
            _espressione = espressione;
        }

        public Token Operando => _operando;

        public EspressioneBase Espressione => _espressione;
        public override TipoToken TipoToken => TipoToken.EspressioneUnaria;

        public override IEnumerable<TokenBase> GetFigli()
        {
            yield return _operando;
            yield return _espressione;
        }
    }
}

