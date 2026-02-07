using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class ModManager : MonoBehaviour
{
    public MonoBehaviour script;
    
    // Start is called before the first frame update
    void Start()
    {
         var addonFile = Directory.GetFiles(Application.dataPath + "/Plugins/", "*Addon.dll", SearchOption.AllDirectories).FirstOrDefault();
         var ass = Assembly.LoadFile(addonFile);
         foreach (var type in ass.GetTypes())
            {
                //этот тип унаследован от ScriptingBase?
                // не абстрактный?
                if (!type.IsAbstract)
                {
                    //создаем экземпляр скрипта
                    script = Activator.CreateInstance(type) as MonoBehaviour;
                    break;
                }
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
