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
        };

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;

        }

        public EspressioneBase GetEspressione(int prioritàCorrente = 0)
        {
            EspressioneBase sinistra = GetEspressionePrimaria();
           
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

        public EspressioneBase GetEspressionePrimaria()
        {
            if (Corrente.TipoToken == TipoToken.ApertaParentesi)
            {
                var openPar = LeggiToken();
                var espressioneParentesi = GetEspressione();
                var closePars = LeggiToken();
                return new EspressioneParentesi(openPar, espressioneParentesi, closePars);

            }

            return new EspressioneLetterale(LeggiToken());
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

