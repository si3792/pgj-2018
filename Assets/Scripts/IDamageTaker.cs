﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageTaker {
    void TakeDamage(int value);
    int Health();
}
