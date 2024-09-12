using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TutorialPoint
{
    public Point Point;
    [TextArea(3, 10)] public string Message;
}

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private HudHandler _hud;
    [SerializeField] private TutorialPoint[] _tutorialPoints;
    [SerializeField] private bool _isOpenSkill;
    private Queue<TutorialPoint> _tutorials; 

    private void Start()
    {
        _player.Initialize(skillOpen: _isOpenSkill);

        _tutorials = new Queue<TutorialPoint>();
        foreach (TutorialPoint tutorialPoint in _tutorialPoints)
            _tutorials.Enqueue(tutorialPoint);

        NextPoint();
    }

    private void OnEnable()
    {
        Point.PointComplete += OnPointComplete;
    }

    private void OnDisable()
    {
        Point.PointComplete -= OnPointComplete;
    }
    
    private void NextPoint()
    {
        if (_tutorials.Count == 0) return;

        TutorialPoint questPoint = _tutorials.Dequeue();
        questPoint.Point.Show();
        _hud.SetMessage(questPoint.Message);
    }

    private void OnPointComplete()
    {
        NextPoint();    
    }
}
