using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScreenSettings : MonoBehaviour
{
    [SerializeField] private string fullScreenKey;
    
    private Resolution[] _resolutions;
    private bool _isFull;

    private void Awake()
    {
        _resolutions = Screen.resolutions;
        foreach (var res in _resolutions)
        {
            Debug.Log(res);
        }
        
        SetFullScreenMode(Convert.ToBoolean(PlayerPrefs.GetInt(fullScreenKey, 1)));
        SetResolution(_resolutions.Length - 1);
    }

    public void SetFullScreenMode(int isFull)
    {
        SetFullScreenMode(Convert.ToBoolean(isFull));
    }

    private void SetFullScreenMode(bool isFull)
    {
        _isFull = isFull;
        Screen.fullScreen = isFull;
        PlayerPrefs.SetInt(fullScreenKey, _isFull ? 1 : 0);
    }

    public void SetResolution(int index)
    {
        Resolution res = _resolutions[index];
        Screen.SetResolution(res.width, res.height, _isFull);
    }
}
