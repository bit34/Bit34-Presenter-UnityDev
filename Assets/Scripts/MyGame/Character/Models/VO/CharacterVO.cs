using UnityEngine;

namespace MyGame.Character.Models.VO
{
    public class CharacterVO
    {
        //  MEMBERS
        public readonly int  id;
        public string        name;
        public Vector3       position;

        //  CONSTRUCTORS
        public CharacterVO(int     id,
                           string  name,
                           Vector3 position)
        {
            this.id       = id;
            this.name     = name;
            this.position = position;
        }
    }
}
