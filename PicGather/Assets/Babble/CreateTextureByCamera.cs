using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class CreateTextureByCamera : MonoBehaviour {

    public Texture2D Screenshot { get; private set; }

    [Range(1, 5)]
    public int TextureScale = 1;

    void Awake()
    {
        int width = Screen.width / TextureScale;
        int height = Screen.height / TextureScale;
        Screenshot = new Texture2D(width, height, TextureFormat.RGB24, false);
        this.camera.fieldOfView = 40;

    }

    void OnPostRender()
    {
        Screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        Screenshot.Apply();
    }

    void OnDestroy()
    {
        Destroy(Screenshot);
    }
}
