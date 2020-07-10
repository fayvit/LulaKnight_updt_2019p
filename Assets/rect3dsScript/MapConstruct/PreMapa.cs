using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using MapConstructor;

public class MapConstruct
{

    private Dictionary<MyVector2Int, MyColor> GetMapDates { get; set; } = new Dictionary<MyVector2Int, MyColor>();

    public Texture2D TexturaDoMapaAtual 
    {
        get { return TexturaDeMapaAtual.Get(GetMapDates); }
    }

    public void DeletarPixelsDoMapa(Tilemap t)
    {
        
        Dictionary<MyVector2Int, MyColor> d = ConstruaMapa(t,new Dictionary<MyVector2Int, MyColor>());

        UpdateMap.DeletarPngPixels(d);

    }

    public void AtualizarMapa()
    {
        
        TilemapCollider2D[] mapCols = GameObject.FindObjectsOfType<TilemapCollider2D>();
        GetMapDates.Clear();
        for (int i = 0; i < mapCols.Length; i++)
        {
            if(!mapCols[i].isTrigger)
                GetMapDates= ConstruaMapa(mapCols[i].GetComponent<Tilemap>(),GetMapDates);
        }

        UpdateMap.CriarPngMap(GetMapDates);

    }

    

    private Dictionary<MyVector2Int, MyColor> ConstruaMapa(Tilemap tilemap, Dictionary<MyVector2Int, MyColor> thisBase)
    {
        BoundsInt area = tilemap.cellBounds;

        Dictionary<MyVector2Int, MyColor> retorno = thisBase;

        for (int col = area.yMax; col >= area.yMin; col--)
        {
            for (int row = area.xMin; row <= area.xMax; row++)
            {
                
                Vector3 V = tilemap.CellToWorld(new Vector3Int(row, col, 0));

                if (tilemap.GetTile(new Vector3Int(row, col, 0)) != null)
                {
                    retorno[new MyVector2Int((int)V.x, (int)V.y)] = new MyColor(Color.black);                  
                    
                }
            }
        }

        return retorno;
    }
}
