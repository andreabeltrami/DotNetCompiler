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

            while (true)
            {
                string ultimoNumero = string.Empty;
                string ultimaKeyword = string.Empty;

                // Leggo valori numerici
                while (!FineFile && char.IsDigit(Corrente))
                {
                    ultimoNumero += Corrente;
                    LeggiCarattere();
                }

                // Leggo le parole
                while (!FineFile && char.IsLetter(Corrente))
                {
                    ultimaKeyword += Corrente;
                    LeggiCarattere();
                }

                if (!string.IsNullOrEmpty(ultimoNumero))
                {
                    listaToken.Add(new Token(TipoToken.Number, ultimoNumero));
                }
                else if (!string.IsNullOrEmpty(ultimaKeyword))
                {
                    if (ultimaKeyword == "true")
                        listaToken.Add(new Token(TipoToken.TrueKeyword, ultimaKeyword));
                    else if (ultimaKeyword == "false")
                        listaToken.Add(new Token(TipoToken.FalseKeyword, ultimaKeyword));
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
                    case '=':
                        if(Prossimo == '=')
                        {
                            listaToken.Add(new Token(TipoToken.EqualsEquals, "=="));
                            LeggiCarattere();
                        }  
                        break;
                    case '!':
                        if (Prossimo == '=')
                        {
                            listaToken.Add(new Token(TipoToken.NotEquals, "!="));
                            LeggiCarattere();
                        }
                        break;
                    case '>':
                        listaToken.Add(new Token(TipoToken.Greater, Corrente.ToString()));
                        break;
                    case '<':
                        listaToken.Add(new Token(TipoToken.Minor, Corrente.ToString()));
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


        private char Prossimo => _input[_posizione + 1];
        private char Corrente => _input[_posizione];
        private bool FineFile => _posizione > (_input.Length - 1);

    }
}

