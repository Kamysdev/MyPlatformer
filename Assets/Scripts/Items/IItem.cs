using UnityEngine;

public interface IItem
{
    string GetName();
    void Use(GameObject player);
}