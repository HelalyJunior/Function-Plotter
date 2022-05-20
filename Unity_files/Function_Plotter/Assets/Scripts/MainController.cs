using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Diagnostics;


public class MainController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("name_label").GetComponent<UnityEngine.UI.Text>().text+=PlayerPrefs.GetString("name");
    }

    public void LogOut()
    {
        PlayerPrefs.SetString("name", "");
        SceneManager.LoadScene("LoginScene");
    }

    public void getFunction()
    {
        UnityEngine.UI.Text err = GameObject.FindGameObjectWithTag("error").GetComponent<UnityEngine.UI.Text>();
        err.color = Color.red;
        if (GameObject.FindGameObjectWithTag("low").GetComponent<UnityEngine.UI.Text>().text.Length==0 ||
            GameObject.FindGameObjectWithTag("high").GetComponent<UnityEngine.UI.Text>().text.Length==0)
        {
            err.text = "Please Type in correct limits"; return;//error

        }
        int low = int.Parse(GameObject.FindGameObjectWithTag("low").GetComponent<UnityEngine.UI.Text>().text);
        int high = int.Parse(GameObject.FindGameObjectWithTag("high").GetComponent<UnityEngine.UI.Text>().text);

        if(!(high>low))
        {
            err.text = "Please Type in a valid function"; return;//error
        }


        List<char> possible = new List<char>{'x',
        '+',
        '-',
        '*',
        '/',
        '^',
        '1',
        '2',
        '3',
        '4',
        '5',
        '6',
        '7',
        '8',
        '9',
        '0' };

        string func =  GameObject.FindGameObjectWithTag("name").GetComponent<UnityEngine.UI.Text>().text;
        bool hasBroken = false;
        func = func.Replace(" ", "");
        int length = func.Length;

        if(length==0)
        {
            err.text = "Please Type in a valid function"; return;//error

        }


        if (func[0] == '+' || func[0] == '-' || func[0] == '*' || func[0] == '/' || func[0] == '^'||
            func[length-1] == '+' || func[length - 1] == '-' || func[length - 1] == '*' 
            || func[length - 1] == '/' || func[length - 1] == '^')
        {
            err.text="Please Type in a valid function"; return; //error
        }

        foreach (char c in func)
        {
            foreach(char element in possible)
            {
                if (c == element)
                {
                    hasBroken = true;
                    break;
                }
            }
            if (!hasBroken)
            {
                err.text = "The function can only be a function in 'x'"; return;//error
            }
        }

        for(int i=0;i<func.Length-1;i++)
        {
            if(i>0)
            {
                if(func[i]=='x'&& (char.IsDigit(func[i-1])||func[i-1]=='x'))
                {
                    err.text = "Please Type in a valid function"; return;//error
                }
            }
            if(func[i]=='+' || func[i] == '-' || func[i] == '*' || func[i] == '/' || func[i] == '^')
            {
                if(func[i+1] == '+' || func[i+1] == '-' || func[i+1] == '*' || func[i+1] == '/' || func[i+1] == '^')
                {
                    err.text = "Please Type in a valid function"; return; //error
                }
            }
        }

        if (func[length-1] == 'x' && (char.IsDigit(func[length - 2]) || func[length-2] == 'x'))
        {
            err.text = "Please Type in a valid function , you should add '*' "; return;//error
        }

        using (StreamWriter writer = new StreamWriter(@"func.txt"))
        {
            writer.AutoFlush = true;
            writer.Write(func);
            writer.Close();
        }
        using (StreamWriter writer = new StreamWriter(@"limits.txt"))
        {
            writer.AutoFlush = true;
            writer.WriteLine(low);
            writer.Write(high);
            writer.Close();
        }
        Process cmd = new Process();
        cmd.StartInfo.FileName = @"plotter.exe";
        cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        cmd.Start();
        SceneManager.LoadScene("finalScene");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
