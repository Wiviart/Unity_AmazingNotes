using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ConsoleToGUI : MonoBehaviour
{
    private const int kChars = 270000;
    private string myLog = "*begin log";
    private string filename = "";
    [SerializeField] private bool doShow = false;
    [SerializeField] private int wScene = 1920;
    [SerializeField] private int hScene = 1080;
    [SerializeField] private int xPos = 10;
    [SerializeField] private int yPos = 10;
    [SerializeField] private int width = 600;
    [SerializeField] private int height = 400;
    [SerializeField] private int fontSize = 20;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

#if UNITY_EDITOR
        doShow = true;
#endif
    }

    private void OnEnable()
    {
        Application.logMessageReceived += Log;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= Log;
    }

    private void Log(string logString, string stackTrace, LogType type)
    {
        // Time in minutes and seconds
        var time = DateTime.Now.ToString("HH:mm:ss");
        // for onscreen...
        myLog += "\n" + "[" + time + "] " + logString;
        if (myLog.Length > kChars)
        {
            myLog = myLog.Substring(myLog.Length - kChars);
        }

        // for the file ...
        if (filename == "")
        {
            var d = Environment.GetFolderPath(
                Environment.SpecialFolder.Desktop) + "/YOUR_LOGS";
            System.IO.Directory.CreateDirectory(d);
            var r = Random.Range(1000, 9999).ToString();
            filename = d + "/log-" + r + ".txt";
        }

        try
        {
            System.IO.File.AppendAllText(filename, logString + "\n");
        }
        catch
        {
            filename = "";
        }
    }

    private void OnGUI()
    {
        if (!doShow) return;

        var pos = new Vector3(Screen.width / (float)wScene, Screen.height / (float)hScene, 1.0f);
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, pos);

        // Define a custom GUIStyle for the text area
        var textStyle = new GUIStyle(GUI.skin.textArea)
        {
            fontSize = fontSize,
            wordWrap = true
        };

        GUI.TextArea(new Rect(xPos, yPos, width, height), myLog, textStyle);
    }
}