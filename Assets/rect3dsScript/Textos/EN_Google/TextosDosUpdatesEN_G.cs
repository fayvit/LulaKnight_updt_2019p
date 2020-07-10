using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextosDosUpdatesEN_G
{
    public static Dictionary<ChaveDeTexto, List<string>> txt = new Dictionary<ChaveDeTexto, List<string>>()
    {
        { ChaveDeTexto.androidUpdateMenu,new List<string>()
        {
            "Movement",
            "Attack",
            "Attack down",
            "Attack Up",
            "Jump",
            "Magic recovery",
            "Magic Attack",
            "Dash",
            "Magic falling arrow",
            "Double jump",
            "Blue Flag",
            "Green Flag",
            "Golden Flag",
            "Red Flag",
            "Movement"
        } },
        { ChaveDeTexto.androidUpdateInfo,new List<string>()
        {
            "Use the virtual joystick to move",
            "To attack use",
            "During the jump press down and the attack button",
            "Press up and the attack button [also during the jump]",
            "To Jump use",
            "To recover the HP hold",
            "To use magic attack press",
            "To use Dash [also during the jump] press",
            "During the jump, press down and the magic button",
            "In the air press the jump button again",
            "You can break blue barriers with this Flag, select the Flag by pressing",
            "You can break green barriers with this Flag, select the Flag by pressing",
            "You can break gold barriers with this Flag, select the Flag by pressing",
            "You can break red barriers with this Flag, select the Flag by pressing",
            "To move press"
        }
        },
        {
            ChaveDeTexto.botonsInfo,new List<string>()
            {
                "You can add emblems to your Flag while you have available slots",
                "The stars left by enemies are attracted to the flag",
                "Increases your attack potential",
                "Increases invulnerability time by being hit by an attack."
            }
        },
        {
            ChaveDeTexto.emblemasTitle,new List<string>()
            {
                "Pin Available",
                "Magnetic Hope",
                "Enhanced Attack",
                "Long Sigh"
            }
        },
         {
            ChaveDeTexto.frasesDeBotons,new List<string>()
            {
               "You have put the emblem {0} on the flag",
                "You need {0} pins to equip {1}. You do not have enough space",
                "This emblem is already on the flag",
                "This is a pins to insert an emblem",
                "No emblem available",
                "You do not have any badge available to fit the flag",
                "Occupy {0} pins",
                "You collected the emblem:"
            }
        },
         {
            ChaveDeTexto.frasesDeColetaveis,new List<string>()
            {
                "You mobilized a courage activist",
                "By joining groups with six of these militants, your resistance bar is increased",
                "You mobilized a perseverance activist",
                "By joining a group of five of these militants, your hope bar is increased",
                "You received a Doctor Honoris Causa diploma",
                "Another pin for skill emblems is added"
            }
        },
          {
            ChaveDeTexto.nomesItens,new List<string>()
            {
                "Coalition sphere",
                "Key to the city ...",
                "Stairway to the depths"
            }
        },
          {
            ChaveDeTexto.descricaoDosItensNoInventario,new List<string>()
            {
               "A sphere that is difficult to break. Some say that breaking it is a sign of luck that can restore hope",
                "A key with the inscription \" Key to the city of ... \", the name of the city is unreadable. \n \r It looks like a key given to prominent people when they visit cities that admire them",
                "Ladder to the depths"
            }
        },
          {
            ChaveDeTexto.descricaoDosItensVendidos,new List<string>()
            {
                @"When looking steadily at this sphere we can see images of regional colonels, physiologic parliamentarians and beings thirsty for positions.

Some say that anyone who can break this sphere can rescue and rechannel a great deal of lost hope. ",
                @"A disproportionate key with a scratched inscription that reads 'Key to the city of ...', the name of the city is unreadable.

Perhaps the distortion of time and space has changed the meaning and the lock that this key opens.

",
                @"It is very irritating to jump into that gap in the sewer of opportunists and not be able to go back is not it?

Your problems are over!!

Buying this ladder you can climb back up from the crack. ",
                @"This old stamp reminds us of a history full of hypocrisy.

In these dark times that hover over us, there are collectors who admire the motto of \'love as a base \' ",
                @"Have you seen many of your valuable stars roll into places you can't get to?

Your problems are over!!

This emblem makes the stars attract you. ",
                "With that emblem on your flag, the time you stay invincible when taking damage increases. Think about it ... Is it good or not to have a longer breath?",
                "With some valuable stars we can send a ticket for a courageous campaigner to join our cause",
                "With a few valuable stars, we can send a ticket for a perseverance activist to join our cause."
            }
        },
          {
            ChaveDeTexto.nomeParaItensVendidos,new List<string>()
            {
                "Coalition sphere",
                "Key to the city ...",
                "Stairway to the depths",
                "Positivist Stamp of Love",
                "Magnetic hope emblem",
                "Emblem of the Long Sigh",
                "courage activist",
                "Perseverance activist"
            }
        },
          {
            ChaveDeTexto.frasesParaTutoPlacas,new List<string>()
            {
                "You can recover your resistance points by holding",
                "Recovering points of resistance costs points of hope. You recover points of hope by attacking spirits of hate",
                "You received a Doctor Honoris Causa diploma",
                "Another pin for a skill emblem is available",
                "You can put emblems on your flag while at a checkpoint",
                "When at a checkpoint use the pause menu to put emblems on the flag"
            }
        },
        {
            ChaveDeTexto.updateSetaSombria, new List<string>()
            {
               "You learned how to use the Magic Arrow",
                "Using the magic arrow costs magic points. You recover magic points by attacking enemies",
                "To use the magic arrow press",
                "By quickly pressing the magic button you will fire a magic arrow."
            }
        },
        {
            ChaveDeTexto.updateBlueSword, new List<string>()
            {
                "You collected the Blue flag",
                "With the Blue flag you can break blue barriers",
                "Toggle the color of the flag",
                "You can change the color of your flag by pressing "
            }
        }
    };
}
