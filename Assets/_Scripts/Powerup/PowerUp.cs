using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PowerUp : MonoBehaviour {

    public Stats.StatsEntry[] goodEntries;
    public Stats.StatsEntry[] badEntries;
    public GameObject mesh;
    
    void RandomizeStats()
    {
        float goodValue = 6;
        float badValue = 4;

        int goodN = UnityEngine.Random.Range(1, 3); // random fom 1 to 2;
        int badN = UnityEngine.Random.Range(1, 4); // random from 1 to 3
        goodEntries = new Stats.StatsEntry[goodN];
        badEntries = new Stats.StatsEntry[badN];

        Array enumstats = Enum.GetValues(typeof(Stats.StatsName));
        bool[] used = new bool[enumstats.Length];
        for (int i = 0; i < goodN; i++)
        {
            Stats.StatsName choosen;
            int statsIndex = 0;
            
            do statsIndex = UnityEngine.Random.Range(0, enumstats.Length);
            while (used[statsIndex]);
            used[statsIndex] = true;
            choosen = (Stats.StatsName)enumstats.GetValue(statsIndex);
            

            if (i == goodN - 1) // se é o último, pega o que restou
            {
                //stats.SetStat(choosen, goodValue);
                goodEntries[i].name = choosen;
                goodEntries[i].value = goodValue;
                goodValue = 0;
            }
            else // se não põe random entre 1 e tudo - goodN
            {
                int value = UnityEngine.Random.Range(1, (int)(goodValue - (goodN - i)+1));
                goodValue -= value;

                goodEntries[i].name = choosen;
                goodEntries[i].value = value;
                //stats.SetStat(choosen, value);
            }
        }
        for (int i = 0; i < badN; i++)
        {
            Stats.StatsName choosen;
            int statsIndex = 0;

            do statsIndex = UnityEngine.Random.Range(0, enumstats.Length);
            while (used[statsIndex]);
            used[statsIndex] = true;
            choosen = (Stats.StatsName)enumstats.GetValue(statsIndex);


            if (i == badN - 1) // se é o último, pega o que restou
            {
                //stats.SetStat(choosen, goodValue);
                badEntries[i].name = choosen;
                badEntries[i].value = -badValue;
                badValue = 0;
            }
            else // se não põe random entre 1 e tudo - goodN
            {
                int value = UnityEngine.Random.Range(1, (int)(badValue - (badN - i) + 1));
                badValue -= value;

                badEntries[i].name = choosen;
                badEntries[i].value = -value;
                //stats.SetStat(choosen, value);
            }
        }
        //for (int i = 0; i < badN; i++)
        //{

        //    Stats.StatsName choosen;
        //    do
        //        choosen = (Stats.StatsName)enumstats.GetValue(UnityEngine.Random.Range(0, enumstats.Length));
        //    while (stats.GetStat(choosen) != 0);
        //    // seleciona um status não alterado

        //    if (i == badN - 1) // se é o último, pega o que restou
        //    {
        //        stats.SetStat(choosen, badValue);
        //        badValue = 0;
        //    }
        //    else // se não põe random entre 1 e tudo - goodN
        //    {
        //        float value = -UnityEngine.Random.Range(1, (int)(badValue - (badN - i)));
        //        badValue -= value;

        //        stats.SetStat(choosen, value);
        //    }
        //}
    }
    void UpdateTextMesh()
    {
        TextMesh[] tms = GetComponentsInChildren<TextMesh>();
        foreach (var item in tms)
            item.gameObject.SetActive(false);

        Array enumstats = Enum.GetValues(typeof(Stats.StatsName));
        Stats.StatsName choosen = Stats.StatsName.cooldown; // dane-se o valor inicial
        
        // get greater value
        Stats.StatsEntry bgstentry = new Stats.StatsEntry() { name = Stats.StatsName.cooldown, value = 0 };
        for (int i = 0; i < goodEntries.Length; i++)
            if (goodEntries[i].value > bgstentry.value)
                bgstentry = goodEntries[i];

        if (bgstentry.value > 0)
        {
            tms[0].gameObject.SetActive(true);
            tms[0].text = Stats.GetStatChar(bgstentry.name) + "";
        }

        // get second biggest
        Stats.StatsEntry scndentry = new Stats.StatsEntry() { name = Stats.StatsName.cooldown, value = 0 };
        for (int i = 0; i < goodEntries.Length; i++)
            if (goodEntries[i].value > scndentry.value && goodEntries[i].name != bgstentry.name)
                scndentry = goodEntries[i];

        if (scndentry.value > 0)
        {
            tms[1].gameObject.SetActive(true);
            tms[1].text = Stats.GetStatChar(scndentry.name) + "";
        }

        // get lowest
        Stats.StatsEntry lwstEntry = new Stats.StatsEntry() { name = Stats.StatsName.cooldown, value = 0 };
        for (int i = 0; i < badEntries.Length; i++)
            if (badEntries[i].value < lwstEntry.value)
                lwstEntry = badEntries[i];

        if (lwstEntry.value < 0)
        {
            tms[2].gameObject.SetActive(true);
            tms[2].text = Stats.GetStatChar(lwstEntry.name) + "";
        }

        // get second lowest
        Stats.StatsEntry scndlwstValue = new Stats.StatsEntry() { name = Stats.StatsName.cooldown, value = 0 };
        for (int i = 0; i < badEntries.Length; i++)
            if (badEntries[i].value < scndlwstValue.value && badEntries[i].name != lwstEntry.name)
                scndlwstValue = badEntries[i];

        if (scndlwstValue.value < 0)
        {
            tms[3].gameObject.SetActive(true);
            tms[3].text = Stats.GetStatChar(scndlwstValue.name) + "";
        }
        // get second lowest
        Stats.StatsEntry thrdlwstValue = new Stats.StatsEntry() { name = Stats.StatsName.cooldown, value = 0 };
        for (int i = 0; i < badEntries.Length; i++)
            if (badEntries[i].value < thrdlwstValue.value && badEntries[i].name != lwstEntry.name && badEntries[i].name != scndlwstValue.name)
                thrdlwstValue = badEntries[i];

        if (thrdlwstValue.value < 0)
        {
            tms[4].gameObject.SetActive(true);
            tms[4].text = Stats.GetStatChar(thrdlwstValue.name) + "";
        }

    }

    void Start()
    {
        RandomizeStats();
        UpdateTextMesh();
    }
	void Update () {
        if(mesh != null)
            mesh.transform.Rotate(mesh.transform.up, 360 * Time.deltaTime);	
	}
    void OnTriggerEnter(Collider col)
    {
        MutableShooter ms = col.GetComponentInChildren<MutableShooter>();
        if (ms != null)
        {
            foreach (var item in goodEntries)
                ms.stats.Add(item);
            foreach (var item in badEntries)
                ms.stats.Add(item);
            Destroy(gameObject);
        }
    }
}
