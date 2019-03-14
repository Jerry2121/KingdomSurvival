using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{


    public class PlayerSetup : MonoBehaviour
    {
        public Slider PlayerHealthBar;
        public GameObject PlayerHealthBarText;
        public Slider PlayerStaminaBar;
        public GameObject PlayerStaminaBarText;
        public float Health;
        private float Stamina = 100;
        private bool moving;
        private float prevStamina;
        private float prevHealth;
        // Start is called before the first frame update
        void Start()
        {
            prevHealth = Health;
            Debug.Log("Previous Health Has Been Set. The Previous Health is " + prevHealth);
            prevStamina = Stamina;
            Debug.Log("Previous Stamina Has Been Set. The Previous Stamina is " + prevStamina);
            GetComponent<RigidbodyFirstPersonController>().movementSettings.stamina = Stamina;
        }

        // Update is called once per frame
        void Update()
        {
            if (GetComponent<RigidbodyFirstPersonController>().movementSettings.stamina < Stamina || GetComponent<RigidbodyFirstPersonController>().movementSettings.stamina > Stamina)
            {
                Stamina = GetComponent<RigidbodyFirstPersonController>().movementSettings.stamina;
            }
            if (GetComponent<RigidbodyFirstPersonController>().movementSettings.staminarechargetimer >= 0)
            {
                GetComponent<RigidbodyFirstPersonController>().movementSettings.staminarechargetimer -= Time.deltaTime;
                    if (GetComponent<RigidbodyFirstPersonController>().movementSettings.staminarechargetimer <= 0 && GetComponent<RigidbodyFirstPersonController>().movementSettings.stamina < 100)
                    {
                    GetComponent<RigidbodyFirstPersonController>().movementSettings.stamina += Time.deltaTime * 10;
                    GetComponent<RigidbodyFirstPersonController>().movementSettings.staminarechargetimer = 0;
                    }
                    else if (GetComponent<RigidbodyFirstPersonController>().movementSettings.stamina > 0)
                    {
                    GetComponent<RigidbodyFirstPersonController>().movementSettings.CanRun = true;
                    }
                    else if (Input.GetKey(KeyCode.LeftShift))
                {
                    GetComponent<RigidbodyFirstPersonController>().movementSettings.CanRunRecharge = false;
                    if (GetComponent<RigidbodyFirstPersonController>().movementSettings.stamina > 0)
                    {
                        GetComponent<RigidbodyFirstPersonController>().movementSettings.CanRun = true;
                    }
                }
            }
            //Health Bar Update and Caps
            if (Health > 100)
            {
                Debug.Log("Health went above the max health which is 100, resetting it back to 100");
                Health = 100;
                PlayerHealthBar.value = Health;
            }
            else if (Health < 0)
            {
                Debug.Log("Healht went below the min health which is 0, resetting it back to 0");
                Health = 0;
                PlayerHealthBar.value = Health;
            }
            if (Health < prevHealth || Health > prevHealth)
            {
                Debug.Log("Health isn't the same as the previous health! Running the update health bar text function!!");
                prevHealth = Health;
                PlayerHealthBar.value = Health;
                PlayerHealthBarText.GetComponent<UIBarValueGrabber>().UpdateHealthBarText();
            }
            //Stamina Bar Update and Caps
            if (Stamina > 100)
            {
                Debug.Log("Stamina went above the max stamina which is 100, resetting it back to 100");
                Stamina = 100;
                GetComponent<RigidbodyFirstPersonController>().movementSettings.stamina = 100;
                PlayerStaminaBar.value = Stamina;
            }
            else if (Stamina < 0)
            {
                Debug.Log("Stamina went below the min stamina which is 0, resetting it back to 0");
                Stamina = 0;
                GetComponent<RigidbodyFirstPersonController>().movementSettings.stamina = 0;
                PlayerStaminaBar.value = Stamina;
            }
            if (Stamina < prevStamina || Stamina > prevStamina)
            {
                Debug.Log("Stamina isn't the same as the previous stamina! Running the update stamina bar text function!!");
                prevStamina = Stamina;
                PlayerStaminaBar.value = Stamina;
                PlayerStaminaBarText.GetComponent<UIBarValueGrabber>().UpdateStaminaBarText();
            }
        }
    }
}