using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversasDaArea1PT_BR
{
    public static Dictionary<ChaveDeTexto, List<string>> txt = new Dictionary<ChaveDeTexto, List<string>>()
    {
        { ChaveDeTexto.atravessouTecidoDoTempo,new List<string>()
        {
            "Hey!! Você é mais uma figura que atravessou o tecido do tempo?",
            "Desde a ascenção dos espiritos de ódio, vez ou outra, uma figura transcende os limites do tempo e do espaço.",
            "Normalmente, estes são figuras que se colocaram em oposição ao regime de ódio antes do cataclisma.",
            "Você também está aqui para lutar?"
        }
        },
        { ChaveDeTexto.caminhoAdiante,new List<string>()
        {
            "Se você treme de indignação diante de uma injustiça então pode me chamar de companheiro.",
            "Como companheiro, devo te alertar do que há pela frente",
            "A maioria dos que transcederam o tempo, como nós, pularam na fenda adiante.",
            "A fenda leva ao esgoto dos oportunistas",
            "Parece que há uma concentração de espiritos de ódio por lá",
            "Se existe saida para esse cataclisma, o caminho começa enfrentando o que há de mais baixo no esgoto",
            "Mas devo te alertar... A maioria dos que foram não voltaram",
            "Lutar é resistir!",
            " Até a vitória sempre!!"
        }
        },
        {
            ChaveDeTexto.EstatuasDeValor,new List<string>()
            {
                "No caminho até aqui encontrei algumas estátuas que emitiam estrelas de valor",
                "Eu costumo chama-las de canalizadores de valor",
                "Se encontrar por ai estatuas de canalizadores de valor, as ataque",
                "Você deve conseguir estrelas de valor assim"
            }
        },
        {
            ChaveDeTexto.distorcaoDoEspacoPeloOdio,new List<string>()
            {
                "Me disseram que os espiritos de ódio que vagam por ai tiveram origem em noticias falsas que distorceram a realidade",
                "Com a distorção da realidade os espiritos de ódio causaram um ferimento no tecido do tempo",
                "Com a distorção do tempo, eu já nem sei mais se o presidente está mandando atear fogo na amazonia, ",
                "ou se o presidente está confiscando a caderneta de poupança do povo"
            }
        },
        {
            ChaveDeTexto.ocupacaoResiste,new List<string>()
            {
                "Eu ocupei essa terra para servir de repouso para aqueles que ainda não foram consumidos pelos espiritos de ódio",
                "Neste lugar há mais terra sem gente do que gente sem terra.",
                "Mas a maior parte está concentrada sob o poder dos espirítos de ódio",
                "Ocupar é resistir a essas desigualdades que se apresentam escancaradas na nossa frente.",
                "Alguns já passaram por aqui e devo aguarda-los caso retornem.",
                "Devo defender a ocupação para que sempre exista um ponto de resistencia contra os espiritos de ódio",
                "Enquanto a ocupação resistir ela será um porto seguro para onde você pode retornar."
            }
        },
        {
            ChaveDeTexto.resgatandoComerciante,new List<string>()
            {
                "Own...! o que está acontecendo? Como vim parar aqui? meus pensamentos parecem dormentes.",
                "Parece que essa onda de ódio perturbou minha mente",
                "Eu estive me deslocando pelas zonas dominadas pelo ódio para levar recursos para a ocupação dos resistentes",
                "Eu colho estrelas de valor na ocupação e venho aos comerciantes das profundezas trocar por recursos",
                "Não esperava que os espiritos de ódio poderiam afetar minha sanidade",
                "Meu estoque está numa barraca na ocupação dos resistentes. Talvez algo que eu guardo lá possa te ajudar"
            }
        },
        {

            ChaveDeTexto.naoDeixeDeMeProcurar,new List<string>()
            {
                "Vou sair daqui logo. Estou indo para a ocupação dos resistentes. Não deixe de me procurar por lá."
            }
        },
        {

            ChaveDeTexto.conhecimentoSobreTecidoDoTempo,new List<string>()
            {
                "Vejam só se não é mais um que trancendeu o tecido do tempo e do espaço",
                "Durante algum tempo eu canalisei valor antes do cataclisma",
                "Antes de todos eu já venci o tempo, me deslocando para momentos especificos da história",
                "Diante da tragédia que se formou democraticamente, eu não vejo outra alternativa, vou compartilhar segredos com você.",
            }
        },
        {

            ChaveDeTexto.comoViajarNoEspaco,new List<string>()
            {
                "Veja essa maquina aqui ao lado...",
                "Eu aprendi a me deslocar através do tempo e do espaço para locais onde exemplares dessa maquina podem ser encontrados",
                "Vá até essa maquina e pressione alguns botões",
                "Ela mostrará os locais para onde você pode viajar"
            }
        },
        {

            ChaveDeTexto.prazerEmConhecerCapsulas,new List<string>()
            {
                "O cataclisma apagou o rastro das maquinas que ficaram espalhadas pelo tempo",
                "Para voltar a acessa-las preciso que você as encontre",
                "Quando encontrarmos as maquinas espalhadas pelo cataclisma poderemos nos deslocar pelos diferentes pontos do espaço e do tempo",
                "Acredito que isso nos ajudará no combate aos espirítos de ódio."
            }
        },
        {

            ChaveDeTexto.locomoverComACapsula,new List<string>()
            {
                "No painel da maquina você pode ver os locais onde ela pode te transportar.",
                "Interaja com a maquina e te ajudarei a se transportar com ela."
            }
        },
        {

            ChaveDeTexto.companheiraDosEspolios,new List<string>()
            {
                "Uma de nossas companheiras retornou...",
                "Ela tem incansávelmente buscado recursos para manter a ocupação e a resistencia",
                "Agora ela está na barraca dela ajeitando o estoque.",
                "Vá até lá, no estoque da ocupação deve ter algo que te interesse"
            }
        },
        {

            ChaveDeTexto.mantendoEstoque,new List<string>()
            {
                "O estoque de recursos da ocupação é mantido através de comercios realizados nas profundezas do cataclisma",
                "Membros da ocupação tem viajado nos caminhos da realidade distorcida pelo ódio em busca de comerciantes que ajudam a causa",
                "A moeda de troca por aqui são as estrelas de valor.",
                "Por isso nossa companheira vai trocar itens do nosso estoque por estrelas de valor",
                "Troque itens do nosso estoque por estrelas de valor e você estará ajudando a ocupação dos resistentes"
            }
        },
        {

            ChaveDeTexto.obrigadoPorResgatarManu,new List<string>()
            {
                "Muito obrigado por me resgatar na ocupação em reintegração.",
                "Acho que as noticias falsas mexeram com a minha mente",
                "É dificil manter a saude mental quando se é bombardeado com noticias fraudulentas distorcendo a nossa realidade",
                "Mas é preciso resistir!",
                "A final pessoas como eu e você, que trancendemos o cataclisma do ódio, temos o dever de lutar contra a fraude."

            }
        },
        {

            ChaveDeTexto.comprarParaAjudarResistencia,new List<string>()
            {
                "Usamos as estrelas de valor para trezer recursos  aos resistentes que retornam a ocupação",
                "Quando você troca suas estrelas de valor pelos produtos em nosso estoque, você está ajudando a resistencia ao ódio",
                "Junte as estrelas de valor que você puder coletar dos espiritos de ódio e venha até o estoque",
                "Garanto que existem itens que serão de grande utilidade no seu caminho"
            }
        },
        {

            ChaveDeTexto.estoqueEsgotado,new List<string>()
            {
                "Infelizmente, não há mais nada no nosso estoque.",
                "Estou me preparando para sair em jornada e buscar mais recursos para a ocupação",
                "Não se preocupe se você visistar a minha barraca e eu não estiver",
                "Voltarei em breve para abastecer o estoque"

            }
        }



    };
}
