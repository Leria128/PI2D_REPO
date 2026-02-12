using UnityEngine;

namespace DialogueSystem_V
{
    [CreateAssetMenu(fileName = "New_DialogueCharacter" , menuName = "Scriptable Objects/Dialogue Character")]

    public class Dialogue_Character : ScriptableObject
    {
        [Header("Character Information")]
        [SerializeField] private string characterName;
        [SerializeField] private Sprite profilePhoto;

        public string Name => characterName;
        public Sprite Photo => profilePhoto;


        
    }
}
