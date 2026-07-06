using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    [SerializeField] GameObject clone = null;

    private Dictionary<Panel, GameObject> dictionary = new Dictionary<Panel, GameObject>();

    public void Open(Panel panel)
    {
        if (dictionary.TryGetValue(panel, out clone) == false)
        {
            Debug.Log($"[PanelManager] 로드 시도 중인 panel 값: '{panel}'");
            clone = (GameObject)Instantiate(Resources.Load(panel.ToString()));


            clone.name = clone.name.Replace("(Clone)", " ");

            dictionary.Add(panel, clone);

            DontDestroyOnLoad(clone);
        }
        else
        {
            clone = dictionary[panel];

            clone.SetActive(true);
        }
    }

    public void Open(Panel panel, string message)
    {
        if(dictionary.TryGetValue(panel, out clone) == false)
        {
            clone = (GameObject)Instantiate(Resources.Load(panel.ToString()));

            clone.name = clone.name.Replace("(Clone)", " ");

            dictionary.Add(panel, clone);

            DontDestroyOnLoad(clone);
        }
        else
        {
            clone = dictionary[panel];

            clone.SetActive(true);
        }

        clone.GetComponent<ErrorPanel>().SetMessage(message);   
    }
}
