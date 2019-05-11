using UnityEngine;

namespace Assets.TestArea.Scripts.PlayerScripts
{
    public class PlayerInteraction : MonoBehaviour
    {
        private GameObject currentInterractedObject;

        public InteractionObject CurrentInterractedObjectScript;

        public Inventory inventory;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        // when we enter into object with collideable area we enter the function
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("InteractableObject"))
            {
                currentInterractedObject = other.gameObject;
                CurrentInterractedObjectScript = currentInterractedObject.GetComponent<InteractionObject>();
                if (CurrentInterractedObjectScript.CanBeAddedToInventory)
                {
                    inventory.AddItem(currentInterractedObject);
                    currentInterractedObject.SetActive(false);
                    currentInterractedObject = null; // cleans memory from unnecessary data
                }
            }
        }

        // when we mouve away from the object with Ccllideable area we enter the function
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("InteractableObject"))
            {
                if (other.gameObject == currentInterractedObject)
                {
                    currentInterractedObject = null;
                }
            }
        }

    }
}
