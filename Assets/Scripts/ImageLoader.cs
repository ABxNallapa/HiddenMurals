using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{

    private API api;
    private ImageConverter converter;
    private Image image;


    // Start is called before the first frame update
    void Start()
    {
        api = new API();
        converter = new ImageConverter();
        image = GetComponent<Image>();

        StartCoroutine(api.GetImg(State.locationId, (webRequest) => {
            if (webRequest.result == UnityEngine.Networking.UnityWebRequest.Result.Success) {
                string response = webRequest.downloadHandler.text.ToString();
                string data = response.Substring(10, response.Length - 10 - 3 - 1);

                Texture2D tex = converter.StringToTexture2d(data);
                // image.material.mainTexture = tex;
                Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.one * 0.5f);

                // Assign the new Sprite to the Image component.
                image.sprite = sprite;
            } else {
                Debug.LogError("Failed To Get Image.");
            }
        }));
    }
}

class RespData
{
    public string data;
}
