using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem_V
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Scriptable Objects/Dalogue Round")]

    public class Dialogue_Round : ScriptableObject
    {
        [SerializeField]private List<Dialogue_Turn> dialogueTurnList;

        public List<Dialogue_Turn> Dialogue_Turns => dialogueTurnList;
        
        
    }
}
