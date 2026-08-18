<h1 align="center" style="font-weight: bold;">
  BIME
  <img 
    width="40" 
    height="40" 
    alt="BIME Icon" 
    src="https://github.com/user-attachments/assets/3d43a934-b565-46c8-8e1a-7401da9d7f50"
    style="vertical-align: middle; margin-left: 22px;"
  />
</h1>

<p align="center">
  <a href="#screens">Telas</a> •
  <a href="#how">Como Funciona</a> •
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

<h2>👨‍💻 Desenvolvedor</h2>

<p align="center">
  Desenvolvido por <b>Ismael Gabri</b>
</p>
