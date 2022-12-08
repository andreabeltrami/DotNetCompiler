
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write(">");
                string stringa = Console.ReadLine();

                var tokens = LeggiToken.Leggi(stringa);
                Parser parser = new Parser(tokens);
                Nodo nodo = parser.GetNodo();

                PrettyPrint(nodo);

                Evaluator evaluator = new Evaluator(nodo);
                var valore = evaluator.Evaluate();
                Console.WriteLine($"Valore: {valore}");
            }
        }

        public static void PrettyPrint(Nodo nodo, string indent = "")
        {
            Console.WriteLine($"{indent}{nodo.Token.TipoToken} {nodo.Token.Text}");
            indent += "    ";
            if(nodo.Sinistra is not null)
                PrettyPrint(nodo.Sinistra, indent);
            if (nodo.Destra is not null)
                PrettyPrint(nodo.Destra, indent);
            
        }
    }


    public class Evaluator
    {
        Nodo _nodo;
        public Evaluator(Nodo nodo)
        {
            _nodo = nodo;
        }

        public int Evaluate()
        {
            return EvaluateNodo(_nodo);
        }

        private int EvaluateNodo(Nodo nodo)
        {

            if (nodo.Token.IsOperator())
            {
                var resultSinistra = EvaluateNodo(nodo.Sinistra);
                var resultDestra = EvaluateNodo(nodo.Destra);

                switch (nodo.Token.TipoToken)
                {
                    case TipoToken.Piu:
                        return resultSinistra + resultDestra;
                    case TipoToken.Meno:
                        return resultSinistra - resultDestra;
                    case TipoToken.Per:
                        return resultSinistra * resultDestra;
                    case TipoToken.Diviso:
                        return resultSinistra / resultDestra;
                }

            }

            if (nodo.Destra is null && nodo.Sinistra is null)
                return Convert.ToInt32(nodo.Token.Text);

            return 0;
        }
    }

    public class Parser
    {
        private Stack<Nodo> _stack = new Stack<Nodo>();
        private int _posizione = 0;
        private List<Token> _tokens = new List<Token>();
        Dictionary<TipoToken, int> _dizionarioPriorità = new Dictionary<TipoToken, int> 
        {
            { TipoToken.Piu, 0},
            { TipoToken.Meno, 0},
            { TipoToken.Per, 1},
            { TipoToken.Diviso, 1},
            { TipoToken.ApertaParentesi, 2},
            { TipoToken.ChiusaParentesi, 2},
        };

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;

        }
        public Nodo GetNodo(int prioritàCorrente = 0)
        {
            while (_posizione < _tokens.Count)
            {
                Token token = _tokens[_posizione];
              
                if (token.IsOperator())
                {
                    if (_dizionarioPriorità[token.TipoToken] < prioritàCorrente)
                        break;

                    _posizione++;

                    Nodo sinistra = _stack.Pop(); 
                    Nodo destra = GetNodo(_dizionarioPriorità[token.TipoToken]);
                    Nodo node = new Nodo(sinistra, token, destra);

                    _stack.Push(node);
                }
                else if(token.TipoToken == TipoToken.Numero)
                {
                    _stack.Push(new Nodo(token));
                    _posizione++;
                }
            }

            return _stack.Peek();
        }

    }

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

    public class LeggiToken
    {
        public static List<Token> Leggi(string stringa)
        {
            List<Token> listaToken = new List<Token>();  
          
            int posizione = 0;
            string ultimoNumero = "";
            
            while(true)
            {
                char charCorrente = '0';
                bool fineFile = posizione > (stringa.Length -1);

                if (!fineFile)
                    charCorrente = stringa[posizione];
       
                if (!fineFile && char.IsDigit(charCorrente))
                {
                    ultimoNumero +=charCorrente;
                }
                else
                {
                    if(!string.IsNullOrEmpty(ultimoNumero))
                    {
                        listaToken.Add(new Token(TipoToken.Numero, ultimoNumero));
                        ultimoNumero = string.Empty;
                    }

                    if(charCorrente == '+')
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
                    //listaToken.Add(new Token(TipoToken.FineFile, ""));
                    break;
                }
                

                posizione++;      
            }

            return listaToken;
        }
    }
    public class Token
    {
        private TipoToken _tipoToken;
        private string _text;

        public Token(TipoToken tipoToken, string text)
        {
            TipoToken = tipoToken;
            Text = text;
        }

        public bool IsOperator()
        {
            switch (_tipoToken)
            {
                case TipoToken.Piu:
                case TipoToken.Meno:
                case TipoToken.Per:
                case TipoToken.Diviso:
                    return true;
            } 

            return false;
        }

        public TipoToken TipoToken { get => _tipoToken; set => _tipoToken = value; }
        public string Text { get => _text; set => _text = value; }
    }
    public enum TipoToken
    {
        Piu, 
        Meno, 
        Per, 
        Diviso,
        Numero,
        ApertaParentesi,
        ChiusaParentesi,
        FineFile
       
    }
}

