using Sandbox;
using System;

[Library( "ent_radio4", Title = "Radio", Spawnable = true )]
public partial class RadioEntity4: Prop, IUse
{

	public bool Enable { get; set; } = false;
	private Sound RadioSnd;

	public override void Spawn()
	{
		base.Spawn();
		CheckSnd();
		SetModel("models/sbox_props/ticket_dispenser/ticket_dispenser.vmdl");
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
			CheckSnd();
		}

		return false;
	}

	public void CheckSnd()
	{
		if(Enable==true){
			Enable=false;
			RadioSnd = base.PlaySound("radioengi");
		}else{
			Enable=true;
			RadioSnd.Stop();
		}
	}

	protected override void OnDestroy()
	{
		RadioSnd.Stop();
		base.OnDestroy();
	}
}
