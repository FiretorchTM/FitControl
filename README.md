# 🏋️‍♂️ FitControl - Academia de Ginástica

Sistema de gerenciamento de academia desenvolvido em **C# (Console Application)** focado em boas práticas de Programação Orientada a Objetos (POO) e Engenharia de Software.

### 🚀 Arquitetura e Padrões Aplicados:
- **Padrão MVC Adaptado:** Separação clara de responsabilidades entre Dados (`Models`), Regras de Negócio (`Controllers`) e Interface de Usuário (`Views`).
- **Generics e Herança:** Utilização de uma classe `BaseCRUD<T>` abstrata para gerenciar a persistência em memória de qualquer entidade do sistema sem duplicação de código.
- **Composição de Objetos:** Entidades altamente coesas (ex: `AlunoModel` possui uma referência direta ao objeto `PlanoModel`).
- **Encapsulamento e Documentação:** Proteção de atributos privados, propriedades seguras e código 100% documentado via XML (`<summary>`).