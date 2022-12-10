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
            if (nodo.Sinistra is not null)
                PrettyPrint(nodo.Sinistra, indent);
            if (nodo.Destra is not null)
                PrettyPrint(nodo.Destra, indent);

        }
    }
}

