using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{

    private Image panel;
    void Awake()
    {
        
        panel = GetComponent<Image>();
        panel.CrossFadeAlpha(0.0f, 0.0f, true);
        // Use this for initialization

    }

    void Start()
    {
        panel.CrossFadeAlpha(1.0f, 3.0f, false);
        // Use this for initialization

    }
}
