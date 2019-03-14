using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContinueTextColorChange : MonoBehaviour
{
    public GameObject ButtonText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<Button>().interactable == false)
        {
            ButtonText.GetComponent<TextMeshProUGUI>().color = new Color32(200, 200, 200, 255);
        }
        else
        {
            ButtonText.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
        }
    }
}
