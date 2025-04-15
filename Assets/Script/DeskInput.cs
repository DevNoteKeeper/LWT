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
        computerInteraction = FindObjectOfType<ComputerInteraction>(); // ComputerInteraction ��ũ��Ʈ ã��
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

            // UI�� �ݰ�, �÷��̾ �ٽ� ������ �� �ֵ��� ��
            if (computerInteraction != null)
            {
                computerInteraction.CloseUI(); // UI�� �ݰ�
            }
        }
    }
}
