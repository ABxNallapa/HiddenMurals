using System;
using UnityEngine;

public class ImageConverter
{
    public string Texture2dToString(Texture2D texture2D)
    {
        byte[] byteArray = texture2D.EncodeToPNG();
        string result = System.Convert.ToBase64String(byteArray);
        return result;
    }

    public Texture2D StringToTexture2d(string base64String)
    {
        byte[] byteArray = System.Convert.FromBase64String(base64String);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(byteArray);
        return tex;
    }
}
