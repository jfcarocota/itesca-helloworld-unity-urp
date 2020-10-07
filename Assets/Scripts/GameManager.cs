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
    [SerializeField]
    AudioClip startCombatSFX;
    [SerializeField]
    AudioClip normalBGAudio;
    [SerializeField]
    AudioClip combatBGAudio;
    [SerializeField]
    AudioSource bgAud;

    AudioSource aud;

    [SerializeField]
    CombatPanel combatPanel;

    void Awake()
    {
        if(!instance)
        {
            instance = this;
            aud = GetComponent<AudioSource>();
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

    public CombatPanel GetCombatPanel => combatPanel;

    public void StartCombatAudio()
    {
        aud.PlayOneShot(startCombatSFX, 1f);
        bgAud.clip = combatBGAudio;
        bgAud.Play();
        bgAud.loop = true;
    }

    public void ResetBGAudio()
    {
        bgAud.clip = normalBGAudio;
        bgAud.Play();
        bgAud.loop = true;
    }
}
