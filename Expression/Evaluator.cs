namespace Expression
{
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
}

