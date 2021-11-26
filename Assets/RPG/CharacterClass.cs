using UnityEngine;
using UnityEngine.Events;
namespace RPG{
    public enum MainStat{
        Dexterity,
        Strength,
        Intelligence,
    }
public class CharacterClass : IHaveStats,IHaveHealth,IHaveMana
{
    public string className{get;private set;}
    private MainStat charMainStat;
    public int STR {get;private set;} = 10;
    public int INT{get;private set;} = 10;
    public int DEX{get;private set;} = 10;
    public int VIT{get;private set;} = 10;
    public int MaxHealth{get;private set;}
    public int CurrentHealth{get;private set;}
    public int MaxMana{get;private set;} 
    public int CurrentMana{get;private set;}
    public int damage{get;private set;}
     public event UnityAction OnHealthChange;

    [Header("Default char attributes")]
    private int defaultHealth;
    private int defaultMana;
    private int defaultDamage;

    public void InitializecharacterClass(string name,int str,int intel,int dex,int vit,MainStat mainStat){
        className = name;
        STR = str;
        VIT = vit;
        INT = intel;
        DEX = DEX;
        charMainStat = mainStat;
        CalculateMaxHP();
        CalculateMaxMP();
        CalculateDamage(charMainStat);
    }
    public void UpdateStats(int str,int intel,int dex,int vit){
        STR = str;
        VIT = vit;
        INT = intel;
        DEX = DEX;
        CalculateMaxHP();
        CalculateMaxMP();
        CalculateDamage(charMainStat);
    }
    
    public void ApplyDamage(int HP){
        CurrentHealth-=HP;
    }
    public void ApplyHealing(int HP){
        CurrentHealth+=HP;
    }
    public void IncreaseMana(int MP){
        CurrentMana += MP;
    }
    public void DecreaseMana(int MP){
        CurrentMana -= MP;
    }
    private void CalculateMaxHP(){
        MaxHealth = CalculateFormula(VIT,defaultHealth);
    }
    private void CalculateMaxMP(){
        MaxMana = CalculateFormula(INT,defaultMana);
    }
    private void CalculateDamage(MainStat stat){
        if(stat == MainStat.Dexterity){
            damage = CalculateFormula(DEX,defaultDamage);
        }
        if(stat == MainStat.Intelligence){
            damage = CalculateFormula(INT,defaultDamage);
        }
        if(stat==MainStat.Strength){
            damage = CalculateFormula(STR,defaultDamage);
        }
    }
    private int CalculateFormula(int statNumber, int defaultNumber){
        return (int)Mathf.Floor(statNumber/2)*10+defaultNumber;
    }
    public string GetStats(){
       return string.Format("name:{0}"+"\n"+"STR: {1}"+"\n"+"INT: {2}"+"\n"+"DEX: {3}"+"\n"+"VIT: {4}",className,STR,INT,DEX,VIT);
        //return $"name {className}\nSTR: {STR}";
    }

}
}
