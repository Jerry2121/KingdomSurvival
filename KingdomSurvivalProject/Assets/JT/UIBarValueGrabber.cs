using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBarValueGrabber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateHealthBarText()
    {
        GetComponent<TextMeshProUGUI>().text = "Health: " + GetComponentInParent<Slider>().value + "%";
        Debug.Log("Changed Health Text Completed Sucessfully!");
    }
    public void UpdateStaminaBarText()
    {
        GetComponent<TextMeshProUGUI>().text = "Stamina: " + GetComponentInParent<Slider>().value + "%";
        Debug.Log("Changed Stamina Text Completed Sucessfully!");
    }
}
