using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Volume>().profile.TryGet<Vignette>(out Vignette vignette);
        vignette.active = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
