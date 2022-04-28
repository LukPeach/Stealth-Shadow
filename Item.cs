
using UnityEngine;


public class Item : ScriptableObject
{
    public string itemName;

    public int ID;

    public int price;

    public bool Stackable;

    public Sprite itemIcon;

    public string Description;

    public virtual void Use()
    {
     
    }
}
