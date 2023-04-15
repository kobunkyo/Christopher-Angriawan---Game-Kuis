using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private LevelPackKuis _soalSoal = null;

    [SerializeField]
    private UI_Pertanyaan _pertanyaan = null; // Penghubung script ke UI_Pertanyaan

    [SerializeField]
    private UI_PoinJawaban[] _pilihanJawaban = new UI_PoinJawaban[0]; // Penghubung script ke UI_PoinJawaban

    private int _indexSoal = -1;

    public void Start()
    {
        if(!_playerProgress.MuatProgress())
        {
            _playerProgress.SimpanProgress();
        }
        
        NextLevel();
    }

    public void NextLevel()
    {
        _indexSoal++;

        if(_indexSoal >= _soalSoal.BanyakLevel)
        {   
            _indexSoal = 0;
        }

        LevelSoalKuis soal = _soalSoal.AmbilLevelKe(_indexSoal);

        _pertanyaan.SetPertanyaan($"Soal {_indexSoal + 1}", soal.pertanyaan, soal.petunjukJawaban); // Masukin value dari Level Manager ke script UI_Pertanyaan

        for(int i = 0; i<_pilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _pilihanJawaban[i]; // Masukin ke jawaban A - D lewat for loop
            LevelSoalKuis.OpsiJawaban opsi = soal.opsiJawaban[i];
            poin.SetJawaban(opsi.jawabanTeks, opsi.adalahBenar); // Masukin value dari Level Manager ke script UI_PoinJawaban
        }
    }
}
