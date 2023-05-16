using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGLoadScriptTsubasa : MonoBehaviour
{
    public Sprite[] koma;

    void Start()
    {
        koma = Resources.LoadAll<Sprite>("Images/koma");
    }

    void Update()
    {
        
    }
}
