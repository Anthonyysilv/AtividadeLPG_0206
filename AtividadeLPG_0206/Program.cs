//Desenvolver uma aplicação em C# para calcular e mostrar informações de um aluno em seu respectivo curso e turma.
//Deve-se informar as 4 médias do aluno e calcular a média final.
//Informar se esta aprovado, reprovado ou de recuperação.
//Usar agregação, sobrecarga de métodos e construtores (ID e nome Aluno).
//Aprovado média >= 6
//Recuperação 6 > média >= 3
//Reprovado média < 3
using System;

interface IOperacao
{
    void CalcularMedia(Aluno aluno, double nota1, double nota2);
    void CalcularMedia(Aluno aluno, double nota1, double nota2, double nota3, double nota4);
    void ExibirRelatorio(Aluno[] alunos);
}

class Aluno
{
    public string nomeAluno;
    public int codigoAluno;
    public int serieAluno;
    public string cursoAluno;

    public Aluno(string nome, int codigo, int serie, string curso)
    {
        nomeAluno = nome;
        codigoAluno = codigo;
        serieAluno = serie;
        cursoAluno = curso;
    }
}

class MediaFinal : IOperacao
{
    public void CalcularMedia(Aluno aluno, double nota1, double nota2)
    {
        double mediaSemestral = (nota1 + nota2) / 2;
        Console.WriteLine($"Média semestral do aluno {aluno.nomeAluno}: {mediaSemestral}");
        VerificarStatus(aluno, mediaSemestral);
    }

    public void CalcularMedia(Aluno aluno, double nota1, double nota2, double nota3, double nota4)
    {
        double mediaFinal = (nota1 + nota2 + nota3 + nota4) / 4;
        Console.WriteLine($"Média final do aluno {aluno.nomeAluno}: {mediaFinal}");
        VerificarStatus(aluno, mediaFinal);
    }

    public void ExibirRelatorio(Aluno[] alunos)
    {
        Console.WriteLine("Relatório dos alunos:");
        foreach (var aluno in alunos)
        {
            Console.WriteLine($"Nome: {aluno.nomeAluno}, Código: {aluno.codigoAluno}, Série: {aluno.serieAluno}, Curso: {aluno.cursoAluno}");
        }
    }

    private void VerificarStatus(Aluno aluno, double media)
    {
        if (media < 3)
        {
            Console.WriteLine($"Situação do aluno {aluno.nomeAluno}: Reprovado");
        }
        else if (media < 6)
        {
            Console.WriteLine($"Situação do aluno {aluno.nomeAluno}: Recuperação");
        }
        else
        {
            Console.WriteLine($"Situação do aluno {aluno.nomeAluno}: Aprovado");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Aluno[] alunos = new Aluno[5];
        alunos[0] = new Aluno("João", 1, 8, "Matemática");
        alunos[1] = new Aluno("Maria", 2, 9, "Ciências");
        alunos[2] = new Aluno("Pedro", 3, 7, "História");
        alunos[3] = new Aluno("Ana", 4, 8, "Geografia");
        alunos[4] = new Aluno("Lucas", 5, 9, "Português");

        MediaFinal mediaFinal = new MediaFinal();

        Console.WriteLine("Selecione a operação:");
        Console.WriteLine("1 - Calcular média semestral");
        Console.WriteLine("2 - Calcular média final");
        Console.WriteLine("3 - Exibir relatório dos alunos");

        int opc = Convert.ToInt32(Console.ReadLine());

        switch (opc)
        {
            case 1:
                Console.WriteLine("Informe o código do aluno:");
                int codigoAlunoSemestral = Convert.ToInt32(Console.ReadLine());
                Aluno alunoSemestral = BuscarAlunoPorCodigo(alunos, codigoAlunoSemestral);
                if (alunoSemestral != null)
                {
                    Console.WriteLine("Informe a nota 1:");
                    double nota1Semestral = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Informe a nota 2:");
                    double nota2Semestral = Convert.ToDouble(Console.ReadLine());
                    mediaFinal.CalcularMedia(alunoSemestral, nota1Semestral, nota2Semestral);
                }
                else
                {
                    Console.WriteLine("Aluno não encontrado.");
                }
                break;

            case 2:
                Console.WriteLine("Informe o código do aluno:");
                int codigoAlunoFinal = Convert.ToInt32(Console.ReadLine());
                Aluno alunoFinal = BuscarAlunoPorCodigo(alunos, codigoAlunoFinal);
                if (alunoFinal != null)
                {
                    Console.WriteLine("Informe a nota 1:");
                    double nota1Final = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Informe a nota 2:");
                    double nota2Final = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Informe a nota 3:");
                    double nota3Final = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Informe a nota 4:");
                    double nota4Final = Convert.ToDouble(Console.ReadLine());
                    mediaFinal.CalcularMedia(alunoFinal, nota1Final, nota2Final, nota3Final, nota4Final);
                }
                else
                {
                    Console.WriteLine("Aluno não encontrado.");
                }
                break;

            case 3:
                mediaFinal.ExibirRelatorio(alunos);
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }

    static Aluno BuscarAlunoPorCodigo(Aluno[] alunos, int codigo)
    {
        foreach (var aluno in alunos)
        {
            if (aluno.codigoAluno == codigo)
            {
                return aluno;
            }
        }
        return null;
    }
}
