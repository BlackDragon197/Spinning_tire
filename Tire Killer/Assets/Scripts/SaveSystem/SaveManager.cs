
using UnityEngine;


public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    public GameDataSO GameDataSO;

    public FileHandler _fileHandler;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Load();
    }

    public void Save()
    {
        _fileHandler.SaveToFile(GameDataSO);
    }

    public void Load()
    {
        _fileHandler.LoadFromFile();
    }
}
