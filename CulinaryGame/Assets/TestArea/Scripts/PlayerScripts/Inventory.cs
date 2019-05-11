using System.Collections.Generic;
using UnityEngine;

namespace Assets.TestArea.Scripts.PlayerScripts
{
    public class Inventory : MonoBehaviour
    {
        public List<GameObject> inventory;

        private readonly int _maxAmountOfStoredItemsInInventory = 5;
        // Start is called before the first frame update
        public void AddItem(GameObject item)
        {
            if(inventory.Count < _maxAmountOfStoredItemsInInventory)
                inventory.Add(item);
            else
                Debug.Log("Max amount of items reached!");

        }

        void Start()
        {
            inventory = new List<GameObject>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
