namespace Expression
{
    public class Evaluator
    {
        EspressioneBase _nodo;
        public Evaluator(EspressioneBase nodo)
        {
            _nodo = nodo;
        }

        public int Evaluate()
        {
            return EvaluateNodo(_nodo);
        }

        private int EvaluateNodo(EspressioneBase espressione)
        {
            if (espressione is EspressioneUnaria u)
            {
                if (u.Operando.TipoToken == TipoToken.Minus)
                    return -EvaluateNodo(u.Espressione);
                return EvaluateNodo(u.Espressione);

            }
            if (espressione is EspressioneParentesi p)
                return EvaluateNodo(p.Espressione);

            if (espressione is EspressioneBinaria b)
            {
                var resultSinistra = EvaluateNodo(b.Sinistra);
                var resultDestra = EvaluateNodo(b.Destra);

                switch (b.Operatore.TipoToken)
                {
                    case TipoToken.Plus:
                        return resultSinistra + resultDestra;
                    case TipoToken.Minus:
                        return resultSinistra - resultDestra;
                    case TipoToken.Star:
                        return resultSinistra * resultDestra;
                    case TipoToken.Slash:
                        return resultSinistra / resultDestra;
                }

            }
            if (espressione is EspressioneLetterale n)
                return Convert.ToInt32(n.TokenLetterale.Text);

            return 0;
        }
    }
}

