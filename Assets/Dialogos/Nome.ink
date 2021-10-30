VAR sabeNome = false
VAR nomeAtual = ""

-> Inicio

== Inicio ==
{(!sabeNome):
    Boa noite #sprite:veio #falante:Senhor
    Qual é seu nome?
    -> Escolhas
  - else:
    Insatisfeito com seu nome?
    
    + Sim #sprite:jogador #falante:nomeJogador
        Escolha um novo nome #sprite:veio #falante:Senhor
        -> Escolhas
        
    + Não  #sprite:jogador #falante:nomeJogador
        Ok, <color="red">{nomeAtual}</color>! #sprite:veio #falante:Senhor
    -> END
}

== Escolhas ==
+ [Fulano] -> Nome("Fulano")
+ [Deltrano] -> Nome("Deltrano")
+ [Ciclano] -> Nome("Ciclano")

== Nome (_nome) ==
    {(nomeAtual != _nome):
        Seu nome agora é <b>{_nome}<\b>
        ~ nomeAtual = _nome
        ~ sabeNome = true
        - else:
        Esse já é seu nome!
    }
    -> Inicio


