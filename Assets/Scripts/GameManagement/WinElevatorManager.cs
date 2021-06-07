using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinElevatorManager : MonoBehaviour
{
    public GameObject Gem_One, Gem_Two, Gem_Three;
    public GameObject Gem_One_Pos, Gem_Two_Pos, Gem_Three_Pos;

    public void Update()
    {
        GemsCollected();
    }
    public void GemsCollected()
    {
        if (TallyManager.score == 1)
        {
            Gem_One.transform.position = Gem_One_Pos.transform.position;
        }

        if (TallyManager.score == 2)
        {
            Gem_One.transform.position = Gem_One_Pos.transform.position;
            Gem_Two.transform.position = Gem_Two_Pos.transform.position;
        }

        if (TallyManager.score == 3)
        {
            Gem_One.transform.position = Gem_One_Pos.transform.position;
            Gem_Two.transform.position = Gem_Two_Pos.transform.position;
            Gem_Three.transform.position = Gem_Three_Pos.transform.position;
        }
    }

    public void LoadNextLevel()
    {
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }
}
