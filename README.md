# SmartAir: Sistema de Gerenciamento de Ares-Condicionados à Distância

![Logo do Projeto](docs/SmartAir%20LOGO.png)

---

> **Mini Trabalho de Conclusão de Curso** apresentado no componente de **Banco de Dados II** do Curso Técnico em Desenvolvimento de Sistemas integrado ao Ensino Médio, na **ETEC de Hortolândia**, 2024.  
> Orientação: Prof. Priscila Batista Martins  

---

## Sobre o Projeto

[**Assista ao vídeo do projeto**](insira-o-link-do-video-aqui)

[**Documento do Projeto**](docs/SmartAir.pdf)

O **SmartAir** é um sistema para gerenciar ares-condicionados à distância, idealizado por nosso grupo com apoio do Prof. Rafael de Colle. O projeto busca alinhar-se aos Objetivos de Desenvolvimento Sustentável (ODS) da ONU, destacando:

- **ODS 7** — Energia limpa e acessível (meta 7.3 - aumentar eficiência energética)  
- **ODS 9** — Indústria, Inovação e Infraestrutura (meta 9.4 - modernizar infraestrutura)  
- **ODS 12** — Consumo e Produção Responsáveis (meta 12.2 - uso eficiente de recursos)  
- **ODS 13** — Ação contra a mudança climática (meta 13.2 - integrar medidas de clima)  
- **ODS 17** — Parcerias e Meios de Implementação (meta 17.7 - promover transferência de tecnologias sustentáveis)

O projeto consiste em um sistema de gerenciamento remoto, permitindo controlar aparelhos de ar-condicionado por meio de uma aplicação **WPF** conectada ao **ESP32** via Wi-Fi. O ESP32, junto de sensores infravermelhos e emissores IR, transmite códigos de controle em padrão **NEC** para os aparelhos, reproduzindo sinais de controle físico e armazenando os comandos no banco de dados da aplicação. Assim, professores ou técnicos podem controlar remotamente os aparelhos a partir de dispositivos desktop (computadores dos professores ou da manutenção).

A aplicação possui duas telas principais:

- **Tela de Login**: autenticação de usuários (admin ou professores)  
- **Tela Principal**: interface de gerenciamento dos ares-condicionados

## Tecnologias Utilizadas

- **WPF .NET (C#)**  
- **MySQL**  
- **ESP32** (programado em Wiring, baseado em C++)  
- **Arduino IDE**  
- **IRremote (biblioteca infravermelho)**  

O sistema integra conceitos de **Internet das Coisas (IoT)** para proporcionar maior praticidade, automação e controle remoto.

## Instalação e Execução

1. Clone ou baixe o projeto  
2. Conecte e rode o banco de dados MySQL  
3. Abra a solução no Visual Studio 2022  
4. Execute o projeto  
5. Acesse com login: **ADM** e senha: **123** (ou utilize a seta de bypass na tela de login)

## Informações Adicionais

- Projeto inscrito no **Laboratório de IoT** da ETEC de Hortolândia (coordenado pelo Prof. Rafael de Colle) no âmbito do projeto **SIPEP 4.3.01.01 — Tecnologias Digitais, Formação Docente e Divulgação de Conhecimento**  
- Status: **Em andamento**  
- Ano: **2024**

## Autores

- **Miguel Trentini Tortella**  
- **Paulo Eduardo Ferreira Junior**  
- **Pedro Santana Filipini**  
- **Vicente Matheus Collin Pedroso**

