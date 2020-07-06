using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public List<GameObject>  drops;
    public Sprite openLoot;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag=="Player"){
            Destroy(this.gameObject.GetComponent<Collider2D>());
            Destroy(this.transform.GetChild(0).gameObject);
            SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = openLoot;
            Color temp = spriteRenderer.color;
            temp.a = 0.5f;
            spriteRenderer.color = temp;
            int random = Random.Range(0,drops.Count-1);
            Instantiate(drops[2],this.transform.position,this.transform.rotation);
        }
    }
}
