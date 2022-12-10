namespace Expression
{
    public class Parser
    {
        private int _posizione = 0;
        private List<Token> _tokens = new List<Token>();
        Dictionary<TipoToken, int> _dizionarioPrioritàBinary = new Dictionary<TipoToken, int>
        {
            { TipoToken.Plus, 1},
            { TipoToken.Minus, 1},
            { TipoToken.Star, 2},
            { TipoToken.Slash, 2},
        };

        Dictionary<TipoToken, int> _dizionarioPrioritàUnary = new Dictionary<TipoToken, int>
        {
            { TipoToken.Plus, 3},
            { TipoToken.Minus, 3},
        };


        public Parser(List<Token> tokens)
        {
            _tokens = tokens;

        }

        public EspressioneBase GetEspressione(int prioritàCorrente = 0)
        {
            EspressioneBase sinistra;
            var precedenzaUnaria = GetPriorityUnaria(Corrente.TipoToken);
            if(precedenzaUnaria != 0 && precedenzaUnaria >= prioritàCorrente)
            {
                var operando = LeggiToken();
                var espression = GetEspressione(precedenzaUnaria);
                sinistra = new EspressioneUnaria(operando, espression);
            }
            else 
            {
                sinistra = GetEspressionePrimaria();
            }
            
           
            while (true)
            {
                int precedenza = GetPriorityBinaria(Corrente.TipoToken);
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

        public int GetPriorityBinaria(TipoToken tipoToken)
        {
            if (_dizionarioPrioritàBinary.ContainsKey(tipoToken))
                return _dizionarioPrioritàBinary[tipoToken];

            return 0;
        }

        public int GetPriorityUnaria(TipoToken tipoToken)
        {
            if (_dizionarioPrioritàUnary.ContainsKey(tipoToken))
                return _dizionarioPrioritàUnary[tipoToken];

            return 0;
        }
    }
}

