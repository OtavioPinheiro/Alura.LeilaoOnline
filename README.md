# Alura.LeilaoOnline - TDD, TUs com xUnit e C#
Curso da Alura sobre testes unitários automatizados com xUnit e C#.

## Sumário
1. [TDD](#tdd)
2. [Frameworks de testes unitários](#frameworks-de-testes-unitários)
3. [Fixtures com xUnit](#fixtures-com-xunit)

## TDD
TDD (Test Driven Development) é uma técnica de desenvolvimento de software que consiste em escrever testes automatizados antes de implementar o código de produção. A ideia é que o desenvolvedor escreva um teste que falhe, implemente o código que faça o teste passar e, por fim, refatore o código.

### Ciclo do TDD
1. **Red**: escrever um teste que falhe
2. **Green**: implementar o código que faça o teste passar
3. **Refactor**: refatorar o código
4. **Repeat**: repetir o ciclo
5. **Release**: liberar o código

### Vantagens
- Código mais limpo e organizado
- Código mais testado
- Menos bugs
- Facilita a manutenção do código
- Facilita a integração contínua

### Desvantagens
- Curva de aprendizado
- Pode ser mais lento no início
- Pode ser difícil de aplicar em projetos:
  - legados;
  - com requisitos muito voláteis, complexos, mal definidos, específicos e/ou variados;

[Sumário](#sumário)

## Frameworks de testes unitários
Existem diversos frameworks de testes unitários para diversas linguagens de programação. Alguns exemplos são:
- JUnit (Java)
- NUnit (C#)
- xUnit (C#)
- PHPUnit (PHP)
- RSpec (Ruby)
- Jasmine (JavaScript)
- Mocha (JavaScript)
- Jest (JavaScript)
- PyTest (Python)
- unittest (Python)
- CppUnit (C++)
- Google Test (C++)
- Boost.Test (C++)
- Catch2 (C++)
- doctest (C++)
- Test::More (Perl)
- Test::Simple (Perl)
- Test::Unit (Ruby)
- Test::Class (Ruby)
- Test::More (Perl)
- Test::Simple (Perl)

### Frameworks de testes unitários para C#
Em C#, existem vários frameworks populares para testes unitários, cada um com suas características e funcionalidades. Os mais utilizados são:

**1. NUnit:**

*   **Histórico e Popularidade:** O **NUnit** é um dos frameworks de teste unitário mais antigos e populares para .NET. Ele foi inspirado no **JUnit** (para Java) e oferece uma estrutura robusta e madura para escrever testes.
*   **Anotações:** O **NUnit** utiliza atributos (semelhantes a anotações em Java) para definir métodos de teste, métodos de _setup_ e _teardown_, entre outros. Alguns atributos comuns incluem `[Test]`, `[SetUp]`, `[TearDown]`, `[OneTimeSetUp]`, `[OneTimeTearDown]`.
*   **Asserções:** O **NUnit** oferece uma rica variedade de asserções para verificar diferentes condições, como `Assert.AreEqual()`, `Assert.IsTrue()`, `Assert.Throws()`, entre outras.
*   **Data-Driven Tests:** O **NUnit** suporta testes orientados a dados, permitindo executar o mesmo teste com diferentes conjuntos de dados usando atributos como `[TestCase]`, `[TestCaseSource]` e `[ValueSource]`.
*   **Extensibilidade:** O **NUnit** é extensível e permite a criação de atributos e extensões personalizadas.

**Exemplo com NUnit:**

```csharp
using NUnit.Framework;

[TestFixture]
public class CalculadoraTest
{
    private Calculadora calculadora;

    [SetUp]
    public void Setup()
    {
        calculadora = new Calculadora();
    }

    [Test]
    public void SomarDoisNumerosPositivos()
    {
        int resultado = calculadora.Somar(2, 3);
        Assert.AreEqual(5, resultado);
    }

    [TearDown]
    public void Teardown(){
        calculadora = null;
    }
}

public class Calculadora{
    public int Somar(int a, int b){
        return a + b;
    }
}
```

**2. xUnit.net:**

*   **Filosofia:** O **xUnit.net** adota **uma abordagem mais moderna e minimalista** em relação ao **NUnit**. Ele enfatiza a simplicidade e a extensibilidade.
*   **Convenções:** O **xUnit.net** usa convenções em vez de muitos atributos, o que torna o código de teste mais limpo e conciso. Métodos de teste são simplesmente métodos públicos sem parâmetros, anotados com `[Fact]` para testes simples ou `[Theory]` para testes com dados.
*   **Asserções:** O **xUnit.net** oferece um conjunto conciso de asserções, como `Assert.Equal()`, `Assert.True()`, `Assert.Throws()`.
*   **Data-Driven Tests:** O **xUnit.net** suporta testes orientados a dados usando o atributo `[InlineData]` para dados fixos ou `[MemberData]` para dados provenientes de métodos.

**Exemplo com xUnit.net:**

```csharp
using Xunit;

public class CalculadoraTest
{
    private Calculadora calculadora;

    public CalculadoraTest(){
        calculadora = new Calculadora();
    }

    [Fact]
    public void SomarDoisNumerosPositivos()
    {
        int resultado = calculadora.Somar(2, 3);
        Assert.Equal(5, resultado);
    }
}

public class Calculadora{
    public int Somar(int a, int b){
        return a + b;
    }
}
```

**3. MSTest (Microsoft Test Framework):**

*   **Integração com Visual Studio:** O **MSTest** é o framework de teste unitário da Microsoft, integrado ao Visual Studio. Ele oferece boa integração com o ambiente de desenvolvimento da Microsoft.
*   **Atributos:** O **MSTest** utiliza atributos como `[TestMethod]`, `[TestInitialize]`, `[TestCleanup]`, `[ClassInitialize]`, `[ClassCleanup]`.
*   **Asserções:** O **MSTest** possui um conjunto de asserções semelhante aos outros frameworks, como `Assert.AreEqual()`, `Assert.IsTrue()`, `Assert.ThrowsException()`.

**Exemplo com MSTest:**

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CalculadoraTest
{
    private Calculadora calculadora;

    [TestInitialize]
    public void Setup()
    {
        calculadora = new Calculadora();
    }

    [TestMethod]
    public void SomarDoisNumerosPositivos()
    {
        int resultado = calculadora.Somar(2, 3);
        Assert.AreEqual(5, resultado);
    }
}

public class Calculadora{
    public int Somar(int a, int b){
        return a + b;
    }
}
```

**Comparativo Resumido:**

| Característica        | NUnit                                     | xUnit.net                                | MSTest                                  |
|-----------------------|-------------------------------------------|------------------------------------------|-----------------------------------------|
| Abordagem             | Mais tradicional, rico em atributos        | Mais moderno, focado em convenções       | Integrado ao Visual Studio              |
| Anotações/Atributos   | `[Test]`, `[SetUp]`, `[TearDown]`, etc. | `[Fact]`, `[Theory]`, `[InlineData]`, etc. | `[TestMethod]`, `[TestInitialize]`, etc. |
| Data-Driven Tests     | Suporte robusto com vários atributos    | Suporte com `[InlineData]` e `[MemberData]` | Suporte com `[DataRow]`                  |
| Extensibilidade       | Extensível                                | Altamente extensível                       | Extensível                               |

**Qual escolher?**

*   **xUnit.net:** É frequentemente a escolha preferida para novos projetos devido à sua simplicidade, extensibilidade e foco em convenções.
*   **NUnit:** Continua sendo uma ótima opção, especialmente para projetos existentes que já o utilizam.
*   **MSTest:** Pode ser uma boa escolha se você já está fortemente integrado ao ecossistema da Microsoft e precisa de integração direta com o Visual Studio.

Em geral, todos os três frameworks são excelentes opções para testes unitários em C#. A escolha depende mais das preferências da equipe e das necessidades do projeto. O importante é escolher um e começar a escrever testes!

[Sumário](#sumário)

## Fixtures com xUnit
Fixtures são classes que contêm métodos de configuração e limpeza que são executados antes e depois dos testes. Eles são usados para preparar o ambiente de teste, inicializar recursos, configurar o estado do sistema, entre outras tarefas. Isso evita a repetição de código em cada método de teste, melhorando a manutenção e legibilidade dos testes.

---

### **Tipos de Fixtures no xUnit**

#### 1. **Setup e Teardown (por teste)**  
Usados para inicializar e limpar objetos antes e depois de cada teste.

- **`IClassFixture`**: Compartilha objetos por toda a classe de testes.  
- **`ICollectionFixture`**: Compartilha objetos entre múltiplas classes de testes.

---

### **Por que usar Fixtures?**

Fixtures permitem:  
1. **Reduzir código repetitivo**: Objetos podem ser criados uma vez e usados em todos os testes.  
2. **Melhorar performance**: Em vez de recriar objetos complexos em cada teste, eles são criados uma vez e reutilizados.  
3. **Facilitar organização**: Mantém o código limpo e com menos boilerplate.

---

### **Exemplos de Fixtures**

#### **1. Setup e Teardown simples**

Utilize o método construtor e o `Dispose` para inicializar e limpar recursos automaticamente.  

```csharp
public class DatabaseTest : IDisposable
{
    private readonly DatabaseConnection _connection;

    public DatabaseTest()
    {
        // Setup: Inicializa o recurso
        _connection = new DatabaseConnection();
        _connection.Open();
    }

    [Fact]
    public void TesteComBancoDeDados()
    {
        // Usa o recurso compartilhado
        Assert.True(_connection.IsOpen);
    }

    public void Dispose()
    {
        // Teardown: Limpa o recurso
        _connection.Close();
    }
}
```

---

#### **2. Reutilizando objetos com `IClassFixture`**  
Use `IClassFixture` para compartilhar o estado entre os testes de uma única classe.

```csharp
public class DatabaseFixture : IDisposable
{
    public DatabaseConnection Connection { get; private set; }

    public DatabaseFixture()
    {
        // Setup do recurso compartilhado
        Connection = new DatabaseConnection();
        Connection.Open();
    }

    public void Dispose()
    {
        // Limpeza do recurso
        Connection.Close();
    }
}

public class DatabaseTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;

    public DatabaseTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void TesteComRecursoCompartilhado()
    {
        // Usa o recurso compartilhado
        Assert.True(_fixture.Connection.IsOpen);
    }
}
```

---

#### **3. Compartilhando objetos entre várias classes com `ICollectionFixture`**

Para compartilhar uma fixture entre diferentes classes de teste:

1. Crie a fixture:
```csharp
public class SharedFixture : IDisposable
{
    public string Resource { get; private set; }

    public SharedFixture()
    {
        Resource = "Recurso compartilhado";
    }

    public void Dispose()
    {
        // Cleanup do recurso
    }
}
```

2. Use `ICollectionFixture`:
```csharp
[CollectionDefinition("Shared collection")]
public class SharedCollection : ICollectionFixture<SharedFixture>
{
    // Essa classe não precisa de código; apenas define a coleção
}
```

3. Implemente a fixture nas classes de teste:
```csharp
[Collection("Shared collection")]
public class TestClass1
{
    private readonly SharedFixture _fixture;

    public TestClass1(SharedFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Teste1()
    {
        Assert.Equal("Recurso compartilhado", _fixture.Resource);
    }
}

[Collection("Shared collection")]
public class TestClass2
{
    private readonly SharedFixture _fixture;

    public TestClass2(SharedFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Teste2()
    {
        Assert.Equal("Recurso compartilhado", _fixture.Resource);
    }
}
```

---

### **Vantagens do uso de Fixtures**

1. **Eficiente**: Reduz a sobrecarga de inicializar e destruir objetos em cada teste.
2. **Organizado**: Separa claramente o código de configuração dos próprios testes.
3. **Reutilizável**: Permite compartilhar objetos entre diferentes testes e classes.

[Sumário](#sumário)
