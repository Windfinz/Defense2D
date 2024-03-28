using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;

    [Header("UI")]
    public Image darkBG;
    public GameObject gameOver;
    public GameObject gameWin;

    //private UnityAction GameWinAction;
    //private UnityAction GameOverAction;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        DisableScreen();
        SetTranformScreenScale();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void DisableScreen()
    {
        darkBG.gameObject.SetActive(false);
        gameWin.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
    }

    private void SetTranformScreenScale()
    {
        gameOver.transform.localScale = Vector3.zero;
        gameWin.transform.localScale = Vector3.zero;
    }

    public void GameWin()
    {
        darkBG.gameObject.SetActive(true);
        gameWin.transform.DOScale(1f, 1f).SetEase(Ease.Linear);
    }
    public void GameOver()
    {
        darkBG.gameObject.SetActive(true);
        gameOver.transform.DOScale(1f, 1f).SetEase(Ease.Linear);
    }
}
