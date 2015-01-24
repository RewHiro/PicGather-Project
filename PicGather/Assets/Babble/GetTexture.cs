using UnityEngine;
using System.Collections;

public class GetTexture : MonoBehaviour
{
    
    [SerializeField,Range(0, 100)]
    private float offset = 0;
    
    public CreateTextureByCamera Target;

    void Update()
    {
        renderer.material.mainTexture = Target.Screenshot;
    }
}