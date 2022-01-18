using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpecialManager : MonoBehaviour
{
    public static string state;
    public static Stats stateStats;

    public const string playerState = "Player";
    public const string slimeState = "Slime";
    public const string flyingState = "Flying";
    public const string walkingState = "Walking";



    public int specialsPickedUp;
    public Image killBar;
    public Sprite[] sprites;
    bool updating;
    public Sprite damageSprite;

    public static GameObject slimeBall;

    public GameObject inspectorSlimeBall;

    public State[] stats;

    private void Start()
    {
        slimeBall = inspectorSlimeBall;
        state = playerState;

    }
    private void Update()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            if(stats[i].name == state)
            {
                stateStats = stats[i].stat;
            }
        }
        UpdateKillBar();
    }
    void UpdateKillBar()
    {
        if (specialsPickedUp > 22)
        {
            specialsPickedUp = 22;
        }
        if (!updating)
        {
            
                killBar.sprite = sprites[specialsPickedUp];

            

        }
        else
        {
            killBar.sprite = damageSprite;

        }
    }

    public void PickedUp()
    {
        specialsPickedUp++;

        StartCoroutine(Up1());
    }



    IEnumerator Up1()
    {
        updating = true;
        yield return new WaitForSeconds(0.1f);
        updating = false;

    }





}

[System.Serializable]
public class State
{
    public string name;
    public Stats stat;
}
