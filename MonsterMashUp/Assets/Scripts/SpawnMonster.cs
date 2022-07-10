using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnMonster : MonoBehaviour {

    public GameObject[] parent;

    GameObject newMonster;
    EggMonster myMonster;
    MonsterTraits pMonster1, pMonster2;
    public GameObject monsterPrefab;

    public GameObject p1, p2;
    
    
    //records the two monsters on the screen when the new monster is instantiated
    void GetParent()
    {
       parent = GameObject.FindGameObjectsWithTag("Monster");
       p1 = parent[0];
       p2 = parent[1];
       
    }

    void SetUpChild()
    {
        myMonster.genotypes = new string[4];
        myMonster.domaniantTraits = new Sprite[4];
        myMonster.recessiveTraits = new Sprite[4];
        myMonster.pheno = new Sprite[4];

        Array.Copy(p1.GetComponent<MonsterTraits>().domaniantTraits, myMonster.domaniantTraits, 4);
        Array.Copy(p1.GetComponent<MonsterTraits>().recessiveTraits, myMonster.recessiveTraits, 4);

    }

    //instantiates the new monster
    public void CreateMonster()
    {
        if(newMonster != null)
        {
            Destroy(newMonster);
        }
        newMonster = Instantiate(monsterPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        newMonster.tag = "Child Monster";
        
        myMonster = newMonster.AddComponent<EggMonster>();

        GetParent();
        SetUpChild();
        //passes the parent monsters to the new monster
        myMonster.Parent1 = p1;
        myMonster.Parent2 = p2;
        myMonster.GetGenealogy();
    }

   
}
