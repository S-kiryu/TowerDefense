using System.Collections.Generic;
using UnityEngine;

public class TowerDataRegistry : MonoBehaviour
{
    public static TowerDataRegistry Instance { get; private set; }

    [SerializeField] private List<Status> _towerStatuses;

    private Dictionary<TowerType, Status> _statusDictionary;

    void Awake()
    {
        Instance = this;

        _statusDictionary = new Dictionary<TowerType, Status>();

        // List‚©‚çDictionary‚É•ÏŠ·‚µ‚Ä
        // TowerType‚ğƒL[‚É‚µ‚ÄStatus‚ğæ“¾‚Å‚«‚é‚æ‚¤‚É‚·‚é
        foreach (var status in _towerStatuses)
        {
            _statusDictionary[status.TowerType] = status;
        }
    }

    public Status GetStatus(TowerType towerType)
    {
        if (_statusDictionary.TryGetValue(towerType, out var status))
        {
            return status;
        }
            Debug.LogError($"TowerType {towerType} ‚ÌStatus‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ‚Å‚µ‚½I");
            return null;
    }

}