using UnityEngine;
using System.Collections.Generic;

namespace MapConstructor
{
    public static class TexturaDeMapaAtual
    {
        public static Texture2D Get(Dictionary<MyVector2Int, MyColor> d)
        {
            LimitantesDeMapa L = CalculaLimitanteMap.Calcula(d);

            Texture2D tex = new Texture2D(L.X_Variation+1, L.Y_Variation+1);
            for (int row = 0; row <= L.Y_Variation; row++)
                for (int col = 0; col <= L.X_Variation; col++)
                    tex.SetPixel(col, row, CorAlvoMap(row, col, L, d));

            tex.Apply();

            return tex;
        }

        private static Color CorAlvoMap(int row, int col, LimitantesDeMapa L, Dictionary<MyVector2Int, MyColor> d)
        {
            MyVector2Int V = new MyVector2Int(col + L.xMin, row + L.yMin);

            if (d.ContainsKey(V))
            {
                return d[V].cor;
            }

            return new Color(0,0,0,0);
        }
    }
}
