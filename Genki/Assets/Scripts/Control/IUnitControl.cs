using Genki.Abilitiy;
using Genki.Character;
using UnityEngine;

namespace Genki.Control
{
    public interface IUnitControl
    {
        CharacterSystem getCharacterSystem();
        WeaponSystem getWeaponSystem();

        Vector2 getStartPosition();
    }
}
