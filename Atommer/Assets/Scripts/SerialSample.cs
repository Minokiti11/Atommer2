using UnityEngine;

public class SerialSample : MonoBehaviour
{
    private SerialPortWrapper _serialPort;

    void Awake()
    {
        _serialPort = new SerialPortWrapper("COM3", 9600);
    }

    private void OnDisable()
    {
        _serialPort.KillThread();
    }

    void OnGUI()
    {
        if (GUILayout.Button("n", GUILayout.Width(200f), GUILayout.Height(60f)))
        {
            _serialPort.Write("1");
        }

        if (GUILayout.Button("f", GUILayout.Width(200f), GUILayout.Height(60f)))
        {
            _serialPort.Write("0");
        }
    }
}