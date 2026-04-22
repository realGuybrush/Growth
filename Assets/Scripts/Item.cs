using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemType type;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.name.Equals("MC"))
        {
            other.gameObject.GetComponent<PlayerControls>().EquipItem(type);
            Destroy(gameObject);
        }
    }
}
