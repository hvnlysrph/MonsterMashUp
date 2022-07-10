using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMonster : MonsterTraits
{
    public SpriteRenderer pBody;
    public SpriteRenderer pEyes;
    public SpriteRenderer pMouth;
    public SpriteRenderer pHorns;

    

    MonsterTraits pMonster1, pMonster2, offSpring;

    public void UpdateLook()
    {
        //finds and records the sprite component
        pBody = this.transform.Find("Body").gameObject.GetComponent<SpriteRenderer>();
        pEyes = this.transform.Find("Eyes").gameObject.GetComponent<SpriteRenderer>();
        pMouth = this.transform.Find("Mouth").gameObject.GetComponent<SpriteRenderer>();
        pHorns = this.transform.Find("Horns").gameObject.GetComponent<SpriteRenderer>();

        //assigns the sprite to the components based on what is recorded in the pheno array
        pBody.sprite = pheno[0];
        pEyes.sprite = pheno[1];
        pMouth.sprite = pheno[2];
        pHorns.sprite = pheno[3];
    }

    

   public void GetGenealogy()
    {
        pMonster1 = parent1.GetComponent<MonsterTraits>();
        pMonster2 = parent2.GetComponent<MonsterTraits>();

        string p1Geno, p2Geno;

        //Compares the genotypes of both parents and assigns the appropraite value to the child genotype
        for(int i = 0; i < pMonster1.genotypes.Length; i++)
        {
            p1Geno = pMonster1.genotypes[i];
            p2Geno = pMonster2.genotypes[i];

            if (string.Equals(p1Geno, "HD") && string.Equals(p2Geno, "HR")){
                genotypes[i] = GetGeno();
            }
            else if (string.Equals(p1Geno, "HR") && string.Equals(p2Geno, "HD"))
            {
                genotypes[i] = GetGeno();
            }
            else if (string.Equals(p1Geno, "Hetro") && string.Equals(p2Geno, "Hetro"))
            {
                genotypes[i] = "Hetro";
            }
            else if (string.Equals(p1Geno, "HD") || string.Equals(p2Geno, "HD"))
            {
                genotypes[i] = "HD";
            }
            else if (string.Equals(p1Geno, p2Geno))
            {
                genotypes[i] = p1Geno;
            }
            else
            {
                genotypes[i] = "HR";
            }

        }

        GenerateMonster();
        UpdateLook();
    }

 }
