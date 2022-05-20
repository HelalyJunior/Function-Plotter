using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;



public class UpdateImage : MonoBehaviour
{
    Texture2D new_texture;
    bool b = false;


    void Start()
    {
    }

    IEnumerator load_images()
    {
            var FullPath = Directory.GetCurrentDirectory() + "\\plt.png";
            using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(FullPath))
            {
                yield return uwr.SendWebRequest();

                if (uwr.isNetworkError || uwr.isHttpError)
                {
                    Debug.Log("Cannot find images!");
                    Debug.Log(uwr.error);
                }
                else
                {
                    this.new_texture = DownloadHandlerTexture.GetContent(uwr);
                    this.GetComponent<UnityEngine.UI.RawImage>().texture = this.new_texture;
                    b = true;

                }
        }
    }


    // Update is called once per frame
    void Update()
    {
        StartCoroutine(load_images());
        if (b)
            this.enabled = false;
    }

}
