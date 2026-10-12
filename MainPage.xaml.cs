
using System;
using System.Globalization;

namespace MeuCombustivelMAUI;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCalcularClicked(object sender, EventArgs e)
    {
        string marca = MarcaEntry.Text?.Trim() ?? "";
        string modelo = ModeloEntry.Text?.Trim() ?? "";

        string gasolinaTexto = GasolinaEntry.Text?.Trim() ?? "";
        string etanolTexto = EtanolEntry.Text?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(marca) ||
            string.IsNullOrWhiteSpace(modelo))
        {
            await DisplayAlert("Atenção",
                "Informe a marca e o modelo do veículo.", "OK");
            return;
        }

        bool gasolinaValida = double.TryParse(
            gasolinaTexto.Replace(',', '.'),
            NumberStyles.Float,
            CultureInfo.InvariantCulture,
            out double gasolina);

        bool etanolValido = double.TryParse(
            etanolTexto.Replace(',', '.'),
            NumberStyles.Float,
            CultureInfo.InvariantCulture,
            out double etanol);

        if (!gasolinaValida || !etanolValido ||
            gasolina <= 0 || etanol <= 0)
        {
            await DisplayAlert("Atenção",
                "Informe preços válidos maiores que zero.", "OK");
            return;
        }

        if (etanol <= gasolina * 0.70)
        {
            ResultadoLabel.Text =
                $"O etanol está compensando para o seu {marca} {modelo}.";
        }
        else
        {
            ResultadoLabel.Text =
                $"A gasolina está compensando para o seu {marca} {modelo}.";
        }
    }
}
