using UnityEngine;

namespace Genki.Abilitiy
{
    public class Ability
    {
        public GameObject owner = null;
        public virtual bool canApply(GameObject target) => false;

        public virtual void apply(GameObject target)
        {
        }
    }
}
