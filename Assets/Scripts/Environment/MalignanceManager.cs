using System.Collections.Generic;
using UnityEngine;

public class MalignanceManager : MonoBehaviour
{
    [SerializeField]
    private List<MalignanceLayer> allMalignances;

    [SerializeField]
    private Bed bed;

    private int decayProgress = 0;
    
    private int maxActiveMalignancesToday;
    private int activeMalignancesRemained;
    
    private void Awake()
    {
        bed.OnSleep += StartNewDay;
        Malignance.OnUprooted += UprootOneMal;
        maxActiveMalignancesToday = allMalignances[0].malignances.Count;
        activeMalignancesRemained = maxActiveMalignancesToday;
        ResetAllMalignancies();
    }
    private void OnDestroy()
    {
        bed.OnSleep -= StartNewDay;
        Malignance.OnUprooted -= UprootOneMal;
    }

    private void ResetAllMalignancies()
    {
        for(int layerIndex = 0; layerIndex <= decayProgress; layerIndex++)
            foreach (var mal in allMalignances[layerIndex].malignances)
                mal.Reset();
    }

    private void UprootOneMal()
    {
        activeMalignancesRemained--;
    }

    private void StartNewDay()
    {
        if (PrepareToDecayForAnotherDay())
            ResetAllMalignancies();
    }

    private bool PrepareToDecayForAnotherDay()
    {    
        if (activeMalignancesRemained / maxActiveMalignancesToday > 0.5f)
        {
            decayProgress++;
            Debug.Log("You feel very uneasy.");
            if (decayProgress >= allMalignances.Count)
            {
                Lose();
                return false;
            }
            maxActiveMalignancesToday += allMalignances[decayProgress].malignances.Count;
        }
        activeMalignancesRemained = maxActiveMalignancesToday;
        return true;
    }

    private void Lose()
    {
        //change scene to losing scene
        Debug.Log("You have lost.");
    }
}