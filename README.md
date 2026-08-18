<h1 align="center" style="font-weight: bold;">
  BIME
  <img 
    width="40" 
    height="40" 
    alt="BIME Icon" 
    src="https://github.com/user-attachments/assets/3d43a934-b565-46c8-8e1a-7401da9d7f50"
    style="vertical-align: middle; margin-left: 12px;"
  />
</h1>

<p align="center">
  <b>BI Model Extractor</b>
</p>

<p align="center">
  <a href="#tech">Tecnologias</a> •
  <a href="#screens">Telas</a> •
  <a href="#how">Como Funciona</a> •
  <a href="#about">Sobre o Projeto</a>
</p>

<p align="center">
    <b>
    Ferramenta desenvolvida para extrair a estrutura interna de modelos Power BI,
    convertendo arquivos PBIX em uma representação textual baseada em TMDL,
    compactando todo o conteúdo em ZIP e preparando o modelo para análise por Inteligência Artificial.
    </b>
</p>

---

<h2 id="tech">💻 Tecnologias</h2>

* C#
* .NET
* pbi-tools
* TMDL (Tabular Model Definition Language)

---

<h2 id="screens">🖥️ Telas</h2>

<h3>📊 Extração do Modelo</h3>

Tela principal do BIME, responsável por iniciar o processo de extração do modelo Power BI.

A aplicação identifica automaticamente uma instância do Power BI Desktop aberta e utiliza o modelo carregado no relatório para realizar a extração.

<p align="center">
  <img width="715" height="555" alt="Image" src="https://github.com/user-attachments/assets/d48ed484-4e74-4a0b-b406-4879e7cc81d6" />
</p>

---

<h3>⚙️ Configurações</h3>

Área destinada às configurações da aplicação e dos parâmetros utilizados durante o processo de extração.

<p align="center">
  <img width="722" height="559" alt="Image" src="https://github.com/user-attachments/assets/88e13d19-2591-4cd1-bf49-f6af5a3614a3" />
</p>

---

<h2 id="how">🔄 Como Funciona</h2>

O BIME foi desenvolvido para transformar um arquivo Power BI em uma estrutura que possa ser facilmente interpretada e analisada por ferramentas de Inteligência Artificial.

O processo funciona da seguinte maneira:

### 1. 📂 Abrir o Power BI

O usuário abre o relatório `.pbix` normalmente através do Power BI Desktop.

### 2. 🔎 Identificação automática

O BIME identifica automaticamente uma instância do Power BI Desktop em execução e localiza as informações necessárias para realizar a extração do modelo.

### 3. 📦 Extração do modelo

A aplicação utiliza o `pbi-tools` para extrair a estrutura interna do modelo Power BI.

O conteúdo do PBIX deixa de ser tratado apenas como um arquivo fechado e passa a ser disponibilizado em uma estrutura organizada e legível.

### 4. 📝 Conversão para TMDL

O modelo é disponibilizado utilizando **TMDL — Tabular Model Definition Language**, permitindo visualizar de forma estruturada elementos como:

* Tabelas
* Colunas
* Medidas
* Relacionamentos
* Hierarquias
* Partições
* Propriedades do modelo
* Expressões DAX
* Metadados
* Configurações do modelo
* Estruturas relacionadas ao Power Query/M, quando disponíveis na extração

### 5. 🗜️ Compactação

Após a extração, todos os arquivos gerados são organizados e compactados automaticamente em um arquivo `.zip`.

### 6. 🤖 Análise por Inteligência Artificial

O ZIP gerado pode então ser enviado para uma Inteligência Artificial.

Dessa forma, a IA consegue analisar a estrutura do modelo de maneira muito mais completa, podendo identificar:

* Problemas de modelagem
* Relacionamentos incorretos
* Medidas duplicadas ou inconsistentes
* Problemas em fórmulas DAX
* Colunas desnecessárias
* Tabelas mal estruturadas
* Possíveis problemas de performance
* Inconsistências entre medidas e modelo
* Problemas de cardinalidade
* Dependências entre tabelas e medidas
* Oportunidades de melhoria na arquitetura do BI

---

<h2 id="about">⚙️ Sobre o Projeto</h2>

O **BIME (BI Model Extractor)** foi desenvolvido para facilitar a análise técnica de modelos Power BI utilizando Inteligência Artificial.

Arquivos `.pbix` são extremamente úteis para utilização dentro do Power BI Desktop, porém sua estrutura interna não é naturalmente apresentada de uma forma simples para análise automatizada.

O objetivo do BIME é criar uma ponte entre o **Power BI** e a **Inteligência Artificial**.

Em vez de enviar apenas capturas de tela ou informações isoladas do relatório, o BIME permite extrair a estrutura do modelo e disponibilizá-la em arquivos de texto estruturados.

