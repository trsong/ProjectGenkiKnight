using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    public Sprite doorOpenSprite;
    public Sprite doorCloseSprite;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
    }

    private void OnDoorwayOpen(int id)
    {
        if (id == this.id)
        {
            GetComponent<SpriteRenderer>().sprite = doorOpenSprite;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.onDoorwayTriggerEnter -= OnDoorwayOpen;
    }
}
