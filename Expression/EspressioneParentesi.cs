namespace Expression
{
    public class EspressioneParentesi : EspressioneBase
    {
        private Token _apertaParentesi;
        private EspressioneBase _espressione;
        private Token _chiusaParentesi;

        public EspressioneParentesi(Token apertaParentesi, EspressioneBase espressione, Token chiusaParentesi)
        {
            _apertaParentesi = apertaParentesi;
            _espressione = espressione;
            _chiusaParentesi = chiusaParentesi;
        }

        public EspressioneBase Espressione => _espressione;
        public override TipoToken TipoToken => TipoToken.EspressioneUnaria;

        public override IEnumerable<TokenBase> GetFigli()
        {
            yield return _apertaParentesi;
            yield return _espressione;
            yield return _chiusaParentesi;
        }
    }
}

