using System;
using System.Collections.Generic;
using UnityEngine;

public static class GraphicSettings
{
    private const string FullScreenKey = "FullScreen";
    private const string DisplayWidthKey = "DisplayWidth";
    private const string DisplayHeightKey = "DisplayHeight";
    private const string DisplayRefreshRateKey = "DisplayRefreshRate";

    private static readonly List<Resolution> Resolutions;
    
    private static bool _isFull;
    private static int _width;
    private static int _height;
    private static int _refreshRate;

    public static List<string> ResolutionNames { get; private set; }

    static GraphicSettings()
    {
        Resolutions = new List<Resolution>();
        Resolutions.AddRange(Screen.resolutions);
        ResolutionNames = new List<string>();
        foreach (var res in Resolutions)
        {
            ResolutionNames.Add(res.ToString());
        }

        var bestRes = Resolutions[Resolutions.Count - 1];
        _width = PlayerPrefs.GetInt(DisplayWidthKey, bestRes.width);
        _height = PlayerPrefs.GetInt(DisplayHeightKey, bestRes.height);
        _refreshRate = PlayerPrefs.GetInt(DisplayRefreshRateKey, bestRes.refreshRate);
        
        SetFullScreenMode(Convert.ToBoolean(PlayerPrefs.GetInt(FullScreenKey, 1)));
        SetResolution(_width, _height, _refreshRate);
    }

    public static void SetFullScreenMode(int isFull)
    {
        SetFullScreenMode(Convert.ToBoolean(isFull));
    }
    
    public static void SetResolution(int index)
    {
        var res = Resolutions[index];

        _width = res.width;
        _height = res.height;
        _refreshRate = res.refreshRate;
        
        SetResolution(_width, _height, _refreshRate);
    }
    
    public static int GetCurrentResolutionIndex()
    {
        if (_isFull)
        {
            return Resolutions.IndexOf(Screen.currentResolution);
        }
        var res = new Resolution
        {
            height = _height,
            width = _width,
            refreshRate = _refreshRate
        };
        return Resolutions.IndexOf(res);
    }
    
    private static void SetFullScreenMode(bool isFull)
    {
        _isFull = isFull;
        Screen.SetResolution(_width, _height, _isFull, _refreshRate);
        SaveSettings();
    }


    private static void SetResolution(int width, int height, int refreshRate)
    {
        Screen.SetResolution(width, height, Screen.fullScreenMode, refreshRate);
        SaveSettings();
    }

    private static void SaveSettings()
    {
        PlayerPrefs.SetInt(FullScreenKey, _isFull ? 1 : 0);
        PlayerPrefs.SetInt(DisplayWidthKey, _width);
        PlayerPrefs.SetInt(DisplayHeightKey, _height);
        PlayerPrefs.SetInt(DisplayRefreshRateKey, _refreshRate);
    }
}