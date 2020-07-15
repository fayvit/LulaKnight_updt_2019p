using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

namespace MapConstructor
{
    public static class SaveMapLimits
    {
        public static void Save(LimitantesDeMapa L)
        {

            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(ms, L);
            preJSON pre = new preJSON() { b = ms.ToArray() };
            
            PlayerPrefs.SetString("dates_map_"+ SaveDatesManager.s.IndiceDoJogoAtualSelecionado, JsonUtility.ToJson(pre));

            PlayerPrefs.Save();

        }

        public static LimitantesDeMapa Load()
        {
            LimitantesDeMapa L = new LimitantesDeMapa();
            
            string S2 = PlayerPrefs.GetString("dates_map_" + SaveDatesManager.s.IndiceDoJogoAtualSelecionado);

            if (!string.IsNullOrEmpty(S2))
            {
                MemoryStream ms = new MemoryStream(JsonUtility.FromJson<preJSON>(S2).b);
                BinaryFormatter bf = new BinaryFormatter();
                L = (LimitantesDeMapa)bf.Deserialize(ms);
                
            }

            return L;
        }
    }
}