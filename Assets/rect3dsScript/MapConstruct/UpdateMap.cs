using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapConstructor
{

    public class UpdateMap
    {
        private static LimitantesDeMapa limit;
        public static LimitantesDeMapa Limit
        {
            get { return limit; }
            set {
                //EventAgregator.Publish(new StandardSendGameEvent(EventKey.changeMapLimits, value));
                SaveMapLimits.Save(value);
                limit = value; 
            }
        }
            
            

        public static string FileName { get { return "testeMap" + SaveDatesManager.s.IndiceDoJogoAtualSelecionado; } }

        public static void CriarPngMap(Dictionary<MyVector2Int,MyColor> d)
        {
            LimitantesDeMapa L = CalculaLimitanteMap.Calcula(d);

            Texture2D atualTex = TexturaDeMapaAtual.Get(d);
            Texture2D reservedTex = SaveMap.Carregar(FileName);

            //PasteImageMap(reservedTex, atualTex, L);
            ArrayPasteMap(reservedTex, atualTex, L);

        }
        public static void DeletarPngPixels(Dictionary<MyVector2Int, MyColor> d)
        {
            LimitantesDeMapa L = CalculaLimitanteMap.Calcula(d);
            Texture2D atualTex = TexturaDeMapaAtual.Get(d);
            Texture2D reservedTex = SaveMap.Carregar(FileName);

            if (reservedTex.width > 0 && reservedTex.height > 0)
            {
                Texture2D newTex = new Texture2D(Limit.X_Variation + 1, Limit.Y_Variation + 1);
                TransparentTexture(newTex);

                SetTexture(reservedTex, newTex);

                ClearPixelsInTexture(atualTex,newTex,L,Limit);

                SaveTexture(newTex,Limit);
            }
        }

        static void ClearPixelsInTexture(Texture2D reservedTex, Texture2D newTex,LimitantesDeMapa limit,LimitantesDeMapa newL)
        {

            int starterX = Mathf.Abs(limit.xMin - newL.xMin);
            int starterY = Mathf.Abs(limit.yMin - newL.yMin);

            for (int i = starterX; i < starterX + reservedTex.width; i++)
                for (int j = starterY; j < starterY + reservedTex.height; j++)
                {
                    Color C = reservedTex.GetPixel(i - starterX, j - starterY);
                    if (C.a > 0f)
                        newTex.SetPixel(i, j, new Color(0,0,0,0));
                    
                }

            newTex.Apply();
        }

        private static void SaveTexture(Texture2D atualTex, LimitantesDeMapa newLimit)
        {
            SaveMap.Salvar(atualTex, FileName);
            Limit = newLimit;
            /*
            SpriteRenderer S = GameObject.Find("texTeste").GetComponent<SpriteRenderer>();
            S.sprite = Sprite.Create(atualTex, new Rect(0, 0, atualTex.width, atualTex.height), Vector2.zero);*/
        }

        private static void TransparentTexture(Texture2D t)
        {
            for (int i = 0; i < t.width; i++)
                for (int j = 0; j < t.height; j++)
                    t.SetPixel(i, j, new Color(0, 0, 0, 0));

            t.Apply();
        }

        private static void ArrayPasteMap(Texture2D reservedTex, Texture2D atualTex,LimitantesDeMapa L)
        {
            if (L.Compare(Limit, new LimitantesDeMapa { yMin = 0, yMax = 0, xMin = 0, xMax = 0 }) != 0)
            {
                LimitantesDeMapa newL = ExpandirLimitante(L);
                Texture2D newTex = new Texture2D(newL.X_Variation+1, newL.Y_Variation+1);
                TransparentTexture(newTex);

                SetTexture(newL,Limit, reservedTex,newTex);
                SetTexture(newL,L, atualTex, newTex);

                SaveTexture(newTex, newL);

                MonoBehaviour.Destroy(newTex);
            }
            else
            {
                SaveTexture(atualTex, L);
            }

            MonoBehaviour.Destroy(reservedTex);
            MonoBehaviour.Destroy(atualTex);


        }
        private static void SetTexture(Texture2D reservedTex, Texture2D newTex)
        {
            SetTexture(Limit, Limit, reservedTex, newTex);
        }

        private static void SetTexture(LimitantesDeMapa  newL,LimitantesDeMapa limit,Texture2D reservedTex,Texture2D newTex)
        {
            Color baseColor = newTex.GetPixel(0, 0);

            int starterX = Mathf.Abs(limit.xMin - newL.xMin);
            int starterY = Mathf.Abs(limit.yMin - newL.yMin);

            for (int i = starterX; i < starterX+reservedTex.width; i++)
                for (int j = starterY; j < starterY+reservedTex.height; j++)
                {
                    Color C = reservedTex.GetPixel(i -starterX, j - starterY);
                    if (C.a > 0f)
                        newTex.SetPixel(i, j, C);
                    else if (newTex.GetPixel(i, j) == baseColor)
                    {
                        newTex.SetPixel(i, j, new Color(0, 0, 0, 0));
                    }
                }

            newTex.Apply();
        }

        private static LimitantesDeMapa ExpandirLimitante(LimitantesDeMapa L)
        {
            LimitantesDeMapa retorno;
            if (L.Compare(Limit, new LimitantesDeMapa { yMin = 0, yMax = 0, xMin = 0, xMax = 0 }) != 0)
            {
                retorno = LimitantesDeMapa.Expansive(Limit, L);
            }
            else
            {
                retorno = L;
            }

            return retorno;
        }
    }
}

/* Código não utilizado mas interessante de recordar
        private static void PasteImageMap(Texture2D reservedTex,Texture2D atualTex,LimitantesDeMapa L)
        {
            if (L.Compare(limit, new LimitantesDeMapa { yMin = 0, yMax = 0, xMin = 0, xMax = 0 }) != 0)
            {

                LimitantesDeMapa newL = ExpandirLimitante(L);
                Texture2D newTex = new Texture2D(newL.X_Variation, newL.Y_Variation);

                Graphics.CopyTexture(reservedTex, 0, 0, 0, 0, reservedTex.width, reservedTex.height, newTex, 0, 0,
                    Mathf.Abs(limit.xMin - newL.xMin), Mathf.Abs(limit.yMin - newL.yMin));

                Graphics.CopyTexture(atualTex, 0, 0, 0, 0, atualTex.width, atualTex.height, newTex, 0, 0,
                    Mathf.Abs(limit.xMin - L.xMin), Mathf.Abs(limit.yMin - L.yMin));



                SaveAndShowTexture(newTex, newL);
                
            }
            else
            {
                SaveAndShowTexture(atualTex, L);
            }
        }*/
