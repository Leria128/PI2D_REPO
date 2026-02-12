using UnityEngine;

namespace DialogueSystem_V
{  
    [System.Serializable]
    public class Dialogue_Turn 
    {
        [field: SerializeField]
        public Dialogue_Character Character { get; private set; }

        [SerializeField, TextArea(2, 4)]
        private string dialogue_line = string.Empty;

        public string Dialogue_Line => dialogue_line;

        
    }
}
