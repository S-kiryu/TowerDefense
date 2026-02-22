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

        // ListからDictionaryに変換して
        // TowerTypeをキーにしてStatusを取得できるようにする
        foreach (var status in _towerStatuses)
        {
            _statusDictionary[status.TowerType] = status;
        }
    }

    // TowerTypeを渡すと対応するStatusを返すメソッド
    public Status GetStatus(TowerType towerType)
    {
        if (_statusDictionary.TryGetValue(towerType, out var status))
        {
            return status;
        }
            Debug.LogError($"TowerType {towerType} のStatusが見つかりませんでした！");
            return null;
    }

}