using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WaveApp.Data;
using WaveApp.Services;
using Wave.Core.Models;

namespace WaveApp.ViewModels;

public partial class AlunoViewModel : ObservableObject
{
    private readonly AlunoService _alunoService;

    [ObservableProperty] private int _totalAlunos;
    [ObservableProperty] private int _alunosAtivos;
    [ObservableProperty] private int _alunosInativos;
    [ObservableProperty] private string _busca = string.Empty;

    private List<AlunoItem> _todosAlunos = new();
    public ObservableCollection<AlunoItem> AlunosFiltrados { get; } = new();

    public AlunoViewModel(AlunoService alunoService)
    {
        _alunoService = alunoService;
        CarregarAlunos();
    }

    partial void OnBuscaChanged(string value) => Filtrar(value);

    public void CarregarAlunos()
    {
        var alunos = _alunoService.ListarAlunos();

        TotalAlunos = alunos.Count;
        AlunosAtivos = alunos.Count(a => a.DataVencimento.HasValue && a.DataVencimento >= DateTime.Today);
        AlunosInativos = TotalAlunos - AlunosAtivos;

        _todosAlunos = alunos.Select(a => new AlunoItem(a, Excluir)).ToList();
        Filtrar(string.Empty);
    }

    private void Filtrar(string termo)
    {
        AlunosFiltrados.Clear();
        var filtrados = string.IsNullOrWhiteSpace(termo)
            ? _todosAlunos
            : _todosAlunos.Where(a => a.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase));

        foreach (var a in filtrados)
            AlunosFiltrados.Add(a);
    }

    private void Excluir(int id)
    {
        _alunoService.DeletarAluno(id);
        CarregarAlunos();
    }

    [RelayCommand]
    private async Task NovoAluno()
    {
        await Shell.Current.GoToAsync("CadastroAlunoPage");
    }
}

public class AlunoItem
{
    public int Id { get; }
    public string Nome { get; }
    public string Iniciais { get; }
    public string Vencimento { get; }
    public string StatusTexto { get; }
    public string StatusCor { get; }
    public string StatusBackground { get; }
    public IRelayCommand EditarCommand { get; }
    public IRelayCommand ExcluirCommand { get; }

    public AlunoItem(AlunoModel a, Action<int> onExcluir)
    {
        Id = a.Id;
        Nome = a.Name;

        var partes = a.Name.Split(' ');
        Iniciais = partes.Length >= 2
            ? $"{partes[0][0]}{partes[^1][0]}"
            : a.Name[..1].ToUpper();

        Vencimento = a.DataVencimento?.ToString("dd/MM/yyyy") ?? "—";

        var ativo = a.DataVencimento.HasValue && a.DataVencimento >= DateTime.Today;
        StatusTexto = ativo ? "Ativo" : "Inativo";
        StatusCor = ativo ? "#1D9E75" : "#E24B4A";
        StatusBackground = ativo ? "#0e2a1a" : "#2a0e0e";

        ExcluirCommand = new RelayCommand(() => onExcluir(Id));
        EditarCommand = new RelayCommand(() => { }); // implementar depois
    }
}