Isso possibilita que uma IA tenha acesso a uma visão muito mais completa do projeto, permitindo análises que seriam difíceis de realizar observando apenas o relatório visual.

### 🎯 Objetivo

Simplificar o processo:

**PBIX → Extração → TMDL → ZIP → IA → Análise do Modelo**

---

<h2>🚀 Principais Funcionalidades</h2>

✔ Identificação automática do Power BI Desktop aberto
✔ Extração do modelo Power BI
✔ Conversão da estrutura para TMDL
✔ Extração de tabelas e colunas
✔ Extração de medidas e expressões DAX
✔ Extração de relacionamentos
✔ Extração de metadados do modelo
✔ Organização automática dos arquivos extraídos
✔ Compactação automática em ZIP
✔ Preparação do modelo para análise por Inteligência Artificial
✔ Facilita auditoria e diagnóstico de modelos Power BI

---

<h2>🤖 Por que utilizar o BIME?</h2>

Uma análise tradicional de um Power BI normalmente depende de informações espalhadas entre o relatório, o modelo, o Power Query, as medidas DAX e os relacionamentos.

O BIME centraliza essas informações em uma estrutura que pode ser processada por uma IA.

Com isso, torna-se possível fornecer à IA um contexto muito mais próximo do modelo real utilizado no Power BI.

Por exemplo, ao invés de perguntar:

> "Por que meu faturamento está errado?"

e fornecer apenas uma captura de tela, é possível enviar o modelo extraído e permitir que a IA analise conjuntamente:

**Tabelas + Colunas + Relacionamentos + Medidas + DAX + Estrutura do Modelo**

Isso aumenta significativamente a capacidade de diagnóstico e compreensão do BI.

---

<h2>📁 Estrutura da Extração</h2>

Após a execução do BIME, o conteúdo extraído é organizado em uma estrutura baseada nos arquivos gerados pelo modelo tabular.

Uma representação simplificada pode ser:

```text
BIME-Extract/
│
├── model.bim
│
├── definition/
│   ├── model.tmdl
│   │
│   ├── tables/
│   │   ├── Clientes.tmdl
│   │   ├── Produtos.tmdl
│   │   ├── Vendas.tmdl
│   │   └── ...
│   │
│   └── relationships.tmdl
│
└── ...
```

A estrutura final pode variar de acordo com o modelo Power BI e os recursos utilizados no relatório.

---

<h2>📦 Resultado</h2>

Ao finalizar a operação, o BIME gera um arquivo compactado contendo a estrutura extraída do modelo.

Esse arquivo pode ser utilizado para:

* Análise por IA
* Auditoria de Power BI
* Diagnóstico de problemas
* Revisão de modelagem
* Análise de medidas DAX
* Documentação de modelos
* Investigação de relacionamentos
* Identificação de possíveis problemas de performance

---

<h2>🛠️ Fluxo de Utilização</h2>

```text
┌──────────────────────┐
│   Power BI Desktop   │
│       .PBIX          │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│        BIME          │
│ Identificação do PBI │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│     pbi-tools        │
│      Extract         │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│    Modelo TMDL       │
│ Tabelas / DAX / etc. │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│         ZIP          │
│ Modelo compactado    │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│   Inteligência       │
│     Artificial       │
│                      │
│ Análise do modelo    │
└──────────────────────┘
```

---

<h2>📌 Casos de Uso</h2>

### 🔍 Diagnóstico de BI

Enviar o modelo completo para uma IA investigar erros de medidas, relacionamentos ou cálculos.

### 📐 Auditoria de Modelagem

Avaliar a arquitetura do modelo e identificar possíveis problemas estruturais.

### 🧮 Análise de DAX

Permitir que a IA analise medidas e suas dependências dentro do modelo.

### 🔗 Análise de Relacionamentos

Verificar cardinalidade, direção de filtro e possíveis relacionamentos problemáticos.

### 📚 Documentação

Utilizar a estrutura extraída como base para gerar documentação técnica do modelo.

### 🚀 Otimização

Identificar possíveis oportunidades de melhoria de performance e organização do modelo.

---

<h2>⚠️ Requisitos</h2>

Antes de executar uma extração, certifique-se de que:

* O Windows esteja executando o BIME.
* O Power BI Desktop esteja aberto.
* O relatório `.pbix` esteja carregado no Power BI Desktop.
* O `pbi-tools` esteja disponível conforme a configuração da aplicação.
* O usuário tenha permissão para acessar os processos necessários.

---

<h2>👨‍💻 Desenvolvedor</h2>

<p align="center">
  Desenvolvido por <b>Ismael Gabri</b>
</p>
