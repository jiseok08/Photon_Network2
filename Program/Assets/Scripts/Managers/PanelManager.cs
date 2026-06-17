using System.Collections.Generic;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    [SerializeField] GameObject clone = null;

    private Dictionary<Panel, GameObject> list = new Dictionary<Panel, GameObject>();

    public void Open(string message)
    {
        Debug.Log(message);
    }
}
