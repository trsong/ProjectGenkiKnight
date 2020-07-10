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
        bool isUsingMouse;
        protected Joystick joyStickRight;
        void Start()
        {
            sprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
            isUsingMouse = false;
            mousePos = Input.mousePosition;
            joyStickRight = GameObject.Find("Fixed Joystick Right").GetComponent<Joystick>();
        }

        void Update()
        {
            checkMode();
            rotate();
        }

        void rotate()
        {
            Vector2 lookDir;
            if (isUsingMouse)
            {
                mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
                lookDir = mousePos - new Vector2(transform.position.x, transform.position.y);
            }
            else
            {
                lookDir = new Vector2(joyStickRight.Horizontal, joyStickRight.Vertical);
            }
            
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
        void checkMode()
        {
            if (mousePos.Equals(Input.mousePosition))
            {
                isUsingMouse = false;
            }
            else
            {
                isUsingMouse = true;
            }
        }
    }
}
