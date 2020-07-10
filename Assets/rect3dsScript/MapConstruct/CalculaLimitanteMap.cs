using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapConstructor
{
    public static class CalculaLimitanteMap
    {

        private static LimitantesDeMapa CalculaLimitanteMapBase(Dictionary<MyVector2Int, MyColor> d)
        {
            LimitantesDeMapa L = new LimitantesDeMapa() { xMin = 0, xMax = 0, yMin = 0, yMax = 0 };
            Dictionary<MyVector2Int, MyColor>.KeyCollection.Enumerator z = d.Keys.GetEnumerator();
            z.MoveNext();
            MyVector2Int V = z.Current;
            L = new LimitantesDeMapa() { xMin = V.x, xMax = V.x, yMin = V.y, yMax = V.y };
            return L;
        }

        static LimitantesDeMapa VerificaMudancasDeLimitantes(MyVector2Int V, LimitantesDeMapa L)
        {
            if (L.xMin > V.x)
                L.xMin = V.x;

            if (L.yMin > V.y)
                L.yMin = V.y;

            if (L.xMax < V.x)
                L.xMax = V.x;

            if (L.yMax < V.y)
                L.yMax = V.y;



            return L;
        }

        public static LimitantesDeMapa Calcula(Dictionary<MyVector2Int, MyColor> d)
        {
            LimitantesDeMapa L = CalculaLimitanteMapBase(d);

            Dictionary<MyVector2Int, MyColor>.KeyCollection keys = d.Keys;

            foreach (MyVector2Int V in keys)
            {
                L = VerificaMudancasDeLimitantes(V, L);
            }

            return L;

        }
    }
}