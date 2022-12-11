namespace Expression
{
    public class Lexer
    {
        private int _posizione = 0;
        private string _input;

        public Lexer(string input)
        {
            _input = input;
        }

        public  List<Token> Leggi()
        {
            List<Token> listaToken = new List<Token>();
            string ultimoNumero = "";

            while (true)
            {              
                while (!FineFile && char.IsDigit(Corrente))
                {
                    ultimoNumero += Corrente;
                    LeggiCarattere();
                }

                if (!string.IsNullOrEmpty(ultimoNumero))
                {
                    listaToken.Add(new Token(TipoToken.Number, ultimoNumero));
                    ultimoNumero = string.Empty;
                }

                if (FineFile)
                {
                    listaToken.Add(new Token(TipoToken.EndOfFile, ""));
                    break;
                }

                switch (Corrente)
                {
                    case '+':
                        listaToken.Add(new Token(TipoToken.Plus, Corrente.ToString()));
                        break;
                    case '-':
                        listaToken.Add(new Token(TipoToken.Minus, Corrente.ToString()));
                        break;
                    case '*':
                        listaToken.Add(new Token(TipoToken.Star, Corrente.ToString()));
                        break;
                    case '/':
                        listaToken.Add(new Token(TipoToken.Slash, Corrente.ToString()));
                        break;
                    case '(':
                        listaToken.Add(new Token(TipoToken.ApertaParentesi, Corrente.ToString()));
                        break;
                    case ')':
                        listaToken.Add(new Token(TipoToken.ChiusaParentesi, Corrente.ToString()));
                        break;
                }

                LeggiCarattere();

            }

            return listaToken;
        }

        private void LeggiCarattere()
        {
            _posizione++;
        }

        private char Corrente => _input[_posizione];
        private bool FineFile => _posizione > (_input.Length - 1);

    }
}

