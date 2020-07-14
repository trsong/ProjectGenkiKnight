using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Genki.Control
{
    public class PlayerWeaponMovementControl : MonoBehaviour
    {
        Vector2 mousePos;
        private SpriteRenderer sprite;
        public Camera camera;
        void Start()
        {
            sprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
            mousePos = Input.mousePosition;
        }

        void Update()
        {
            //checkMode();
            rotate();
        }

        void rotate()
        {
            Vector2 lookDir;
            mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            lookDir = mousePos - new Vector2(transform.position.x, transform.position.y);

            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;
            if (rotation.eulerAngles.z < 270 && rotation.eulerAngles.z > 90)
            {
                sprite.sortingOrder = 4;
            }
            else
            {
                sprite.sortingOrder = 6;
            }
        }
    }
}
