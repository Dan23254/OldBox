﻿ using Sandbox;
using System;

[Library( "ent_hotdog", Title = "Hotdog", Spawnable = true )]
public partial class Hotdog : Prop, IUse
{
	public float MaxSpeed { get; set; } = 1000.0f;
	public float SpeedMul { get; set; } = 1.2f;

	public override void Spawn()
	{
		base.Spawn();

		SetModel( "models/citizen_props/hotdog01.vmdl" );
		SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );
	}

	public bool IsUsable( Entity user )
	{
		return true;
	}

	public bool OnUse( Entity user )
	{
		if ( user is Player player )
		{
			player.Health += 15;

			Delete();
		}

		return false;
	}
}
