namespace Expression
{
    public class Parser
    {
        private int _posizione = 0;
        private List<Token> _tokens = new List<Token>();
        Dictionary<TipoToken, int> _dizionarioPriorità = new Dictionary<TipoToken, int>
        {
            { TipoToken.Plus, 1},
            { TipoToken.Minus, 1},
            { TipoToken.Star, 2},
            { TipoToken.Slash, 2},
            { TipoToken.ApertaParentesi, 3},
            { TipoToken.ChiusaParentesi, 3},
        };

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;

        }

        public EspressioneBase GetEspressione(int prioritàCorrente = 0)
        {
            EspressioneBase sinistra = new EspressioneLetterale(LeggiToken());
           
            while (true)
            {
                int precedenza = GetPriority(Corrente.TipoToken);
                if (precedenza == 0 || precedenza <= prioritàCorrente)
                    break;

                Token token = LeggiToken();
                EspressioneBase destra = GetEspressione(precedenza);
                sinistra = new EspressioneBinaria(sinistra, token, destra);
            }
            return sinistra;
        }
        public Token Corrente => _tokens[_posizione];

        public Token LeggiToken()
        {
            var token = Corrente;
            _posizione++;
            return token;
        }

        public int GetPriority(TipoToken tipoToken)
        {
            if (_dizionarioPriorità.ContainsKey(tipoToken))
                return _dizionarioPriorità[tipoToken];

            return 0;
        }
    }
}

