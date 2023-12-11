using ClothesShop.Character;
using UnityEngine;

namespace ClothesShop
{
    public class DebugLogInteractable : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log("I was interacted with!");
        }
    }
}
