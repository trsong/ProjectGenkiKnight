using UnityEngine;
using TMPro;

namespace Genki.Control
{
    public class DamagePopupControl : MonoBehaviour
    {
        // Create a Damage Popup
        public DamagePopupControl ShowDamage(Vector3 position, int damageAmount, bool isCriticalHit) {
            var damagePopupInstance = Instantiate(gameObject, position, Quaternion.identity);
            DamagePopupControl damagePopup = damagePopupInstance.GetComponent<DamagePopupControl>();
            damagePopup.Setup(damageAmount, isCriticalHit);
            return damagePopup;
        }
    
        private static int sortingOrder;
    
        private const float DISAPPEAR_TIMER_MAX = 1f;
    
        private TextMeshPro textMesh;
        private float disappearTimer;
        private Color textColor;
        private Vector3 moveVector;
    
        private void Awake() {
            textMesh = transform.GetComponent<TextMeshPro>();
        }
    
        public void Setup(int damageAmount, bool isCriticalHit) {
            textMesh.SetText(damageAmount.ToString());
            if (!isCriticalHit) {
                // Normal hit
                textMesh.fontSize = 5;
                textColor = Color.yellow;
            } else {
                // Critical hit
                textMesh.fontSize = 7;
                textColor = Color.red;
            }
            textMesh.color = textColor;
            disappearTimer = DISAPPEAR_TIMER_MAX;
    
            sortingOrder++;
            textMesh.sortingOrder = sortingOrder;
    
            moveVector = new Vector3(.7f, 1) * 5f;
        }
    
        private void Update() {
            transform.position += moveVector * Time.deltaTime;
            moveVector -= moveVector * 8f * Time.deltaTime;
    
            if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f) {
                // First half of the popup lifetime
                float increaseScaleAmount = 1f;
                transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
            } else {
                // Second half of the popup lifetime
                float decreaseScaleAmount = 1f;
                transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
            }
    
            disappearTimer -= Time.deltaTime;
            if (disappearTimer < 0) {
                // Start disappearing
                float disappearSpeed = 1f;
                textColor.a -= disappearSpeed * Time.deltaTime;
                textMesh.color = textColor;
                if (textColor.a < 0) {
                    Destroy(gameObject);
                }
            }
        }
    
    }
}

