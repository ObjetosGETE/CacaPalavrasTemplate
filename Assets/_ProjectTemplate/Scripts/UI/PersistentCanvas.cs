using UnityEngine;

public class PersistentCanvas : MonoBehaviour
{
    private static PersistentCanvas _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);

        _instance = this;
    }
}
