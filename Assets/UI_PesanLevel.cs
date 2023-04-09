using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_PesanLevel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _tempatPesan = null;

    public string Pesan
    {
        // Mengambil informasi
        get => _tempatPesan.text;
        // Mengubah informasi
        set => _tempatPesan.text = value;
    }

    private void Awake()
    {
        if(gameObject.activeSelf) gameObject.SetActive(false);
    }
}
