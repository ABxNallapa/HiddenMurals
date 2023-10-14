using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        string path = Application.dataPath + "/Materials/ScreenshotSave.png";
        print(path);
        byte[] bytes = System.IO.File.ReadAllBytes(path);
        print(bytes);

        Texture2D loadTexture = new Texture2D(100, 100); //mock size 1x1
        loadTexture.LoadImage(bytes);
        print(loadTexture);
    }
}
