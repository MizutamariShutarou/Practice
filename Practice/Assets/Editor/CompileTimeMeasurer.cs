using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public sealed class CompileTimeMeasurer : EditorWindow
{
    [SerializeField] private List<string> _list = new List<string>();
    [SerializeField] private long _startTime = 0;

    private bool _isCompiling;
    private Vector2 _scrollPos;

    [MenuItem("Tools/Compile Time Measurer")]
    public static void Init()
    {
        GetWindow<CompileTimeMeasurer>();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Clear"))
        {
            _list.Clear();
        }

        _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);

        foreach (var n in _list)
        {
            EditorGUILayout.LabelField(n);
        }

        EditorGUILayout.EndScrollView();
    }

    private void OnEnable()
    {
        EditorApplication.update += OnUpdate;
    }

    private void OnDisable()
    {
        EditorApplication.update -= OnUpdate;
    }

    private void OnUpdate()
    {
        var isCompiling = EditorApplication.isCompiling;
        var isStarted = !_isCompiling && isCompiling;
        var isEnded = _isCompiling && !isCompiling;
        var millisecond = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

        if (isStarted)
        {
            _isCompiling = true;
            _startTime = millisecond;
        }
        else if (isEnded)
        {
            _isCompiling = false;
            var time = (millisecond - _startTime) / 1000f;
            _list.Add(time.ToString("0.###") + " •b");
            Repaint();
        }
    }
}