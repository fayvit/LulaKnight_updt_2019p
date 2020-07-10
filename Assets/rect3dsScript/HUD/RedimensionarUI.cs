using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RedimensionarUI
{
    public static void NaVertical(RectTransform redimensionado, GameObject item, int num)
    {
        redimensionado.sizeDelta
            = new Vector2(0, num * item.GetComponent<LayoutElement>().preferredHeight);
    }

    public static void NaHorizontal(RectTransform redimensionado, GameObject item, int num)
    {
        redimensionado.sizeDelta
            = new Vector2( num * item.GetComponent<LayoutElement>().preferredWidth,0);
    }

    public static void EmGrade(RectTransform redimensionado, GameObject item, int num)
    {
        LayoutElement lay = item.GetComponent<LayoutElement>();
        GridLayoutGroup grid = redimensionado.GetComponent<GridLayoutGroup>();

        float outlineLength = 0;
        Outline O = item.GetComponent<Outline>();

        if (O!= null)
            outlineLength = O.effectDistance.x;
        
        int quantidade = Mathf.CeilToInt((redimensionado.rect.width-grid.padding.left-grid.padding.right) / (grid.cellSize.x + grid.spacing.x +2*outlineLength));

        Debug.Log("Redimensionar grade: " + num + " :" + quantidade + ": " + (grid.cellSize.x + grid.spacing.y) + " : " + redimensionado.rect.width);
        int numeroDeLinhas = Mathf.CeilToInt((float)(num) / (quantidade));
        redimensionado.sizeDelta
                    = new Vector2(redimensionado.sizeDelta.x, numeroDeLinhas * (grid.cellSize.x + grid.spacing.x + 2 * outlineLength ));

    }
}

public enum TipoDeRedimensionamento
{
    vertical,
    emGrade,
    horizontal
}