using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace MapConstructor
{
    public class MapInfos
    { 
        public static string ThisMapID 
        { 
            get => "mapID_" + SceneManager.GetActiveScene().name + SaveDatesManager.s.IndiceDoJogoAtualSelecionado; 
        }
    }
}
