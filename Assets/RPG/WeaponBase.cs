using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG{
public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField]private int m_baseDamage=1;
    [SerializeField]private float m_attackCooldown=0.5f;
    [SerializeField]private Character m_currentWeaponUser;
    private bool canAttack = true;
    public virtual void DealDamage(IHaveHealth target){
        if(canAttack==true){
            target.ApplyDamage(m_baseDamage);
            canAttack = false;
            StartCoroutine(WaitForCooldown());
        }
        
    }
    private IEnumerator WaitForCooldown(){
        yield return new WaitForSecondsRealtime(m_attackCooldown);
        canAttack = true;
    }

}
}