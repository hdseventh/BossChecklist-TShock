using System.Text;
using System;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace BossChecklist_TShock
{
    [ApiVersion(2, 1)]
    public class BossChecklist_TShock : TerrariaPlugin
    {
        public override string Author => "hdseventh";
        public override string Description => "Boss Checklist for TShock";
        public override string Name => "Boss Checklist";
        public override Version Version { get { return new Version(1, 0, 0, 0); } }
        public BossChecklist_TShock(Main game) : base(game) { }
        public override void Initialize()
        {
            ServerApi.Hooks.GameInitialize.Register(this, OnInitialize);
        }

        public void OnInitialize(EventArgs args)
        {
            Commands.ChatCommands.Add(new Command("bcheck.use", bosscheck, "bosses"));
        }

        public void bosscheck(CommandArgs args)
        {
            var killed = "([c/FF0000:Killed] [i/s1:193])";
            var alive = "([c/00FF00:Alive] [i/s1:29])";
            StringBuilder sb = new StringBuilder();
            sb.Append("Eye of Cthulhu " + (NPC.downedBoss1 ? killed : alive));
            sb.Append("\nKing Slime " + (NPC.downedSlimeKing ? killed : alive));
            if (WorldGen.crimson)
            {
                sb.Append("\nBrain of Cthulhu " + (NPC.downedBoss2 ? killed : alive));
            }
            else
            {
                sb.Append("\nEater of Worlds " + (NPC.downedBoss2 ? killed : alive));
            }
            // Add Queen Bee
            sb.Append("\nSkeletron " + (NPC.downedBoss3 ? killed : alive));
            sb.Append("\nWall of Flesh " + (Main.hardMode ? killed : alive));
            sb.Append("\nQueen Slime " + (NPC.downedQueenSlime ? killed : alive));
            sb.Append("\nThe Destroyer " + (NPC.downedMechBoss1 ? killed : alive));
            sb.Append("\nThe Twins " + (NPC.downedMechBoss2 ? killed : alive));
            sb.Append("\nSkeletron Prime " + (NPC.downedMechBoss3 ? killed : alive));
            sb.Append("\nDuke Fishron " + (NPC.downedFishron ? killed : alive));
            sb.Append("\nGolem " + (NPC.downedGolemBoss ? killed : alive));
            sb.Append("\nPlantera " + (NPC.downedPlantBoss ? killed : alive));
            sb.Append("\nEmpress of Light " + (NPC.downedEmpressOfLight ? killed : alive));
            sb.Append("\nLunatic Cultist " + (NPC.downedAncientCultist ? killed : alive));
            sb.Append("\nMoon Lord " + (NPC.downedMoonlord ? killed : alive));
            args.Player.SendInfoMessage(sb.ToString());
        }

        protected override void Dispose(bool Disposing)
        {
            if (Disposing)
            {
                ServerApi.Hooks.GameInitialize.Deregister(this, OnInitialize);
            }
            base.Dispose(Disposing);
        }
    }
}
