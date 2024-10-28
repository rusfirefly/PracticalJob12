using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct QuestPoint
{
    public Point Point;
    [TextArea(3, 10)] public string Message;
}

public class QuestHandler : MonoBehaviour
{
    [SerializeField] private HudHandler _hud;
    [SerializeField] private QuestPoint[] _tutorialPoints;
    private Queue<QuestPoint> _tutorials; 

    private void Start()
    {
        if (_hud)
        {
            Initialized();
        }
    }

    private void OnEnable()
    {
        Point.PointComplete += OnPointComplete;
    }

    private void OnDisable()
    {
        Point.PointComplete -= OnPointComplete;
    }

    public void Initialized()
    {
        _tutorials = new Queue<QuestPoint>();
        foreach (QuestPoint tutorialPoint in _tutorialPoints)
            _tutorials.Enqueue(tutorialPoint);

        NextPoint();
    }

    private void NextPoint()
    {
        if (_tutorials.Count == 0) return;

        QuestPoint questPoint = _tutorials.Dequeue();
        questPoint.Point.Show();
        _hud.SetMessage(questPoint.Message);
    }

    private void OnPointComplete()
    {
        NextPoint();    
    }
}
