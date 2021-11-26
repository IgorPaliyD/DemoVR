using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG{
public interface IHaveStats 
{
    int STR{get;}
    int INT{get;}
    int DEX{get;}
    int VIT{get;}
    
    void UpdateStats(int str,int intel,int dex,int vit);
    
}
}