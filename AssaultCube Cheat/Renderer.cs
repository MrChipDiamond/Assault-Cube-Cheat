using AssaultCube_Cheat;
using Swed64;

Renderer renderer = new Renderer();
renderer.Start().Wait();

Swed swed = new Swed ("ac_client");
IntPtr moduleBase = swed.GetModuleBase("ac_client.exe");


//ac_client.exe+C73EF - FF 08 <---Ammo   
//ac_client.exe+1C223 - 29 73 04 <---health 
//ac_client.exe+C7E5D - FF 08 <--- Gernades               

IntPtr ammoAddress = moduleBase + 0xC73EF;
IntPtr healthAddress = moduleBase + 0x1C223;
IntPtr nadeAddress = moduleBase + 0xC7E5D;

while (true)
{
    if (renderer.godMode)
    {
        swed.WriteBytes(healthAddress, "90 90 90"); //Enable gMode
    }
    else
    {
        swed.WriteBytes(healthAddress, "29 73 04"); //Disable gMode
    }
    //---
    if (renderer.unlimtedAmmo) 
    {
        swed.WriteBytes(ammoAddress, "90 90"); //Enable Ammo
    }
    else
    {
        swed.WriteBytes(ammoAddress, "FF 08"); //Disable Ammo
    }
    if (renderer.unlimtedNades)
    {
        swed.WriteBytes(nadeAddress, "90 90"); //Enable Gernades
    }
    else
    {
        swed.WriteBytes(nadeAddress, "FF 08"); //Disable Gernades
    }
    //---

}
