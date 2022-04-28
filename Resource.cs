using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "Item/Resource")]
public class Resource : Item
{
    public resourceType type;

    public override void Use()
    {
        base.Use();
    }

    public enum resourceType { Leather, Stick, Rope }
}
