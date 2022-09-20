namespace FractalTree;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        var degrees = args.NewValue;
        displayLabel.Text = $"The angle is {degrees}° degrees";

        ((FractalTreeDrawable)fractalTreeView.Drawable).DeltaAngle = degrees * (Math.PI / 180);
        fractalTreeView.Invalidate();
    }
}