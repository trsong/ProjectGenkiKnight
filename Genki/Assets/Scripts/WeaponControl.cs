using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    Vector2 mousePos;
    public Camera cameraVariable;
    public SpriteRenderer sprite;
    public GameObject bullet;
    public Transform firePoint;
    public float bulletForce = 20f;
    // Update is called once per frame
    void Update()
    {
        rotate();
        shoot();        
    }

    void rotate(){
        mousePos = cameraVariable.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - new Vector2(this.transform.position.x,this.transform.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)* Mathf.Rad2Deg + 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
        if(rotation.eulerAngles.z < 270 && rotation.eulerAngles.z > 90 ){
            sprite.sortingOrder = 4;
        }else{
            sprite.sortingOrder = 6;
        }
    }

    void shoot(){
        if(Input.GetButtonDown("Fire1")){
            GameObject b = Instantiate(bullet, firePoint.position,firePoint.rotation);
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.AddForce(-firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
