using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour {

    public new string name;

    private void OnEnable()
    {
        Debug.Log(name + " OnEnable");
    }

    private void OnDisable()
    {
        Debug.Log(name + " OnDisable");
    }
}
