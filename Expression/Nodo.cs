namespace Expression
{
    public class Nodo
    {
        private Nodo _sinistra;
        private Nodo _destra;
        private Token _token;

        public Nodo(Token token)
        {
            Token = token;
        }

        public Nodo(Nodo sinistra, Token token, Nodo destra)
        {
            Token = token;
            Sinistra = sinistra;
            Destra = destra;
        }

        public Nodo Sinistra { get => _sinistra; set => _sinistra = value; }
        public Nodo Destra { get => _destra; set => _destra = value; }
        public Token Token { get => _token; set => _token = value; }
    }
}

