# urashima-taro
Documentação: Fantasma<br>
Responsável: Alexandre email: alelocci@ime.usp.br<br>
18 de Outubro de 2021<br><br>

Arquivo(s) Criado(s): CacarMoverLimitar.cs.<br><br>

O que foi Implementado?<br>
Foi implementada a lógica de comportamento do No Player Fantasma, a qual possui as seguintes características:<br>

<ol>
<li>O Fantasma se move pelo ambiente de jogo.</li>
<li>O movimento do fantasma é limitado pelo ambiente de jogo.</li>
<li>Fantasma não passa através dos sólidos. </li>
<li>Se Fantasma se encontra a uma certa distância do Player, o fantasma para o movimento por um intervalo de tempo de 2 segundos e depois inicia um ataque indo
em direção ao Player.</li>
<li>Fantasma ataca o Player mesmo não tendo uma linha de visão limpa.
</ol><br>

Configuração do Fantasma:<br>

O No Player possui as seguintes configurações dispostas na interface do Inspector:<br>

<ol>
<li>Velocidade: velocidade com a qual o fantasma vaga pela cena.</li>
<li>Velocidade de ataque: velocidade com a qual o fantasma ataca o Player quando este se encontra no raio de ataque.</li>
<li>Raio alvo: distância mínima entre Fantasma e Player para que o Fantasma ataque o Player.</li>
<li>Tempo sec: tempo que o Fantasma espera para iniciar ataque ao Player.
<li>Altura: considerando a origem do espaço de jogo no ponto (0,0), 
Este parâmetro define o ponto mais distante da origem no eixo y quando x=0. Logo, a área de perambulação do fantasma na cena é delimitada no eixo y pelos pontos
(0,y) e (0,-y), sendo y o valor definido na interface.</li>
<li>Comprimento: considerando a origem do espaço de jogo no ponto (0,0), 
este parâmetro define o ponto mais distante da origem no eixo x quando y=0. Logo, a área de perambulação do fantasma na cena é delimitada no eixo x pelos pontos
(x,0) e (-x,0), sendo x o valor definido na interface.</li>
<li>Retorno: é o deslocamento feito pelo fantasma quando este atinge os limites de cena determinados pelos 5 e 6, neste 
limites devem ser colocados nas paredes externas da cena caso o ambiente seja fechado.
</ol><br>

Situação atual do desenvolvimento:<br>

Concluído.



