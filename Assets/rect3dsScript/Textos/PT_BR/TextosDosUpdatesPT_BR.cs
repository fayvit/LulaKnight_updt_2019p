using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextosDosUpdatesPT_BR {
    public static Dictionary<ChaveDeTexto, List<string>> txt = new Dictionary<ChaveDeTexto, List<string>>()
    {
        { ChaveDeTexto.androidUpdateMenu,new List<string>()
        {
            "Movimentação",
            "Ataque",
            "Ataque para baixo",
            "Ataque para cima",
            "Pulo",
            "Recuperação magica",
            "Ataque magico",
            "Dash",
            "Flecha cadente magica",
            "Duplo pulo",
            "Bandeira azul",
            "Bandeira verde",
            "Bandeira dourada",
            "Bandeira Vermelha",
            "Movimentação"
        } },
        { ChaveDeTexto.androidUpdateInfo,new List<string>()
        {
            "Use o joystick virtual para se movimentar",
            "Para atacar use",
            "Durante o pulo pressione para baixo e o botão de ataque",
            "Pressione para cima e o botão de ataque [também durante o pulo]",
            "Para pular use ",
            "Para recuperar o HP segure ",
            "Para usar o ataque magico pressione ",
            "Para usar o Dash [também durante o pulo]  pressione ",
            "Durante o pulo, pressione para baixo e o botão de magia",
            "No ar pressione o botão de pulo novamente",
            "Você pode quebrar barreiras azuis com essa bandeira, selecione a bandeira pressionando ",
            "Você pode quebrar barreiras verdes com essa bandeira, selecione a bandeira pressionando ",
            "Você pode quebrar barreiras douradas com essa bandeira, selecione a bandeira pressionando ",
            "Você pode quebrar barreiras vermelhas com essa bandeira, selecione a bandeira pressionando ",
            "Para movimentar-se pressione"
        }
        },
        {
            ChaveDeTexto.botonsInfo,new List<string>()
            {
                "Você pode adicionar bótons na sua bandeira enquanto tiver encaixes disponiveis",
                "As estrelas deixadas pelos inimigos são atraidas pela bandeira",
                "Aumenta seu potencial de ataque",
                "Aumenta o tempo de invulnerabilidade ao ser atingido por um ataque."
            }
        },
        {
            ChaveDeTexto.emblemasTitle,new List<string>()
            {
                "Espaço Disponivel",
                "Esperança Magnetica",
                "Ataque Aprimorado",
                "Suspiro Longo"
            }
        },
         {
            ChaveDeTexto.frasesDeBotons,new List<string>()
            {
                "Você colocou na bandeira o bóton {0}",
                "São necessários {0} alfinetes de bóton para equipar {1}. Você não tem alfinetes suficientes",
                "Este bóton já está na bandeira",
                "Isso é um alfinete livre para inserir um bóton",
                "Nenhum bóton disponivel",
                "Você não tem nenhum bóton disponivel para usar na bandeira",
                "Ocupa {0} alfinetes",
                "Você coletou o Bóton:"
            }
        },
         {
            ChaveDeTexto.frasesDeColetaveis,new List<string>()
            {
                "Você mobilizou um militante de coragem",
                "Ao unir grupos com seis desses militantes sua barra de resistencia é aumentada",
                "Você mobilizou um militante de perseverança",
                "Ao unir um grupo com cinco desses militantes sua barra de esperança é aumentada",
                "Você recebeu um diploma de Doutor Honoris Causa",
                "Está adicionado mais um alfinete para botton de habilidade"
            }
        },
          {
            ChaveDeTexto.nomesItens,new List<string>()
            {
                "Esfera de coalisão",
                "Chave da cidade ... ",
                "Escada para profundezas"
            }
        },
          {
            ChaveDeTexto.descricaoDosItensNoInventario,new List<string>()
            {
                "Uma esfera dificil de quebrar. Há quem diga que quebra-la é um sinal de sorte que pode reestabelecer a esperança",
                "Uma chave com a inscrição \" Chave da cidade de ...\", o nome da cidade está ilegivel. \n\r Parece uma chave entregue para pessoas de destaque quando estas visitam cidades que os admiram",
                "Escada para profundezas"
            }
        },
          {
            ChaveDeTexto.descricaoDosItensVendidos,new List<string>()
            {
                @"Ao olhar firme para essa esfera podemos ver imagens de coroneis regionais, parlamentares fisiologicos e seres sedentos por cargos.

Há quem diga que quem puder quebrar essa esfera pode resgatar e recanalizar uma grande quantidade de esperança perdida.",
                @"Uma chave desproporcional com uma inscrição raspada onde pode-se ler 'Chave da cidade de ...', o nome da cidade está ilegivel.

Talvez a distorção do tempo e do espaço tenha mudado o significado e a fechadura que essa chave abre. 

",
                @"É bem irritante pular naquela fenda para o esgoto dos oportunistas e não poder voltar não é?

Seus problemas acabaram!!

Comprando essa escada você poderá subir de volta a partir da fenda.",
                @"Esse selo antigo remete a uma história repleta de hipocrisia. 

Nesses tempos sombrios que pairam sobre nós, existem colecionadores que admiram o lema do \'amor como base\'",
                @"Você tem visto muitas de suas estrelas de valor rolarem para lugares onde você não consegue pegar?

Seus problemas acabaram!!

Esse bóton faz com que as estrelas sejam atraidas por você.",
                "Com esse bóton na sua bandeira o tempo que você fica invencivel ao tomar dano aumenta. Pense bem... É ou não é bom ter um suspiro mais longo?",
                "Com algumas estrelas de valor podemos enviar uma passagem para um militante de coragem se juntar a nossa causa",
                "Com algumas estrelas de valor podemos enviar uma passagem para um militante de perseverança se juntar a nossa causa.",


            }
        },
          {
            ChaveDeTexto.nomeParaItensVendidos,new List<string>()
            {
                "Esfera de coalisão",
                "Chave da cidade ... ",
                "Escada para as profundezas",
                "Selo Positivista do Amor",
                "Bóton do dinheiro magnético",
                "Bóton do Suspiro Longo",
                "Militante de coragem",
                "Militante de perseverança"
            }
        },
          {
            ChaveDeTexto.frasesParaTutoPlacas,new List<string>()
            {
                "Você pode recuperar seus pontos de resistencia segurando",
                "Recuperar pontos de resistencia custa pontos de esperança. Você recupera pontos de esperança atacando espiritos de ódio",
                "Você recebeu um diploma de Doutor Honoris Causa",
                "Está disponivel mais um espaço para bóton de habilidade",
                "Você pode colocar bótons na sua bandeira enquanto está num checkPoint",
                "Quando em um checkpoint utilize o menu de pause para colocar bótons na bandeira"
            }
        },
        {
            ChaveDeTexto.updateSetaSombria, new List<string>()
            {
                "Você aprendeu a usar a Seta Magica",
                "Usar a seta magica custa pontos de magia. Você recupera pontos de magia atacando inimigos",
                "Para usar a seta magica pressione",
                "Pressionando rapidamente o botão de magia você disparará uma seta magica."
            }
        },
        {
            ChaveDeTexto.updateBlueSword, new List<string>()
            {
                "Você coletou a bandeira Azul",
                "Com a bandeira Azul você pode quebrar barreiras azuis",
                "Alterna a cor da bandeira",
                "Você pode alternar a cor da sua bandeira pressionando "
            }
        }
    };
}