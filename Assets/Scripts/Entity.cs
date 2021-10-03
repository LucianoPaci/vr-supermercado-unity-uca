using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private string key;
    private string entityName;

    public event Action<Entity> OnStatusChanged;
    public bool picked = false;
    // Start is called before the first frame update
    
    
    void Start()
    {
        entityName = transform.root.name;
        if (key != null)
        {
            gameObject.name = key;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsPicked()
    {
        return picked;
    }

    public void ChangeStatus()
    {
        picked = !picked;
        OnStatusChanged?.Invoke(this);
    }
    public string GetName()
    {
        return entityName;
    }
    public string GetKey()
    {
        return key;
    }
}
