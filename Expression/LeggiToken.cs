namespace Expression
{
    public class LeggiToken
    {
        public static List<Token> Leggi(string stringa)
        {
            List<Token> listaToken = new List<Token>();

            int posizione = 0;
            string ultimoNumero = "";

            while (true)
            {
                char charCorrente = '0';
                bool fineFile = posizione > (stringa.Length - 1);

                if (!fineFile)
                    charCorrente = stringa[posizione];

                if (!fineFile && char.IsDigit(charCorrente))
                {
                    ultimoNumero += charCorrente;
                }
                else
                {
                    if (!string.IsNullOrEmpty(ultimoNumero))
                    {
                        listaToken.Add(new Token(TipoToken.Number, ultimoNumero));
                        ultimoNumero = string.Empty;
                    }

                    if (charCorrente == '+')
                        listaToken.Add(new Token(TipoToken.Plus, charCorrente.ToString()));
                    if (charCorrente == '-')
                        listaToken.Add(new Token(TipoToken.Minus, charCorrente.ToString()));
                    if (charCorrente == '*')
                        listaToken.Add(new Token(TipoToken.Star, charCorrente.ToString()));
                    if (charCorrente == '/')
                        listaToken.Add(new Token(TipoToken.Slash, charCorrente.ToString()));
                    if (charCorrente == '(')
                        listaToken.Add(new Token(TipoToken.ApertaParentesi, charCorrente.ToString()));
                    if (charCorrente == ')')
                        listaToken.Add(new Token(TipoToken.ChiusaParentesi, charCorrente.ToString()));
                }

                if (fineFile)
                {
                    listaToken.Add(new Token(TipoToken.EndOfFile, ""));
                    break;
                }


                posizione++;
            }

            return listaToken;
        }
    }
}

