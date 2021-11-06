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
            var killed = "([c/FF0000:Killed])";
            var alive = "([c/00FF00:Alive])";
            StringBuilder sb = new StringBuilder();
            sb.Append("Eye of Cthulu " + (NPC.downedBoss1 ? killed : alive));
            sb.Append(", King Slime " + (NPC.downedSlimeKing ? killed : alive));
            if (WorldGen.crimson)
            {
                sb.Append(", Brain of Cthulu " + (NPC.downedBoss2 ? killed : alive));
            }
            else
            {
                sb.Append(", Eater of World " + (NPC.downedBoss2 ? killed : alive));
            }
            sb.Append(", Skeletron " + (NPC.downedBoss3 ? killed : alive));
            sb.Append(", Wall of Flesh " + (Main.hardMode ? killed : alive));
            sb.Append(", Queen Slime " + (NPC.downedQueenSlime ? killed : alive));
            sb.Append(", The Destroyer " + (NPC.downedMechBoss1 ? killed : alive));
            sb.Append(", The Twins " + (NPC.downedMechBoss2 ? killed : alive));
            sb.Append(", Skeletron Prime " + (NPC.downedMechBoss3 ? killed : alive));
            sb.Append(", Duke of Fishron " + (NPC.downedFishron ? killed : alive));
            sb.Append(", Golem " + (NPC.downedGolemBoss ? killed : alive));
            sb.Append(", Plantera " + (NPC.downedPlantBoss ? killed : alive));
            sb.Append(", Empress of Light " + (NPC.downedEmpressOfLight ? killed : alive));
            sb.Append(", Lunatic Cultist " + (NPC.downedAncientCultist ? killed : alive));
            sb.Append(", Moon Lord " + (NPC.downedMoonlord ? killed : alive));
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
