# 🧮 Calculadora de Álgebra & Batalha Naval

Este projeto é uma aplicação de consola desenvolvida em C# que combina uma calculadora de operações algébricas (matrizes e vetores) com um minijogo de Batalha Naval. O projeto foi estruturado utilizando o padrão MVC.

## 📋 Funcionalidades

A aplicação está dividida em três módulos principais:

### 1. Operações com Matrizes
* Leitura e apresentação de matrizes;
* Soma de matrizes;
* Multiplicação de matrizes;
* Multiplicação por um escalar;
* Cálculo da Transposta;
* Cálculo da Inversa (específico para matrizes 2x2);
* Cálculo do Determinante (específico para matrizes 3x3);
* Verificações de propriedades (se é Diagonal ou Triangular).

### 2. Operações com Vetores
* Leitura e apresentação de vetores;
* Soma de vetores;
* Multiplicação por uma constante;
* Produto interno (escalar) de dois vetores.

### 3. Extra
* **Batalha Naval:** Um jogo clássico de estratégia implementado na consola.

## 🛠️ Requisitos Técnicos

* **.NET 8.0 SDK** ou superior.


## 📖 Guia de Utilização

Ao iniciar a aplicação, verá o **Menu Principal** com várias opções numéricas.

### 1. Fluxo Básico (Álgebra)
A calculadora funciona com um sistema de **memória por nomes**, permitindo guardar resultados para usar em contas futuras.

1.  **Criar Dados:**
    * Selecione **1** para ler uma Matriz ou **11** para um Vetor.
    * Insira os valores solicitados pelo programa.
    * **Atribua um nome único** (ex: `MatrizA`, `v1`) quando solicitado.
2.  **Realizar Operações:**
    * Escolha uma operação (ex: **3** para Somar Matrizes).
    * Quando questionado "Quais as matrizes?", digite os **nomes** que definiu anteriormente, separados por espaço (ex: `MatrizA MatrizB`).
    * No final, pode optar por guardar o resultado numa nova variável.
3.  **Comandos Úteis:**
    * `LM`: Lista todas as matrizes guardadas na memória.
    * `LV`: Lista todos os vetores guardados.

### 2. Jogo Batalha Naval (Opção 15)
O objetivo é afundar 3 navios escondidos num tabuleiro 5x5.

* **Como jogar:** O jogo pedirá um vetor de coordenadas para o tiro. Defina o tamanho como `2`, e insira a **Linha** (0-4) e a **Coluna** (0-4).
* **Legenda do Radar:**
    * `0`: Mar desconhecido.
    * `8`: **ACERTO** (Navio atingido!).
    * `-1`: **ÁGUA** (Tiro falhado).
* **Sair:** Escreva `q` a qualquer momento durante a leitura das coordenadas para abandonar a missão.
