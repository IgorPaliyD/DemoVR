using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GazedObject : MonoBehaviour, iGazeReceiver
{
    private bool isGazingUpon;

    // Start is called before the first frame update
    public bool isOnTarget;
    public int taskNumber;
    public UnityEvent onGazeFinished;
    private float currentAmount = 0;
    private float lookFill = 0;
    private float min=0;
    private float max=1;
    [Tooltip("Скорость срабатывания подсветки")] public float lookDuration;
    [Tooltip("Материал объекта для подсветки")] public Material _material;
    [Tooltip("Материал объекта во время подсветки")] public Material _materialGazing;
    private Coroutine routine;

    [SerializeField, Tooltip("Если активна то работет для группы материалов")] private bool _isGlobal = false;

    private void UpdateProgress(float duration = 2f)
    {
        routine = StartCoroutine(GazeProgress(duration));
    }
    IEnumerator GazeProgress(float duration)
    {
        float time = 0;

        while (time < duration)
        { 
            time += Time.deltaTime;
            GazeEffect(time, duration);
        
            if (duration <= time + 0.1f && duration >= time - 0.1f)
            {
                onGazeFinished.Invoke();
             
            }
         
            yield return null;
        }
    }
    public void GazingUpon()
    {
         
        isGazingUpon = true;
        if (!isOnTarget)
        {
            DeleteMaterial();
            AddMaterial(_materialGazing);
            if (lookDuration > 0)
                UpdateProgress(lookDuration);
            else
                UpdateProgress();
            isOnTarget = true;
        }
    }
  
    public void NotGazingUpon()
    {
        DeleteMaterial();
        AddMaterial(_material);
        _materialGazing.SetFloat("_Power", 3);
        isGazingUpon = false;
        routine = StartCoroutine(GazeProgress(1));
        StopCoroutine(routine);
        isOnTarget = false;

    }
    // Действия в момент активации объекта
    void OnEnable()
    {
        AddMaterial(_material);
    }
    // Действия в момент деактивации объекта
    void OnDesable()
    {
        DeleteMaterial();
    }
    // Добавление материала подсветки на объект
    void AddMaterial(Material material)
    {
        if (_isGlobal)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var materials = new List<Material>();

                var meshRenderer = this.transform.GetChild(i).GetComponent<MeshRenderer>();

                meshRenderer.GetMaterials(materials);

                materials.Add(material);

                meshRenderer.materials = materials.ToArray();
            }

        }
        else
        {
            var materials = new List<Material>();

            var meshRenderer = this.GetComponent<MeshRenderer>();

            meshRenderer.GetMaterials(materials);

            materials.Add(material);

            meshRenderer.materials = materials.ToArray();
        }
       

    }
    // Эффект подсветки материала
    void GazeEffect(float time, float duration)
    {
        min = _materialGazing.GetFloat("_MinFill");
        max = _materialGazing.GetFloat("_MaxFill");
        var perc = (time / duration);
        var otherperc = min + (max-min) * perc;
        // _materialGazing.SetFloat("_Power",otherperc);
        _materialGazing.SetVector("_Fill", new Vector4(0, otherperc, 0, 0));
    }
    // Удаление материала с объектов
    void DeleteMaterial()
    {
        if (_isGlobal)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var materials = new List<Material>();

                var meshRenderer = this.transform.GetChild(i).GetComponent<MeshRenderer>();

                meshRenderer.GetMaterials(materials);
                if (materials.Count > 1)
                {
                    materials.RemoveAt(materials.Count - 1);
                    meshRenderer.materials = materials.ToArray();
                }
                else return;
            }
        }
        else
        {
            var materials = new List<Material>();

            var meshRenderer = this.GetComponent<MeshRenderer>();

            meshRenderer.GetMaterials(materials);
            if (materials.Count > 1)
            {
                materials.RemoveAt(materials.Count - 1);
                meshRenderer.materials = materials.ToArray();
            }
            else return;
        }
    }
}
