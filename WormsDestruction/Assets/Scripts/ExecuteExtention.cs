using UnityEngine;
using System.Collections;
using System;

public static class ExecuteExtention {

    public static void Execute<T>(this GameObject target, Action<T> message)
    {
        // we vragen de target of hij een lijst met components heeft die de gevraagde interface implementeren (in mijn voorbeeld IDamageable)
        T[] components = target.GetComponents<T>();

        // we loopen over alle components heen en roepen de Action message() aan
        // en geven de component door als argument
        foreach (T component in components)
        {
            message(component);
        }
    }
}
