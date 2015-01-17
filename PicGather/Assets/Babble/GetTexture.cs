using UnityEngine;
using System.Collections;

public class GetTexture : MonoBehaviour
{

    public CreateTextureByCamera Target;

    void Update()
    {
        renderer.material.mainTexture = Target.Screenshot;
    }
}