using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Reward
{
	public int id;
	public String name;
	public Func<GameObject, int> applyReward;

	public Reward(int idReward, string nameReward, Func<GameObject, int> applyRewardFunction)
	{
		id = idReward;
		name = nameReward;
		applyReward = applyRewardFunction;
		

	}


}
