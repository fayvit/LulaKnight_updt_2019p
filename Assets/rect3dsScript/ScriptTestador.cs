using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScriptTestador : MonoBehaviour
{
    [SerializeField] private InputTextDoCriandoNovoJogo input = default;

    private void Start()
    {
        SaveDatesManager.s.SavedGames = new List<SaveDates>();
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            input.Iniciar();
        }
    }
}
