using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapConstructor
{
    [System.Serializable]
    public struct LimitantesDeMapa:IComparer<LimitantesDeMapa>
    {
        public int xMin;
        public int xMax;
        public int yMin;
        public int yMax;

        public int X_Variation { get { return xMax - xMin; } }
        public int Y_Variation { get { return yMax - yMin; } }

        public int Compare(LimitantesDeMapa x, LimitantesDeMapa y)
        {
            return Mathf.Abs(x.xMax - y.xMax) + Mathf.Abs(x.xMin - y.xMin) + Mathf.Abs(x.yMax - y.yMax) + Mathf.Abs(x.yMin - y.yMin);
        }

        public static LimitantesDeMapa Expansive(LimitantesDeMapa L1, LimitantesDeMapa L2)
        {
            return new LimitantesDeMapa
            {
                xMin = Mathf.Min(L1.xMin, L2.xMin),
                yMin = Mathf.Min(L1.yMin, L2.yMin),
                xMax = Mathf.Max(L1.xMax, L2.xMax),
                yMax = Mathf.Max(L1.yMax, L2.yMax),
            };
        }
    }
}
