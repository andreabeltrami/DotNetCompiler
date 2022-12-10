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

                EspressioneBase espressione = parser.GetEspressione();
                PrettyPrint(espressione);

                Evaluator evaluator = new Evaluator(espressione);
                var valore = evaluator.Evaluate();
                Console.WriteLine($"Valore: {valore}");
            }
        }

        public static void PrettyPrint(EspressioneBase espressioneBase, string indent = "")
        {
            if(espressioneBase is EspressioneParentesi p)
            {
                Console.WriteLine($"{indent}{p.TipoToken}");
                indent += "    ";
                PrettyPrint(p.Espressione, indent);
            }
            else if (espressioneBase is EspressioneLetterale n)
                Console.WriteLine($"{indent}{n.TipoToken} {n.TokenLetterale.Text}");
            else if (espressioneBase is EspressioneBinaria b)
            {
                Console.WriteLine($"{indent}{b.TipoToken} {b.Operatore.Text}");
                indent += "    ";
                if (b.Sinistra is not null)
                    PrettyPrint(b.Sinistra, indent);
                if (b.Destra is not null)
                    PrettyPrint(b.Destra, indent);
                
            }
        }
    }
}

