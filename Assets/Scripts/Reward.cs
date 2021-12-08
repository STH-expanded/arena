using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Reward
{
	public String name;
	public Func<GameObject, int> applyReward;

	public Reward(string nameReward, Func<GameObject, int> applyRewardFunction)
	{
		name = nameReward;
		applyReward = applyRewardFunction;
		

	}


}
