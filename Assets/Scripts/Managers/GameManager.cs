using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static GameManager Instance;
    
    private const string TutorialKey = "Tutorial";

    private bool _isGameover = false;
    private bool _isEnteredToFinishLine = false, _isGameComplete = false;
    
    public bool IsGameover { get { return _isGameover; } set { _isGameover = value; } }
    public bool IsEnteredToFinishLine { get { return _isEnteredToFinishLine; } set { _isEnteredToFinishLine = value; } }
    public bool IsGameComplete { get { return _isGameComplete; } set { _isGameComplete = value; } }

    public int collectedStarCount=0;
    public int reachedLastMultiplier=1;
    public bool IsTutorialComplete
    {
        get => PlayerPrefs.GetInt(TutorialKey, 0) == 1;
        set => PlayerPrefs.SetInt(TutorialKey, value ? 1 : 0);
    }
    
    public bool IsGameContinue => !IsGameover && !IsGameComplete && IsTutorialComplete;
    
    private void Awake()
    {
        Instance = this;
    }

    public bool IsPlayingOnWebGL => Application.platform == RuntimePlatform.WebGLPlayer;
}
