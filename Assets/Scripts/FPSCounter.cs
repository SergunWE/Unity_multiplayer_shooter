using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private int frameRange = 60;

    private int[] _fpsBuffer;
    private int _fpsBufferIndex;
    
    private int _averageFps;
    private int _highestFps;
    private int _lowestFps;

    private void Update()
    {
        if (_fpsBuffer == null || _fpsBuffer.Length != frameRange)
        {
            InitializeBuffer();
        }
        UpdateBuffer();
        CalculateFps();
    }

    private void InitializeBuffer()
    {
        if (frameRange <= 0)
        {
            frameRange = 1;
        }

        _fpsBuffer = new int[frameRange];
        _fpsBufferIndex = 0;
    }

    private void UpdateBuffer()
    {
        _fpsBuffer[_fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
        if (_fpsBufferIndex >= frameRange)
        {
            _fpsBufferIndex = 0;
        }
    }

    private void CalculateFps()
    {
        int sum = 0;
        int highest = 0;
        int lowers = int.MaxValue;
        foreach (var fpsValue in _fpsBuffer)
        {
            int fps = fpsValue;
            sum += fps;
            if (fps > highest)
            {
                highest = fps;
            }

            if (fps < lowers)
            {
                lowers = fps;
            }
        }

        _averageFps = sum / frameRange;
        _highestFps = highest;
        _lowestFps = lowers;
    }
    
    public int AverageFps => _averageFps;
    public int HighestFps => _highestFps;
    public int LowestFps => _lowestFps;
}
