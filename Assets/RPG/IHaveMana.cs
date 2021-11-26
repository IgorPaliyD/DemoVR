
public interface IHaveMana 
{
    int MaxMana{get;}
    int CurrentMana{get;}
    
    void DecreaseMana(int number);
    void IncreaseMana(int number);

}
