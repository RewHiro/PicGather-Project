using UnityEngine;
using System.Collections;

public class GetTexture : MonoBehaviour
{
    
    public CreateTextureByCamera Target;

    void Start()
    {
    }

    void Update()
    {
        GetComponent<Renderer>().material.mainTexture = Target.Screenshot;
    }
}