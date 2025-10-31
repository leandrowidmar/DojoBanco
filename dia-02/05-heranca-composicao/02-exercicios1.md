# Herança em C# — Conteúdo + Exercício 1

> Baseado no material fornecido sobre **Herança**: classe base (genérica) e classes derivadas (especializadas).  
> Objetivo: praticar modelagem hierárquica, reuso de código, polimorfismo e sobrescrita (`override`).

---

## Revisão rápida
- **Classe base**: expõe atributos e comportamentos **comuns**.
- **Classe derivada**: especializa a base adicionando/alterando comportamento.
- **`virtual`/`override`**: permitem **polimorfismo** (comportamento adequado ao tipo real).
- Prefira **`decimal`** para valores monetários; valide entradas e estados.

---

## Etapas do Exercício

### Etapa 1 — Hierarquia de Contas
Crie uma classe **base** `Conta` com:
- Propriedades: `Titular` (string), `NumeroConta` (string).
- Método `Depositar(decimal valor)` e `Sacar(decimal valor)`. Ambos **virtuais** e com validação (valor > 0; impedir saldo negativo).  
- Propriedade protegida `Saldo` (somente leitura pública via método ou `protected set`).
- Método **virtual** `Resumo()` que retorna uma string com dados básicos.

Crie as derivadas:
- `ContaCorrente` com `TarifaSaque` (decimal). Sobrescreva `Sacar` para incluir a tarifa.
- `Poupanca` com `TaxaRendimentoAnual` (decimal). Adicione método `RenderJuros(int dias)` que aplica rendimento proporcional simples ao período (dias/365).
- `ContaConjunta` herdando de `ContaCorrente` com `SegundoTitular` (string) e `Resumo()` sobrescrito indicando os dois titulares.

### Etapa 2 — Polimorfismo
Crie uma lista `List<Conta>` com instâncias de **ContaCorrente**, **Poupanca** e **ContaConjunta**.  
- Faça operações de depósito/saque e depois percorra a lista chamando **`Resumo()`**.  
- Verifique que o método adequado de cada classe é chamado (polimorfismo).

### Etapa 3 — Transferências
Na classe base `Conta`, crie método `Transferir(Conta destino, decimal valor)` que:  
- Chama internamente `Sacar(valor)` na origem e `Depositar(valor)` no destino.  
- Validações: `destino` não pode ser `null`, `valor > 0`.  
- Demonstre a transferência entre contas de tipos distintos (ex.: de `ContaCorrente` para `Poupanca`).

### Etapa 4 — Registro de Movimentações (opcional)
Adicione um registro simples de movimentações na classe base: uma lista de `Movimentacao` com `Data`, `Descricao` e `Valor`.  
- Registre depósitos (+), saques (-) e transferências (saída/entrada).  
- Exponha como **somente leitura** e imprima ao final do teste.

---

## Critérios de Avaliação
- Modelagem correta da hierarquia e **uso de `virtual`/`override`**.  
- **Validações** (impedir valores inválidos/saldo negativo).  
- **Polimorfismo** demonstrado via lista de `Conta`.  
- Clareza do código, nomes descritivos e saídas legíveis.
