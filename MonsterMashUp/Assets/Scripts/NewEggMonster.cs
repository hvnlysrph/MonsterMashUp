using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEggMonster : MonoBehaviour
{
    public GameObject parent1, parent2;

    //MonsterTraits newMonster = new EggMonster();

    public GameObject Parent1
    {
        set { parent1 = value; }
    }

    public GameObject Parent2
    {
        set { parent2 = value; }
    }
}
