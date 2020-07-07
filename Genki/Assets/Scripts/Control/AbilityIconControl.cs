using Genki.Abilitiy;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIconControl : MonoBehaviour
{
    private Ability ability = null;

    private GameObject uiActive;
    private GameObject cooldownIcon;
    private Text cooldownText;
    private Text descriptionText;

    public void setAbility(Ability newAbility)
    {
        ability = newAbility;
        gameObject.transform.Find("Icon").GetComponent<Image>().sprite = newAbility.icon;
    }
    
    void Start()
    {
        uiActive = gameObject.transform.Find("Active").gameObject;
        cooldownIcon = gameObject.transform.Find("Cooldown").gameObject;
        cooldownIcon.SetActive(false);
        cooldownText = cooldownIcon.transform.Find("Text").GetComponent<Text>();
        cooldownText.text = "";
        
        var keyIcon = gameObject.transform.Find("Key").gameObject;
        descriptionText = keyIcon.transform.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ability == null) return;

        if (ability.canApply())
        {
            cooldownIcon.SetActive(false);
        }
        else
        {
            if(!cooldownIcon.activeSelf)
                cooldownIcon.SetActive(true);

            int seconds = ability.getCooldownInSec();
            if (seconds > 0)
            {
                cooldownText.text = ability.getCooldownInSec().ToString();
            }
            else
            {
                cooldownText.text = "";
            }
        }
        descriptionText.text = ability.description + "x" + ability.getQuantity();
        if (ability.getQuantity() <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public void OnClickButton(){
        if (ability != null)
        {
            ability.apply();
        }
    }
}
