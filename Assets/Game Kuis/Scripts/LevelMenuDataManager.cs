using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField]
    private PlayerProgress _playerPorgress = null;

    [SerializeField]
    private TextMeshProUGUI _tempatKoin = null;
    private void Start() 
    {
        _tempatKoin.text = $"{_playerPorgress.progresData.koin}";
    }
}
