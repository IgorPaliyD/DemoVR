using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG{
public enum Sex{
    male,
    female,
    helicopter
}
public class Character : MonoBehaviour
{
    [SerializeField]private Sex characterSex;
    private CharacterClass characterClassInstance;
    

    private void Awake() {
    }
    public void SetupClass(CharacterClass characterClass){
        characterClassInstance = characterClass;
        Debug.Log(characterClassInstance.GetStats());
    }



}
}