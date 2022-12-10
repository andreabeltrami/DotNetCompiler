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
                        listaToken.Add(new Token(TipoToken.Numero, ultimoNumero));
                        ultimoNumero = string.Empty;
                    }

                    if (charCorrente == '+')
                        listaToken.Add(new Token(TipoToken.Piu, charCorrente.ToString()));
                    if (charCorrente == '-')
                        listaToken.Add(new Token(TipoToken.Meno, charCorrente.ToString()));
                    if (charCorrente == '*')
                        listaToken.Add(new Token(TipoToken.Per, charCorrente.ToString()));
                    if (charCorrente == '/')
                        listaToken.Add(new Token(TipoToken.Diviso, charCorrente.ToString()));
                    if (charCorrente == '(')
                        listaToken.Add(new Token(TipoToken.ApertaParentesi, charCorrente.ToString()));
                    if (charCorrente == ')')
                        listaToken.Add(new Token(TipoToken.ChiusaParentesi, charCorrente.ToString()));
                }

                if (fineFile)
                {
                    listaToken.Add(new Token(TipoToken.FineFile, ""));
                    break;
                }


                posizione++;
            }

            return listaToken;
        }
    }
}

