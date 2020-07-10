using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLock : MonoBehaviour
{
    [SerializeField] private Vector3 forward = Vector3.forward;
    [SerializeField] private Vector3 up = Vector3.up;
    [SerializeField] private Vector3 scale = Vector3.one;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(forward, up) ;
    }
}
