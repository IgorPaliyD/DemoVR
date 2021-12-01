using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;

namespace RPG{
public class UIClassSetuper : MonoBehaviour
{
    public Character character;
    private List<CharacterClass> classes;

    private void Awake() {
        classes = new List<CharacterClass>();
       
    }
    public void SelectClass(int i){
    
    }
}
}