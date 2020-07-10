using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AutoSetCamForCanvas : MonoBehaviour
{
    private Canvas C;
    private bool foi;
    // Start is called before the first frame update
    void Start()
    {
        C = GetComponent<Canvas>();
        Invoke("SetarCamera", .25f);
    }

    void SetarCamera()
    {
        if (Camera.main)
        {
            C.worldCamera = Camera.main;
            foi = true;
        }

        if(!foi)
            Invoke("SetarCamera", .25f);

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
