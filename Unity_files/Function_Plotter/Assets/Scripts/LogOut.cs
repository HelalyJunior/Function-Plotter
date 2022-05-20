using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;


public class LogOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Logout()
    {
        PlayerPrefs.SetString("name", "");
        File.Delete(@"plt.png");
        SceneManager.LoadScene("LoginScene");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
