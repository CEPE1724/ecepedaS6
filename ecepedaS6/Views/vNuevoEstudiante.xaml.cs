using System.Net;

namespace ecepedaS6.Views;

public partial class vNuevoEstudiante : ContentPage
{
	public vNuevoEstudiante()
	{
		InitializeComponent();
	}

	private async void btnAgregarEstudiante_Clicked(object sender, EventArgs e)
	{
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
			parametros.Add("apellido", txtApellido.Text);
			parametros.Add("edad", txtEdad.Text);
			cliente.UploadValues("http://192.168.56.1/ws_uisrael/ws_estudiante.php", "POST",parametros);
			await DisplayAlert("Éxito","Estudiante agregado correctamente", "OK");
			await Navigation.PushAsync(new vEstudiante());
		}
		catch (Exception ex)
		{
			await DisplayAlert("Alerta", ex.Message, "OK");
		}
	}
}