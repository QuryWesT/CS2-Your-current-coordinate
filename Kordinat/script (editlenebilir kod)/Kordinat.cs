using System.Numerics;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Entities;
using CounterStrikeSharp.API.Modules.Utils;

namespace Kordinat
{
    public class plugin_init: BasePlugin
    {
        public override string ModuleName => "Anlık Koordinat";
        public override string ModuleVersion => "1.0";
        public override string ModuleAuthor => "QuryWesT";

        public override void Load(bool hotReload)
        {
            AddCommandListener("sm_kordinat", pGetPlayerKordinat);
        }

        private HookResult pGetPlayerKordinat(CCSPlayerController? iPlayer, CommandInfo info)
        {
            if (iPlayer == null || !iPlayer.IsValid || !iPlayer.PawnIsAlive) { Server.PrintToChatAll("Konumunuzu almak için oyunda canlı olmalısınız!"); return HookResult.Continue; }
            var IsPlayerPawn = iPlayer.Pawn.Value;
            var IsPlayerPosition = IsPlayerPawn.AbsOrigin;
            var IsMessage = $"Mevcut konumunuz: X={IsPlayerPosition.X}, Y={IsPlayerPosition.Y}, Z={IsPlayerPosition.Z}";
            info.ReplyToCommand(IsMessage);
            Console.WriteLine($"{iPlayer?.PlayerName ?? "Bilinmeyen Oyuncu"} {ChatColors.Red}koordinatlar: {ChatColors.Blue}{IsMessage}");
            iPlayer.PrintToChat($"{iPlayer?.PlayerName ?? "Bilinmeyen Oyuncu"} {ChatColors.Red}koordinatlar: {ChatColors.Blue}{IsMessage}");
            return HookResult.Stop;
        }
    }
}
