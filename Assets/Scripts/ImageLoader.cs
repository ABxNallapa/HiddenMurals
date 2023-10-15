using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Texture2D loadTexture = Resources.Load("blank") as Texture2D;
    }
}
