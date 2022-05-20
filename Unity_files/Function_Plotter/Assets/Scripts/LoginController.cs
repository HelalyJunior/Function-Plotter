using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{

    bool digit;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("name").Length>0)
            SceneManager.LoadScene("MainScene");
    }

    public void getName()
    {
        string name = GameObject.FindGameObjectWithTag("name").GetComponent<UnityEngine.UI.Text>().text;
        foreach(char c in name)
        {
            if(char.IsDigit(c))
                digit= true;
        }
        if (name.Length>0 && !digit)
        {
            PlayerPrefs.SetString("name",name );
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            GameObject.FindGameObjectWithTag("name_label").GetComponent<UnityEngine.UI.Text>().color = Color.red;
        }
        digit = false;

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
