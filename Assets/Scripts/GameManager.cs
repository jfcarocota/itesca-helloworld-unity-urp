using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    Score score;

    [SerializeField]
    GameDialogBox dialogBox;

    [SerializeField]
    CombatText combatText;

    void Awake()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Transform PlayerTransform => playerTransform;

    public Score GetScore => score;

    public GameDialogBox GetDialogBox => dialogBox;

    public CombatText GetCombat => combatText;
}
