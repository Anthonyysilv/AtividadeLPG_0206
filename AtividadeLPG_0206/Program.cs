﻿//Desenvolver uma aplicação em C# para calcular e mostrar informações de um aluno em seu respectivo curso e turma.
//Deve-se informar as 4 médias do aluno e calcular a média final.
//Informar se esta aprovado, reprovado ou de recuperação.
//Usar agregação, sobrecarga de métodos e construtores (ID e nome Aluno).
//Aprovado média >= 6
//Recuperação 6 > média >= 3
//Reprovado média < 3
using System;
class Aluno
{
    public string nomeAluno;
    public int codigoAluno;
    public int serieAluno;
    public string cursoAluno;
}
class MediaFinal
{
    public double nota1;
    public double nota2;
    public double nota3;
    public double nota4;
    public MediaFinal(double mediaF)
    {
        mediaF = (this.nota1 + this.nota2 + this.nota3 + this.nota4) / 4;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("------------------Sistema Escolar------------------");
        Console.WriteLine("Informe, dentre as opções, o'que se deseja fazer");
        Console.WriteLine("1 - Acessar informações de um aluno");
        Console.WriteLine("2 - Adicionar notas para o calculo da média final");
        Console.WriteLine("3 - Filtrar alunos aprovados/recuperação/reprovados");
    }
}