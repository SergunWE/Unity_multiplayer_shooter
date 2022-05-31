using System;
using System.Collections.Generic;
using UnityEngine;

public static class GraphicSettings
{
    private const string FullScreenKey = "FullScreen";
    private const string DisplayWidthKey = "DisplayWidth";
    private const string DisplayHeightKey = "DisplayHeight";
    private const string DisplayRefreshRateKey = "DisplayRefreshRate";
    private const string QualityKey = "Quality";

    private static readonly List<Resolution> Resolutions;
    
    private static bool _isFull;
    private static int _width;
    private static int _height;
    private static int _refreshRate;
    private static int _quality;

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
        _quality = PlayerPrefs.GetInt(QualityKey, QualitySettings.names.Length - 1);
        
        SetFullScreenMode(Convert.ToBoolean(PlayerPrefs.GetInt(FullScreenKey, 1)));
        SetResolution(_width, _height, _refreshRate);
        SetQuality(_quality);
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
    
    public static void SetQuality(int index)
    {
        _quality = index;
        QualitySettings.SetQualityLevel(_quality, true);
        PlayerPrefs.SetInt(QualityKey, _quality);
    }
    
    public static int GetCurrentResolutionIndex()
    {
        var res = new Resolution
        {
            height = _height,
            width = _width,
            refreshRate = _refreshRate
        };
        return Resolutions.IndexOf(res);
    }

    public static int GetCurrentQualityIndex()
    {
        return _quality;
    }
    
    private static void SetFullScreenMode(bool isFull)
    {
        _isFull = isFull;
        Screen.SetResolution(_width, _height, _isFull, _refreshRate);
        PlayerPrefs.SetInt(FullScreenKey, _isFull ? 1 : 0);
    }
    
    private static void SetResolution(int width, int height, int refreshRate)
    {
        Screen.SetResolution(width, height, Screen.fullScreenMode, refreshRate);
        PlayerPrefs.SetInt(DisplayWidthKey, _width);
        PlayerPrefs.SetInt(DisplayHeightKey, _height);
        PlayerPrefs.SetInt(DisplayRefreshRateKey, _refreshRate);
    }
}