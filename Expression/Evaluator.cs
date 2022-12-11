namespace Expression
{
    public class Evaluator
    {
        EspressioneBase _nodo;
        public Evaluator(EspressioneBase nodo)
        {
            _nodo = nodo;
        }

        public object Evaluate()
        {
            return EvaluateNodo(_nodo);
        }

        private object EvaluateNodo(EspressioneBase espressione)
        {
            if (espressione is EspressioneParentesi p)
                return EvaluateNodo(p.Espressione);


            if (espressione is EspressioneUnaria u)
            {
                if (u.Operando.TipoToken == TipoToken.Minus)
                    return -(int)EvaluateNodo(u.Espressione);
                return EvaluateNodo(u.Espressione);
            }
          
            if (espressione is EspressioneBinaria b)
            {
                var resultSinistra = EvaluateNodo(b.Sinistra);
                var resultDestra = EvaluateNodo(b.Destra);

                switch (b.Operatore.TipoToken)
                {
                    case TipoToken.Plus:
                        return (int)resultSinistra + (int)resultDestra;
                    case TipoToken.Minus:
                        return (int)resultSinistra - (int)resultDestra;
                    case TipoToken.Star:
                        return (int)resultSinistra * (int)resultDestra;
                    case TipoToken.Slash:
                        return (int)resultSinistra / (int)resultDestra;
                    case TipoToken.EqualsEquals:
                        return resultSinistra.Equals(resultDestra);
                    case TipoToken.NotEquals:
                        return !resultSinistra.Equals(resultDestra);
                }

            }
            if (espressione is EspressioneLetterale n)
                return n.Value;
            
            
               

            return null;
        }
    }
}

