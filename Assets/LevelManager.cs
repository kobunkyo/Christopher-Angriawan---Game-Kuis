using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public struct DataSoal
    {
        public string pertanyaan;
        public Sprite petunjukJawaban;
        public string[] pilihanJawaban;
        public bool[] adalahBenar;
    }

    [SerializeField]
    private DataSoal[] _soalSoal = new DataSoal[0];

    [SerializeField]
    private UI_Pertanyaan _pertanyaan = null; // Penghubung script ke UI_Pertanyaan

    [SerializeField]
    private UI_PoinJawaban[] _pilihanJawaban = new UI_PoinJawaban[0]; // Penghubung script ke UI_PoinJawaban

    private int _indexSoal = -1;

    public void Start()
    {
        NextLevel();
    }

    public void NextLevel()
    {
        _indexSoal++;

        if(_indexSoal >= _soalSoal.Length)
        {   
            _indexSoal = 0;
        }

        DataSoal soal = _soalSoal[_indexSoal];

        _pertanyaan.SetPertanyaan($"Soal {_indexSoal + 1}", soal.pertanyaan, soal.petunjukJawaban); // Masukin value dari Level Manager ke script UI_Pertanyaan

        for(int i = 0; i<_pilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _pilihanJawaban[i]; // Masukin ke jawaban A - D lewat for loop
            poin.SetJawaban(soal.pilihanJawaban[i], soal.adalahBenar[i]); // Masukin value dari Level Manager ke script UI_PoinJawaban
        }
    }
}
