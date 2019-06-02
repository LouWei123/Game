using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

    public static int _aliveEnemyNum = 0;
    public Waves[] _waves;
    public Transform _startPosition;
    public float _waveRate = 0.2f;
    private Coroutine _coroutine;

    void Start()
    {
        _coroutine = StartCoroutine(SpawnEnemy());
    }
    public Text EnemyShowTime;
    public Text WaveText;
    private float timer = 1f;
    private  int ttt=10;
    private void Update()
    {
        if (ttt <= 0) return;
         timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 1f;
            ttt--;
            EnemyShowTime.text = "敌人将要来临：" + ttt;
            if (ttt <= 0) EnemyShowTime.text = "敌人来临 ！";
        }
    }
    public void GameStop()
    {
        StopCoroutine(_coroutine);
    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(10f);
        int n = 1;
        foreach (Waves wave in _waves)
        {
            WaveText.text = "波数: "+( n++) + "/9";
            for (int i = 0; i < wave.count; i++)
            {
                FactoryManager.EnemyFactory.CreateEnemy(wave.enemyType, _startPosition, 1);
                _aliveEnemyNum++;
                if (i != wave.count - 1)
                    yield return new WaitForSeconds(wave.rate);
            }
            while (_aliveEnemyNum > 0)
            {
                yield return 0;
            }
            ttt = 10;
            yield return new WaitForSeconds(_waveRate);
        }
        while (_aliveEnemyNum > 0)
        {
            yield return 0;
        }

        Game_Manager.ShowGameWinUI();
    }
}
