using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeskInput : MonoBehaviour
{
    public InputField nameInput;
    public Dropdown genderDropdown;
    public Dropdown podDropdown;


    public void OnSubmit()
    {
        if (!string.IsNullOrEmpty(nameInput.text))
        {
            PlayerInfoManager.isInfoSubmitted = true;
            PlayerInfoManager.selectedGenderType = genderDropdown.options[genderDropdown.value].text;
            PlayerInfoManager.selectedPodType = podDropdown.options[podDropdown.value].text;
            PlayerInfoManager.enteredName = nameInput.text;
            Debug.Log("Finish enter info");
        }

    }
}
