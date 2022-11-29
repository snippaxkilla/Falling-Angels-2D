using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalDeathCount : MonoSingleton<TotalDeathCount>
{
    public int amountOfDeaths;

    public void Death()
    {
        amountOfDeaths++;
    }

    public void DeathCountReset()
    {
        amountOfDeaths = 0;
    }
}
