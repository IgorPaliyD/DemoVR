using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace RPG{
public interface IHaveHealth
{
  int MaxHealth{get;}
  int CurrentHealth{get;}
  event UnityAction OnHealthChange;
  void ApplyDamage(int number);
  void ApplyHealing(int number);
}
}