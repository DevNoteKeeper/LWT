using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeskInput : MonoBehaviour
{
    public InputField nameInput;
    public Dropdown genderDropdown;
    public Dropdown podDropdown;
    private ComputerInteraction computerInteraction;

    void Start()
    {
        computerInteraction = FindObjectOfType<ComputerInteraction>(); // ComputerInteraction 스크립트 찾기
    }

    public void OnSubmit()
    {
        if (!string.IsNullOrEmpty(nameInput.text))
        {
            string podText = podDropdown.options[podDropdown.value].text;
            string genderText = genderDropdown.options[genderDropdown.value].text;

            string podKey = podText.ToLower().Contains("family") ? "family" : "general";
            string genderKey = genderText.ToLower().Contains("female") ? "female" : "male";

            PlayerInfoManager.isInfoSubmitted = true;
            PlayerInfoManager.selectedGenderType = genderText;
            PlayerInfoManager.selectedPodType = podKey;
            PlayerInfoManager.enteredName = nameInput.text;

            Debug.Log("Finish enter info");

            // UI를 닫고, 플레이어가 다시 움직일 수 있도록 함
            if (computerInteraction != null)
            {
                computerInteraction.CloseUI(); // UI를 닫고
            }
        }
    }
}
