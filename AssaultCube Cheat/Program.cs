using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ClickableTransparentOverlay;
using ImGuiNET;
using System.Runtime.InteropServices;

namespace AssaultCube_Cheat
{
    public class Renderer : Overlay
    {
        public bool godMode = false;
        public bool unlimtedAmmo = false;
        public bool unlimtedNades = false;
        private bool showMenu = true;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;

        public Renderer()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
        }

        protected override void Render()
        {
            if (ImGui.IsKeyPressed(ImGuiKey.Insert))
            {
                showMenu = !showMenu;
            }

            if (!showMenu) return;

            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4(0.1f, 0.1f, 0.1f, 0.9f));
            ImGui.PushStyleColor(ImGuiCol.TitleBg, new Vector4(0.2f, 0.2f, 0.8f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.TitleBgActive, new Vector4(0.3f, 0.3f, 1.0f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0.2f, 0.6f, 0.8f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.ButtonHovered, new Vector4(0.3f, 0.7f, 0.9f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.ButtonActive, new Vector4(0.1f, 0.5f, 0.7f, 1.0f));

            Vector2 windowSize = new Vector2(520, 300);
            ImGui.SetNextWindowSize(windowSize);
            ImGui.Begin("Assault Cube");

            if (ImGui.BeginTabBar("OptionsTabBar"))
            {
                if (ImGui.BeginTabItem("Main"))
                {
                    ImGui.Text("Basic Cheats");
                    ImGui.Checkbox("Enable God Mode", ref godMode);
                    ImGui.Checkbox("Enable Unlimited Ammo", ref unlimtedAmmo);
                    ImGui.Checkbox("Enable Unlimited Gernades", ref unlimtedNades);
                    ImGui.Separator(); 
                    ImGui.EndTabItem();
                }

                if (ImGui.BeginTabItem("ESP"))
                {
                    ImGui.Separator(); 
                    ImGui.EndTabItem();
                }

                ImGui.EndTabBar();
            }

            if (ImGui.Button("Exit"))
            {
                Environment.Exit(0); 
            }

            ImGui.End();
        }
    }
}
