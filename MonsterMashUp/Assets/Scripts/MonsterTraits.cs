using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTraits : MonoBehaviour
{
    [Tooltip("Science Grade: Define domaniant traits")]
    public Sprite[] domaniantTraits;//Records the possible domaniant traits
    [Tooltip("Science Grade: Define recessive traits")]
    public Sprite[] recessiveTraits;//Records the possible recessive traits
    [Tooltip("Science Grade: Define genotypes")]
    public string[] genotypes; //records the genotypes (first set will be random, child sets are calculated)
    [Tooltip("Science Grade: Define phenotypes")]
    public Sprite[] pheno; //records the assigned phenotypes(observed physical traits)

    public GameObject parent1, parent2;//if a child records the parent objects

    //Coin Toss for first monsters

    /*public void Start()
    {
        genotypes = new string[4];
    }*/

    public string GetGeno()
    {
        int a1, a2;

        string genotype = "";

        a1 = Random.Range(1, 100);
        a2 = Random.Range(1, 100);

        if (a1 > 50 && a2 > 50)
        {
            genotype = "HD";
        }
        else if (a1 > 50 || a2 > 50)
        {
            genotype = "HR";
        }
        else
        {
            genotype = "Hetro";
        }

        return genotype;
    }


    //Randomize the first 2 monsters 
    public void GenerateMonster()
    {
        for (int i = 0; i < genotypes.Length; i++)
        {
            genotypes[i] = GetGeno();

            switch (genotypes[i])
            {
                case "HD":
                    pheno[i] = domaniantTraits[i];
                    break;
                case "HR":
                    pheno[i] = recessiveTraits[i];
                    break;
                default:
                    pheno[i] = domaniantTraits[i];
                    break;
            }
        }
    }

    public GameObject Parent1
    {
        set { parent1 = value; }
    }

    public GameObject Parent2
    {
        set { parent2 = value; }
    }

}