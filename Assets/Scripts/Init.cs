using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface para todas as classes que implementam o Init()
// O Init � utilizado para garantir que ao instanciar um prefab, eu consiga que tudo dentro dele esteja inicializado
// E n�o dependo da fun��o Start() que � ass�ncrona dentro do Unity e pode levar a problemas de sincronia
public interface Init<T>
{
    T Init();
}
