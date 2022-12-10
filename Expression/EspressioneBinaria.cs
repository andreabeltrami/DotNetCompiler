namespace Expression
{
    public class EspressioneBinaria : EspressioneBase
    {
        private EspressioneBase _sinistra;
        private Token _operatore;
        private EspressioneBase _destra;


        public EspressioneBinaria(EspressioneBase sinistra, Token operatore, EspressioneBase destra)
        {
            _sinistra = sinistra;
            _operatore = operatore;
            _destra = destra;
        }

        public EspressioneBase Sinistra => _sinistra;
        public Token Operatore => _operatore;
        public EspressioneBase Destra => _destra;

        public override TipoToken TipoToken => TipoToken.EspressioneBinaria;
        public override IEnumerable<TokenBase> GetFigli()
        {
            yield return _sinistra;
            yield return _operatore;
            yield return _destra;

        }
    }
}

