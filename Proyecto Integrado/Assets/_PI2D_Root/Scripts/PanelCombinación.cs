using DialogueSystem_V;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCombinación : MonoBehaviour
{
    [SerializeField] private string correctCode = "1997";
    [SerializeField] private Door door;
    private string currentInput = "";

    public void AddNumber(string number)
    {
        currentInput += number;

        if (currentInput.Length >= correctCode.Length)
        {
            if (currentInput == correctCode)
            {
                door.UnlockDoor();
            }

            currentInput = "";
        }
    }



}
