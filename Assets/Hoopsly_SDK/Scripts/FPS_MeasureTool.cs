using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_MeasureTool : MonoBehaviour
{
    public static FPS_MeasureTool _instance;
    private List<int> m_readings = new List<int>();
    private bool m_isMeasuring = false;

    [Range(.1f, 2)]
    public float m_measurementIntervals = 1f;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);
    }

    public void StartMeasurement()
    {
        m_isMeasuring = true;
        StartCoroutine(FPS_MeasurementRoutine());
    }


    public int[] StopMeasurement()
    {
        int[] result = new int[3];
        m_isMeasuring = false;
        int[] m_readingsArray = m_readings.ToArray();
        Array.Sort(m_readingsArray);
        result[0] = Average(m_readingsArray);
        result[1] = (int)Percentile(m_readingsArray, .01f);
        result[2] = (int)Percentile(m_readingsArray, .05f);
        m_readings.Clear();
        return result;
    }

    IEnumerator FPS_MeasurementRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(m_measurementIntervals);
        m_readings.Clear();
        while(m_isMeasuring)
        {
            m_readings.Add((int)(1f / Time.unscaledDeltaTime));
            yield return delay;
        }
        
    }

    private int Average(int[] sequence)
    {
        int sum = 0;
        for (int i = 0; i < sequence.Length; i++)
        {
            sum += sequence[i];
        }
        return sum / sequence.Length;
    }

    //percentile 0-1 range
    private double Percentile(int[] sequence, double percentile)
    {
        int N = sequence.Length;
        double n = (N - 1) * percentile + 1;
        if (n == 1d) return sequence[0];
        else if (n == N) return sequence[N - 1];
        else
        {
            int k = (int)n;
            double d = n - k;
            return sequence[k - 1] + d * (sequence[k] - sequence[k - 1]);
        }
    }
}
