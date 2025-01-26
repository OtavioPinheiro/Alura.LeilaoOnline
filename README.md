# Alura.LeilaoOnline - TDD, TUs com xUnit e C#
Curso da Alura sobre testes unit�rios automatizados com xUnit e C#.

## Sum�rio
1. [TDD](#tdd)
2. [Frameworks de testes unit�rios](#frameworks-de-testes-unit�rios)
3. [Fixtures com xUnit](#fixtures-com-xunit)

## TDD
TDD (Test Driven Development) � uma t�cnica de desenvolvimento de software que consiste em escrever testes automatizados antes de implementar o c�digo de produ��o. A ideia � que o desenvolvedor escreva um teste que falhe, implemente o c�digo que fa�a o teste passar e, por fim, refatore o c�digo.

### Ciclo do TDD
1. **Red**: escrever um teste que falhe
2. **Green**: implementar o c�digo que fa�a o teste passar
3. **Refactor**: refatorar o c�digo
4. **Repeat**: repetir o ciclo
5. **Release**: liberar o c�digo

### Vantagens
- C�digo mais limpo e organizado
- C�digo mais testado
- Menos bugs
- Facilita a manuten��o do c�digo
- Facilita a integra��o cont�nua

### Desvantagens
- Curva de aprendizado
- Pode ser mais lento no in�cio
- Pode ser dif�cil de aplicar em projetos:
  - legados;
  - com requisitos muito vol�teis, complexos, mal definidos, espec�ficos e/ou variados;

[Sum�rio](#sum�rio)

## Frameworks de testes unit�rios
Existem diversos frameworks de testes unit�rios para diversas linguagens de programa��o. Alguns exemplos s�o:
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

### Frameworks de testes unit�rios para C#
Em C#, existem v�rios frameworks populares para testes unit�rios, cada um com suas caracter�sticas e funcionalidades. Os mais utilizados s�o:

**1. NUnit:**

*   **Hist�rico e Popularidade:** O **NUnit** � um dos frameworks de teste unit�rio mais antigos e populares para .NET. Ele foi inspirado no **JUnit** (para Java) e oferece uma estrutura robusta e madura para escrever testes.
*   **Anota��es:** O **NUnit** utiliza atributos (semelhantes a anota��es em Java) para definir m�todos de teste, m�todos de _setup_ e _teardown_, entre outros. Alguns atributos comuns incluem `[Test]`, `[SetUp]`, `[TearDown]`, `[OneTimeSetUp]`, `[OneTimeTearDown]`.
*   **Asser��es:** O **NUnit** oferece uma rica variedade de asser��es para verificar diferentes condi��es, como `Assert.AreEqual()`, `Assert.IsTrue()`, `Assert.Throws()`, entre outras.
*   **Data-Driven Tests:** O **NUnit** suporta testes orientados a dados, permitindo executar o mesmo teste com diferentes conjuntos de dados usando atributos como `[TestCase]`, `[TestCaseSource]` e `[ValueSource]`.
*   **Extensibilidade:** O **NUnit** � extens�vel e permite a cria��o de atributos e extens�es personalizadas.

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

*   **Filosofia:** O **xUnit.net** adota **uma abordagem mais moderna e minimalista** em rela��o ao **NUnit**. Ele enfatiza a simplicidade e a extensibilidade.
*   **Conven��es:** O **xUnit.net** usa conven��es em vez de muitos atributos, o que torna o c�digo de teste mais limpo e conciso. M�todos de teste s�o simplesmente m�todos p�blicos sem par�metros, anotados com `[Fact]` para testes simples ou `[Theory]` para testes com dados.
*   **Asser��es:** O **xUnit.net** oferece um conjunto conciso de asser��es, como `Assert.Equal()`, `Assert.True()`, `Assert.Throws()`.
*   **Data-Driven Tests:** O **xUnit.net** suporta testes orientados a dados usando o atributo `[InlineData]` para dados fixos ou `[MemberData]` para dados provenientes de m�todos.

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

*   **Integra��o com Visual Studio:** O **MSTest** � o framework de teste unit�rio da Microsoft, integrado ao Visual Studio. Ele oferece boa integra��o com o ambiente de desenvolvimento da Microsoft.
*   **Atributos:** O **MSTest** utiliza atributos como `[TestMethod]`, `[TestInitialize]`, `[TestCleanup]`, `[ClassInitialize]`, `[ClassCleanup]`.
*   **Asser��es:** O **MSTest** possui um conjunto de asser��es semelhante aos outros frameworks, como `Assert.AreEqual()`, `Assert.IsTrue()`, `Assert.ThrowsException()`.

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

| Caracter�stica        | NUnit                                     | xUnit.net                                | MSTest                                  |
|-----------------------|-------------------------------------------|------------------------------------------|-----------------------------------------|
| Abordagem             | Mais tradicional, rico em atributos        | Mais moderno, focado em conven��es       | Integrado ao Visual Studio              |
| Anota��es/Atributos   | `[Test]`, `[SetUp]`, `[TearDown]`, etc. | `[Fact]`, `[Theory]`, `[InlineData]`, etc. | `[TestMethod]`, `[TestInitialize]`, etc. |
| Data-Driven Tests     | Suporte robusto com v�rios atributos    | Suporte com `[InlineData]` e `[MemberData]` | Suporte com `[DataRow]`                  |
| Extensibilidade       | Extens�vel                                | Altamente extens�vel                       | Extens�vel                               |

**Qual escolher?**

*   **xUnit.net:** � frequentemente a escolha preferida para novos projetos devido � sua simplicidade, extensibilidade e foco em conven��es.
*   **NUnit:** Continua sendo uma �tima op��o, especialmente para projetos existentes que j� o utilizam.
*   **MSTest:** Pode ser uma boa escolha se voc� j� est� fortemente integrado ao ecossistema da Microsoft e precisa de integra��o direta com o Visual Studio.

Em geral, todos os tr�s frameworks s�o excelentes op��es para testes unit�rios em C#. A escolha depende mais das prefer�ncias da equipe e das necessidades do projeto. O importante � escolher um e come�ar a escrever testes!

[Sum�rio](#sum�rio)

## Fixtures com xUnit
Fixtures s�o classes que cont�m m�todos de configura��o e limpeza que s�o executados antes e depois dos testes. Eles s�o usados para preparar o ambiente de teste, inicializar recursos, configurar o estado do sistema, entre outras tarefas. Isso evita a repeti��o de c�digo em cada m�todo de teste, melhorando a manuten��o e legibilidade dos testes.

---

### **Tipos de Fixtures no xUnit**

#### 1. **Setup e Teardown (por teste)**  
Usados para inicializar e limpar objetos antes e depois de cada teste.

- **`IClassFixture`**: Compartilha objetos por toda a classe de testes.  
- **`ICollectionFixture`**: Compartilha objetos entre m�ltiplas classes de testes.

---

### **Por que usar Fixtures?**

Fixtures permitem:  
1. **Reduzir c�digo repetitivo**: Objetos podem ser criados uma vez e usados em todos os testes.  
2. **Melhorar performance**: Em vez de recriar objetos complexos em cada teste, eles s�o criados uma vez e reutilizados.  
3. **Facilitar organiza��o**: Mant�m o c�digo limpo e com menos boilerplate.

---

### **Exemplos de Fixtures**

#### **1. Setup e Teardown simples**

Utilize o m�todo construtor e o `Dispose` para inicializar e limpar recursos automaticamente.  

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
Use `IClassFixture` para compartilhar o estado entre os testes de uma �nica classe.

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

#### **3. Compartilhando objetos entre v�rias classes com `ICollectionFixture`**

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
    // Essa classe n�o precisa de c�digo; apenas define a cole��o
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
2. **Organizado**: Separa claramente o c�digo de configura��o dos pr�prios testes.
3. **Reutiliz�vel**: Permite compartilhar objetos entre diferentes testes e classes.

[Sum�rio](#sum�rio)
