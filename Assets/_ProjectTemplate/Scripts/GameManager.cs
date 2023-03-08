using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public InputController InputController { get; private set; }
    public SoundController SoundController { get; private set; }
    public VideoController VideoController { get; private set; }
    public FrontManager FrontManager { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        InputController = GetComponentInChildren<InputController>();
        SoundController = GetComponentInChildren<SoundController>();
        VideoController = GetComponentInChildren<VideoController>();
        FrontManager = GetComponentInChildren<FrontManager>();
    }

    private void Start()
    {
        InputController.StartMain();
        SoundController.StartMain();
        VideoController.StartMain();
    }

    private void Update()
    {
        InputController.UpdateMain();        
    }

    public void LoadScene(int p_numberScene)
    {
        SceneManager.LoadScene(p_numberScene);
    }

    public void Settings(GameObject p_ObjSettings)
    {
        p_ObjSettings.SetActive(!p_ObjSettings.activeSelf);
    }

    public void Pause(int p_pause)
    {
        Time.timeScale = p_pause;
    }

    public void RestoreDefaultVideoSettings()
    {
        VideoController.RestoreDefaultSettings();
    }
    public void RestoreDefaultAudioSettings()
    {
        SoundController.RestoreDefaultSettings();
    }
    public void RestoreDefaultControllersSettings()
    {
        InputController.RestoreDefaultSettings();
    }
}
