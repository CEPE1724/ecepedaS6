namespace ecepedaS6.Views;
using ecepedaS6.Models;
using System.Net;

public partial class vActualizarEliminar : ContentPage
{
	public vActualizarEliminar(Estudiante datos)
	{
		InitializeComponent();
		txtCodigo.Text = datos.codigo.ToString();
		txtNombre.Text = datos.nombre;
		txtApellido.Text = datos.apellido;
		txtEdad.Text = datos.edad.ToString();
	}

	public async void btnActualizar_Clicked(object sender, EventArgs e)
	{
			try
		{
			//El servicio lee el PUT desde la URL ($_GET), igual que en Postman
			string url = "http://192.168.56.1/ws_uisrael/ws_estudiante.php" +
				"?codigo=" + Uri.EscapeDataString(txtCodigo.Text) +
				"&nombre=" + Uri.EscapeDataString(txtNombre.Text) +
				"&apellido=" + Uri.EscapeDataString(txtApellido.Text) +
				"&edad=" + Uri.EscapeDataString(txtEdad.Text);
			WebClient cliente = new WebClient();
			cliente.UploadString(url, "PUT", "");
			await DisplayAlert("Éxito","Estudiante actualizado correctamente", "OK");
			await Navigation.PushAsync(new vEstudiante());
		}
		catch (Exception ex)
		{
			await DisplayAlert("Alerta", ex.Message, "OK");
		}
	}

	public async void btnEliminar_Clicked(object sender, EventArgs e)
	{
		bool confirmar = await DisplayAlert("Confirmar",
			"¿Está seguro de eliminar al estudiante " + txtNombre.Text + " " + txtApellido.Text + "?",
			"Sí", "No");
		if (!confirmar)
		{
			return;
		}

		try
		{
			//El servicio lee el DELETE desde la URL ($_GET)
			string url = "http://192.168.56.1/ws_uisrael/ws_estudiante.php" +
				"?codigo=" + Uri.EscapeDataString(txtCodigo.Text);
			WebClient cliente = new WebClient();
			cliente.UploadString(url, "DELETE", "");
			await DisplayAlert("Éxito", "Estudiante eliminado correctamente", "OK");
			await Navigation.PushAsync(new vEstudiante());
		}
		catch (Exception ex)
		{
			await DisplayAlert("Alerta", ex.Message, "OK");
		}
	}
}	