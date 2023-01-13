using System.Diagnostics;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Components;
using Dalamud.Logging;
using ImGuiNET;

namespace AutoHook.Ui;

internal class TabGeneral : TabBaseConfig
{
    public override bool Enabled => true;
    public override string TabName => "General";

    public override void DrawHeader()
    {
        ImGui.Text("General settings");

        ImGui.Separator();

        ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.DalamudYellow);
        ImGui.TextWrapped("Things might be broken in this new version. If you spot any weird behavior, please click the button below.");
        ImGui.PopStyleColor();
      
        ImGui.Spacing();

        if (ImGui.Button("Click here to report an issue or make a suggestion"))
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/InitialDet/AutoHook/issues", UseShellExecute = true });
        }
        ImGui.Spacing();

#if DEBUG

        if (ImGui.Button("Testing"))
        {
            PluginLog.Debug($"Version = {Service.Configuration.Version}");
        }
#endif
    }
    public override void Draw()
    {

        if (ImGui.BeginTabBar("TabBarsGeneral", ImGuiTabBarFlags.NoTooltip))
        {
            if (ImGui.BeginTabItem("Default Cast###DC1"))
            {
                ImGui.PushID("TabDefaultCast");
                DrawDefaultCast();
                ImGui.PopID();
                ImGui.EndTabItem();
            }

            if (ImGui.BeginTabItem("Default Mooch###DM1"))
            {
                ImGui.PushID("TabDefaultMooch");
                DrawDefaultMooch();
                ImGui.PopID();
                ImGui.EndTabItem();
            }

            ImGui.EndTabBar();
        }

    }

    public void DrawDefaultCast()
    {
        ImGui.Spacing();
        ImGui.Checkbox("Use Default Cast", ref Service.Configuration.DefaultCastConfig.Enabled);
        ImGuiComponents.HelpMarker("This is the default hooking behavior if no Custom Preset is found.");

        ImGui.Indent();

        DrawInputDoubleMinTime(Service.Configuration.DefaultCastConfig);
        DrawInputDoubleMaxTime(Service.Configuration.DefaultCastConfig);
        DrawHookCheckboxes(Service.Configuration.DefaultCastConfig);
        DrawFishersIntuitionConfig(Service.Configuration.DefaultCastConfig);
        DrawCheckBoxDoubleTripleHook(Service.Configuration.DefaultCastConfig);

        ImGui.Unindent();

    }

    public void DrawDefaultMooch()
    {
        ImGui.Spacing();
        ImGui.Checkbox("Use Default Mooch", ref Service.Configuration.DefaultMoochConfig.Enabled);
        ImGuiComponents.HelpMarker("This is the default hooking behavior if no Custom Preset is found.");

        ImGui.Indent();

        DrawInputDoubleMinTime(Service.Configuration.DefaultMoochConfig);
        DrawInputDoubleMaxTime(Service.Configuration.DefaultMoochConfig);
        DrawHookCheckboxes(Service.Configuration.DefaultMoochConfig);
        DrawFishersIntuitionConfig(Service.Configuration.DefaultMoochConfig);
        DrawCheckBoxDoubleTripleHook(Service.Configuration.DefaultMoochConfig);

        ImGui.Unindent();
    }
}