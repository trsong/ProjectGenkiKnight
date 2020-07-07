using System.Collections.Generic;
using Genki.Character;
using UnityEngine;

namespace Genki.Abilitiy
{
    [CreateAssetMenu(fileName = "New FreezeAbilityData", menuName = "Freeze Ability")]
    public class FreezeAbility: Ability
    {
        public GameObject blockerPrefab = null;
        private GameObject statusInstance = null;
        private float originalSpeed = 0f;
        private List<GameObject> blockers = null;

        public override bool canApply(GameObject target)
        {
            if (!canStartTimer()) return false;
            return owner && !statusInstance;
        }

        protected override void activate(GameObject target)
        {
            if (owner)
            {
                var characterSystem = owner.GetComponent<CharacterSystem>();
                originalSpeed = characterSystem.speed;
                characterSystem.speed = 0f;
                statusInstance = attachDebuff(icon);
                if(blockers == null) blockers = new List<GameObject>();

                for (int dx = -1; dx < 2; dx++)
                {
                    for (int dy = -1; dy < 2; dy++)
                    {
                        if(dx == 0 && dy == 0) continue;
                        Vector2 offset = new Vector2(dx, dy);
                        Vector2 position = owner.transform.position;
                        blockers.Add(Instantiate(blockerPrefab, position + offset, Quaternion.identity));
                    }
                }
            }
        }

        protected override void deactivate()
        {
            if (owner)
            {
                var characterSystem = owner.GetComponent<CharacterSystem>();
                characterSystem.speed = originalSpeed;
                Destroy(statusInstance);
                statusInstance = null;
                foreach (var blocker in blockers)
                {
                    Destroy(blocker);
                }
            }
        }
    }
}
