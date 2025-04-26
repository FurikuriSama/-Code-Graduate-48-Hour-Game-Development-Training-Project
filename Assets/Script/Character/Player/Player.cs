using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // 你可以在这里添加玩家特有的属性或方法

    // 例如：用于受伤的处理方法
    public void Hurt(float damage)
    {
        TakeDamage(damage); // 调用基类的 TakeDamage 方法
    }
}