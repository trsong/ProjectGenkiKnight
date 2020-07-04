using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    public Sprite doorOpenSprite;
    public Sprite doorCloseSprite;
    public bool initialOpen;
    void Start()
    {
        DoorEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
        DoorEvents.current.onDoorwayTriggerExit += OnDoorwayClose;
        if (initialOpen)
            openDoor();
        else
            closeDoor();
    }

    private void openDoor()
    {
        GetComponent<SpriteRenderer>().sprite = doorOpenSprite;
        GetComponent<Collider2D>().enabled = false;
    }

    private void closeDoor()
    {
        GetComponent<SpriteRenderer>().sprite = doorCloseSprite;
        GetComponent<Collider2D>().enabled = true;
    }

    private void OnDoorwayOpen(int id)
    {
        if (id == this.id)
        {
            openDoor();
        }
    }

    private void OnDoorwayClose(int id)
    {
        if (id == this.id)
        {
            closeDoor();
        }
    }

    private void OnDestroy()
    {
        DoorEvents.current.onDoorwayTriggerEnter -= OnDoorwayOpen;
        DoorEvents.current.onDoorwayTriggerExit -= OnDoorwayClose;
    }
}
