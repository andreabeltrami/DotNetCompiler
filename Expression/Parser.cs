namespace Expression
{
    public class Parser
    {
        private int _posizione = 0;
        private List<Token> _tokens = new List<Token>();
        Dictionary<TipoToken, int> _dizionarioPriorità = new Dictionary<TipoToken, int>
        {
            { TipoToken.Piu, 1},
            { TipoToken.Meno, 1},
            { TipoToken.Per, 2},
            { TipoToken.Diviso, 2},
            { TipoToken.ApertaParentesi, 3},
            { TipoToken.ChiusaParentesi, 3},
        };

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;

        }

        public Nodo GetNodo(int prioritàCorrente = 0)
        {
            Nodo sinistra = new Nodo(LeggiToken());
            while (true)
            {
                int precedenza = GetPriority(Corrente.TipoToken);
                if (precedenza == 0 || precedenza <= prioritàCorrente)
                    break;

                Token token = LeggiToken();
                Nodo destra = GetNodo(precedenza);
                sinistra = new Nodo(sinistra, token, destra);
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

