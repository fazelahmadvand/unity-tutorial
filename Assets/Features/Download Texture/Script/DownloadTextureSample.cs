using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DownloadTextureSample : MonoBehaviour
{
    [Multiline][SerializeField] private string pictureUrl;
    [Header("UI Elements")]
    [SerializeField] private RawImage rawImage;
    [SerializeField] private Image img;

    public async void DownloadAndShowTexture()
    {
        var texture = await DownloadTexture();
        if (texture != null)
        {
            //set texture in raw image
            rawImage.texture = texture;

            //convert texture to sprite and set it in image
            Vector2 pivot = new Vector2(texture.width, texture.height) / 2;
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), pivot);
            img.sprite = sprite;

        }
    }

    private async Task<Texture2D> DownloadTexture()
    {
        var req = UnityWebRequestTexture.GetTexture(pictureUrl);
        req.SendWebRequest();
        while (!req.isDone)
            await Task.Yield();
        if (req.result == UnityWebRequest.Result.Success)
        {
            var texture = DownloadHandlerTexture.GetContent(req);
            return texture;
        }
        else
        {
            Debug.LogError($"Cant Dwonload Texture {req.error}");
            return null;
        }
    }

}
