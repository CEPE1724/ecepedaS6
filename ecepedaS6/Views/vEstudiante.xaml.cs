namespace ecepedaS6.Views;
using ecepedaS6.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
public partial class vEstudiante : ContentPage
{
	private const string Url="http://192.168.56.1/ws_uisrael/ws_estudiante.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> _estudiante;

	public vEstudiante()
	{
		InitializeComponent();
		Mostrar();
    }

	public async void Mostrar()
	{
		var content = await cliente.GetStringAsync(Url);
		List <Estudiante> mostrarEstudiante = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		_estudiante = new ObservableCollection<Estudiante>(mostrarEstudiante);
		listaEstudiantes.ItemsSource = _estudiante;
	}

	private async void btnAgregarEstudiante_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new vNuevoEstudiante());
	}

	private async void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		
		var ObjEstudiante = (Estudiante)e.SelectedItem;
		await Navigation.PushAsync(new vActualizarEliminar(ObjEstudiante));

	}
}