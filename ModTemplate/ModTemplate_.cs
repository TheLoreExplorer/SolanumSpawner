using NewHorizons;
using NewHorizons.External.Modules;
using NewHorizons.Utility;
using OWML.Common;
using OWML.ModHelper;
using System;
using System.Runtime.InteropServices;
using UnityEngine.InputSystem;

namespace ModTemplate
{
    public class ModTemplate : ModBehaviour
    {
        private SolanumAnimController _solanumAnimController;
        private SolanumAnimController _solanumAnimController1;

        private void Awake()
        {
            
        }

        private void Start()
        {

            ModHelper.Console.WriteLine($"My mod {nameof(ModTemplate)} is loaded!", MessageType.Success);

            NewHorizons.Main.Instance.OnStarSystemLoaded.AddListener((sceneName) =>
            {
                if (sceneName != "SolarSystem") return;
                NewHorizons.Utility.Delay.FireOnNextUpdate(() =>
                {
                    var playerBody = FindObjectOfType<PlayerBody>();
                    ModHelper.Console.WriteLine($"Found player body, and it's called {playerBody.name}!",
                        MessageType.Success);

                    var Solanum1 = NewHorizons.Builder.Props.DetailBuilder.Make(Locator._timberHearth.gameObject, Locator._timberHearth._rootSector, this, new PropModule.DetailInfo()
                    {
                        position = new NewHorizons.Utility.MVector3(18.9473f, -45.9614f, 184.2829f),
                        rotation = new NewHorizons.Utility.MVector3(89.517f, 185.759f, 180.9649f),
                        path = "QuantumMoon_Body/Sector_QuantumMoon/State_EYE/Interactables_EYEState/ConversationPivot/Character_NOM_Solanum/Nomai_ANIM_SkyWatching_Idle",


                    });


                    _solanumAnimController = Solanum1.GetComponentInChildren<SolanumAnimController>();

                    var Solanum2 = NewHorizons.Builder.Props.DetailBuilder.Make(Locator._timberHearth.gameObject, Locator._timberHearth._rootSector, this, new PropModule.DetailInfo()
                    {
                        position = new NewHorizons.Utility.MVector3(16.43488f, -42.70979f, 185.3024f),
                        rotation = new NewHorizons.Utility.MVector3(356.3597f, 94.0201f, 102.8434f),
                        path = "QuantumMoon_Body/Sector_QuantumMoon/State_EYE/Interactables_EYEState/ConversationPivot/Character_NOM_Solanum/Nomai_ANIM_SkyWatching_Idle",

                    });
                    _solanumAnimController1 = Solanum2.GetComponentInChildren<SolanumAnimController>();
                });

            });
        }

      
        private void Update()
        {
            if (Keyboard.current[Key.U].wasReleasedThisFrame)
            {
              
                _solanumAnimController.StartWatchingPlayer();
                _solanumAnimController.PlayRaiseCairns();
                _solanumAnimController1._playerCameraTransform = SearchUtilities.Find("TimberHearth_Body/Sector_TH/Sector_Village/Interactables_Village/LaunchTower/Effects_HEA_Campfire").transform;
                _solanumAnimController1.StartWatchingPlayer();
            }
        }

        
    }
}
